using Library.Application.Interfaces.Authentication;
using Library.Application.Interfaces.Persistance;
using Library.Application.Interfaces.Services;
using Library.Infrastructure.Authentication;
using Library.Infrastructure.Persistance.BookRepo;
using Library.Infrastructure.Persistance.LibraryRepo;
using Library.Infrastructure.Persistance.UserRepo;
using Library.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
			var JwtSettings = new JwtSettings();
			configuration.Bind("JwtSettings", JwtSettings);
			services.AddSingleton(Options.Create(JwtSettings));
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(o =>
			{
				var Key = Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]);
				o.SaveToken = true;
				o.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = configuration["JwtSettings:Issuer"],
					ValidAudience = configuration["JwtSettings:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Key)
				};
			});
			services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();
            return services;
        }
    }
}
