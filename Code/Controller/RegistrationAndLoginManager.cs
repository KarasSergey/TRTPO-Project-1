﻿using System.Collections.Generic;
using RSS_Reader.Model;

namespace RSS_Reader.Controller
{
    class RegistrationAndLoginManager
    {
        private readonly FileManager _profileFileManager = new FileManager();

        public List<string> GetUserNameList()
        {
            return _profileFileManager.GetUserNameList();
        }

        public User RegisterUser(string userName)
        {
            if (NameIsBusy(userName)) return null;
            var user = new User
            {
                Name = userName,
                Status = Status.Registered,
                Profile = _profileFileManager.GetUserProfile(Status.Anonym.ToString())
            };
            _profileFileManager.SaveUserProfile(user);
            return user;
        }

        public User LogIn(string userName)
        {
            return new User
            {
                Name = userName,
                Status = Status.Registered,
                Profile = _profileFileManager.GetUserProfile(userName)
            };
        }

        private bool NameIsBusy(string name)
        {
            return _profileFileManager.GetUserNameList().Exists(x => x.Equals(name));
        }
    }
}