using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SpinWaveToolsFramework
{
    public interface IInstrument : IDisposable
    {
        bool IsOpen { get; }
        void Write(string str, Action<string> callback = null);
        void WriteAsync(string str, Action<string> callback = null);
        void Open(string hostname);
        Task OpenAsync(string hostname);
        void Close();
        string host();
    }
    public class TelnetConnection : IInstrument
    {
        TcpClient m_Client;
        NetworkStream m_Stream;
        bool m_IsOpen = false;
        bool busy = false;
        public string host()
        {
            return m_Hostname;
        }
        string m_Hostname;
        int m_ReadTimeout = 1000; // ms
        public int port = 5025;
        public delegate void ConnectionDelegate();
        public event ConnectionDelegate Opened;
        public event ConnectionDelegate Closed;
        public bool IsOpen { get { return m_IsOpen; } }
        public TelnetConnection() { }
        public TelnetConnection(bool open) : this("localhost", true) { }
        public TelnetConnection(string host, bool open)
        {
            if (open)
                Open(host);
        }
        void CheckOpen()
        {
            if (!IsOpen)
                throw new Exception("Connection not open.");
        }
        public string Hostname
        {
            get { return m_Hostname; }
        }
        public int ReadTimeout
        {
            set { m_ReadTimeout = value; if (IsOpen) m_Stream.ReadTimeout = value; }
            get { return m_ReadTimeout; }
        }

        public void Write(string str, Action<string> callback = null)
        {

            //FieldFox Programming Guide 6
            CheckOpen();

            while (busy) { };

            busy = true;
            byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            m_Stream.Write(bytes, 0, bytes.Length);
            WriteTerminator();
            if (str.IndexOf('?') >= 0 && callback != null)
                callback(Read());
            busy = false;
        }
        public async void WriteAsync(string str, Action<string> callback = null)
        {
            await Task.Run(() => Write(str, callback));
        }
        public void WriteLine(string str)
        {
            CheckOpen();
            byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            m_Stream.Write(bytes, 0, bytes.Length);
            WriteTerminator();
        }

        void WriteTerminator()
        {
            byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes("\r\n\0");
            m_Stream.Write(bytes, 0, bytes.Length);
            m_Stream.Flush();
        }

        public string Read()
        {
            CheckOpen();
            return System.Text.ASCIIEncoding.ASCII.GetString(ReadBytes());
        }

        /// <summary>
        /// Reads bytes from the socket and returns them as a byte[].
        /// </summary>
        /// <returns></returns>
        public byte[] ReadBytes()
        {
            int i = m_Stream.ReadByte();
            byte b = (byte)i;
            int bytesToRead = 0;
            var bytes = new List<byte>();

            if ((char)b == '#')
            {
                bytesToRead = ReadLengthHeader();
                if (bytesToRead > 0)
                {
                    i = m_Stream.ReadByte();
                    if ((char)i != '\n') // discard carriage return after length header.
                        bytes.Add((byte)i);
                }
            }
            if (bytesToRead == 0)
            {
                while (i != -1 && b != (byte)'\n')
                {
                    bytes.Add(b);
                    i = m_Stream.ReadByte();
                    b = (byte)i;
                }
            }
            else
            {
                int bytesRead = 0;
                while (bytesRead < bytesToRead && i != -1)
                {
                    i = m_Stream.ReadByte();
                    if (i != -1)
                    {
                        bytesRead++;
                        // record all bytes except \n if it is the last char.
                        if (bytesRead < bytesToRead || (char)i != '\n')
                            bytes.Add((byte)i);
                    }
                }
            }

            return bytes.ToArray();
        }

        int ReadLengthHeader()
        {
            int numDigits = Convert.ToInt32(new string(new char[] { (char)m_Stream.ReadByte() }));
            string bytes = "";
            for (int i = 0; i < numDigits; ++i)
                bytes = bytes + (char)m_Stream.ReadByte();
            return Convert.ToInt32(bytes);
        }

        public void Open(string hostname)
        {
            if (IsOpen)
                Close();
            m_Hostname = hostname;
            
            m_Client = new TcpClient();
            m_Client.ReceiveTimeout = 1000;
            m_Client.SendTimeout = 1000;
            m_Client.Connect(hostname, port);
            m_Stream = m_Client.GetStream();
            m_Stream.ReadTimeout = ReadTimeout;
            m_IsOpen = true;
            busy = false;
            if (Opened != null)
                Opened();
        }

        public async Task OpenAsync(string hostname)
        {
            await Task.Run(() => Open(hostname));
        }
        public void Close()
        {
            if (!m_IsOpen)
                return;

            busy = false;
            m_Stream.Close();
            m_Client.Close();
            m_IsOpen = false;
            if (Closed != null)
                Closed();
        }

        public void Dispose()
        {
            Close();
        }
    }

    public class Hislip : IInstrument
    {
        public enum MessageType
        {
            Initialize = 0,
            InitializeResponse = 1,
            FatalError = 2,
            Error = 3,
            AsyncLock = 4,
            AsyncLockResponse = 5,
            Data = 6,
            DataEnd = 7,
            DeviceClearComplete = 8,
            DeviceClearAcknowledge = 9,
            AsyncRemoteLocalControl = 10,
            AsyncRemoteLocalResponse = 11,
            Trigger = 12,
            Interrupted = 13,
            AsyncInterrupted = 14,
            AsyncMaximumMessageSize = 15,
            AsyncMaximumMessageSizeResponse = 16,
            AsyncInitialize = 17,
            AsyncInitializeResponse = 18,
            AsyncDeviceClear = 19,
            AsyncServiceRequest = 20,
            AsyncStatusQuery = 21,
            AsyncStatusResponse = 22,
            AsyncDeviceClearAcknowledge = 23,
            AsyncLockInfo = 24,
            AsyncLockInfoResponse = 25
        }

        Socket Async;
        Socket Sync;

        public string host()
        {
            return m_Hostname;
        }
        bool busy = false;
        bool m_IsOpen = false;
        string m_Hostname;
        public int port = 4880;
        public int version = 0x0100;
        public int vendor = 0x5253;
        public string subaddress = "hislip0";
        public int sessionID = 0;
        public int message_id = 0;

        public delegate void ConnectionDelegate();
        public event ConnectionDelegate Opened;
        public event ConnectionDelegate Closed;
        public bool IsOpen { get { return m_IsOpen; } }
        public Hislip() { }
        public Hislip(bool open) : this("localhost", true) { }
        public Hislip(string host, bool open)
        {
            if (open)
                Open(host);
        }
        void CheckOpen()
        {
            if (!IsOpen)
                throw new Exception("Connection not open.");
        }
        public string Hostname
        {
            get { return m_Hostname; }
        }

        public Action<string> PrintHandler = null;
        public void Print(string data)
        {
            if (PrintHandler != null)
            {
                PrintHandler(data);
            }
        }

        public void Write(bool async, Message message)
        {
            //FieldFox Programming Guide 6
            Socket socket = async ? Async : Sync;
            CheckOpen();

            message.Send(socket);
        }
        public void Write(string message, Action<string> callback = null)
        {
            while (busy) { }
            busy = true;
            try
            {
                Write(false, Messages.DataEnd(message + "\n", message_id));
                if (callback != null)
                {
                    //Thread.Sleep(300);
                    var answer = "";
                    var answer_message = ReadMessage(Sync);
                    while (answer_message.parameter != message_id)
                    {
                        answer_message = ReadMessage(Sync);
                    }
                    answer += answer_message.message;
                    while (answer_message.type == MessageType.Data)
                    {
                        answer_message = ReadMessage(Sync);
                        answer += answer_message.message;
                    }
                    callback(answer.Remove(answer.Length - 1));
                    Console.WriteLine(answer);
                }
            }
            catch { }
            busy = false;
            message_id++;
        }
        public async void WriteAsync(string message, Action<string> callback = null)
        {
            await Task.Run(() => Write(message, callback));
        }
        public void Open(string hostname)
        {
            if (IsOpen)
                Close();

            m_Hostname = hostname;
            Print("Attemp to connect async and sync connections on a " + hostname);

            busy = false;

            Sync = new Socket(SocketType.Stream, ProtocolType.Tcp);
            Sync.ReceiveTimeout = 3000;
            Sync.Connect(hostname, port);
            Print("Sync client connected");
            ConnectSync();

            Async = new Socket(SocketType.Stream, ProtocolType.Tcp);
            Async.ReceiveTimeout = 3000;
            Async.Connect(hostname, port);
            Print("Async client connected");
            ConnectAsync();

            m_IsOpen = true;
            if (Opened != null)
                Opened();
        }
        public async Task OpenAsync(string hostname)
        {
            await Task.Run(() => Open(hostname));
        }
        public void ConnectSync()
        {
            Print("Send Initialize event");
            Messages.Initialize(version, vendor, subaddress).Send(Sync);
            var answer = ReadMessage(Sync);
            sessionID = answer.parameters[1];
            Print("my sessionID: " + sessionID);
            Print("Sync init success");
        }
        public void ConnectAsync()
        {
            Print("Send AsyncInitialize event");
            Messages.InitializeAsync(sessionID).Send(Async);
            var answer = ReadMessage(Async);
            var vendor = answer.parameter;
            Print("Async init success");
            /*Messages.AsyncMaximumMessageSize(1024 * 1024 * 10).Send(Async);
            answer = ReadMessage(Async);
            Print("maximum size: " + BitConverter.ToUInt64(answer.data));*/
        }
        private byte[] ReadBytes(byte[] buffer, int pos, int size)
        {
            var bytes = new byte[size];

            for (var i = pos; i < pos + size; i++)
            {
                bytes[i - pos] = buffer[i];
            }

            return bytes;
        }
        private byte ReadByte(byte[] buffer, int pos)
        {
            return buffer[pos];
        }
        public Message ReadMessage(Socket socket)
        {
            var buffer = new byte[16];
            socket.Receive(buffer);
            var chars = ReadBytes(buffer, 0, 2);
            var prologue = ASCIIEncoding.ASCII.GetString(chars); // 2
            var type = (MessageType)ReadByte(buffer, 2); // 1
            var code = ReadByte(buffer, 3);               // 1
            var parameters = new ushort[] { (ushort)((ReadByte(buffer, 4) << 8) + ReadByte(buffer, 5)), (ushort)((ReadByte(buffer, 6) << 8) + ReadByte(buffer, 7)) }; // 4
            uint parameter = (uint)(parameters[0] << 16) + (uint)parameters[1];
            long length = 0;
            for (var i = 0; i < 8; i++)
            {
                length = (length << 8) + (long)ReadByte(buffer, 8 + i);
            }
            if (length > 0xfffff)
                length = 0;
            var data = new byte[length];
            if (length > 0)
            {
                var come = socket.Receive(data);
                if (come < length)
                {
                    int offset = come;
                    while(offset < length)
                    {
                        come = socket.Receive(data, offset, (int)length - offset, SocketFlags.None);
                        offset += come;
                    }
                }
            }
            return new Message()
                .SetCode((byte)code)
                .SetParameter((uint)parameter)
                .SetType(type)
                .SetData(data);
        }

        public void Close()
        {
            if (!m_IsOpen)
                //FieldFox Programming Guide 7
                return;

            Async.Close();
            Sync.Close();
            m_IsOpen = false;
            if (Closed != null)
                Closed();
        }

        public void Dispose()
        {
            Close();
        }

        public class Message
        {
            public string prologue = "HS";
            public MessageType type = MessageType.DeviceClearAcknowledge;
            public byte control_code = 0;
            public ushort[] parameters = new ushort[] { 0, 0 };
            public uint parameter = 0;
            byte[] raw_parameter = Array.Empty<byte>();
            public ulong length = 0;
            public byte[] data = Array.Empty<byte>();
            public string message = "";
            public Message()
            {

            }
            public Message(string prologue, MessageType type, byte control_code, uint parameter, ulong length, byte[] data)
            {
                this.prologue = prologue;
                this.type = type;
                this.control_code = control_code;
                this.parameter = parameter;
                this.length = length;
                this.data = data;
            }
            public void Send(NetworkStream stream)
            {
                stream.Write(ASCIIEncoding.ASCII.GetBytes(prologue), 0, 2);
                stream.Write(BitConverter.GetBytes((byte)type), 0, 1);
                stream.Write(BitConverter.GetBytes(control_code), 0, 1);
                stream.Write(raw_parameter, 0, 4);
                var length_bytes = BitConverter.GetBytes(length);
                Array.Reverse(length_bytes);
                stream.Write(length_bytes, 0, 8);
                stream.Write(data, 0, data.Length);
                stream.Flush();
            }
            public byte[] GetBytes()
            {
                var array = new List<byte>();

                array.AddRange(ASCIIEncoding.ASCII.GetBytes(prologue));
                array.Add((byte)type);
                array.Add((byte)control_code);
                array.AddRange(raw_parameter);
                var length_bytes = BitConverter.GetBytes(length);
                Array.Reverse(length_bytes);
                array.AddRange(length_bytes);
                array.AddRange(data);

                return array.ToArray();
            }
            public void Send(Socket socket)
            {
                socket.Send(GetBytes());
            }
            public Message SetType(MessageType type)
            {
                this.type = type;
                return this;
            }
            public Message SetCode(byte code)
            {
                this.control_code = code;
                return this;
            }
            public Message SetParameter(uint parameter)
            {
                this.parameter = parameter;
                parameters[0] = (ushort)(parameter >> 16);
                parameters[1] = (ushort)(parameter & 0xffff);
                raw_parameter = BitConverter.GetBytes(parameter);
                Array.Reverse(raw_parameter);
                return this;
            }
            public Message SetParameter(ushort upper, ushort lower)
            {
                this.parameter = (uint)(upper << 16) + (uint)(lower);
                parameters[0] = upper;
                parameters[1] = lower;
                raw_parameter = BitConverter.GetBytes(parameter);
                Array.Reverse(raw_parameter);
                return this;
            }
            public Message SetData(byte[] data)
            {
                this.data = data;
                this.length = (ulong)data.Length;
                this.message = ASCIIEncoding.ASCII.GetString(data);
                return this;
            }
            public Message SetData(string data)
            {
                this.data = ASCIIEncoding.ASCII.GetBytes(data);
                this.length = (ulong)data.Length;
                this.message = data;
                return this;
            }
        }

        public static class Messages
        {
            public static Message Initialize(int version, int vendor, string subaddress)
            {
                return new Message()
                    .SetType(MessageType.Initialize)
                    .SetParameter((ushort)version, (ushort)vendor)
                    .SetData(subaddress);
            }
            public static Message InitializeAsync(int sessionid)
            {
                return new Message()
                    .SetType(MessageType.AsyncInitialize)
                    .SetParameter((uint)sessionid);
            }
            public static Message AsyncMaximumMessageSize(int size)
            {
                byte[] length = BitConverter.GetBytes((long)size);
                Array.Reverse(length);
                return new Message()
                    .SetType(MessageType.AsyncMaximumMessageSize)
                    .SetData(length);
            }
            public static Message DataEnd(string message, int id)
            {
                return new Message()
                    .SetType(MessageType.DataEnd)
                    .SetData(message)
                    .SetParameter((uint)id);
            }
        }
    }
}
