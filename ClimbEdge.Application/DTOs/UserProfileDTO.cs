using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.DTOs
{
    public class CreateUserProfileDTO
    {
        public string UserId { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Website { get; set; }
        public string? Location { get; set; }
        public string Country { get; set; } = Constants.DefaultCountry;
        public string TimeZone { get; set; } = Constants.DefaultTimeZone;
        public string PreferredLanguage { get; set; } = Constants.DefaultLanguage;
        public bool IsPublic { get; set; } = true;
        public bool EmailNotifications { get; set; } = true;
        public bool PushNotifications { get; set; } = true;
    }
    public class UpdateUserProfileDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Website { get; set; }
        public string? Location { get; set; }
        public string? Country { get; set; } = Constants.DefaultCountry;
        public string? TimeZone { get; set; } = Constants.DefaultTimeZone;
        public string? PreferredLanguage { get; set; } = Constants.DefaultLanguage;
        public bool IsPublic { get; set; } = true;
        public bool EmailNotifications { get; set; } = true;
        public bool PushNotifications { get; set; } = true;
    }
    public class GetUserProfileDTO : BaseDTO
    {
        public long UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Website { get; set; }
        public string? Location { get; set; }
        public string Country { get; set; } = Constants.DefaultCountry;
        public string TimeZone { get; set; } = Constants.DefaultTimeZone;
        public string PreferredLanguage { get; set; } = Constants.DefaultLanguage;
        public bool IsPublic { get; set; } = true;
        public bool EmailNotifications { get; set; } = true;
        public bool PushNotifications { get; set; } = true;
        public string FullName { get; set; } = string.Empty;
        public int? Age { get; set; }
        public string? Initials { get; set; }
        public ClimbUserProfileData? ClimbData { get; set; }
    }
}
