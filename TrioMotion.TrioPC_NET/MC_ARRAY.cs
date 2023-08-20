using System;

namespace TrioMotion.TrioPC_NET
{
	public abstract class MC_ARRAY<T>
	{
		private object locker = new object();

		private bool[] dirty;

		private int dirtyCount;

		private int GetTableFlag;

		internal ArchitectureIndependentTrioPC dllWrapper;

		protected IntPtr context = IntPtr.Zero;

		protected T[] data;

		public bool AutoCommit;

		protected abstract string name
		{
			get;
		}

		public T this[int index]
		{
			get
			{
				return Get(index);
			}
			set
			{
				Set(index, value);
			}
		}

		internal MC_ARRAY(ArchitectureIndependentTrioPC dllWrapper, IntPtr context, int dataLength)
		{
			this.dllWrapper = dllWrapper;
			this.context = context;
			data = new T[dataLength];
			dirty = new bool[dataLength];
			dirtyCount = 0;
		}

		protected abstract bool ReadValue(int Index, int Length);

		protected abstract bool WriteValue(int Index, int Length);

		public T Get(int Index)
		{
			return Get(Index, 1)[0];
		}

		public T[] Get(int Index, int Length)
		{
			lock (locker)
			{
				if (GetTableFlag == 0)
				{
					GetTableFlag++;
					dirtyCount = 0;
				}
				Commit();
				if (!ReadValue(Index, Length))
				{
					throw new InvalidOperationException($"Error accessing {name}({Index}..{Index + Length - 1})");
				}
				if (Index == 0 && Length == data.Length)
				{
					return data;
				}
				T[] array = new T[Length];
				Array.Copy(data, Index, array, 0, Length);
				return array;
			}
		}

		public void Set(int Index, T Value, bool AutoCommit = false)
		{
			T[] values = new T[1]
			{
				Value
			};
			Set(Index, values, 0, 1, AutoCommit);
		}

		public void Set(int Index, T[] Values, int Offset, int Length, bool AutoCommit = false)
		{
			lock (locker)
			{
				Array.Copy(Values, Offset, data, Index, Length);
				while (Length > 0)
				{
					if (!dirty[Index])
					{
						dirty[Index] = true;
						dirtyCount++;
					}
					Index++;
					Length--;
				}
				if (AutoCommit || this.AutoCommit)
				{
					Commit();
				}
			}
		}

		public void Commit()
		{
			lock (locker)
			{
				int i = 0;
				while (dirtyCount > 0)
				{
					for (; !dirty[i]; i++)
					{
					}
					int j;
					for (j = 0; dirty[i + j]; j++)
					{
						dirty[i + j] = false;
					}
					if (!WriteValue(i, j))
					{
						throw new InvalidOperationException($"Error accessing {name}({i}..{i + j - 1})");
					}
					dirtyCount -= j;
				}
			}
		}
	}
}
