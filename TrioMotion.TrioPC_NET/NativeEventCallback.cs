using System;

namespace TrioMotion.TrioPC_NET
{
	internal delegate bool NativeEventCallback(IntPtr eventContext, int eventType, int integerData, IntPtr stringData);
}
