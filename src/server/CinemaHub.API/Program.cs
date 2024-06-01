
using CinemaHub.API.Implementation;
using CinemaHub.API.Interfaces;
using CinemaHub.Domain.Context;
using CinemaHub.Domain.Entities;
using CinemaHub.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CinemaHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();/*.AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });*/

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient", builder =>
                {
                    builder.WithOrigins("https://localhost:7035")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cinema Hub", Version = "v1" });
            });
            builder.Services.AddDbContext<CinemaContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                    , options => options.EnableRetryOnFailure());
            });
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            builder.Services.AddScoped<IFileService, FileService>();
            var app = builder.Build();
            app.UseCors("AllowBlazorClient");
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "img");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(dir),
                RequestPath = "/images"
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           
            app.UseHttpsRedirection();

            app.UseAuthorization();

            
            app.MapControllers();

            app.Run();
        }
    }
}
