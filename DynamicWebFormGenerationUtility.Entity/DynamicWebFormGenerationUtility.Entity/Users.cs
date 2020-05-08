using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicWebFormGenerationUtility.Entity
{
    public class Users
    {
        public int UserID { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsOverrideAuth { get; set; }
        public string AuthKey { get; set; }
        public bool IsLogout { get; set; }
        public Int64 RoleID { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string HostName { get; set; }
        public string IpAddr { get; set; }
        public string ApplicantData { get; set; }
        public string UserType { get; set; }
        public string ProjectId { get; set; }
        public string RoleName { get; set; }
        public string CollegeIds { get; set; }
        public string ProgramIds { get; set; }
        public string UserImagePath { get; set; }

        public bool IsInsert { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }

        public bool IsApprove { get; set; }
        public bool IsReject { get; set; }
        public bool Custom1 { get; set; }
        public bool Custom2 { get; set; }
        public bool Custom3 { get; set; }
        public bool Custom4 { get; set; }
    }
}
