using System;

namespace Smoker.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}