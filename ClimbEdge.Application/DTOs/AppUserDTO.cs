using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.DTOs
{
    public record class RegisterRequestDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public RegisterRequestDTO() { }
    }

    public record class LoginRequestDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public record class ChangePasswordRequestDTO
    {
        public required string CurrentPassword { get; set; }
        public required string NewPassword { get; set; }
        public required string ConfirmPassword { get; set; }
    }

    public record class ForgotPasswordRequestDTO
    {
        public required string Email { get; set; }
    }

    public record class ResetPasswordRequestDTO
    {
        public required string Email { get; set; }
        public required string Token { get; set; }
        public required string NewPassword { get; set; }
        public required string ConfirmPassword { get; set; }
    }

    public record class RefreshTokenRequestDTO
    {
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }
    }

    public record class AuthResponseDTO
    {
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }
        public required UserInfoDTO User { get; set; }
    }
    public record class UserInfoDTO : BaseDTO
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool EmailConfirmed { get; set; }
        public List<string>? Roles { get; set; }
    }
}
