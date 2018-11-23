﻿using System;
using System.Collections.Generic;

namespace MatchaLatte.Identity.App.Queries.Users
{
    public class UserDetail
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<RoleDetail> Roles { get; set; } = new List<RoleDetail>();
    }
}