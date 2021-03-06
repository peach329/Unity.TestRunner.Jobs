﻿using TestCase.Basic.Subtraction.Simple;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Provider.Containers;
using WorkSpace.Provider.Settings;

namespace WorkSpace.Tests.Basic.Subtraction.Simple
{
    internal sealed class Int1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int), TypeConfig.DataInt1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<int>, NativeArray<int>, NativeArray<int>>.Create<SimpleSubtractionIntJob>(
                    TestName(),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<int>, NativeArray<int>, NativeArray<int>>
                    .Create<SimpleSubtractionIntJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                        inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                        inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<int[], int[], int[]>.Create<SimpleSubtractionIntPlain>(
                    TestName(),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<int[], int[], int[]>.Create<SimpleSubtractionIntSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
            };
        }
    }
}