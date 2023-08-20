using System;

namespace TrioMotion.TrioPC_NET
{
	public sealed class VR : MC_ARRAY<double>
	{
		protected override string name => "VR";

		internal VR(ArchitectureIndependentTrioPC dllWrapper, IntPtr context)
			: base(dllWrapper, context, 65536)
		{
		}

		protected override bool ReadValue(int Index, int Length)
		{
			bool result = true;
			while (Length > 0)
			{
				result = dllWrapper.GetVr(context, (short)Index, out data[Index++]);
				Length--;
			}
			return result;
		}

		protected override bool WriteValue(int Index, int Length)
		{
			bool result = true;
			while (Length > 0)
			{
				result = dllWrapper.SetVr(context, (short)Index, data[Index++]);
				Length--;
			}
			return result;
		}
	}
}
