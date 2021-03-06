using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;
using TestWrapper.InputData;

namespace TestWrapper.Container.Multi
{
    internal class MultiContainer<TData, TConfig, T1, T2, T3, T4, T5, T6, T7> :
        MultiContainer<TData, TConfig, T1, T2, T3, T4, T5, T6>, IMultiContainer<T1, T2, T3, T4, T5, T6, T7>
        where TData : class, IInputData<T1, T2, T3, T4, T5, T6, T7>
        where TConfig : class, IDataConfig
    {
        public T7 Item7 => _dataProxyContainer7.Value;

        private readonly IDataProxyContainer<T7> _dataProxyContainer7;

        public MultiContainer(TData data, params TConfig[] config) : base(data, config)
        {
            _dataProxyContainer7 = new DataProxyContainer<T7, TConfig>(data.ItemArray7, GetCurrentConfig());
        }

        protected override int CurrentConfigCount()
        {
            return 7;
        }

        protected override void AppendToContainerInfoData(List<IContainerInfoData> containerInfoData)
        {
            base.AppendToContainerInfoData(containerInfoData);
            containerInfoData.Add(_dataProxyContainer7.Info());
        }

        public override void SetUp()
        {
            base.SetUp();
            _dataProxyContainer7.SetUp();
        }

        public override void CleanUp()
        {
            base.CleanUp();
            _dataProxyContainer7.CleanUp();
        }
    }
}