﻿using TestWrapper.Workers;
using Unity.Mathematics;

namespace TestCase.Basic.Subtraction.Simd
{
    public struct SimdSubtractionInt2Plain : IPlainExt<int2[], int2[], int2[]>
    {
        private int2[] _data1;
        private int2[] _data2;
        private int2[] _data3;

        public int DataSize { get; set; }

        public int2[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public int2[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public int2[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = _data1[i] - _data2[i];
            }
        }

        public void CustomSetUp()
        {
        }

        public void CustomCleanUp()
        {
        }
    }
}