using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokerLib
{
    public class Smokes
    {
        #region privates
        private static int _idCounter = 0;
        #endregion

        #region ctor
        public Smokes(int id, string username, string firstName, string lastName, string email)
        {

        }
        #endregion

        public int Id { get; private set; }

        public string UserName { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

    }

    public class Smoke
    {
        public DateTime Time { get; set; }

        public string Comment { get; set; }

        public bool DuringWork { get; set; }
        public bool DuringFreeTime { get; set; }
        public bool DuringNightLife { get; set; }
        public bool DuringIndoors { get; set; }
        public bool DuringAlcohol { get; set; }
    }
}
