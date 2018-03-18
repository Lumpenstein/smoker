using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using smoker.Model;
using Smoker.Model;

namespace Smoker.Design
{
    public class DesignDataService : IDataService
    {
        public void CreateSmokesTable(Action<Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void CreateSmokesTable()
        {
            throw new NotImplementedException();
        }

        public void GetSmokeCount(Action<int, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetSmokeCount(Action<System.Collections.Generic.List<Smoke>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetSmokes(Action<List<Smoke>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void InsertSmoke(DateTime time, Action<Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void SetupDB(Action<Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void SetupDB()
        {
            throw new NotImplementedException();
        }
    }
}