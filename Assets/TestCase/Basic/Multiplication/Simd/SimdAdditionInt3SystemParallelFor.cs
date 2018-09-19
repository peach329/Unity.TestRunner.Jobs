﻿using TestWrapper.Workers;
using Unity.Mathematics;

namespace TestCase.Basic.Multiplication.Simd
{
    public struct SimdMultiplicationInt3SystemParallelFor : ISystemParallelForExt<int3[], int3[], int3[]>
    {
        private int3[] _data1;
        private int3[] _data2;
        private int3[] _data3;

        public int DataSize { get; set; }

        public int3[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public int3[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public int3[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = _data1[i] * _data2[i];
        }

        public void CustomSetUp()
        {
        }

        public void CustomCleanUp()
        {
        }
    }
}