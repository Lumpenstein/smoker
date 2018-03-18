using System;
using System.Threading.Tasks;

namespace Smoker.Model
{
    public interface IDataService
    {
        void SetupDB();

        void CreateSmokesTable();

        void InsertSmoke(DateTime time);

        void GetSmokeCount();

        void GetData(Action<DataItem, Exception> callback);
    }
}