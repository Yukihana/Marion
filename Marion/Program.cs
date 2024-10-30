using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Marion;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Swagger: Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();

        builder.Services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.DefaultApiVersion = new(2, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new QueryStringApiVersionReader("api-version"),
                new HeaderApiVersionReader("X-Version"),
                new MediaTypeApiVersionReader("X-Version"));
        });
        builder.Services.AddMvc();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            //app.UseSwagger();
            //app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}