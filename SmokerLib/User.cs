using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokerLib
{
    public class User
    {
        #region privates
        private static int _idCounter = 0;
        #endregion

        #region ctor
        public User(int id, string username, string firstName, string lastName, string email)
        {
            Id = Id;
            UserName = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public User(string username, string firstName, string lastName, string email)
        {
            Id = ++_idCounter;
            UserName = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        #endregion

        public int Id { get; private set; }

        public string UserName { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

    }
}
