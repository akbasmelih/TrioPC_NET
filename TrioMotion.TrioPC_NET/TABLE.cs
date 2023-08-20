using System;
using System.Runtime.InteropServices;

namespace TrioMotion.TrioPC_NET
{
	public sealed class TABLE : MC_ARRAY<double>
	{
		protected override string name => "TABLE";

		internal TABLE(ArchitectureIndependentTrioPC dllWrapper, IntPtr context)
			: base(dllWrapper, context, 512000)
		{
		}

		protected override bool ReadValue(int Index, int Length)
		{
			bool flag = false;
			GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
			try
			{
				return dllWrapper.GetTable(context, Index, Length, IntPtr.Add(gCHandle.AddrOfPinnedObject(), Index * 8));
			}
			finally
			{
				gCHandle.Free();
			}
		}

		protected override bool WriteValue(int Index, int Length)
		{
			bool flag = false;
			GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
			try
			{
				return dllWrapper.SetTable(context, Index, Length, IntPtr.Add(gCHandle.AddrOfPinnedObject(), Index * 8));
			}
			finally
			{
				gCHandle.Free();
			}
		}
	}
}
