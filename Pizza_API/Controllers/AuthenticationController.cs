using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pizza_Core.DTOs;

using Pizza_API.Helpers;
using Pizza_Core.Models;
using Pizza_API.Repositories;

namespace Pizza_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepository<User> _repository; // Contexte de la base de données
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings; // Paramètres de configuration Appsettings

        public AuthenticationController(IRepository<User> repository, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerDTO)
        {
            if (await _repository.Get(u => u.Email == registerDTO.Email) != null)
                return BadRequest("A user with this email already exists");

            registerDTO.Password = PasswordCrypter.Encrypt(registerDTO.Password, _appSettings.SecretKey);

            var user = _mapper.Map<User>(registerDTO);

            await _repository.Add(user);

            var userDTO = _mapper.Map<UserDTO>(user);

            if (await _repository.Get(u => u.Id == user.Id) != null)
                return Ok(new
                {
                    Message = "Utilisateur créé",
                    User = registerDTO
                });
            return BadRequest("Issue creating the user");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestDTO login)
        {
            login.Password = PasswordCrypter.Encrypt(login.Password, _appSettings.SecretKey);

            var user = await _repository.Get(u => u.Email == login.Email && u.Password == login.Password);

            if (user == null) return BadRequest("Invalid authentication");

            var role = user.IsAdmin ? Constants.RoleAdmin : Constants.RoleUser;

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role),
            };

            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.SecretKey!)), SecurityAlgorithms.HmacSha256);

            // Crée le JWT
            JwtSecurityToken jwt = new JwtSecurityToken(
               claims: claims, // Liste des revendications (claims) associées à l'utilisateur
                issuer: _appSettings.ValidIssuer, // L'émetteur du token, utilisé pour la validation du token côté serveur
                audience: _appSettings.ValidAudience, // Le public cible du token, spécifie à qui le token est destiné
                signingCredentials: signingCredentials, // Les credentials utilisées pour signer le token
                expires: DateTime.Now.AddHours(2)); // La durée de validité du token, ici fixée à 2 heures après l'émission. Expire après 2 heures

            // Génère le token à partir du JWT
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Retourne le token et des informations sur l'utilisateur
            return Ok(new
            {
                Token = token,
                Message = "Authentication Succefull !!",
                User = user
            });

        }
    }
}
