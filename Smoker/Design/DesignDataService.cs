using System;
using System.Threading.Tasks;
using Smoker.Model;

namespace Smoker.Design
{
    public class DesignDataService : IDataService
    {
        public void SetupDB()
        {
            throw new NotImplementedException();
        }

        public void CreateSmokesTable()
        {
            throw new NotImplementedException();
        }

        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }

        public void InsertSmoke(DateTime time)
        {
            throw new NotImplementedException();
        }

        public void GetSmokeCount()
        {
            throw new NotImplementedException();
        }
    }
}