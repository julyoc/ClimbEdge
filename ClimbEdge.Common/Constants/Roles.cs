using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Common.Constants
{
    public static class Roles
    {
        public const string User = "User";
        public const string Admin = "Admin";
        public const string SuperAdmin = "SuperAdmin";
        public const string Moderator = "Moderator";
        public const string Guest = "Guest";
        public const string Support = "Support";
        public const string Developer = "Developer";
        public const string Tester = "Tester";
        public const string Manager = "Manager";
        public const string Climb = "Climb";
        public const string Mountaingeer = "";
        public const string ContentCreator = "ContentCreator";
        public const string ContentEditor = "ContentEditor";
        public const string ContentViewer = "ContentViewer";
        public const string AnalyticsViewer = "AnalyticsViewer";
        public const string SystemUser = "SystemUser";

        public static IReadOnlyList<string> roles = new List<string> { User, Admin, SuperAdmin, Moderator, Guest, Support,
                                                                       Developer, Tester, Manager, Climb, Mountaingeer,
                                                                       ContentCreator, ContentEditor, ContentViewer,
                                                                       AnalyticsViewer, SystemUser };
    }
}
