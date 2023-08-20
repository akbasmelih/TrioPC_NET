using System;
using System.Reflection;
using System.Text;

namespace TrioMotion.TrioPC_NET
{
	internal class ArchitectureIndependentTrioPC
	{
		public delegate IntPtr Delegate_CreateContext();

		public delegate void Delegate_DestroyContext(IntPtr context);

		public delegate void Delegate_SetHost(IntPtr context, string host);

		public delegate bool Delegate_SetBoard(IntPtr context, short board);

		public delegate long Delegate_GetBoard(IntPtr context);

		public delegate void Delegate_SetHostAddress(IntPtr context, string hostAddress);

		public delegate string Delegate_GetHostAddress(IntPtr context);

		public delegate int Delegate_GetConnectionType(IntPtr context);

		public delegate void Delegate_SetCmdProtocol(IntPtr context, int cmdProtocol);

		public delegate int Delegate_GetCmdProtocol(IntPtr context);

		public delegate void Delegate_SetFlushBeforeWrite(IntPtr context, int FlushBeforeWrite);

		public delegate int Delegate_GetFlushBeforeWrite(IntPtr context);

		public delegate void Delegate_SetFastSerialMode(IntPtr context, int FastSerialMode);

		public delegate int Delegate_GetFastSerialMode(IntPtr context);

		public delegate int Delegate_GetLastError(IntPtr context);

		public delegate bool Delegate_ProductVersion(IntPtr context, StringBuilder Version, int VersionSize);

		public delegate bool Delegate_ProductName(IntPtr context, StringBuilder Name, int NameSize);

		public delegate void Delegate_Close(IntPtr context, PortId portId);

		public delegate bool Delegate_Open(IntPtr context, PortType portType, PortId portId, IntPtr NativeCommunicationsEventContext, NativeEventCallback NativeCommunicationsEvent);

		public delegate bool Delegate_SetAxisVariable(IntPtr context, string variable, short axis, double value);

		public delegate bool Delegate_GetAxisVariable(IntPtr context, string variable, short axis, out double value);

		public delegate bool Delegate_SetProcVariable(IntPtr context, string variable, short proc, double value);

		public delegate bool Delegate_GetProcVariable(IntPtr context, string variable, short proc, out double value);

		public delegate bool Delegate_SetSlotVariable(IntPtr context, string Variable, short Slot, double value);

		public delegate bool Delegate_GetSlotVariable(IntPtr context, string variable, short slot, out double value);

		public delegate bool Delegate_SetPortVariable(IntPtr context, string variable, short Port, double value);

		public delegate bool Delegate_GetPortVariable(IntPtr context, string variable, short port, out double value);

		public delegate bool Delegate_SetVr(IntPtr context, short Variable, double Value);

		public delegate bool Delegate_GetVr(IntPtr context, short Variable, out double Value);

		public delegate bool Delegate_SetVrString(IntPtr context, short VrPosition, string stringValue);

		public delegate bool Delegate_GetVrString(IntPtr context, short VrPositon, StringBuilder stringValue);

		public delegate bool Delegate_SetVariable(IntPtr context, string variable, double value);

		public delegate bool Delegate_GetVariable(IntPtr context, string variable, out double value);

		public delegate bool Delegate_GetProcessVariable(IntPtr context, short variable, short process, out double value);

		public delegate bool Delegate_GetProcessVariablestr(IntPtr context, string processVarStr, short process, StringBuilder processVarOutput);

		public delegate bool Delegate_SetTable(IntPtr context, int StartPosition, int NumberOfValues, IntPtr Values);

		public delegate bool Delegate_GetTable(IntPtr context, int StartPosition, int NumberOfValues, IntPtr Value);

		public delegate bool Delegate_MoveRel(IntPtr context, short Axes, IntPtr Distance, int BaseAxis);

		public delegate bool Delegate_Base(IntPtr context, short Axes, double[] Order);

		public delegate bool Delegate_MoveAbs(IntPtr context, short Axes, IntPtr Distance, short Axis);

		public delegate bool Delegate_MoveCirc(IntPtr context, double FinishBase, double FinishNext, double CentreBase, double CentreNext, short Direction, int BaseAxis);

		public delegate bool Delegate_AddAxis(IntPtr context, short LinkAxis, int Axis);

		public delegate bool Delegate_Cambox(IntPtr context, short TableStart, short TableStop, double TableMultiplier, double LinkDistance, short LinkAxis, short LinkOptions, double LinkPos, int Axis);

		public delegate bool Delegate_Cam(IntPtr context, short TableStart, short TableStop, double TableMultiplier, double LinkDistance, int Axis);

		public delegate bool Delegate_Cancel(IntPtr context, short Mode, int Axis);

		public delegate bool Delegate_Connect(IntPtr context, double Ratio, short LinkAxis, int Axis);

		public delegate bool Delegate_Datum(IntPtr context, short Sequence, int Axis);

		public delegate bool Delegate_Forward(IntPtr context, int BaseAxis);

		public delegate bool Delegate_MoveHelical(IntPtr context, double FinishBase, double FinishNext, double CentreBase, double CentreNext, short Direction, double LastDistance, short Axis);

		public delegate bool Delegate_MoveLink(IntPtr context, double Distance, double LinkDistance, double LinkAcceleration, double LinkDecceleration, short LinkAxis, short LinkOptions, double LastPosition, short Axis);

		public delegate bool Delegate_MoveModify(IntPtr context, double position, short Axis);

		public delegate bool Delegate_RapidStop(IntPtr context);

		public delegate bool Delegate_Reverse(IntPtr context, short BaseAxis);

		public delegate bool Delegate_Run(IntPtr context, string Program, int Process);

		public delegate bool Delegate_Stop(IntPtr context, string Program, int Process);

		public delegate bool Delegate_Op(IntPtr context, short StartChannel, short StopChannel, int Value);

		public delegate bool Delegate_Ain(IntPtr context, short Channel, out double value);

		public delegate bool Delegate_Get(IntPtr context, short channel, out short value);

		public delegate bool Delegate_Input(IntPtr context, short Channel, out double Value);

		public delegate bool Delegate_Key(IntPtr context, short channel, out short value);

		public delegate bool Delegate_Mark(IntPtr context, short axis, out short value);

		public delegate bool Delegate_MarkB(IntPtr context, short Axis, out short value);

		public delegate bool Delegate_Linput(IntPtr context, short channel, short startVr);

		public delegate bool Delegate_PswitchOff(IntPtr context, short Switch, short Hold);

		public delegate bool Delegate_Pswitch(IntPtr context, short Switch, short Enable, int Axis, int OutputNumber, int OutputStatus, double SetPosition, double ResetPosition);

		public delegate bool Delegate_ReadPacket(IntPtr context, short PortNumber, short StartVr, short NumberVr, short Format);

		public delegate bool Delegate_Regist1(IntPtr context, short Mode);

		public delegate bool Delegate_Regist2(IntPtr context, short Mode, double Distance);

		public delegate bool Delegate_Setcom(IntPtr context, int BaudRate, short DataBits, short StopBits, short Parity, short Port, int Control);

		public delegate bool Delegate_In(IntPtr context, short StartChannel, short StopChannel, out double value);

		public delegate bool Delegate_Execute(IntPtr context, string command);

		public delegate bool Delegate_New(IntPtr context, string Program);

		public delegate bool Delegate_Select(IntPtr context, string Program);

		public delegate bool Delegate_Dir(IntPtr context, StringBuilder Directory, int DirectorySize, string Option);

		public delegate bool Delegate_InsertLine(IntPtr context, string Program, short LineNumber, string Line);

		public delegate bool Delegate_SendData(IntPtr context, short channel, string data);

		public delegate bool Delegate_GetData(IntPtr context, short channel, StringBuilder data, int data_size);

		public delegate bool Delegate_MechatroLink(IntPtr context, short Module, short Function, short NumberOfParameter, double MLPParameter, out double pdResult);

		public delegate bool Delegate_LoadProject(IntPtr context, string ProjectFile);

		public delegate bool Delegate_LoadSystem(IntPtr context, string SystemFile);

		public delegate bool Delegate_LoadProgram(IntPtr context, string ProgramFile, bool SlowLoad);

		public delegate bool Delegate_StepRatio(IntPtr context, int Numerator, int Denominator, short Axis);

		public delegate bool Delegate_DefPos(IntPtr context, double Position, short Axis);

		public delegate bool Delegate_ConnPath(IntPtr context, double Ratio, short LinkAxis, short Axis);

		public delegate bool Delegate_UserFrame(IntPtr context, short Identity, short Axes, double[] Positions);

		public delegate bool Delegate_UserFrameB(IntPtr context, short Identity);

		public delegate bool Delegate_EncoderRatio(IntPtr context, short MposCount, short InputCount, short Axis);

		public delegate bool Delegate_MoveSpherical(IntPtr context, double EndMidX, double EndMidY, double EndMidZ, double CentreX, double CentreY, double CentreZ, short Mode, short Axis, short gtpi, short rotau, short rotav, short rotaw);

		public delegate bool Delegate_MoveSphericalSP(IntPtr context, double EndMidX, double EndMidY, double EndMidZ, double CentreX, double CentreY, double CentreZ, short Mode, short Axis, short gtpi, short rotau, short rotav, short rotaw);

		public delegate bool Delegate_MoveCircSP(IntPtr context, double FinishBase, double FinishNext, double CentreBase, double CentreNext, short Direction, short Axis, short transAngle, short output);

		public delegate bool Delegate_MoveHelicalSP(IntPtr context, double FinishBase, double FinishNext, double CentreBase, double CentreNext, short Direction, double LinearDistance, short Axis, short mode);

		public delegate bool Delegate_MoveRelSP(IntPtr context, short Axes, IntPtr Distance, int BaseAxis);

		public delegate bool Delegate_MoveAbsSP(IntPtr context, short Axes, IntPtr Distance, short Axis);

		public delegate bool Delegate_FrameGroup(IntPtr context, short Group, short table_offset, short Axis);

		public delegate bool Delegate_MoveContour(IntPtr context, short tablePointer, short Axes, short nPoints, short options, short speed_option, short output_table_area, short shortLen, short CornerAcc, short Axis);

		public delegate bool Delegate_InvertIn(IntPtr context, short input, short state);

		public delegate bool Delegate_FrameTrans(IntPtr context, short Frame, short table_in, short table_out, double direction, short table_offset);

		public delegate bool Delegate_UserFrameTrans(IntPtr context, short UserFrame_in, short UserFrame_out, short tool_offset_in, short tool_offset_out, short table_in, short table_out, short scale);

		public delegate bool Delegate_Aout(IntPtr context, short Channel, double Value, out double aoutVal);

		public delegate bool Delegate_AddDac(IntPtr context, short SecondAxis, short Axis);

		public delegate bool Delegate_AxesDiff(IntPtr context, short Axis1, short Axis2, short Axis);

		public delegate bool Delegate_FlexLink(IntPtr context, double BaseDist, double ExciteDist, double LinkDist, short BaseIn, short BaseOut, short ExciteAcc, short ExciteDec, short LinkAxis, short LinkOption, double LinkPos, short Axis);

		public delegate bool Delegate_HwPswitch(IntPtr context, short Mode, short Direction, short Opstate, int TableStart, int TableEnd, short Axis);

		public delegate bool Delegate_MoveRelSeq(IntPtr context, short TablePointer, short Axes, short nPoints, short Options, double Radius, short Output, double TransitionAngle, short Axis);

		public delegate bool Delegate_MoveAbsSeq(IntPtr context, short TablePointer, short Axes, short nPoints, short Options, double Radius, short Output, double TransitionAngle, short Axis);

		public delegate bool Delegate_MoveAdd(IntPtr context, double Distance, short Axis);

		public delegate bool Delegate_MovePick(IntPtr context, short Mode, double X, double Y, double Z, double Withdraw, double OverlapControlA, double OverlapControlB, double U, double V, double W, double WithdrawControl, double XYControl, double ApproachControl, short Axis);

		public delegate bool Delegate_MoveDispense(IntPtr context, short tablePointer, short Axes, short nPoints, short options, short speed_option, short output_table_area, short shortLen, short CornerAcc, short nCodeVr, short Axis);

		public delegate bool Delegate_MoveTang(IntPtr context, double AbsolutePosition, short LinkAxis, short Axis);

		public delegate bool Delegate_SphereCentre(IntPtr context, short TableMid, short TableEnd, short TableOut);

		public delegate bool Delegate_Sync(IntPtr context, short Control, double SyncTime, double SyncPosition, short SyncAxis, double Pos1, double Pos2, double Pos3, short Axis);

		public delegate bool Delegate_ToolOffset(IntPtr context, short Identity, double XOffset, double YOffset, double ZOffset);

		public delegate bool Delegate_PWMControl(IntPtr context, short value, double p1, short p2, short p3, short p4, short p5, short Axis);

		public delegate bool Delegate_SetMotion(IntPtr context, short Axis, double Speed, double Accel, double Decel, double Jerk);

		public delegate bool Delegate_SetMotionSP(IntPtr context, short Axis, double forceSpeed, double startMoveSpeed, double endMoveSpeed, double forceAccel, double forceDecel, double forceJerk, double forceRamp, double forceDwell);

		public delegate bool Delegate_TextFileLoader(IntPtr context, string SourceFile, int DestinationMemory, string DestinationFile, int Protocol, bool Compression, int CompressionLevel, bool Timeout, int TimeoutSeconds, int Direction);

		public delegate bool Delegate_IsOpen(IntPtr context, PortId portId);

		public delegate bool Delegate_IsError(IntPtr context);

		public delegate bool Delegate_ScopeOnOff(IntPtr context, bool OnOff);

		public delegate bool Delegate_Scope(IntPtr context, bool OnOff, int SamplePeriod, int TableStart, int TableEnd, string CaptureParams);

		public delegate bool Delegate_Trigger(IntPtr context);

		public delegate bool Delegate_ReadOp(IntPtr context, short StartChannel, short StopChannel, out int Value);

		public delegate bool Delegate_PRMBLK_DefineAxis(IntPtr context, int blockNumber, string variable);

		public delegate bool Delegate_PRMBLK_DefineSystem(IntPtr context, int blockNumber, string variable);

		public delegate bool Delegate_PRMBLK_DefineVr(IntPtr context, int blockNumber, short variable);

		public delegate bool Delegate_PRMBLK_DefineTable(IntPtr context, int blockNumber, short variable);

		public delegate bool Delegate_PRMBLK_DefineProgram(IntPtr context, int blockNumber, string programName, int processNumber, string variable);

		public delegate bool Delegate_PRMBLK_Append(IntPtr context, int blockNumber, IntPtr variable);

		public delegate bool Delegate_PRMBLK_Get(IntPtr context, int blockNumber, bool all, IntPtr variable);

		public delegate bool Delegate_PRMBLK_GetAxis(IntPtr context, int blockNumber, int Axis, bool all, IntPtr variable);

		public delegate bool Delegate_PRMBLK_Delete(IntPtr context, int blockNumber);

		public readonly Delegate_CreateContext CreateContext;

		public readonly Delegate_DestroyContext DestroyContext;

		public readonly Delegate_SetHost SetHost;

		public readonly Delegate_SetBoard SetBoard;

		public readonly Delegate_GetBoard GetBoard;

		public readonly Delegate_SetHostAddress SetHostAddress;

		public readonly Delegate_GetHostAddress GetHostAddress;

		public readonly Delegate_GetConnectionType GetConnectionType;

		public readonly Delegate_SetCmdProtocol SetCmdProtocol;

		public readonly Delegate_GetCmdProtocol GetCmdProtocol;

		public readonly Delegate_SetFlushBeforeWrite SetFlushBeforeWrite;

		public readonly Delegate_GetFlushBeforeWrite GetFlushBeforeWrite;

		public readonly Delegate_SetFastSerialMode SetFastSerialMode;

		public readonly Delegate_GetFastSerialMode GetFastSerialMode;

		public readonly Delegate_GetLastError GetLastError;

		public Delegate_ProductVersion ProductVersion;

		public Delegate_ProductName ProductName;

		public readonly Delegate_Close Close;

		public readonly Delegate_Open Open;

		public readonly Delegate_SetAxisVariable SetAxisVariable;

		public readonly Delegate_GetAxisVariable GetAxisVariable;

		public readonly Delegate_SetProcVariable SetProcVariable;

		public readonly Delegate_GetProcVariable GetProcVariable;

		public readonly Delegate_SetSlotVariable SetSlotVariable;

		public readonly Delegate_GetSlotVariable GetSlotVariable;

		public readonly Delegate_SetPortVariable SetPortVariable;

		public readonly Delegate_GetPortVariable GetPortVariable;

		public readonly Delegate_SetVr SetVr;

		public readonly Delegate_GetVr GetVr;

		public readonly Delegate_SetVrString SetVrString;

		public readonly Delegate_GetVrString GetVrString;

		public readonly Delegate_SetVariable SetVariable;

		public readonly Delegate_GetVariable GetVariable;

		public readonly Delegate_GetProcessVariable GetProcessVariable;

		public readonly Delegate_GetProcessVariablestr GetProcessVariableStr;

		public readonly Delegate_SetTable SetTable;

		public readonly Delegate_GetTable GetTable;

		public readonly Delegate_MoveRel MoveRel;

		public readonly Delegate_Base Base;

		public readonly Delegate_MoveAbs MoveAbs;

		public readonly Delegate_MoveCirc MoveCirc;

		public readonly Delegate_AddAxis AddAxis;

		public readonly Delegate_Cambox Cambox;

		public readonly Delegate_Cam Cam;

		public readonly Delegate_Cancel Cancel;

		public readonly Delegate_Connect Connect;

		public readonly Delegate_Datum Datum;

		public readonly Delegate_Forward Forward;

		public readonly Delegate_MoveHelical MoveHelical;

		public readonly Delegate_MoveLink MoveLink;

		public readonly Delegate_MoveModify MoveModify;

		public readonly Delegate_RapidStop RapidStop;

		public readonly Delegate_Reverse Reverse;

		public readonly Delegate_Run Run;

		public readonly Delegate_Stop Stop;

		public readonly Delegate_Op Op;

		public readonly Delegate_Ain Ain;

		public readonly Delegate_Get Get;

		public readonly Delegate_Input Input;

		public readonly Delegate_Key Key;

		public readonly Delegate_Mark Mark;

		public readonly Delegate_MarkB MarkB;

		public readonly Delegate_Linput Linput;

		public readonly Delegate_PswitchOff PswitchOff;

		public readonly Delegate_Pswitch Pswitch;

		public readonly Delegate_ReadPacket ReadPacket;

		public readonly Delegate_Regist1 Regist1;

		public readonly Delegate_Regist2 Regist2;

		public readonly Delegate_Setcom Setcom;

		public readonly Delegate_In In;

		public readonly Delegate_Execute Execute;

		public readonly Delegate_New New;

		public readonly Delegate_Select Select;

		public readonly Delegate_Dir Dir;

		public readonly Delegate_InsertLine InsertLine;

		public readonly Delegate_SendData SendData;

		public readonly Delegate_GetData GetData;

		public readonly Delegate_MechatroLink MechatroLink;

		public readonly Delegate_LoadProject LoadProject;

		public readonly Delegate_LoadSystem LoadSystem;

		public readonly Delegate_LoadProgram LoadProgram;

		public readonly Delegate_StepRatio StepRatio;

		public readonly Delegate_DefPos Defpos;

		public readonly Delegate_ConnPath ConnPath;

		public readonly Delegate_UserFrame UserFrame;

		public readonly Delegate_UserFrameB UserFrameB;

		public readonly Delegate_EncoderRatio EncoderRatio;

		public readonly Delegate_MoveSpherical MoveSpherical;

		public readonly Delegate_MoveSphericalSP MoveSphericalSP;

		public readonly Delegate_MoveCircSP MoveCircSP;

		public readonly Delegate_MoveHelicalSP MoveHelicalSP;

		public readonly Delegate_MoveRelSP MoveRelSP;

		public readonly Delegate_MoveAbsSP MoveAbsSP;

		public readonly Delegate_FrameGroup FrameGroup;

		public readonly Delegate_MoveContour MoveContour;

		public readonly Delegate_InvertIn InvertIn;

		public readonly Delegate_FrameTrans FrameTrans;

		public readonly Delegate_UserFrameTrans UserFrameTrans;

		public readonly Delegate_Aout Aout;

		public readonly Delegate_AddDac AddDac;

		public readonly Delegate_AxesDiff AxesDiff;

		public readonly Delegate_FlexLink FlexLink;

		public readonly Delegate_HwPswitch HwPswitch;

		public readonly Delegate_MoveRelSeq MoveRelSeq;

		public readonly Delegate_MoveAbsSeq MoveAbsSeq;

		public readonly Delegate_MoveAdd MoveAdd;

		public readonly Delegate_MovePick MovePick;

		public readonly Delegate_MoveDispense MoveDispense;

		public readonly Delegate_MoveTang MoveTang;

		public readonly Delegate_SphereCentre SphereCentre;

		public readonly Delegate_Sync Sync;

		public readonly Delegate_ToolOffset ToolOffset;

		public readonly Delegate_PWMControl PWMControl;

		public readonly Delegate_SetMotion SetMotion;

		public readonly Delegate_SetMotionSP SetMotionSP;

		public readonly Delegate_TextFileLoader TextFileLoader;

		public readonly Delegate_IsOpen IsOpen;

		public readonly Delegate_IsError IsError;

		public readonly Delegate_ScopeOnOff ScopeOnOff;

		public readonly Delegate_Scope Scope;

		public readonly Delegate_Trigger Trigger;

		public readonly Delegate_ReadOp ReadOp;

		public readonly Delegate_PRMBLK_DefineAxis PRMBLK_DefineAxis;

		public readonly Delegate_PRMBLK_DefineSystem PRMBLK_DefineSystem;

		public readonly Delegate_PRMBLK_DefineVr PRMBLK_DefineVr;

		public readonly Delegate_PRMBLK_DefineTable PRMBLK_DefineTable;

		public readonly Delegate_PRMBLK_DefineProgram PRMBLK_DefineProgram;

		public readonly Delegate_PRMBLK_Append PRMBLK_Append;

		public readonly Delegate_PRMBLK_Get PRMBLK_Get;

		public readonly Delegate_PRMBLK_GetAxis PRMBLK_GetAxis;

		public readonly Delegate_PRMBLK_Delete PRMBLK_Delete;

		protected ArchitectureIndependentTrioPC(Delegate_CreateContext CreateContext, Delegate_DestroyContext DestroyContext, Delegate_SetHost SetHost, Delegate_SetBoard SetBoard, Delegate_GetBoard GetBoard, Delegate_SetHostAddress SetHostAddress, Delegate_GetHostAddress GetHostAddress, Delegate_GetConnectionType GetConnectionType, Delegate_SetCmdProtocol SetCmdProtocol, Delegate_GetCmdProtocol GetCmdProtocol, Delegate_SetFlushBeforeWrite SetFlushBeforeWrite, Delegate_GetFlushBeforeWrite GetFlushBeforeWrite, Delegate_SetFastSerialMode SetFastSerialMode, Delegate_GetFastSerialMode GetFastSerialMode, Delegate_GetLastError GetLastError, Delegate_ProductVersion ProductVersion, Delegate_ProductName ProductName, Delegate_Close Close, Delegate_Open Open, Delegate_SetAxisVariable SetAxisVariable, Delegate_GetAxisVariable GetAxisVariable, Delegate_SetProcVariable SetProcVariable, Delegate_GetProcVariable GetProcVariable, Delegate_SetSlotVariable SetSlotVariable, Delegate_GetSlotVariable GetSlotVariable, Delegate_SetPortVariable SetPortVariable, Delegate_GetPortVariable GetPortVariable, Delegate_SetVr SetVr, Delegate_GetVr GetVr, Delegate_SetVrString SetVrString, Delegate_GetVrString GetVrString, Delegate_SetVariable SetVariable, Delegate_GetVariable GetVariable, Delegate_GetProcessVariable GetProcessVariable, Delegate_GetProcessVariablestr GetProcessVariableStr, Delegate_SetTable SetTable, Delegate_GetTable GetTable, Delegate_MoveRel MoveRel, Delegate_Base Base, Delegate_MoveAbs MoveAbs, Delegate_MoveCirc MoveCirc, Delegate_AddAxis AddAxis, Delegate_Cambox Cambox, Delegate_Cam Cam, Delegate_Cancel Cancel, Delegate_Connect Connect, Delegate_Datum Datum, Delegate_Forward Forward, Delegate_MoveHelical MoveHelical, Delegate_MoveLink MoveLink, Delegate_MoveModify MoveModify, Delegate_RapidStop RapidStop, Delegate_Reverse Reverse, Delegate_Run Run, Delegate_Stop Stop, Delegate_Op Op, Delegate_Ain Ain, Delegate_Get Get, Delegate_Input Input, Delegate_Key Key, Delegate_Mark Mark, Delegate_MarkB MarkB, Delegate_Linput Linput, Delegate_PswitchOff PswitchOff, Delegate_Pswitch Pswitch, Delegate_ReadPacket ReadPacket, Delegate_Regist1 Regist1, Delegate_Regist2 Regist2, Delegate_Setcom Setcom, Delegate_In In, Delegate_Execute Execute, Delegate_New New, Delegate_Select Select, Delegate_Dir Dir, Delegate_InsertLine InsertLine, Delegate_SendData SendData, Delegate_GetData GetData, Delegate_MechatroLink MechatroLink, Delegate_LoadProject LoadProject, Delegate_LoadSystem LoadSystem, Delegate_LoadProgram LoadProgram, Delegate_StepRatio StepRatio, Delegate_DefPos Defpos, Delegate_ConnPath ConnPath, Delegate_UserFrame UserFrame, Delegate_UserFrameB UserFrameB, Delegate_EncoderRatio EncoderRatio, Delegate_MoveSpherical MoveSpherical, Delegate_MoveSphericalSP MoveSphericalSP, Delegate_MoveCircSP MoveCircSP, Delegate_MoveHelicalSP MoveHelicalSP, Delegate_MoveRelSP MoveRelSP, Delegate_MoveAbsSP MoveAbsSP, Delegate_FrameGroup FrameGroup, Delegate_MoveContour MoveContour, Delegate_InvertIn InvertIn, Delegate_FrameTrans FrameTrans, Delegate_UserFrameTrans UserFrameTrans, Delegate_Aout Aout, Delegate_AddDac AddDac, Delegate_AxesDiff AxesDiff, Delegate_FlexLink FlexLink, Delegate_HwPswitch HwPswitch, Delegate_MoveRelSeq MoveRelSeq, Delegate_MoveAbsSeq MoveAbsSeq, Delegate_MoveAdd MoveAdd, Delegate_MovePick MovePick, Delegate_MoveDispense MoveDispense, Delegate_MoveTang MoveTang, Delegate_SphereCentre SphereCentre, Delegate_Sync Sync, Delegate_ToolOffset ToolOffset, Delegate_PWMControl PWMControl, Delegate_SetMotion SetMotion, Delegate_SetMotionSP SetMotionSP, Delegate_TextFileLoader TextFileLoader, Delegate_IsOpen IsOpen, Delegate_IsError IsError, Delegate_ScopeOnOff ScopeOnOff, Delegate_Scope Scope, Delegate_Trigger Trigger, Delegate_ReadOp ReadOp, Delegate_PRMBLK_DefineAxis PRMBLK_DefineAxis, Delegate_PRMBLK_DefineSystem PRMBLK_DefineSystem, Delegate_PRMBLK_DefineVr PRMBLK_DefineVr, Delegate_PRMBLK_DefineTable PRMBLK_DefineTable, Delegate_PRMBLK_DefineProgram PRMBLK_DefineProgram, Delegate_PRMBLK_Append PRMBLK_Append, Delegate_PRMBLK_Get PRMBLK_Get, Delegate_PRMBLK_GetAxis PRMBLK_GetAxis, Delegate_PRMBLK_Delete PRMBLK_Delete)
		{
			this.CreateContext = CreateContext;
			this.DestroyContext = DestroyContext;
			this.SetHost = SetHost;
			this.SetBoard = SetBoard;
			this.GetBoard = GetBoard;
			this.SetHostAddress = SetHostAddress;
			this.GetHostAddress = GetHostAddress;
			this.GetConnectionType = GetConnectionType;
			this.SetCmdProtocol = SetCmdProtocol;
			this.GetCmdProtocol = GetCmdProtocol;
			this.SetFlushBeforeWrite = SetFlushBeforeWrite;
			this.GetFlushBeforeWrite = GetFlushBeforeWrite;
			this.SetFastSerialMode = SetFastSerialMode;
			this.GetFastSerialMode = GetFastSerialMode;
			this.GetLastError = GetLastError;
			this.ProductVersion = ProductVersion;
			this.ProductName = ProductName;
			this.Close = Close;
			this.Open = Open;
			this.SetAxisVariable = SetAxisVariable;
			this.GetAxisVariable = GetAxisVariable;
			this.SetProcVariable = SetProcVariable;
			this.GetProcVariable = GetProcVariable;
			this.SetSlotVariable = SetSlotVariable;
			this.GetSlotVariable = GetSlotVariable;
			this.SetPortVariable = SetPortVariable;
			this.GetPortVariable = GetPortVariable;
			this.SetVr = SetVr;
			this.GetVr = GetVr;
			this.SetVrString = SetVrString;
			this.GetVrString = GetVrString;
			this.SetVariable = SetVariable;
			this.GetVariable = GetVariable;
			this.GetProcessVariable = GetProcessVariable;
			this.GetProcessVariableStr = GetProcessVariableStr;
			this.SetTable = SetTable;
			this.GetTable = GetTable;
			this.MoveRel = MoveRel;
			this.Base = Base;
			this.MoveAbs = MoveAbs;
			this.MoveCirc = MoveCirc;
			this.AddAxis = AddAxis;
			this.Cambox = Cambox;
			this.Cam = Cam;
			this.Cancel = Cancel;
			this.Connect = Connect;
			this.Datum = Datum;
			this.Forward = Forward;
			this.MoveHelical = MoveHelical;
			this.MoveLink = MoveLink;
			this.MoveModify = MoveModify;
			this.RapidStop = RapidStop;
			this.Reverse = Reverse;
			this.Run = Run;
			this.Stop = Stop;
			this.Op = Op;
			this.Ain = Ain;
			this.Get = Get;
			this.Input = Input;
			this.Key = Key;
			this.Mark = Mark;
			this.MarkB = MarkB;
			this.Linput = Linput;
			this.PswitchOff = PswitchOff;
			this.Pswitch = Pswitch;
			this.ReadPacket = ReadPacket;
			this.Regist1 = Regist1;
			this.Regist2 = Regist2;
			this.Setcom = Setcom;
			this.In = In;
			this.Execute = Execute;
			this.New = New;
			this.Select = Select;
			this.Dir = Dir;
			this.InsertLine = InsertLine;
			this.SendData = SendData;
			this.GetData = GetData;
			this.MechatroLink = MechatroLink;
			this.LoadProject = LoadProject;
			this.LoadSystem = LoadSystem;
			this.LoadProgram = LoadProgram;
			this.StepRatio = StepRatio;
			this.Defpos = Defpos;
			this.ConnPath = ConnPath;
			this.UserFrame = UserFrame;
			this.UserFrameB = UserFrameB;
			this.EncoderRatio = EncoderRatio;
			this.MoveSpherical = MoveSpherical;
			this.MoveSphericalSP = MoveSphericalSP;
			this.MoveCircSP = MoveCircSP;
			this.MoveHelicalSP = MoveHelicalSP;
			this.MoveRelSP = MoveRelSP;
			this.MoveAbsSP = MoveAbsSP;
			this.FrameGroup = FrameGroup;
			this.MoveContour = MoveContour;
			this.InvertIn = InvertIn;
			this.FrameTrans = FrameTrans;
			this.UserFrameTrans = UserFrameTrans;
			this.Aout = Aout;
			this.AddDac = AddDac;
			this.AxesDiff = AxesDiff;
			this.FlexLink = FlexLink;
			this.HwPswitch = HwPswitch;
			this.MoveRelSeq = MoveRelSeq;
			this.MoveAbsSeq = MoveAbsSeq;
			this.MoveAdd = MoveAdd;
			this.MovePick = MovePick;
			this.MoveDispense = MoveDispense;
			this.MoveTang = MoveTang;
			this.SphereCentre = SphereCentre;
			this.Sync = Sync;
			this.ToolOffset = ToolOffset;
			this.PWMControl = PWMControl;
			this.SetMotion = SetMotion;
			this.SetMotionSP = SetMotionSP;
			this.TextFileLoader = TextFileLoader;
			this.IsOpen = IsOpen;
			this.IsError = IsError;
			this.ScopeOnOff = ScopeOnOff;
			this.Scope = Scope;
			this.Trigger = Trigger;
			this.ReadOp = ReadOp;
			this.PRMBLK_DefineAxis = PRMBLK_DefineAxis;
			this.PRMBLK_DefineSystem = PRMBLK_DefineSystem;
			this.PRMBLK_DefineVr = PRMBLK_DefineVr;
			this.PRMBLK_DefineTable = PRMBLK_DefineTable;
			this.PRMBLK_DefineProgram = PRMBLK_DefineProgram;
			this.PRMBLK_Append = PRMBLK_Append;
			this.PRMBLK_Get = PRMBLK_Get;
			this.PRMBLK_GetAxis = PRMBLK_GetAxis;
			this.PRMBLK_Delete = PRMBLK_Delete;
			FieldInfo[] fields = typeof(ArchitectureIndependentTrioPC).GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.GetValue(this) == null)
				{
					throw new MissingFieldException($"Missing definition for {fieldInfo.Name}.");
				}
			}
		}
	}
}
