﻿using System;

namespace MatchaLatte.Identity.App.ViewModels.Permission
{
    public class UpdatePermissionOption
    {
        public Guid PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}