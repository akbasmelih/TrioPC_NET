using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TrioMotion.TrioPC_NET
{
	public class TrioPC : IDisposable
	{
		public delegate bool NativeEventHandler(NativeEventCallbackType EventType, long IntegerData, string message);

		private ArchitectureIndependentTrioPC dllWrapper;

		private IntPtr context = IntPtr.Zero;

		private NativeEventCallback nativeCallbackDelegate;

		public VR VR;

		public TABLE TABLE;

		private const int SizeOfNativeVariant = 16;

		private object locker = new object();

		public string HostAddress
		{
			get
			{
				lock (locker)
				{
					return dllWrapper.GetHostAddress(context);
				}
			}
			set
			{
				lock (locker)
				{
					dllWrapper.SetHostAddress(context, value);
				}
			}
		}

		public event NativeEventHandler OnNativeEvent;

		public TrioPC()
		{
			nativeCallbackDelegate = NativeCallbackFunction;
			if (Environment.Is64BitProcess)
			{
				dllWrapper = new TrioPCx64();
			}
			else
			{
				dllWrapper = new TrioPCx86();
			}
			context = dllWrapper.CreateContext();
			if (context == IntPtr.Zero)
			{
				throw new InsufficientMemoryException("Cannot assign DLL wrapper context");
			}
			VR = new VR(dllWrapper, context);
			TABLE = new TABLE(dllWrapper, context);
		}

		~TrioPC()
		{
			Dispose(disposing: false);
		}

		protected bool NativeCallbackFunction(IntPtr eventContext, int event_type, int integerData, IntPtr stringData)
		{
			if (this.OnNativeEvent == null)
			{
				return true;
			}
			string message = "";
			if (stringData != IntPtr.Zero)
			{
				message = Marshal.PtrToStringAnsi(stringData);
			}
			return this.OnNativeEvent((NativeEventCallbackType)event_type, integerData, message);
		}

		protected void Dispose(bool disposing)
		{
			lock (locker)
			{
				if (dllWrapper != null && context != IntPtr.Zero)
				{
					if (dllWrapper.IsOpen(context, PortId.Any))
					{
						dllWrapper.Close(context, PortId.Any);
					}
					dllWrapper.DestroyContext(context);
					context = IntPtr.Zero;
				}
				if (disposing)
				{
					dllWrapper = null;
					nativeCallbackDelegate = null;
				}
			}
		}

		public void Dispose()
		{
			lock (locker)
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		}

		public void SetHost(string host)
		{
			HostAddress = host;
		}

		public bool SetBoard(int board)
		{
			lock (locker)
			{
				return dllWrapper.SetBoard(context, (short)board);
			}
		}

		public long GetBoard()
		{
			lock (locker)
			{
				return dllWrapper.GetBoard(context);
			}
		}

		public int GetConnectionType()
		{
			lock (locker)
			{
				return dllWrapper.GetConnectionType(context);
			}
		}

		public void SetCmdProtocol(long cmdProtocol)
		{
			lock (locker)
			{
				dllWrapper.SetCmdProtocol(context, (int)cmdProtocol);
			}
		}

		public int GetCmdProtocol()
		{
			lock (locker)
			{
				return dllWrapper.GetCmdProtocol(context);
			}
		}

		public void SetFlushBeforeWrite(long FlushBeforeWrite)
		{
			lock (locker)
			{
				dllWrapper.SetFlushBeforeWrite(context, (int)FlushBeforeWrite);
			}
		}

		public int GetFlushBeforeWrite()
		{
			lock (locker)
			{
				return dllWrapper.GetFlushBeforeWrite(context);
			}
		}

		public void SetFastSerialMode(long FastSerialMode)
		{
			lock (locker)
			{
				dllWrapper.SetFastSerialMode(context, (int)FastSerialMode);
			}
		}

		public int GetFastSerialMode()
		{
			lock (locker)
			{
				return dllWrapper.GetFastSerialMode(context);
			}
		}

		public int GetLastError()
		{
			lock (locker)
			{
				return dllWrapper.GetLastError(context);
			}
		}

		public string ProductVersion()
		{
			lock (locker)
			{
				StringBuilder stringBuilder = new StringBuilder(1024);
				return dllWrapper.ProductVersion(context, stringBuilder, 1024) ? stringBuilder.ToString() : "";
			}
		}

		public string ProductName()
		{
			lock (locker)
			{
				StringBuilder stringBuilder = new StringBuilder(1024);
				return dllWrapper.ProductName(context, stringBuilder, 1024) ? stringBuilder.ToString() : "";
			}
		}

		public void Close(PortId portId)
		{
			lock (locker)
			{
				TABLE.Commit();
				VR.Commit();
				dllWrapper.Close(context, portId);
			}
		}

		public void Close()
		{
			lock (locker)
			{
				dllWrapper.Close(context, PortId.Any);
			}
		}

		public bool Open(PortType portType, PortId portId)
		{
			lock (locker)
			{
				return portId != PortId.Any && dllWrapper.Open(context, portType, portId, IntPtr.Zero, nativeCallbackDelegate);
			}
		}

		public bool SetAxisVariable(string variable, int axis, double value)
		{
			lock (locker)
			{
				return dllWrapper.SetAxisVariable(context, variable, (short)axis, value);
			}
		}

		public bool GetAxisVariable(string variable, int axis, out double value)
		{
			lock (locker)
			{
				return dllWrapper.GetAxisVariable(context, variable, (short)axis, out value);
			}
		}

		public bool SetProcVariable(string variable, int process, double value)
		{
			lock (locker)
			{
				return dllWrapper.SetProcVariable(context, variable, (short)process, value);
			}
		}

		public bool GetProcVariable(string variable, int process, out double value)
		{
			lock (locker)
			{
				return dllWrapper.GetProcVariable(context, variable, (short)process, out value);
			}
		}

		public bool SetSlotVariable(string variable, int slot, double value)
		{
			lock (locker)
			{
				return dllWrapper.SetSlotVariable(context, variable, (short)slot, value);
			}
		}

		public bool GetSlotVariable(string variable, int slot, out double value)
		{
			lock (locker)
			{
				return dllWrapper.GetSlotVariable(context, variable, (short)slot, out value);
			}
		}

		public bool SetPortVariable(string variable, int port, double value)
		{
			lock (locker)
			{
				return dllWrapper.SetPortVariable(context, variable, (short)port, value);
			}
		}

		public bool GetPortVariable(string variable, int port, out double value)
		{
			lock (locker)
			{
				return dllWrapper.GetPortVariable(context, variable, (short)port, out value);
			}
		}

		public bool SetVr(int Variable, double Value)
		{
			lock (locker)
			{
				return dllWrapper.SetVr(context, (short)Variable, Value);
			}
		}

		public bool GetVr(int Variable, out double Value)
		{
			lock (locker)
			{
				return dllWrapper.GetVr(context, (short)Variable, out Value);
			}
		}

		public bool SetVrString(int vrPosition, string stringValue)
		{
			lock (locker)
			{
				return dllWrapper.SetVrString(context, (short)vrPosition, stringValue);
			}
		}

		public bool GetVrString(int vrPosition, out string stringValue)
		{
			lock (locker)
			{
				StringBuilder stringBuilder = new StringBuilder(128);
				if (!dllWrapper.GetVrString(context, (short)vrPosition, stringBuilder))
				{
					stringValue = "";
					return false;
				}
				stringValue = stringBuilder.ToString();
				return true;
			}
		}

		public bool SetVariable(string variable, double value)
		{
			lock (locker)
			{
				return dllWrapper.SetVariable(context, variable, value);
			}
		}

		public bool GetVariable(string Variable, out double Value)
		{
			lock (locker)
			{
				return dllWrapper.GetVariable(context, Variable, out Value);
			}
		}

		public bool GetProcessVariable(int variable, int process, out double value)
		{
			lock (locker)
			{
				return dllWrapper.GetProcessVariable(context, (short)variable, (short)process, out value);
			}
		}

		public bool GetProcessVariableStr(string processVarStr, int process, out string processVarOutput)
		{
			lock (locker)
			{
				StringBuilder stringBuilder = new StringBuilder(128);
				if (!dllWrapper.GetProcessVariableStr(context, processVarStr, (short)process, stringBuilder))
				{
					processVarOutput = "";
					return false;
				}
				processVarOutput = stringBuilder.ToString();
				return true;
			}
		}

		public bool SetTable(int StartPosition, double[] Values)
		{
			lock (locker)
			{
				return SetTable(StartPosition, Values, 0, Values.Length);
			}
		}

		public bool SetTable(int StartPosition, int NumberOfValues, double[] Values)
		{
			lock (locker)
			{
				return SetTable(StartPosition, Values, 0, NumberOfValues);
			}
		}

		public bool SetTable(int StartPosition, double[] Values, int Offset, int NumberOfValues)
		{
			lock (locker)
			{
				bool result = true;
				try
				{
					TABLE.Set(StartPosition, Values, Offset, NumberOfValues);
					TABLE.Commit();
				}
				catch
				{
					result = false;
				}
				return result;
			}
		}

		public bool GetTable(int StartPosition, ref double[] Values)
		{
			lock (locker)
			{
				return GetTable(StartPosition, Values.Length, 0, ref Values);
			}
		}

		public bool GetTable(int startPosition, int NumberOfValues, ref double[] Values)
		{
			lock (locker)
			{
				if (NumberOfValues > Values.Length)
				{
					return false;
				}
				return GetTable(startPosition, NumberOfValues, 0, ref Values);
			}
		}

		public bool GetTable(int StartPosition, int NumberOfValues, int Offset, ref double[] Values)
		{
			lock (locker)
			{
				bool result = true;
				try
				{
					Array.Copy(TABLE.Get(StartPosition, NumberOfValues), 0, Values, Offset, NumberOfValues);
				}
				catch
				{
					result = false;
				}
				return result;
			}
		}

		public bool MoveRel(double[] Distance, int Offset, int Axes, int BaseAxis)
		{
			lock (locker)
			{
				bool result = false;
				GCHandle gCHandle = GCHandle.Alloc(Distance, GCHandleType.Pinned);
				try
				{
					result = dllWrapper.MoveRel(context, (short)Axes, IntPtr.Add(gCHandle.AddrOfPinnedObject(), Offset * 8), BaseAxis);
				}
				finally
				{
					gCHandle.Free();
				}
				return result;
			}
		}

		public bool MoveRel(double[] distance)
		{
			lock (locker)
			{
				return MoveRel(distance, -1);
			}
		}

		public bool MoveRel(double[] Distance, int BaseAxis)
		{
			lock (locker)
			{
				return MoveRel(Distance, 0, Distance.Length, BaseAxis);
			}
		}

		public bool MoveRel(double[] Distance, int Axes, int BaseAxis)
		{
			lock (locker)
			{
				return MoveRel(Distance, 0, Axes, BaseAxis);
			}
		}

		public bool Base(int Axes, double[] Order)
		{
			lock (locker)
			{
				return dllWrapper.Base(context, (short)Axes, Order);
			}
		}

		public bool MoveAbs(double[] distance)
		{
			lock (locker)
			{
				return MoveAbs(distance, -1);
			}
		}

		public bool MoveAbs(double[] Distance, int BaseAxis)
		{
			lock (locker)
			{
				return MoveAbs(Distance, 0, Distance.Length, BaseAxis);
			}
		}

		public bool MoveAbs(double[] Distance, int Axes, int BaseAxis)
		{
			lock (locker)
			{
				return MoveAbs(Distance, 0, Axes, BaseAxis);
			}
		}

		public bool MoveAbs(double[] Distance, int Offset, int Axes, int BaseAxis)
		{
			lock (locker)
			{
				bool result = false;
				GCHandle gCHandle = GCHandle.Alloc(Distance, GCHandleType.Pinned);
				try
				{
					result = dllWrapper.MoveAbs(context, (short)Axes, IntPtr.Add(gCHandle.AddrOfPinnedObject(), Offset * 8), (short)BaseAxis);
				}
				finally
				{
					gCHandle.Free();
				}
				return result;
			}
		}

		public bool MoveCirc(double FinishBase, double FinishNext, double CentreBase, double CentreNext, int Direction, int BaseAxis)
		{
			lock (locker)
			{
				return dllWrapper.MoveCirc(context, FinishBase, FinishNext, CentreBase, CentreNext, (short)Direction, BaseAxis);
			}
		}

		public bool MoveCirc(double FinishBase, double FinishNext, double CentreBase, double CentreNext, int Direction)
		{
			lock (locker)
			{
				return MoveCirc(FinishBase, FinishNext, CentreBase, CentreNext, (short)Direction, -1);
			}
		}

		public bool AddAxis(int LinkAxis, int BaseAxis)
		{
			lock (locker)
			{
				return dllWrapper.AddAxis(context, (short)LinkAxis, BaseAxis);
			}
		}

		public bool AddAxis(int LinkAxis)
		{
			lock (locker)
			{
				return AddAxis((short)LinkAxis, -1);
			}
		}

		public bool Cambox(int TableStart, int TableStop, double TableMultiplier, double LinkDistance, int LinkAxis, int LinkOptions, double LinkPos, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.Cambox(context, (short)TableStart, (short)TableStop, TableMultiplier, LinkDistance, (short)LinkAxis, (short)LinkOptions, LinkPos, Axis);
			}
		}

		public bool Cambox(int TableStart, int TableStop, double TableMultiplier, double LinkDistance, int LinkAxis, int LinkOptions, double LinkPos)
		{
			lock (locker)
			{
				return Cambox((short)TableStart, (short)TableStop, TableMultiplier, LinkDistance, (short)LinkAxis, (short)LinkOptions, LinkPos, -1);
			}
		}

		public bool Cam(int TableStart, int TableStop, double TableMultiplier, double LinkDistance, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.Cam(context, (short)TableStart, (short)TableStop, TableMultiplier, LinkDistance, Axis);
			}
		}

		public bool Cam(int TableStart, int TableStop, double TableMultiplier, double LinkDistance)
		{
			lock (locker)
			{
				return Cam((short)TableStart, (short)TableStop, TableMultiplier, LinkDistance, -1);
			}
		}

		public bool Cancel(int Mode, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.Cancel(context, (short)Mode, Axis);
			}
		}

		public bool Cancel(int Mode)
		{
			lock (locker)
			{
				return Cancel(Mode, -1);
			}
		}

		public bool Connect(double Ratio, int LinkAxis, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.Connect(context, Ratio, (short)LinkAxis, Axis);
			}
		}

		public bool Connect(double Ratio, int LinkAxis)
		{
			lock (locker)
			{
				return Connect(Ratio, (short)LinkAxis, -1);
			}
		}

		public bool Datum(int Sequence)
		{
			lock (locker)
			{
				return Datum((short)Sequence, -1);
			}
		}

		public bool Datum(int Sequence, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.Datum(context, (short)Sequence, Axis);
			}
		}

		public bool Forward(int Axes)
		{
			lock (locker)
			{
				return dllWrapper.Forward(context, Axes);
			}
		}

		public bool Forward()
		{
			lock (locker)
			{
				return Forward(-1);
			}
		}

		public bool MoveHelical(double FinishBase, double FinishNext, double CentreBase, double CentreNext, int Direction, double LastDistance, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.MoveHelical(context, FinishBase, FinishNext, CentreBase, CentreNext, (short)Direction, LastDistance, (short)Axis);
			}
		}

		public bool MoveHelical(double FinishBase, double FinishNext, double CentreBase, double CentreNext, int Direction, double LastDistance)
		{
			lock (locker)
			{
				return MoveHelical(FinishBase, FinishNext, CentreBase, CentreNext, (short)Direction, LastDistance, -1);
			}
		}

		public bool MoveLink(double Distance, double LinkDistance, double LinkAcceleration, double LinkDecceleration, int LinkAxis, int LinkOptions, double LastPosition, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.MoveLink(context, Distance, LinkDistance, LinkAcceleration, LinkDecceleration, (short)LinkAxis, (short)LinkOptions, LastPosition, (short)Axis);
			}
		}

		public bool MoveLink(double Distance, double LinkDistance, double LinkAcceleration, double LinkDecceleration, int LinkAxis, int LinkOptions, double LastPosition)
		{
			lock (locker)
			{
				return MoveLink(Distance, LinkDistance, LinkAcceleration, LinkDecceleration, (short)LinkAxis, (short)LinkOptions, LastPosition, -1);
			}
		}

		public bool MoveModify(double position, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.MoveModify(context, position, (short)Axis);
			}
		}

		public bool MoveModify(double position)
		{
			lock (locker)
			{
				return MoveModify(position, -1);
			}
		}

		public bool RapidStop()
		{
			lock (locker)
			{
				return dllWrapper.RapidStop(context);
			}
		}

		public bool Reverse(int BaseAxis)
		{
			lock (locker)
			{
				return dllWrapper.Reverse(context, (short)BaseAxis);
			}
		}

		public bool Reverse()
		{
			lock (locker)
			{
				return Reverse(-1);
			}
		}

		public bool Run(string Program, int Process)
		{
			lock (locker)
			{
				return dllWrapper.Run(context, Program, Process);
			}
		}

		public bool Stop(string Program)
		{
			lock (locker)
			{
				return Stop(Program, -1);
			}
		}

		public bool Stop(string Program, int Process)
		{
			lock (locker)
			{
				return dllWrapper.Stop(context, Program, Process);
			}
		}

		public bool Op(int StartChannel, int StopChannel, int Value)
		{
			lock (locker)
			{
				return dllWrapper.Op(context, (short)StartChannel, (short)StopChannel, Value);
			}
		}

		public bool Ain(int Channel, out double Value)
		{
			lock (locker)
			{
				return dllWrapper.Ain(context, (short)Channel, out Value);
			}
		}

		public bool Get(int channel, out short value)
		{
			lock (locker)
			{
				return dllWrapper.Get(context, (short)channel, out value);
			}
		}

		public bool Input(int Channel, out double Value)
		{
			lock (locker)
			{
				return dllWrapper.Input(context, (short)Channel, out Value);
			}
		}

		public bool Key(int channel, out short value)
		{
			lock (locker)
			{
				return dllWrapper.Key(context, (short)channel, out value);
			}
		}

		public bool Mark(int axis, out short value)
		{
			lock (locker)
			{
				return dllWrapper.Mark(context, (short)axis, out value);
			}
		}

		public bool MarkB(short Axis, out short value)
		{
			lock (locker)
			{
				return dllWrapper.MarkB(context, Axis, out value);
			}
		}

		public bool Linput(int channel, int startVr)
		{
			lock (locker)
			{
				return dllWrapper.Linput(context, (short)channel, (short)startVr);
			}
		}

		public bool PswitchOff(int Switch, int Hold)
		{
			lock (locker)
			{
				return dllWrapper.PswitchOff(context, (short)Switch, (short)Hold);
			}
		}

		public bool Pswitch(int Switch, int Enable, int Axis, int OutputNumber, int OutputStatus, double SetPosition, double ResetPosition)
		{
			lock (locker)
			{
				return dllWrapper.Pswitch(context, (short)Switch, (short)Enable, (short)Axis, (short)OutputNumber, (short)OutputStatus, SetPosition, ResetPosition);
			}
		}

		public bool ReadPacket(int PortNumber, int StartVr, int NumberVr, int Format)
		{
			lock (locker)
			{
				return dllWrapper.ReadPacket(context, (short)PortNumber, (short)StartVr, (short)NumberVr, (short)Format);
			}
		}

		public bool Regist1(int Mode)
		{
			lock (locker)
			{
				return dllWrapper.Regist1(context, (short)Mode);
			}
		}

		public bool Regist2(int Mode, double Distance)
		{
			lock (locker)
			{
				return dllWrapper.Regist2(context, (short)Mode, Distance);
			}
		}

		public bool SetCom(int BaudRate, int DataBits, int StopBits, int Parity, int Port, int Control)
		{
			lock (locker)
			{
				return dllWrapper.Setcom(context, BaudRate, (short)DataBits, (short)StopBits, (short)Parity, (short)Port, Control);
			}
		}

		public bool In(int StartChannel, int StopChannel, out double value)
		{
			lock (locker)
			{
				return dllWrapper.In(context, (short)StartChannel, (short)StopChannel, out value);
			}
		}

		public bool Execute(string command)
		{
			lock (this)
			{
				return dllWrapper.Execute(context, command);
			}
		}

		public bool New(string Program)
		{
			lock (locker)
			{
				return dllWrapper.New(context, Program);
			}
		}

		public bool Select(string Program)
		{
			lock (locker)
			{
				return dllWrapper.Select(context, Program);
			}
		}

		public bool Dir(out string Directory, int DirectorySize, string Option)
		{
			lock (locker)
			{
				StringBuilder stringBuilder = new StringBuilder(DirectorySize);
				if (!dllWrapper.Dir(context, stringBuilder, DirectorySize, Option))
				{
					Directory = "";
					return false;
				}
				Directory = stringBuilder.ToString();
				return true;
			}
		}

		public bool Dir(out string Directory)
		{
			lock (locker)
			{
				return Dir(out Directory, 1024, "");
			}
		}

		public bool InsertLine(string Program, int LineNumber, string Line)
		{
			lock (locker)
			{
				return dllWrapper.InsertLine(context, Program, (short)LineNumber, Line);
			}
		}

		public bool SendData(int channel, string data)
		{
			lock (locker)
			{
				return dllWrapper.SendData(context, (short)channel, data);
			}
		}

		public bool GetData(int channel, out string data, int data_size)
		{
			lock (locker)
			{
				StringBuilder stringBuilder = new StringBuilder(data_size);
				if (!dllWrapper.GetData(context, (short)channel, stringBuilder, data_size))
				{
					data = "";
					return false;
				}
				data = stringBuilder.ToString();
				return true;
			}
		}

		public bool MechatroLink(int module, int function, int numberOfParameters, double MLPParameter, out double pdResult)
		{
			lock (locker)
			{
				return dllWrapper.MechatroLink(context, (short)module, (short)function, (short)numberOfParameters, MLPParameter, out pdResult);
			}
		}

		public bool LoadProject(string projectFile)
		{
			lock (locker)
			{
				return dllWrapper.LoadProject(context, projectFile);
			}
		}

		public bool LoadSystem(string systemFile)
		{
			lock (locker)
			{
				return dllWrapper.LoadSystem(context, systemFile);
			}
		}

		public bool LoadProgram(string programFile, bool slowLoad)
		{
			lock (locker)
			{
				return dllWrapper.LoadProgram(context, programFile, slowLoad);
			}
		}

		public bool StepRatio(int Numerator, int Denominator, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.StepRatio(context, Numerator, Denominator, (short)Axis);
			}
		}

		public bool StepRatio(int Numerator, int Denominator)
		{
			lock (locker)
			{
				return StepRatio(Numerator, Denominator, -1);
			}
		}

		public bool Defpos(double position, int axis)
		{
			lock (locker)
			{
				return dllWrapper.Defpos(context, position, (short)axis);
			}
		}

		public bool ConnPath(double Ratio, int LinkAxis, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.ConnPath(context, Ratio, (short)LinkAxis, (short)Axis);
			}
		}

		public bool UserFrame(int Identity, int Axes, double[] Positions)
		{
			lock (locker)
			{
				return dllWrapper.UserFrame(context, (short)Identity, (short)Axes, Positions);
			}
		}

		public bool UserFrameB(int Identity)
		{
			lock (locker)
			{
				return dllWrapper.UserFrameB(context, (short)Identity);
			}
		}

		public bool EncoderRatio(int MposCount, int InputCount, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.EncoderRatio(context, (short)MposCount, (short)InputCount, (short)Axis);
			}
		}

		public bool EncoderRatio(int MposCount, int InputCount)
		{
			lock (locker)
			{
				return EncoderRatio(MposCount, InputCount, -1);
			}
		}

		public bool MoveSpherical(double EndMidX, double EndMidY, double EndMidZ, double CentreX, double CentreY, double CentreZ, int Mode, int Axis, int gtpi, int rotau, int rotav, int rotaw)
		{
			lock (locker)
			{
				return dllWrapper.MoveSpherical(context, EndMidX, EndMidY, EndMidZ, CentreX, CentreY, CentreZ, (short)Mode, (short)Axis, (short)gtpi, (short)rotau, (short)rotav, (short)rotaw);
			}
		}

		public bool MoveSpherical(double EndMidX, double EndMidY, double EndMidZ, double CentreX, double CentreY, double CentreZ, int Mode)
		{
			lock (locker)
			{
				return MoveSpherical(EndMidX, EndMidY, EndMidZ, CentreX, CentreY, CentreZ, Mode, -1, 0, 0, 0, 0);
			}
		}

		public bool MoveSpherical(double EndMidX, double EndMidY, double EndMidZ, double CentreX, double CentreY, double CentreZ, int Mode, int Axis)
		{
			lock (locker)
			{
				return MoveSpherical(EndMidX, EndMidY, EndMidZ, CentreX, CentreY, CentreZ, Mode, Axis, 0, 0, 0, 0);
			}
		}

		public bool MoveSphericalSP(double EndMidX, double EndMidY, double EndMidZ, double CentreX, double CentreY, double CentreZ, int Mode, int Axis, int gtpi, int rotau, int rotav, int rotaw)
		{
			lock (locker)
			{
				return dllWrapper.MoveSphericalSP(context, EndMidX, EndMidY, EndMidZ, CentreX, CentreY, CentreZ, (short)Mode, (short)Axis, (short)gtpi, (short)rotau, (short)rotav, (short)rotaw);
			}
		}

		public bool MoveSphericalSP(double EndMidX, double EndMidY, double EndMidZ, double CentreX, double CentreY, double CentreZ, int Mode)
		{
			lock (locker)
			{
				return MoveSphericalSP(EndMidX, EndMidY, EndMidZ, CentreX, CentreY, CentreZ, Mode, -1, 0, 0, 0, 0);
			}
		}

		public bool MoveSphericalSP(double EndMidX, double EndMidY, double EndMidZ, double CentreX, double CentreY, double CentreZ, int Mode, int Axis)
		{
			lock (locker)
			{
				return MoveSphericalSP(EndMidX, EndMidY, EndMidZ, CentreX, CentreY, CentreZ, Mode, Axis, 0, 0, 0, 0);
			}
		}

		public bool MoveCircSP(double FinishBase, double FinishNext, double CentreBase, double CentreNext, int Direction, int Axis, int transAngle, int output)
		{
			lock (locker)
			{
				return dllWrapper.MoveCircSP(context, FinishBase, FinishNext, CentreBase, CentreNext, (short)Direction, (short)Axis, (short)transAngle, (short)output);
			}
		}

		public bool MoveCircSP(double FinishBase, double FinishNext, double CentreBase, double CentreNext, int Direction, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.MoveCircSP(context, FinishBase, FinishNext, CentreBase, CentreNext, (short)Direction, (short)Axis, -1, -1);
			}
		}

		public bool MoveHelicalSP(double FinishBase, double FinishNext, double CentreBase, double CentreNext, int Direction, double LinearDistance, int Axis, int mode)
		{
			lock (locker)
			{
				return dllWrapper.MoveHelicalSP(context, FinishBase, FinishNext, CentreBase, CentreNext, (short)Direction, LinearDistance, (short)Axis, (short)mode);
			}
		}

		public bool MoveHelicalSP(double FinishBase, double FinishNext, double CentreBase, double CentreNext, int Direction, double LastDistance)
		{
			lock (locker)
			{
				return MoveHelicalSP(FinishBase, FinishNext, CentreBase, CentreNext, (short)Direction, LastDistance, -1, 0);
			}
		}

		public bool MoveRelSP(double[] Distance, int Offset, int Axes, int BaseAxis)
		{
			lock (locker)
			{
				bool result = false;
				GCHandle gCHandle = GCHandle.Alloc(Distance, GCHandleType.Pinned);
				try
				{
					result = dllWrapper.MoveRelSP(context, (short)Axes, IntPtr.Add(gCHandle.AddrOfPinnedObject(), Offset * 8), BaseAxis);
				}
				finally
				{
					gCHandle.Free();
				}
				return result;
			}
		}

		public bool MoveRelSP(double[] distance)
		{
			lock (locker)
			{
				return MoveRelSP(distance, -1);
			}
		}

		public bool MoveRelSP(double[] Distance, int BaseAxis)
		{
			lock (locker)
			{
				return MoveRelSP(Distance, 0, Distance.Length, BaseAxis);
			}
		}

		public bool MoveRelSP(double[] Distance, int Axes, int BaseAxis)
		{
			lock (locker)
			{
				return MoveRelSP(Distance, 0, Axes, BaseAxis);
			}
		}

		public bool MoveAbsSP(double[] Distance, int Offset, int Axes, int BaseAxis)
		{
			lock (locker)
			{
				bool result = false;
				GCHandle gCHandle = GCHandle.Alloc(Distance, GCHandleType.Pinned);
				try
				{
					result = dllWrapper.MoveAbsSP(context, (short)Axes, IntPtr.Add(gCHandle.AddrOfPinnedObject(), Offset * 8), (short)BaseAxis);
				}
				finally
				{
					gCHandle.Free();
				}
				return result;
			}
		}

		public bool MoveAbsSP(double[] distance)
		{
			lock (locker)
			{
				return MoveAbsSP(distance, -1);
			}
		}

		public bool MoveAbsSP(double[] Distance, int BaseAxis)
		{
			lock (locker)
			{
				return MoveAbsSP(Distance, 0, Distance.Length, BaseAxis);
			}
		}

		public bool MoveAbsSP(double[] Distance, int Axes, int BaseAxis)
		{
			lock (locker)
			{
				return MoveAbsSP(Distance, 0, Axes, BaseAxis);
			}
		}

		public bool FrameGroup(int Group)
		{
			lock (locker)
			{
				return FrameGroup(Group, 0, 0);
			}
		}

		public bool FrameGroup(int Group, int table_offset, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.FrameGroup(context, (short)Group, (short)table_offset, (short)Axis);
			}
		}

		public bool InvertIn(int input, int state)
		{
			lock (locker)
			{
				return dllWrapper.InvertIn(context, (short)input, (short)state);
			}
		}

		public bool FrameTrans(int Frame, int table_in, int table_out, double direction)
		{
			lock (locker)
			{
				return FrameTrans(Frame, table_in, table_out, direction, 0);
			}
		}

		public bool FrameTrans(int Frame, int table_in, int table_out, double direction, int table_offset)
		{
			lock (locker)
			{
				return dllWrapper.FrameTrans(context, (short)Frame, (short)table_in, (short)table_out, direction, (short)table_offset);
			}
		}

		public bool UserFrameTrans(int UserFrame_in, int UserFrame_out, int tool_offset_in, int tool_offset_out, int table_in, int table_out)
		{
			lock (locker)
			{
				return UserFrameTrans(UserFrame_in, UserFrame_out, tool_offset_in, tool_offset_out, table_in, table_out, 1000);
			}
		}

		public bool UserFrameTrans(int UserFrame_in, int UserFrame_out, int tool_offset_in, int tool_offset_out, int table_in, int table_out, int scale)
		{
			lock (locker)
			{
				return dllWrapper.UserFrameTrans(context, (short)UserFrame_in, (short)UserFrame_out, (short)tool_offset_in, (short)tool_offset_out, (short)table_in, (short)table_out, (short)scale);
			}
		}

		public bool MoveContour(int tablePointer, int Axes, int nPoints, int options, int speed_option, int output_table_area)
		{
			lock (locker)
			{
				return MoveContour(tablePointer, Axes, nPoints, options, speed_option, output_table_area, 0, 0, 0);
			}
		}

		public bool MoveContour(int tablePointer, int Axes, int nPoints, int options, int speed_option, int output_table_area, int shortLen, int CornerAcc)
		{
			lock (locker)
			{
				return MoveContour(tablePointer, Axes, nPoints, options, speed_option, output_table_area, shortLen, CornerAcc, 0);
			}
		}

		public bool MoveContour(int tablePointer, int Axes, int nPoints, int options, int speed_option, int output_table_area, int shortLen, int CornerAcc, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.MoveContour(context, (short)tablePointer, (short)Axes, (short)nPoints, (short)options, (short)speed_option, (short)output_table_area, (short)shortLen, (short)CornerAcc, (short)Axis);
			}
		}

		public bool Aout(int channel, double value, out double aoutVal)
		{
			lock (locker)
			{
				return dllWrapper.Aout(context, (short)channel, value, out aoutVal);
			}
		}

		public bool AddDac(int SecondAxis, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.AddDac(context, (short)SecondAxis, (short)Axis);
			}
		}

		public bool AddDac(int SecondAxis)
		{
			lock (locker)
			{
				return AddDac((short)SecondAxis, -1);
			}
		}

		public bool AxesDiff(int Axis1, int Axis2, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.AxesDiff(context, (short)Axis1, (short)Axis2, (short)Axis);
			}
		}

		public bool AxesDiff(int Axis1, int Axis2)
		{
			lock (locker)
			{
				return AxesDiff((short)Axis1, (short)Axis2, -1);
			}
		}

		public bool FlexLink(double BaseDist, double ExciteDist, double LinkDist, int BaseIn, int BaseOut, int ExciteAcc, int ExciteDec, int LinkAxis, int LinkOption, double LinkPos, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.FlexLink(context, BaseDist, ExciteDist, LinkDist, (short)BaseIn, (short)BaseOut, (short)ExciteAcc, (short)ExciteDec, (short)LinkAxis, (short)LinkOption, LinkPos, (short)Axis);
			}
		}

		public bool FlexLink(double BaseDist, double ExciteDist, double LinkDist, int BaseIn, int BaseOut, int ExciteAcc, int ExciteDec, int LinkAxis, int Axis)
		{
			lock (locker)
			{
				return FlexLink(BaseDist, ExciteDist, LinkDist, (short)BaseIn, (short)BaseOut, (short)ExciteAcc, (short)ExciteDec, (short)LinkAxis, 0, 0.0, (short)Axis);
			}
		}

		public bool FlexLink(double BaseDist, double ExciteDist, double LinkDist, int BaseIn, int BaseOut, int ExciteAcc, int ExciteDec, int LinkAxis)
		{
			lock (locker)
			{
				return FlexLink(BaseDist, ExciteDist, LinkDist, (short)BaseIn, (short)BaseOut, (short)ExciteAcc, (short)ExciteDec, (short)LinkAxis, 0, 0.0, -1);
			}
		}

		public bool HwPswitch(int Mode, int Direction, int Opstate, int TableStart, int TableEnd, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.HwPswitch(context, (short)Mode, (short)Direction, (short)Opstate, TableStart, TableEnd, (short)Axis);
			}
		}

		public bool HwPswitch(int Mode, int Direction, int Opstate, int TableStart, int TableEnd)
		{
			lock (locker)
			{
				return HwPswitch((short)Mode, (short)Direction, (short)Opstate, TableStart, TableEnd, -1);
			}
		}

		public bool HwPswitch(int Mode)
		{
			lock (locker)
			{
				return HwPswitch((short)Mode, -1);
			}
		}

		public bool HwPswitch(int Mode, int Axis)
		{
			lock (locker)
			{
				return HwPswitch((short)Mode, 0, 0, 0, 0, (short)Axis);
			}
		}

		public bool MoveRelSeq(int TablePointer, int Axes, int nPoints, int Options, double Radius, int Output, double TransitionAngle, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.MoveRelSeq(context, (short)TablePointer, (short)Axes, (short)nPoints, (short)Options, Radius, (short)Output, TransitionAngle, (short)Axis);
			}
		}

		public bool MoveRelSeq(int TablePointer, int Axes, int nPoints, int Options, double Radius, int Output, double TransitionAngle)
		{
			lock (locker)
			{
				return MoveRelSeq((short)TablePointer, (short)Axes, (short)nPoints, (short)Options, Radius, (short)Output, TransitionAngle, -1);
			}
		}

		public bool MoveRelSeq(int TablePointer, int Axes, int nPoints, int Options, double Radius, int Axis)
		{
			lock (locker)
			{
				return MoveRelSeq((short)TablePointer, (short)Axes, (short)nPoints, (short)Options, Radius, 0, 0.0, (short)Axis);
			}
		}

		public bool MoveRelSeq(int TablePointer, int Axes, int nPoints, int Options, double Radius)
		{
			lock (locker)
			{
				return MoveRelSeq((short)TablePointer, (short)Axes, (short)nPoints, (short)Options, Radius, -1);
			}
		}

		public bool MoveAbsSeq(int TablePointer, int Axes, int nPoints, int Options, double Radius, int Output, double TransitionAngle, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.MoveAbsSeq(context, (short)TablePointer, (short)Axes, (short)nPoints, (short)Options, Radius, (short)Output, TransitionAngle, (short)Axis);
			}
		}

		public bool MoveAbsSeq(int TablePointer, int Axes, int nPoints, int Options, double Radius, int Output, double TransitionAngle)
		{
			lock (locker)
			{
				return MoveAbsSeq((short)TablePointer, (short)Axes, (short)nPoints, (short)Options, Radius, (short)Output, TransitionAngle, -1);
			}
		}

		public bool MoveAbsSeq(int TablePointer, int Axes, int nPoints, int Options, double Radius, int Axis)
		{
			lock (locker)
			{
				return MoveAbsSeq((short)TablePointer, (short)Axes, (short)nPoints, (short)Options, Radius, 0, 0.0, (short)Axis);
			}
		}

		public bool MoveAbsSeq(int TablePointer, int Axes, int nPoints, int Options, double Radius)
		{
			lock (locker)
			{
				return MoveAbsSeq((short)TablePointer, (short)Axes, (short)nPoints, (short)Options, Radius, -1);
			}
		}

		public bool MoveAdd(double Distance, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.MoveAdd(context, Distance, (short)Axis);
			}
		}

		public bool MoveAdd(double Distance)
		{
			lock (locker)
			{
				return MoveAdd(Distance, -1);
			}
		}

		public bool MovePick(int Mode, double X, double Y, double Z, double Withdraw, double OverlapControlA, double OverlapControlB, double U, double V, double W, double WithdrawControl, double XYControl, double ApproachControl, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.MovePick(context, (short)Mode, X, Y, Z, Withdraw, OverlapControlA, OverlapControlB, U, V, W, WithdrawControl, XYControl, ApproachControl, (short)Axis);
			}
		}

		public bool MovePick(int Mode, double X, double Y, double Z, double Withdraw, double OverlapControlA, double OverlapControlB, double U, double V, double W, double WithdrawControl, double XYControl, double ApproachControl)
		{
			lock (locker)
			{
				return MovePick((short)Mode, X, Y, Z, Withdraw, OverlapControlA, OverlapControlB, U, V, W, WithdrawControl, XYControl, ApproachControl, -1);
			}
		}

		public bool MoveDispense(int tablePointer, int Axes, int nPoints, int options, int speed_option, int output_table_area, int shortLen, int CornerAcc, int nCodeVr, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.MoveDispense(context, (short)tablePointer, (short)Axes, (short)nPoints, (short)options, (short)speed_option, (short)output_table_area, (short)shortLen, (short)CornerAcc, (short)nCodeVr, (short)Axis);
			}
		}

		public bool MoveDispense(int tablePointer, int Axes, int nPoints, int options, int speed_option, int output_table_area, int shortLen, int CornerAcc, int nCodeVr)
		{
			lock (locker)
			{
				return MoveDispense(tablePointer, Axes, nPoints, options, speed_option, output_table_area, shortLen, CornerAcc, nCodeVr, -1);
			}
		}

		public bool MoveDispense(int tablePointer, int Axes, int nPoints, int options, int speed_option, int output_table_area, int shortLen)
		{
			lock (locker)
			{
				return MoveDispense(tablePointer, Axes, nPoints, options, speed_option, output_table_area, shortLen, 0, 0, -1);
			}
		}

		public bool MoveDispense(int tablePointer, int Axes, int nPoints, int options, int speed_option, int output_table_area, int shortLen, int CornerAcc)
		{
			lock (locker)
			{
				return MoveDispense(tablePointer, Axes, nPoints, options, speed_option, output_table_area, shortLen, CornerAcc, 0, -1);
			}
		}

		public bool MoveTang(double AbsolutePosition, int LinkAxis, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.MoveTang(context, AbsolutePosition, (short)LinkAxis, (short)Axis);
			}
		}

		public bool MoveTang(double AbsolutePosition, int LinkAxis)
		{
			lock (locker)
			{
				return MoveTang(AbsolutePosition, LinkAxis, -1);
			}
		}

		public bool MoveTang(double AbsolutePosition)
		{
			lock (locker)
			{
				return MoveTang(AbsolutePosition, -1, -1);
			}
		}

		public bool SphereCentre(int TableMid, int TableEnd, int TableOut)
		{
			lock (locker)
			{
				return dllWrapper.SphereCentre(context, (short)TableMid, (short)TableEnd, (short)TableOut);
			}
		}

		public bool Sync(int Control, double SyncTime, double SyncPosition, int SyncAxis, double Pos1, double Pos2, double Pos3, int Axis)
		{
			lock (locker)
			{
				return dllWrapper.Sync(context, (short)Control, SyncTime, SyncPosition, (short)SyncAxis, Pos1, Pos2, Pos3, (short)Axis);
			}
		}

		public bool Sync(int Control, double SyncTime, double SyncPosition, int SyncAxis, double Pos1, double Pos2, double Pos3)
		{
			lock (locker)
			{
				return Sync((short)Control, SyncTime, SyncPosition, (short)SyncAxis, Pos1, Pos2, Pos3, -1);
			}
		}

		public bool Sync(int Control, double SyncTime, double SyncPosition, int SyncAxis)
		{
			lock (locker)
			{
				return Sync((short)Control, SyncTime, SyncPosition, (short)SyncAxis, 0.0, 0.0, 0.0, -1);
			}
		}

		public bool Sync(int Control, double SyncTime, double SyncPosition, int SyncAxis, double Pos1)
		{
			lock (locker)
			{
				return Sync((short)Control, SyncTime, SyncPosition, (short)SyncAxis, Pos1, 0.0, 0.0, -1);
			}
		}

		public bool Sync(int Control, double SyncTime, double SyncPosition, int SyncAxis, double Pos1, double Pos2)
		{
			lock (locker)
			{
				return Sync((short)Control, SyncTime, SyncPosition, (short)SyncAxis, Pos1, Pos2, 0.0, -1);
			}
		}

		public bool Sync(int Control, double SyncTime)
		{
			lock (locker)
			{
				if (Control != 4)
				{
					return false;
				}
				return Sync((short)Control, SyncTime, 0.0, -1, 0.0, 0.0, 0.0, -1);
			}
		}

		public bool ToolOffset(int Identity, double XOffset, double YOffset, double ZOffset)
		{
			lock (locker)
			{
				return dllWrapper.ToolOffset(context, (short)Identity, XOffset, YOffset, ZOffset);
			}
		}

		public bool ToolOffset(int Identity)
		{
			lock (locker)
			{
				return ToolOffset((short)Identity, 0.0, 0.0, 0.0);
			}
		}

		public bool PWMControl(int value)
		{
			lock (locker)
			{
				if (value == 0 || value == 1 || value == 4 || value == 5 || value == 6)
				{
					return PWMControl(value, 0.0, 0, 0, 0, 0, -1);
				}
				return false;
			}
		}

		public bool PWMControl(int value, int axis)
		{
			lock (locker)
			{
				if (value == 0 || value == 1 || value == 4 || value == 5 || value == 6)
				{
					return PWMControl(value, 0.0, 0, 0, 0, 0, axis);
				}
				return false;
			}
		}

		public bool PWMControl(int value, double direction_opOrGain, int table_startOrOffset, int table_stopOrLimit, int axisOrLinkAxis, int axis)
		{
			lock (locker)
			{
				switch (value)
				{
				case 2:
				case 3:
					return PWMControl(value, direction_opOrGain, table_startOrOffset, table_stopOrLimit, axisOrLinkAxis, 0, axis);
				case 8:
					return PWMControl(value, direction_opOrGain, table_startOrOffset, table_stopOrLimit, axisOrLinkAxis, axis, -1);
				default:
					return false;
				}
			}
		}

		public bool PWMControl(int value, double direction_opOrGain, int table_startOrOffset, int table_stopOrLimit, int axisOrLinkAxis)
		{
			lock (locker)
			{
				switch (value)
				{
				case 9:
					return PWMControl(value, direction_opOrGain, table_startOrOffset, table_stopOrLimit, 0, 0, axisOrLinkAxis);
				case 2:
				case 3:
					return PWMControl(value, direction_opOrGain, table_startOrOffset, table_stopOrLimit, axisOrLinkAxis, 0, -1);
				default:
					return false;
				}
			}
		}

		public bool PWMControl(int value, double direction_opOrGain, int table_startOrOffset, int table_stopOrLimit)
		{
			lock (locker)
			{
				if (value == 9)
				{
					return PWMControl(value, direction_opOrGain, table_startOrOffset, table_stopOrLimit, 0, 0, -1);
				}
				return false;
			}
		}

		public bool PWMControl(int value, int control_bits, int axis)
		{
			lock (locker)
			{
				if (value == 7)
				{
					return PWMControl(value, control_bits, 0, 0, 0, 0, axis);
				}
				return false;
			}
		}

		public bool PWMControl(int value, double p1, int p2, int p3, int p4, int p5, int Axis)
		{
			lock (locker)
			{
				if (value >= 0 && value <= 9)
				{
					return dllWrapper.PWMControl(context, (short)value, p1, (short)p2, (short)p3, (short)p4, (short)p5, (short)Axis);
				}
				return false;
			}
		}

		public bool SetMotion(int Axis, double Speed, double Accel, double Decel, double Jerk)
		{
			lock (locker)
			{
				return dllWrapper.SetMotion(context, (short)Axis, Speed, Accel, Decel, Jerk);
			}
		}

		public bool SetMotion(int Axis, double Speed)
		{
			lock (locker)
			{
				return SetMotion(Axis, Speed, 0.0, 0.0, 0.0);
			}
		}

		public bool SetMotion(int Axis, double Speed, double Accel)
		{
			lock (locker)
			{
				return SetMotion(Axis, Speed, Accel, 0.0, 0.0);
			}
		}

		public bool SetMotion(int Axis, double Speed, double Accel, double Decel)
		{
			lock (locker)
			{
				return SetMotion(Axis, Speed, Accel, Decel, 0.0);
			}
		}

		public bool SetMotionSP(int Axis, double forceSpeed, double startMoveSpeed, double endMoveSpeed, double forceAccel, double forceDecel, double forceJerk, double forceRamp, double forceDwell)
		{
			lock (locker)
			{
				return dllWrapper.SetMotionSP(context, (short)Axis, forceSpeed, startMoveSpeed, endMoveSpeed, forceAccel, forceDecel, forceJerk, forceRamp, forceDwell);
			}
		}

		public bool SetMotionSP(int Axis, double forceSpeed, double startMoveSpeed, double endMoveSpeed, double forceAccel, double forceDecel, double forceJerk, double forceRamp)
		{
			lock (locker)
			{
				return SetMotionSP(Axis, forceSpeed, startMoveSpeed, endMoveSpeed, forceAccel, forceDecel, forceJerk, forceRamp, 0.0);
			}
		}

		public bool SetMotionSP(int Axis, double forceSpeed, double startMoveSpeed, double endMoveSpeed, double forceAccel, double forceDecel, double forceJerk)
		{
			lock (locker)
			{
				return SetMotionSP(Axis, forceSpeed, startMoveSpeed, endMoveSpeed, forceAccel, forceDecel, forceJerk, 0.0, 0.0);
			}
		}

		public bool SetMotionSP(int Axis, double forceSpeed, double startMoveSpeed, double endMoveSpeed, double forceAccel, double forceDecel)
		{
			lock (locker)
			{
				return SetMotionSP(Axis, forceSpeed, startMoveSpeed, endMoveSpeed, forceAccel, forceDecel, 0.0, 0.0, 0.0);
			}
		}

		public bool SetMotionSP(int Axis, double forceSpeed, double startMoveSpeed, double endMoveSpeed, double forceAccel)
		{
			lock (locker)
			{
				return SetMotionSP(Axis, forceSpeed, startMoveSpeed, endMoveSpeed, forceAccel, 0.0, 0.0, 0.0, 0.0);
			}
		}

		public bool SetMotionSP(int Axis, double forceSpeed, double startMoveSpeed, double endMoveSpeed)
		{
			lock (locker)
			{
				return SetMotionSP(Axis, forceSpeed, startMoveSpeed, endMoveSpeed, 0.0, 0.0, 0.0, 0.0, 0.0);
			}
		}

		public bool SetMotionSP(int Axis, double forceSpeed, double startMoveSpeed)
		{
			lock (locker)
			{
				return SetMotionSP(Axis, forceSpeed, startMoveSpeed, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			}
		}

		public bool SetMotionSP(int Axis, double forceSpeed)
		{
			lock (locker)
			{
				return SetMotionSP(Axis, forceSpeed, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			}
		}

		public bool TextFileLoader(string SourceFile, int DestinationMemory, string DestinationFile, int Protocol, bool Compression, int CompressionLevel, bool Timeout, int TimeoutSeconds, int Direction)
		{
			lock (locker)
			{
				return dllWrapper.TextFileLoader(context, SourceFile, DestinationMemory, DestinationFile, Protocol, Compression, CompressionLevel, Timeout, TimeoutSeconds, Direction);
			}
		}

		public bool IsOpen(PortId portId)
		{
			lock (locker)
			{
				return dllWrapper.IsOpen(context, portId);
			}
		}

		public bool IsError()
		{
			lock (locker)
			{
				return dllWrapper.IsError(context);
			}
		}

		public bool ScopeOnOff(bool OnOff)
		{
			lock (locker)
			{
				return dllWrapper.ScopeOnOff(context, OnOff);
			}
		}

		public bool Scope(bool OnOff, long SamplePeriod, long tableStart, long tableEnd, string captureParams)
		{
			lock (locker)
			{
				return dllWrapper.Scope(context, OnOff, (int)SamplePeriod, (int)tableStart, (int)tableEnd, captureParams);
			}
		}

		public bool Trigger()
		{
			lock (locker)
			{
				return dllWrapper.Trigger(context);
			}
		}

		public bool ReadOp(int StartChannel, int StopChannel, out int Value)
		{
			lock (locker)
			{
				return dllWrapper.ReadOp(context, (short)StartChannel, (short)StopChannel, out Value);
			}
		}

		public bool PRMBLK_DefineAxis(int blockNumber, string variable)
		{
			lock (locker)
			{
				return dllWrapper.PRMBLK_DefineAxis(context, blockNumber, variable);
			}
		}

		public bool PRMBLK_DefineSystem(int blockNumber, string variable)
		{
			return dllWrapper.PRMBLK_DefineSystem(context, (short)blockNumber, variable);
		}

		public bool PRMBLK_DefineVr(int blockNumber, int variable)
		{
			lock (locker)
			{
				return dllWrapper.PRMBLK_DefineVr(context, (short)blockNumber, (short)variable);
			}
		}

		public bool PRMBLK_DefineTable(int blockNumber, int variable)
		{
			lock (locker)
			{
				return dllWrapper.PRMBLK_DefineTable(context, (short)blockNumber, (short)variable);
			}
		}

		public bool PRMBLK_DefineProgram(int blockNumber, string programName, long processNumber, string variable)
		{
			lock (locker)
			{
				return dllWrapper.PRMBLK_DefineProgram(context, (short)blockNumber, programName, (int)processNumber, variable);
			}
		}

		[DllImport("oleaut32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
		private static extern uint VariantClear(IntPtr pvarg);

		public bool PRMBLK_Append(int blockNumber, object variable)
		{
			lock (locker)
			{
				IntPtr intPtr = Marshal.AllocCoTaskMem(16);
				Marshal.GetNativeVariantForObject(variable, intPtr);
				bool result = dllWrapper.PRMBLK_Append(context, (short)blockNumber, intPtr);
				VariantClear(intPtr);
				Marshal.FreeCoTaskMem(intPtr);
				return result;
			}
		}

		public bool PRMBLK_Get(long blockNumber, bool all, out object variable)
		{
			lock (locker)
			{
				IntPtr intPtr = Marshal.AllocCoTaskMem(16);
				bool num = dllWrapper.PRMBLK_Get(context, (int)blockNumber, all, intPtr);
				if (num)
				{
					variable = Marshal.GetObjectForNativeVariant(intPtr);
				}
				else
				{
					variable = null;
				}
				VariantClear(intPtr);
				Marshal.FreeCoTaskMem(intPtr);
				return num;
			}
		}

		public bool PRMBLK_GetAxis(long blockNumber, long axis, bool all, out object variable)
		{
			lock (locker)
			{
				IntPtr intPtr = Marshal.AllocCoTaskMem(16);
				bool num = dllWrapper.PRMBLK_GetAxis(context, (int)blockNumber, (int)axis, all, intPtr);
				if (num)
				{
					variable = Marshal.GetObjectForNativeVariant(intPtr);
				}
				else
				{
					variable = null;
				}
				VariantClear(intPtr);
				Marshal.FreeCoTaskMem(intPtr);
				return num;
			}
		}

		public bool PRMBLK_Delete(int blockNumber)
		{
			lock (locker)
			{
				return dllWrapper.PRMBLK_Delete(context, (short)blockNumber);
			}
		}
	}
}
