﻿using TestRunner.Workers;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace TestCase.Basic.Operators.Inequality.Simd.Optimalization
{
    [BurstCompile]
    public struct SimdOperatorsInequalityOptimalizationBool4JobParallelFor : IJobParallelForExt<bool4, bool4, bool4>
    {
        [ReadOnly] private NativeArray<bool4> _data1;
        [ReadOnly] private NativeArray<bool4> _data2;
        [WriteOnly] private NativeArray<bool4> _data3;

        public int DataSize { get; set; }

        public NativeArray<bool4> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<bool4> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<bool4> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = _data1[i] != _data2[i];
        }

        public void Dispose()
        {
        }

        public void Init()
        {
        }
    }
}