using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Reviews.Application.Helpers;
using Reviews.Application.Interfaces;
using Reviews.Application.Models;
using Reviews.Application.Services;
using Reviews.Application.Validations;
using Reviews.Domain;
using ReviewsWebApplication.Helpers;
using System.Text;
using System.Text.Json.Serialization;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers()
                        .AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            var basePath = AppContext.BaseDirectory;

            var xmlPath = Path.Combine(basePath, "ReviewsWebApplication.xml");

            options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

            options.SwaggerDoc("V1", new OpenApiInfo
            {
                Version = "V1",
                Title = "WebAPI",
                Description = "Reviews_WebAPI"
            });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Description = "Bearer Authentication with JWT Token",
                Type = SecuritySchemeType.Http
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                new OpenApiSecurityScheme {
                    Reference = new OpenApiReference {
                        Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }});

            options.UseInlineDefinitionsForEnums();
        });
        var connectionString = builder.Configuration.GetConnectionString("Review_Database");
        builder.Services.AddDbContext<DataBaseContext>(x => x.UseSqlServer(connectionString), ServiceLifetime.Scoped);

        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddScoped<IReviewService, ReviewService>();
        builder.Services.AddScoped<IRatingService, RatingService>();
        builder.Services.AddScoped<ILoginService, LoginService>();
        builder.Services.AddTransient<IHashService, HashService>();
        builder.Services.AddValidatorsFromAssemblyContaining<AddReviewDTOValidator>();

        var jwtOptions = builder.Configuration.GetSection("JwtOptions");
        builder.Services.Configure<JwtOptions>(jwtOptions);
        builder.Services.AddTransient<JwtProvider>();

        builder.Services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var jwtSettings = jwtOptions.Get<JwtOptions>();
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings!.Issuer,
                ValidAudience = jwtSettings!.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings!.SecretKey))
            };
        });
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/V1/swagger.json", "Reviews_WebAPI");
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        using (var serviceScope = app.Services.CreateScope())
        {
            var services = serviceScope.ServiceProvider;
            var loginService = services.GetRequiredService<ILoginService>();
            var configuration = services.GetRequiredService<IConfiguration>();
            var adminLoginDTO = new LoginDTO()
            {
                UserName = configuration["AdminSettings:Login"],
                Password = configuration["AdminSettings:Password"],
            };

            await loginService.AddLoginAsync(adminLoginDTO);
        }

        app.Run();
    }
}