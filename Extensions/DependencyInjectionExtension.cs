using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.Text;
using Microsoft.OpenApi.Models;
using Pizza_API.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace Pizza_API.Extensions
{
    public static class DependencyInjectionExtension
    {

        public static void InjectDependencies(this WebApplicationBuilder builder)
        {
            builder.AddSwagger();
            builder.AddAuthentication();
        }

        private static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer(); // Active l'explorateur d'API
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizza API", Description = "API pour la gestion de pizzas !!!" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Entête d'autorisation JWT utilisant le schéma Bearer",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.Http
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }});
            });
        }

        public static void AddAuthentication(this WebApplicationBuilder builder)
        {
            var appSettingSection = builder.Configuration.GetSection(nameof(AppSettings));
            builder.Services.Configure<AppSettings>(appSettingSection); // Lie les paramètres de configuration
            AppSettings appSettings = appSettingSection.Get<AppSettings>(); // Récupère les paramètres de configuration

            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey); // Convertit la clé secrète pour la signature

            // Configure l'authentification JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true; // Sauvegarde le token dans le contexte de l'authentification
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true, // Valide la clé de signature de l'émetteur
                        IssuerSigningKey = new SymmetricSecurityKey(key), // Définit la clé de signature
                        ValidateAudience = true, // Valide le public cible du token
                        ValidAudience = appSettings.ValidAudience, // Définit le public cible valide
                        ValidateIssuer = true, // Valide l'émetteur du token
                        ValidIssuer = appSettings.ValidIssuer, // Définit l'émetteur valide
                        ValidateLifetime = true, // Valide la durée de vie du token
                        ClockSkew = TimeSpan.Zero // Ajuste la tolérance de l'horloge pour la validation du token
                    };
                });

            // Configure les politiques d'autorisation basées sur les rôles
            builder.Services.AddAuthorization(options =>
            {
                // Politique pour les administrateurs
                options.AddPolicy(Constants.PolicyAdmin, policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, Constants.RoleAdmin);
                });

                // Politique pour les utilisateurs standards
                options.AddPolicy(Constants.PolicyUser, policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, Constants.RoleUser);
                });
            });
        }
    }
}
