using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpinWaveTool
{
    public class InstrumentStatus
    {
        public bool connected = false;
        public bool validate = false;
        public string error = "";
        public string response = "";

        override public string ToString()
        {
            return (connected ? "Connected;" : "") + (validate ? "Validated;" : "") + (error != "" ? "Error: " + error : "Response: " + response);
        }
    }
    
    public class VNA
    {
        public static string name = "M9374A";
        public static async void CheckStatus(string host, Action<InstrumentStatus> callback)
        {
            var status = new InstrumentStatus();
            var connection = new Hislip();
            try
            {
                connection.Open(host);
                if (!connection.IsOpen)
                {
                    status.error = "Cannot reach instrument!";
                    callback(status);
                    return;
                }
                status.connected = true;
                connection.Write("*IDN?", (answer) =>
                {
                    
                    if (answer.Contains(name))
                    {
                        status.validate = true;
                        status.response = answer;
                    }
                    else
                        status.error = "Wrong instrument: " + answer + "; " + name + " excepted!";
                });
            }
            catch(Exception e)
            {
                status.error = e.Message;
            }
            connection.Dispose();
            callback(status);
        }
    }

    public class PowerSupply
    {
        public static string name = "N6745A";
        public static async void CheckStatus(string host, Action<InstrumentStatus> callback)
        {
            var status = new InstrumentStatus();
            var connection = new TelnetConnection();
            try
            {
                await connection.OpenAsync(host);
                if (!connection.IsOpen)
                {
                    callback(status);
                    return;
                }
                status.connected = true;
                connection.Write("*IDN?", (answer) =>
                {
                    if (answer.Contains(name))
                    {
                        status.validate = true;
                        status.response = answer;
                    }
                    else
                        status.error = "Wrong instrument: " + answer + "; " + name + " excepted!";
                });
            }
            catch (Exception e)
            {
                status.error = e.Message;
            }
            connection.Dispose();
            callback(status);
        }
    }
}
