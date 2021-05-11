<?xml version='1.0' encoding='UTF-8'?>
<Project Type="Project" LVVersion="17008000">
	<Property Name="NI.LV.All.SourceOnly" Type="Bool">false</Property>
	<Item Name="My Computer" Type="My Computer">
		<Property Name="IOScan.Faults" Type="Str"></Property>
		<Property Name="IOScan.NetVarPeriod" Type="UInt">100</Property>
		<Property Name="IOScan.NetWatchdogEnabled" Type="Bool">false</Property>
		<Property Name="IOScan.Period" Type="UInt">10000</Property>
		<Property Name="IOScan.PowerupMode" Type="UInt">0</Property>
		<Property Name="IOScan.Priority" Type="UInt">9</Property>
		<Property Name="IOScan.ReportModeConflict" Type="Bool">true</Property>
		<Property Name="IOScan.StartEngineOnDeploy" Type="Bool">false</Property>
		<Property Name="NI.SortType" Type="Int">3</Property>
		<Property Name="server.app.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.control.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.tcp.enabled" Type="Bool">false</Property>
		<Property Name="server.tcp.port" Type="Int">0</Property>
		<Property Name="server.tcp.serviceName" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.tcp.serviceName.default" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.vi.callsEnabled" Type="Bool">true</Property>
		<Property Name="server.vi.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="specify.custom.address" Type="Bool">false</Property>
		<Item Name="Project Documentation" Type="Folder">
			<Item Name="Documentation Images" Type="Folder">
				<Item Name="loc_open_data_typedef.png" Type="Document" URL="../documentation/loc_open_data_typedef.png"/>
				<Item Name="loc_open_states_typedef.png" Type="Document" URL="../documentation/loc_open_states_typedef.png"/>
				<Item Name="loc_simple_state_machine.png" Type="Document" URL="../documentation/loc_simple_state_machine.png"/>
				<Item Name="loc_state_transition.png" Type="Document" URL="../documentation/loc_state_transition.png"/>
				<Item Name="loc_transition_error.png" Type="Document" URL="../documentation/loc_transition_error.png"/>
				<Item Name="loc_use_state_data.png" Type="Document" URL="../documentation/loc_use_state_data.png"/>
				<Item Name="loc_conditional_state_transition.png" Type="Document" URL="../documentation/loc_conditional_state_transition.png"/>
				<Item Name="loc_new_button.png" Type="Document" URL="../documentation/loc_new_button.png"/>
				<Item Name="loc_new_button_transition.png" Type="Document" URL="../documentation/loc_new_button_transition.png"/>
				<Item Name="loc_new_button_value_change.png" Type="Document" URL="../documentation/loc_new_button_value_change.png"/>
				<Item Name="loc_new_state.png" Type="Document" URL="../documentation/loc_new_state.png"/>
			</Item>
			<Item Name="Simple State Machine Documentation.html" Type="Document" URL="../documentation/Simple State Machine Documentation.html"/>
		</Item>
		<Item Name="Type Definitions" Type="Folder">
			<Item Name="Data.ctl" Type="VI" URL="../controls/Data.ctl"/>
			<Item Name="State.ctl" Type="VI" URL="../controls/State.ctl"/>
			<Item Name="DefType.ctl" Type="VI" URL="../controls/DefType.ctl"/>
		</Item>
		<Item Name="Libraries" Type="Folder">
			<Item Name="KEYSIGHT_VNA" Type="Folder">
				<Item Name="VNA_init.vi" Type="VI" URL="../controls/VNA_init.vi"/>
				<Item Name="VNA_Set_Selected_Measurement.vi" Type="VI" URL="../controls/VNA_Set_Selected_Measurement.vi"/>
				<Item Name="VNA_Trigger.vi" Type="VI" URL="../controls/VNA_Trigger.vi"/>
				<Item Name="VNA_Save.vi" Type="VI" URL="../controls/VNA_Save.vi"/>
				<Item Name="VNA_Set_Freq.vi" Type="VI" URL="../controls/VNA_Set_Freq.vi"/>
				<Item Name="VNA_Set_IF.vi" Type="VI" URL="../controls/VNA_Set_IF.vi"/>
				<Item Name="VNA_Set_PowerLevel.vi" Type="VI" URL="../controls/VNA_Set_PowerLevel.vi"/>
				<Item Name="VNA_Get_Trigger.vi" Type="VI" URL="../controls/VNA_Get_Trigger.vi"/>
				<Item Name="VNA_Set_Trace_Number.vi" Type="VI" URL="../controls/VNA_Set_Trace_Number.vi"/>
				<Item Name="VNA_Format_Set.vi" Type="VI" URL="../controls/VNA_Format_Set.vi"/>
				<Item Name="VNA_WaitCommands.vi" Type="VI" URL="../controls/VNA_WaitCommands.vi"/>
				<Item Name="VNA_Set_Trace_Def.vi" Type="VI" URL="../controls/VNA_Set_Trace_Def.vi"/>
				<Item Name="VNA_ConfigureTraces.vi" Type="VI" URL="../controls/VNA_ConfigureTraces.vi"/>
				<Item Name="VNA_Data_Read.vi" Type="VI" URL="../controls/VNA_Data_Read.vi"/>
			</Item>
			<Item Name="Agilent" Type="Folder">
				<Item Name="Agilent_value_set.vi" Type="VI" URL="../controls/Agilent_value_set.vi"/>
				<Item Name="Agilent_Init.vi" Type="VI" URL="../controls/Agilent_Init.vi"/>
				<Item Name="Agilent_read.vi" Type="VI" URL="../controls/Agilent_read.vi"/>
				<Item Name="Agilent_status.vi" Type="VI" URL="../controls/Agilent_status.vi"/>
			</Item>
			<Item Name="Instrument_check.vi" Type="VI" URL="../controls/Instrument_check.vi"/>
		</Item>
		<Item Name="Main.vi" Type="VI" URL="../Main.vi"/>
		<Item Name="Dependencies" Type="Dependencies">
			<Item Name="vi.lib" Type="Folder">
				<Item Name="Simple Error Handler.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Simple Error Handler.vi"/>
				<Item Name="DialogType.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/DialogType.ctl"/>
				<Item Name="General Error Handler.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/General Error Handler.vi"/>
				<Item Name="DialogTypeEnum.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/DialogTypeEnum.ctl"/>
				<Item Name="General Error Handler Core CORE.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/General Error Handler Core CORE.vi"/>
				<Item Name="whitespace.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/whitespace.ctl"/>
				<Item Name="Check Special Tags.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Check Special Tags.vi"/>
				<Item Name="TagReturnType.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/TagReturnType.ctl"/>
				<Item Name="Set String Value.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Set String Value.vi"/>
				<Item Name="GetRTHostConnectedProp.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/GetRTHostConnectedProp.vi"/>
				<Item Name="Error Code Database.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Error Code Database.vi"/>
				<Item Name="Trim Whitespace.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Trim Whitespace.vi"/>
				<Item Name="Format Message String.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Format Message String.vi"/>
				<Item Name="Set Bold Text.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Set Bold Text.vi"/>
				<Item Name="Find Tag.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Find Tag.vi"/>
				<Item Name="Search and Replace Pattern.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Search and Replace Pattern.vi"/>
				<Item Name="Details Display Dialog.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Details Display Dialog.vi"/>
				<Item Name="ErrWarn.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/ErrWarn.ctl"/>
				<Item Name="eventvkey.ctl" Type="VI" URL="/&lt;vilib&gt;/event_ctls.llb/eventvkey.ctl"/>
				<Item Name="Clear Errors.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Clear Errors.vi"/>
				<Item Name="Not Found Dialog.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Not Found Dialog.vi"/>
				<Item Name="Three Button Dialog.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Three Button Dialog.vi"/>
				<Item Name="Three Button Dialog CORE.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Three Button Dialog CORE.vi"/>
				<Item Name="LVRectTypeDef.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/miscctls.llb/LVRectTypeDef.ctl"/>
				<Item Name="Longest Line Length in Pixels.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Longest Line Length in Pixels.vi"/>
				<Item Name="Convert property node font to graphics font.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Convert property node font to graphics font.vi"/>
				<Item Name="Get Text Rect.vi" Type="VI" URL="/&lt;vilib&gt;/picture/picture.llb/Get Text Rect.vi"/>
				<Item Name="Get String Text Bounds.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Get String Text Bounds.vi"/>
				<Item Name="LVBoundsTypeDef.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/miscctls.llb/LVBoundsTypeDef.ctl"/>
				<Item Name="BuildHelpPath.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/BuildHelpPath.vi"/>
				<Item Name="GetHelpDir.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/GetHelpDir.vi"/>
			</Item>
			<Item Name="instr.lib" Type="Folder">
				<Item Name="N5700 Write to Instrument.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Write to Instrument.vi"/>
				<Item Name="N5700 Error Query.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Error Query.vi"/>
				<Item Name="N5700 Wait.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Wait.vi"/>
				<Item Name="N5700 Config Current Limit.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Config Current Limit.vi"/>
				<Item Name="N5700 Config Output On-Off.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Config Output On-Off.vi"/>
				<Item Name="N5700 Initialize.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Initialize.vi"/>
				<Item Name="N5700 Reset.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Reset.vi"/>
				<Item Name="N5700 Close.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Close.vi"/>
				<Item Name="N5700 Config Voltage Protection.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Config Voltage Protection.vi"/>
				<Item Name="N5700 Config Voltage Limit.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Config Voltage Limit.vi"/>
				<Item Name="N5700 Meas Output Voltage.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Meas Output Voltage.vi"/>
				<Item Name="N5700 Read Instrument Data.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Read Instrument Data.vi"/>
				<Item Name="N5700 Meas Output Current.vi" Type="VI" URL="/&lt;instrlib&gt;/agt_N5700/agt_N5700.llb/N5700 Meas Output Current.vi"/>
			</Item>
			<Item Name="agena Write.vi" Type="VI" URL="../samples/agena/_agena.llb/agena Write.vi"/>
		</Item>
		<Item Name="Build Specifications" Type="Build">
			<Item Name="Main Application" Type="EXE">
				<Property Name="App_copyErrors" Type="Bool">true</Property>
				<Property Name="App_INI_aliasGUID" Type="Str">{B511CD8F-BE21-4470-A7C4-3ACBADFC72C8}</Property>
				<Property Name="App_INI_GUID" Type="Str">{78EABFCD-5B97-4F87-AF3F-FF129EE73305}</Property>
				<Property Name="App_serverConfig.httpPort" Type="Int">8002</Property>
				<Property Name="Bld_buildCacheID" Type="Str">{2CE40C4E-446A-4350-9E11-C85D8BAE8F13}</Property>
				<Property Name="Bld_buildSpecName" Type="Str">Main Application</Property>
				<Property Name="Bld_excludeLibraryItems" Type="Bool">true</Property>
				<Property Name="Bld_excludePolymorphicVIs" Type="Bool">true</Property>
				<Property Name="Bld_localDestDir" Type="Path">../builds/NI_AB_PROJECTNAME/Main Application</Property>
				<Property Name="Bld_localDestDirType" Type="Str">relativeToCommon</Property>
				<Property Name="Bld_modifyLibraryFile" Type="Bool">true</Property>
				<Property Name="Bld_previewCacheID" Type="Str">{09FD23A0-93D2-46A2-B12D-FA02255F97C6}</Property>
				<Property Name="Bld_version.major" Type="Int">1</Property>
				<Property Name="Destination[0].destName" Type="Str">Main.exe</Property>
				<Property Name="Destination[0].path" Type="Path">../builds/NI_AB_PROJECTNAME/Main Application/Main.exe</Property>
				<Property Name="Destination[0].preserveHierarchy" Type="Bool">true</Property>
				<Property Name="Destination[0].type" Type="Str">App</Property>
				<Property Name="Destination[1].destName" Type="Str">Support Directory</Property>
				<Property Name="Destination[1].path" Type="Path">../builds/NI_AB_PROJECTNAME/Main Application/data</Property>
				<Property Name="DestinationCount" Type="Int">2</Property>
				<Property Name="Source[0].itemID" Type="Str">{14AAC4C7-34B2-4A5B-9FE2-521EE78B2DBB}</Property>
				<Property Name="Source[0].type" Type="Str">Container</Property>
				<Property Name="Source[1].destinationIndex" Type="Int">0</Property>
				<Property Name="Source[1].itemID" Type="Ref">/My Computer/Main.vi</Property>
				<Property Name="Source[1].sourceInclusion" Type="Str">TopLevel</Property>
				<Property Name="Source[1].type" Type="Str">VI</Property>
				<Property Name="SourceCount" Type="Int">2</Property>
				<Property Name="TgtF_fileDescription" Type="Str">Main Application</Property>
				<Property Name="TgtF_internalName" Type="Str">Main Application</Property>
				<Property Name="TgtF_legalCopyright" Type="Str">Copyright © 2012 </Property>
				<Property Name="TgtF_productName" Type="Str">Main Application</Property>
				<Property Name="TgtF_targetfileGUID" Type="Str">{A9B9C488-ADD7-40F6-AAC2-547427E5CB24}</Property>
				<Property Name="TgtF_targetfileName" Type="Str">Main.exe</Property>
			</Item>
		</Item>
	</Item>
</Project>
