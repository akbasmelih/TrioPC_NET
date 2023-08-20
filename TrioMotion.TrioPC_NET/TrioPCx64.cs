using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TrioMotion.TrioPC_NET
{
	internal class TrioPCx64 : ArchitectureIndependentTrioPC
	{
		private const string DLL = "TrioPC64.dll";

		public TrioPCx64()
			: base(TrioPC_CreateContext, TrioPC_DestroyContext, TrioPC_SetHost, TrioPC_SetBoard, TrioPC_GetBoard, TrioPC_SetHostAddress, TrioPC_GetHostAddress, TrioPC_GetConnectionType, TrioPC_SetCmdProtocol, TrioPC_GetCmdProtocol, TrioPC_SetFlushBeforeWrite, TrioPC_GetFlushBeforeWrite, TrioPC_SetFastSerialMode, TrioPC_GetFastSerialMode, TrioPC_GetLastError, TrioPC_ProductVersion, TrioPC_ProductName, TrioPC_Close, TrioPC_Open, TrioPC_SetAxisVariable, TrioPC_GetAxisVariable, TrioPC_SetProcVariable, TrioPC_GetProcVariable, TrioPC_SetSlotVariable, TrioPC_GetSlotVariable, TrioPC_SetPortVariable, TrioPC_GetPortVariable, TrioPC_SetVr, TrioPC_GetVr, TrioPC_SetVrString, TrioPC_GetVrString, TrioPC_SetVariable, TrioPC_GetVariable, TrioPC_GetProcessVariable, TrioPC_GetProcessVariableStr, TrioPC_SetTable, TrioPC_GetTable, TrioPC_MoveRel, TrioPC_Base, TrioPC_MoveAbs, TrioPC_MoveCirc, TrioPC_AddAxis, TrioPC_Cambox, TrioPC_Cam, TrioPC_Cancel, TrioPC_Connect, TrioPC_Datum, TrioPC_Forward, TrioPC_MoveHelical, TrioPC_MoveLink, TrioPC_MoveModify, TrioPC_RapidStop, TrioPC_Reverse, TrioPC_Run, TrioPC_Stop, TrioPC_Op, TrioPC_Ain, TrioPC_Get, TrioPC_Input, TrioPC_Key, TrioPC_Mark, TrioPC_MarkB, TrioPC_Linput, TrioPC_PswitchOff, TrioPC_Pswitch, TrioPC_ReadPacket, TrioPC_Regist1, TrioPC_Regist2, TrioPC_Setcom, TrioPC_In, TrioPC_Execute, TrioPC_New, TrioPC_Select, TrioPC_Dir, TrioPC_InsertLine, TrioPC_SendData, TrioPC_GetData, TrioPC_MechatroLink, TrioPC_LoadProject, TrioPC_LoadSystem, TrioPC_LoadProgram, TrioPC_StepRatio, TrioPC_Defpos, TrioPC_ConnPath, TrioPC_UserFrame, TrioPC_UserFrameB, TrioPC_EncoderRatio, TrioPC_MoveSpherical, TrioPC_MoveSphericalSP, TrioPC_MoveCircSP, TrioPC_MoveHelicalSP, TrioPC_MoveRelSP, TrioPC_MoveAbsSP, TrioPC_FrameGroup, TrioPC_MoveContour, TrioPC_InvertIn, TrioPC_FrameTrans, TrioPC_UserFrameTrans, TrioPC_Aout, TrioPC_AddDac, TrioPC_AxesDiff, TrioPC_FlexLink, TrioPC_HwPswitch, TrioPC_MoveRelSeq, TrioPC_MoveAbsSeq, TrioPC_MoveAdd, TrioPC_MovePick, TrioPC_MoveDispense, TrioPC_MoveTang, TrioPC_SphereCentre, TrioPC_Sync, TrioPC_ToolOffset, TrioPC_PWMControl, TrioPC_SetMotion, TrioPC_SetMotionSP, TrioPC_TextFileLoader, TrioPC_IsOpen, TrioPC_IsError, TrioPC_ScopeOnOff, TrioPC_Scope, TrioPC_Trigger, TrioPC_ReadOp, TrioPC_PRMBLK_DefineAxis, TrioPC_PRMBLK_DefineSystem, TrioPC_PRMBLK_DefineVr, TrioPC_PRMBLK_DefineTable, TrioPC_PRMBLK_DefineProgram, TrioPC_PRMBLK_Append, TrioPC_PRMBLK_Get, TrioPC_PRMBLK_GetAxis, TrioPC_PRMBLK_Delete)
		{
		}

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern IntPtr TrioPC_CreateContext();

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern void TrioPC_DestroyContext(IntPtr context);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern void TrioPC_SetHost(IntPtr context, string host);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SetBoard(IntPtr context, short board);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern long TrioPC_GetBoard(IntPtr context);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern void TrioPC_SetHostAddress(IntPtr context, string hostAddress);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		[return: MarshalAs(UnmanagedType.BStr)]
		private static extern string TrioPC_GetHostAddress(IntPtr context);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern int TrioPC_GetConnectionType(IntPtr context);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern void TrioPC_SetCmdProtocol(IntPtr context, int cmdProtocol);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern int TrioPC_GetCmdProtocol(IntPtr context);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern void TrioPC_SetFlushBeforeWrite(IntPtr context, int FlushBeforeWrite);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern int TrioPC_GetFlushBeforeWrite(IntPtr context);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern void TrioPC_SetFastSerialMode(IntPtr context, int FastSerialMode);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern int TrioPC_GetFastSerialMode(IntPtr context);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern int TrioPC_GetLastError(IntPtr context);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_ProductVersion(IntPtr context, StringBuilder Version, int VersionSize);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_ProductName(IntPtr context, StringBuilder Name, int NameSize);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern void TrioPC_Close(IntPtr context, PortId portId);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Open(IntPtr context, PortType portType, PortId portId, IntPtr NativeCommunicationsEventContext, [MarshalAs(UnmanagedType.FunctionPtr)] NativeEventCallback NativeCommunicationsEvent);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SetAxisVariable(IntPtr context, string variable, short axis, double value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_GetAxisVariable(IntPtr context, string variable, short axis, out double value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SetProcVariable(IntPtr context, string variable, short process, double value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_GetProcVariable(IntPtr context, string variable, short proc, out double value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SetSlotVariable(IntPtr context, string variable, short slot, double value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_GetSlotVariable(IntPtr context, string variable, short slot, out double value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SetPortVariable(IntPtr context, string variable, short port, double value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_GetPortVariable(IntPtr context, string variable, short port, out double value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SetVr(IntPtr context, short Variable, double Value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_GetVr(IntPtr context, short Variable, out double Value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SetVrString(IntPtr context, short VrPosition, string stringValue);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_GetVrString(IntPtr context, short VrPosition, StringBuilder stringValue);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SetVariable(IntPtr context, string Variable, double Value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_GetVariable(IntPtr context, string Variable, out double Value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_GetProcessVariable(IntPtr context, short variable, short process, out double value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_GetProcessVariableStr(IntPtr context, string processVarStr, short process, StringBuilder processVarOutput);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SetTable(IntPtr context, int StartPosition, int NumberOfValues, IntPtr Values);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_GetTable(IntPtr context, int StartPosition, int NumberOfValues, IntPtr Values);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveRel(IntPtr context, short Axes, IntPtr Distance, int Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Base(IntPtr context, short Axes, double[] Order);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveAbs(IntPtr context, short Axes, IntPtr Distance, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveCirc(IntPtr context, double FinishBase, double FinishNext, double CentreBase, double CentreNext, short Direction, int BaseAxis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_AddAxis(IntPtr context, short LinkAxis, int Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Cambox(IntPtr context, short TableStart, short TableStop, double TableMultiplier, double LinkDistance, short LinkAxis, short LinkOptions, double LinkPos, int Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Cam(IntPtr context, short TableStart, short TableStop, double TableMultiplier, double LinkDistance, int Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Cancel(IntPtr context, short Mode, int Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Connect(IntPtr context, double Ratio, short LinkAxis, int Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Datum(IntPtr context, short Sequence, int Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Forward(IntPtr context, int Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveHelical(IntPtr context, double FinishBase, double FinishNext, double CentreBase, double CentreNext, short Direction, double LastDistance, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveLink(IntPtr context, double Distance, double LinkDistance, double LinkAcceleration, double LinkDecceleration, short LinkAxis, short LinkOptions, double LastPosition, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveModify(IntPtr context, double position, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_RapidStop(IntPtr context);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Reverse(IntPtr context, short BaseAxis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Run(IntPtr context, string Program, int Process);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Stop(IntPtr context, string Program, int Process);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Op(IntPtr context, short StartChannel, short StopChannel, int Value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Ain(IntPtr context, short Channel, out double Value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Get(IntPtr context, short channel, out short value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Input(IntPtr context, short Channel, out double Value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Key(IntPtr context, short channel, out short value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Mark(IntPtr context, short axis, out short value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MarkB(IntPtr context, short Axis, out short value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Linput(IntPtr context, short channel, short startVr);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_PswitchOff(IntPtr context, short Switch, short Hold);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Pswitch(IntPtr context, short Switch, short Enable, int Axis, int OutputNumber, int OutputStatus, double SetPosition, double ResetPosition);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_ReadPacket(IntPtr context, short PortNumber, short StartVr, short NumberVr, short Format);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Regist1(IntPtr context, short Mode);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Regist2(IntPtr context, short Mode, double Distance);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Setcom(IntPtr context, int BaudRate, short DataBits, short StopBits, short Parity, short Port, int Control);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_In(IntPtr context, short StartChannel, short StopChannel, out double value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Execute(IntPtr context, string command);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_New(IntPtr context, string Program);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Select(IntPtr context, string Program);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Dir(IntPtr context, StringBuilder Directory, int DirectorySize, string Option);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_InsertLine(IntPtr context, string Program, short LineNumber, string Line);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SendData(IntPtr context, short channel, string data);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_GetData(IntPtr context, short channel, StringBuilder data, int size_data);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MechatroLink(IntPtr context, short Module, short Function, short NumberOfParameter, double MLPParameter, out double pdResult);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_LoadProject(IntPtr context, string ProjectFile);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_LoadSystem(IntPtr context, string SystemFile);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_LoadProgram(IntPtr context, string ProgramFile, bool SlowLoad);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_StepRatio(IntPtr context, int Numerator, int Denominator, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Defpos(IntPtr context, double Position, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_ConnPath(IntPtr context, double Ratio, short LinkAxis, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_UserFrame(IntPtr context, short Identity, short Axes, double[] Positions);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_UserFrameB(IntPtr context, short Identity);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_EncoderRatio(IntPtr context, short MposCount, short InputCount, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveSpherical(IntPtr context, double EndMidX, double EndMidY, double EndMidZ, double CentreX, double CentreY, double CentreZ, short Mode, short Axis, short gtpi, short rotau, short rotav, short rotaw);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveSphericalSP(IntPtr context, double EndMidX, double EndMidY, double EndMidZ, double CentreX, double CentreY, double CentreZ, short Mode, short Axis, short gtpi, short rotau, short rotav, short rotaw);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveCircSP(IntPtr context, double FinishBase, double FinishNext, double CentreBase, double CentreNext, short Direction, short Axis, short transAngle, short output);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveHelicalSP(IntPtr context, double FinishBase, double FinishNext, double CentreBase, double CentreNext, short Direction, double LinearDistance, short Axis, short mode);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveRelSP(IntPtr context, short Axes, IntPtr Distance, int Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveAbsSP(IntPtr context, short Axes, IntPtr Distance, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_FrameGroup(IntPtr context, short Group, short table_offset, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveContour(IntPtr context, short tablePointer, short Axes, short nPoints, short options, short speed_option, short output_table_area, short shortLen, short CornerAcc, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_InvertIn(IntPtr context, short input, short state);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_FrameTrans(IntPtr context, short Frame, short table_in, short table_out, double direction, short table_offset);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_UserFrameTrans(IntPtr context, short UserFrame_in, short UserFrame_out, short tool_offset_in, short tool_offset_out, short table_in, short table_out, short scale);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Aout(IntPtr context, short Channel, double Value, out double aoutVal);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_AddDac(IntPtr context, short SecondAxis, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_AxesDiff(IntPtr context, short Axis1, short Axis2, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_FlexLink(IntPtr context, double BaseDist, double ExciteDist, double LinkDist, short BaseIn, short BaseOut, short ExciteAcc, short ExciteDec, short LinkAxis, short LinkOption, double LinkPos, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_HwPswitch(IntPtr context, short Mode, short Direction, short Opstate, int TableStart, int TableEnd, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveRelSeq(IntPtr context, short TablePointer, short Axes, short nPoints, short Options, double Radius, short Output, double TransitionAngle, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveAbsSeq(IntPtr context, short TablePointer, short Axes, short nPoints, short Options, double Radius, short Output, double TransitionAngle, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveAdd(IntPtr context, double Distance, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MovePick(IntPtr context, short Mode, double X, double Y, double Z, double Withdraw, double OverlapControlA, double OverlapControlB, double U, double V, double W, double WithdrawControl, double XYControl, double ApproachControl, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveDispense(IntPtr context, short tablePointer, short Axes, short nPoints, short options, short speed_option, short output_table_area, short shortLen, short CornerAcc, short nCodeVr, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_MoveTang(IntPtr context, double AbsolutePosition, short LinkAxis, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SphereCentre(IntPtr context, short TableMid, short TableEnd, short TableOut);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Sync(IntPtr context, short Control, double SyncTime, double SyncPosition, short SyncAxis, double Pos1, double Pos2, double Pos3, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_ToolOffset(IntPtr context, short Identity, double XOffset, double YOffset, double ZOffset);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_PWMControl(IntPtr context, short value, double p1, short p2, short p3, short p4, short p5, short Axis);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SetMotion(IntPtr context, short Axis, double Speed, double Accel, double Decel, double Jerk);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_SetMotionSP(IntPtr context, short Axis, double forceSpeed, double startMoveSpeed, double endMoveSpeed, double forceAccel, double forceDecel, double forceJerk, double forceRamp, double forceDwell);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_TextFileLoader(IntPtr context, string SourceFile, int DestinationMemory, string DestinationFile, int Protocol, bool Compression, int CompressionLevel, bool Timeout, int TimeoutSeconds, int Direction);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_IsOpen(IntPtr context, PortId portId);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_IsError(IntPtr context);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_ScopeOnOff(IntPtr context, bool OnOff);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Scope(IntPtr context, bool OnOff, int SamplePeriod, int TableStart, int TableEnd, string CaptureParams);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_Trigger(IntPtr context);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_ReadOp(IntPtr context, short StartChannel, short StopChannel, out int Value);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_PRMBLK_DefineAxis(IntPtr context, int blockNumber, string variable);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_PRMBLK_DefineSystem(IntPtr context, int blockNumber, string variable);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_PRMBLK_DefineVr(IntPtr context, int blockNumber, short variable);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_PRMBLK_DefineTable(IntPtr context, int blockNumber, short variable);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_PRMBLK_DefineProgram(IntPtr context, int blockNumber, string programName, int processNumber, string variable);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_PRMBLK_Append(IntPtr context, int blockNumber, IntPtr variable);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_PRMBLK_Get(IntPtr context, int blockNumber, bool all, IntPtr variable);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_PRMBLK_GetAxis(IntPtr context, int blockNumber, int axis, bool all, IntPtr variable);

		[DllImport("TrioPC64.dll", CharSet = CharSet.Ansi)]
		private static extern bool TrioPC_PRMBLK_Delete(IntPtr context, int blockNumber);
	}
}
