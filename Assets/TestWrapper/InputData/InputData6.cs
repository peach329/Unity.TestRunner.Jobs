using System;

namespace TestWrapper.InputData
{
    internal class InputData<T1, T2, T3, T4, T5, T6> : InputData<T1, T2, T3, T4, T5>, IInputData<T1, T2, T3, T4, T5, T6>
    {
        public Array ItemArray6 { get; }

        public InputData(Array itemArray1, Array itemArray2, Array itemArray3, Array itemArray4, Array itemArray5,
            Array itemArray6) : base(itemArray1, itemArray2, itemArray3, itemArray4, itemArray5)
        {
            ItemArray6 = itemArray6;
        }
    }
}