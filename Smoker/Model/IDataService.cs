using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using smoker.Model;

namespace Smoker.Model
{
    public interface IDataService
    {
        void SetupDB();

        void CreateSmokesTable();

        void InsertSmoke(DateTime time, Action<Exception> callback);

        void GetSmokeCount(Action<int, Exception> callback);

        void GetSmokes(Action<List<Smoke>, Exception> callback);

    }
}