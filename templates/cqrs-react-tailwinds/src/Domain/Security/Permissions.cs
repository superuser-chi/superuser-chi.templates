using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Security
{
    public static class Permissions
    {
        public static class Audit
        {
            public const string View = "Permissions.Audit.View";
        }
        public static class Forecast
        {
            public const string View = "Permissions.Audit.View";
        }
        public static class Role
        {
            public const string List = "Permissions.Role.List";
            public const string ListClaims = "Permissions.Role.ListClaims";
            public const string View = "Permissions.Role.View";
            public const string ViewRoleClaim = "Permissions.Role.ViewRoleClaim";
            public const string AddClaimToRole = "Permissions.Role.AddClaimToRole";
            public const string RemoveClaimFromRole = "Permissions.Role.RemoveClaimFromRole";
        }

        public static class Users
        {
            public const string View = "Permissions.Users.View";
            public const string ViewOther = "Permissions.Users.ViewOther";
            public const string Create = "Permissions.Users.Create";
            public const string ChangeRole = "Permissions.Users.ChangeRole";
            public const string Edit = "Permissions.Users.Edit";
            public const string Delete = "Permissions.Users.Delete";
            public const string LockOrUnlock = "Permissions.Users.LockOrUnlock";
            public const string List = "Permissions.Users.List";
        }
        
    }
}