﻿using TestCase.Basic.Multiplication.Simd.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Multiplication.Simd.Optimalization
{
    public sealed class TripleUInt2Test : SampleGenerator
    {
        private const string TestName = nameof(TripleUInt2Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint2), DataConfig.DataUInt2),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<uint2, uint2, uint2>.RunIJob(TestName, new SimdMultiplicationOptimalizationUInt2Job(),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint2, uint2, uint2>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationOptimalizationUInt2JobParallelFor(),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}