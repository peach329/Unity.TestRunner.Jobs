﻿using TestWrapper.Workers;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace TestCase.Basic.Multiplication.Simd.Optimization
{
    [BurstCompile]
    public struct SimdMultiplicationOptimizationFloat2JobParallelFor : IJobParallelForExt<NativeArray<float2>, NativeArray<float2>, NativeArray<float2>>
    {
        [ReadOnly] private NativeArray<float2> _data1;
        [ReadOnly] private NativeArray<float2> _data2;
        [WriteOnly] private NativeArray<float2> _data3;

        public int DataSize { get; set; }

        public NativeArray<float2> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<float2> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<float2> Data3
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