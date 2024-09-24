using Backend.Data;
using Backend.Helpers;
using Backend.Hubs;
using Backend.Logics;
using Backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString).UseLazyLoadingProxies();
            });

            //Mapper service
            builder.Services.AddTransient<MapperHelperService>();

            //Repositories
            builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();
            builder.Services.AddTransient<ITaskListRepository, TaskListRepository>();
            builder.Services.AddTransient<ITaskItemRepository, TaskItemRepository>();
            builder.Services.AddTransient<IUserWorkLogRepository, UserWorkLogRepository>();
            builder.Services.AddTransient<IUserTaskListRepository, UserTaskListRepository>();
            builder.Services.AddTransient<IWorkflowItemRepository, WorkflowItemRepository>();
            builder.Services.AddTransient<IChangeLogRepository, ChangeLogRepository>();
            builder.Services.AddTransient<IUserConnectionRepository, UserConnectionRepository>();

            //Logics
            builder.Services.AddTransient<IAppUserLogic, AppUserLogic>();
            builder.Services.AddTransient<ITaskListLogic, TaskListLogic>();
            builder.Services.AddTransient<ITaskItemLogic, TaskItemLogic>();
            builder.Services.AddTransient<IUserWorkLogLogic, UserWorkLogLogic>();
            builder.Services.AddTransient<IUserTaskListLogic, UserTaskListLogic>();
            builder.Services.AddTransient<IWorkflowItemLogic, WorkflowItemLogic>();
            builder.Services.AddTransient<IChangeLogLogic, ChangeLogLogic>();

            //Identity
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            //Authentication
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "http://www.security.org",
                    ValidIssuer = "http://www.security.org",
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes("eeeeeeeeeeeeeeeeenagyonhosszutitkoskodhelye"))
                };
            });

            //Other
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("SpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("https://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed((x) => true)
                            .AllowCredentials();
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularOrigins",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            builder.Services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });

            var app = builder.Build();

            app.UseCors("SpecificOrigins");
            //app.UseCors("AllowAngularOrigins");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseCors("SpecificOrigins");
                //app.UseCors("AllowAngularOrigins");
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.MapHub<NotificationHub>("/notifications");

            app.Run();
        }
    }
}
