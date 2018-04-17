﻿using System.Collections.Generic;

namespace Manager.ViewModels.Users
{
    public class CreateUserQuery
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<Role> Roles { get; set; }

        public class Role
        {
            public int RoleId { get; set; }
            public string Name { get; set; }
            public bool IsChecked { get; set; }
        }
    }
}