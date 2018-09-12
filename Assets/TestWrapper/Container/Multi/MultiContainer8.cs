using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;
using TestWrapper.InputData;

namespace TestWrapper.Container.Multi
{
    internal class MultiContainer<TData, TConfig, T1, T2, T3, T4, T5, T6, T7, T8> :
        MultiContainer<TData, TConfig, T1, T2, T3, T4, T5, T6, T7>, IMultiContainer<T1, T2, T3, T4, T5, T6, T7, T8>
        where TData : class, IInputData<T1, T2, T3, T4, T5, T6, T7, T8>
        where TConfig : class, IDataConfig
    {
        public T8 Item8 => _dataProxyContainer8.Value;

        private readonly IDataProxyContainer<T8> _dataProxyContainer8;

        public MultiContainer(TData data, params TConfig[] config) : base(data, config)
        {
            _dataProxyContainer8 = new DataProxyContainer<T8, TConfig>(data.ItemArray8, GetCurrentConfig());
        }

        protected override int CurrentConfigCount()
        {
            return 8;
        }

        protected override void AppendToContainerInfoData(List<IContainerInfoData> containerInfoData)
        {
            base.AppendToContainerInfoData(containerInfoData);
            containerInfoData.Add(_dataProxyContainer8.Info());
        }

        public override void SetUp()
        {
            base.SetUp();
            _dataProxyContainer8.SetUp();
        }

        public override void CleanUp()
        {
            base.CleanUp();
            _dataProxyContainer8.CleanUp();
        }
    }
}