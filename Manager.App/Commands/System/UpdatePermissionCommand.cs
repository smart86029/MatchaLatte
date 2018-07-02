﻿namespace Manager.App.Commands.System
{
    public class UpdatePermissionCommand : ICommand
    {
        public int Permission { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}