﻿using TestCase.Basic.Subtraction.Simple;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Subtraction.Simple
{
    public sealed class TripleTypeShort1Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeShort1Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(short), DataConfig.DataShort1),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<short, short, short>.RunIJob(TestName, new SimpleSubtractionShortJob(),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<short, short, short>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionShortJobParallelFor(),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
                WorkerTests<short, short, short>.RunINonJob(TestName, new SimpleSubtractionShortNonJob(),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1)),
            };
        }
    }
}