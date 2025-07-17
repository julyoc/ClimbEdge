using Asp.Versioning;
using ClimbEdge.Application.Commands.AppUserCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Queries.AppUserQuery;
using ClimbEdge.Application.Queries.UserProfileQuery;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities;
using ClimbEdge.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClimbEdge.API.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ClimbEdgeContext _context;
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            IConfiguration configuration,
            ClimbEdgeContext context,
            IMediator mediator,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Registra un nuevo usuario
        /// </summary>
        /// <param name="request">Datos de registro</param>
        /// <returns>Respuesta con token JWT</returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDTO>> Register([FromBody] RegisterRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _mediator.Send(new RegisterAppCommand(request));

                // Generar token JWT
                var token = await GenerateJwtToken(user);
                var refreshToken = GenerateRefreshToken();

                // Guardar refresh token
                user.SecurityStamp = refreshToken;
                await _mediator.Send(new UpdateAppUserCommand(user));

                _logger.LogInformation("Usuario registrado exitosamente: {Email}", request.Email);

                return Ok(new AuthResponseDTO
                {
                    Token = token,
                    RefreshToken = refreshToken,
                    User = Mapper.Map<AppUser, UserInfoDTO>(user)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error durante el registro del usuario: {Email}", request.Email);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Inicia sesión de usuario
        /// </summary>
        /// <param name="request">Datos de inicio de sesión</param>
        /// <returns>Respuesta con token JWT</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] LoginRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _mediator.Send(new FindByEmailUserQuery(request.Email));
                if (user == null)
                    return Unauthorized(new { Message = "Credenciales inválidas" });
                if (user.IsLocked)
                    return Unauthorized(new { Message = "Cuenta bloqueada temporalmente" });

                var result = await _mediator.Send(new LogInWithPasswordQuery(user, request.Password));

                if (result.IsLockedOut)
                    return Unauthorized(new { Message = "Cuenta bloqueada temporalmente" });

                if (!result.Succeeded)
                    return Unauthorized(new { Message = "Credenciales inválidas" });

                // Obtener perfil del usuario
                var userProfile = await _mediator.Send(new FindUserProfileWithUserIdQuery(user.Id));

                // Generar tokens
                var token = await GenerateJwtToken(user);
                var refreshToken = GenerateRefreshToken();

                // Guardar refresh token
                user.SecurityStamp = refreshToken;
                await _mediator.Send(new UpdateAppUserCommand(user));

                Response.Cookies.Append("access_token", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(7)
                });

                _logger.LogInformation("Usuario inició sesión exitosamente: {Email}", request.Email);

                return Ok(new AuthResponseDTO
                {
                    Token = token,
                    RefreshToken = refreshToken,
                    User = new UserInfoDTO
                    {
                        Uid = user.Uid,
                        Email = user.Email,
                        UserName = user.UserName,
                        FirstName = userProfile?.FirstName,
                        LastName = userProfile?.LastName,
                        EmailConfirmed = user.EmailConfirmed,
                        IsLocked = user.IsLocked
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error durante el inicio de sesión: {Email}", request.Email);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Cambia la contraseña del usuario actual
        /// </summary>
        /// <param name="request">Datos para cambio de contraseña</param>
        /// <returns>Resultado del cambio</returns>
        [HttpPost("change-password")]
        [Authorize]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _mediator.Send(new FindUserByPrincipalClaimQuery(User));
                if (user == null)
                    return Unauthorized();

                if (request.NewPassword != request.ConfirmPassword)
                    return BadRequest(new { Message = "Las contraseñas no coinciden" });

                var result = await _mediator.Send(new ChangePasswordCommand(user, request.CurrentPassword, request.NewPassword));
                if (!result.Succeeded)
                {
                    return BadRequest(new { Message = "Error al cambiar contraseña", Errors = result.Errors });
                }

                _logger.LogInformation("Contraseña cambiada exitosamente para el usuario: {Email}", user.Email);

                return Ok(new { Message = "Contraseña cambiada exitosamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cambiar contraseña para el usuario: {UserId}", User.Identity?.Name);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Solicita restablecimiento de contraseña
        /// </summary>
        /// <param name="request">Email del usuario</param>
        /// <returns>Resultado de la solicitud</returns>
        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _mediator.Send(new FindByEmailUserQuery(request.Email));
                if (user == null)
                {
                    // No revelar si el usuario existe o no por seguridad
                    return Ok(new { Message = "Si el email existe, se enviará un enlace de restablecimiento" });
                }

                var token = await _mediator.Send(new GenPasswordResetTokenCommand(user));

                // Aquí deberías enviar el email con el token
                // Por ahora solo loggeamos para desarrollo
                _logger.LogInformation("Token de restablecimiento generado para {Email}: {Token}", request.Email, token);

                return Ok(new { Message = "Si el email existe, se enviará un enlace de restablecimiento" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al solicitar restablecimiento de contraseña: {Email}", request.Email);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Restablece la contraseña con token
        /// </summary>
        /// <param name="request">Datos para restablecer contraseña</param>
        /// <returns>Resultado del restablecimiento</returns>
        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _mediator.Send(new FindByEmailUserQuery(request.Email));
                if (user == null)
                    return BadRequest(new { Message = "Token inválido" });

                var result = await _mediator.Send(new ResetPasswordCommand(user, request.Token, request.NewPassword));
                if (!result.Succeeded)
                {
                    return BadRequest(new { Message = "Error al restablecer contraseña", Errors = result.Errors });
                }

                _logger.LogInformation("Contraseña restablecida exitosamente para el usuario: {Email}", request.Email);

                return Ok(new { Message = "Contraseña restablecida exitosamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al restablecer contraseña para: {Email}", request.Email);
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Renueva el token JWT usando el refresh token
        /// </summary>
        /// <param name="request">Refresh token</param>
        /// <returns>Nuevo token JWT</returns>
        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDTO>> RefreshToken([FromBody] RefreshTokenRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var principal = GetPrincipalFromExpiredToken(request.Token);
                if (principal == null)
                    return Unauthorized(new { Message = "Token inválido" });

                var email = principal.FindFirst(ClaimTypes.Email)?.Value;
                if (string.IsNullOrEmpty(email))
                    return Unauthorized(new { Message = "Token inválido" });

                var user = await _mediator.Send(new FindByEmailUserQuery(email));
                if (user == null || user.SecurityStamp != request.RefreshToken)
                    return Unauthorized(new { Message = "Refresh token inválido" });

                var newToken = await GenerateJwtToken(user);
                var newRefreshToken = GenerateRefreshToken();

                user.SecurityStamp = newRefreshToken;
                await _userManager.UpdateAsync(user);

                var userProfile = await _mediator.Send(new FindUserProfileWithUserIdQuery(user.Id));

                return Ok(new AuthResponseDTO
                {
                    Token = newToken,
                    RefreshToken = newRefreshToken,
                    User = new UserInfoDTO
                    {
                        Uid = user.Uid,
                        Email = user.Email,
                        UserName = user.UserName,
                        FirstName = userProfile?.FirstName,
                        LastName = userProfile?.LastName,
                        EmailConfirmed = user.EmailConfirmed
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al renovar token");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Cierra sesión del usuario actual
        /// </summary>
        /// <returns>Resultado del cierre de sesión</returns>
        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    // Invalidar refresh token
                    await _mediator.Send(new LogOutCommand(user));

                    Response.Cookies.Delete("access_token");

                    _logger.LogInformation("Usuario cerró sesión exitosamente: {Email}", user.Email);
                }

                return Ok(new { Message = "Sesión cerrada exitosamente" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cerrar sesión");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        /// <summary>
        /// Obtiene información del usuario actual
        /// </summary>
        /// <returns>Información del usuario</returns>
        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserInfoDTO>> GetCurrentUser()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return Unauthorized();

                var userProfile = await _mediator.Send(new FindUserProfileWithUserIdQuery(user.Id));

                var roles = await _userManager.GetRolesAsync(user);

                return Ok(new UserInfoDTO
                {
                    Uid = user.Uid,
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = userProfile?.FirstName,
                    LastName = userProfile?.LastName,
                    EmailConfirmed = user.EmailConfirmed,
                    Roles = roles.ToList()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener información del usuario actual");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }

        #region Private Methods

        private async Task<string> GenerateJwtToken(AppUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email!),
                new(ClaimTypes.Name, user.UserName!),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false, // No validar expiración para refresh
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = key,
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                if (validatedToken is not JwtSecurityToken jwtToken ||
                    !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return null;
                }
                return principal;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
