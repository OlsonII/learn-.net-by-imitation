using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VeterinaryManager.API.Extensions;

public static class ServiceExtensions
{

    public static void ConfigureApiUtils(this IServiceCollection services)
    {
        services.AddHealthChecks();
        services.AddHttpContextAccessor();
        services.AddControllersWithViews(options =>
        {
            options.UseGeneralRoutePrefix("veterinary-manager/v{version:apiVersion}");
        });
        services.AddApiVersioning(options => options.ReportApiVersions = true);
        services.AddVersionedApiExplorer(options =>
        {
            // format "'v'major[.minor][-status]"  
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
    }
    
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            ConfigureSwaggerDoc(services, options);
            var basicSecurityScheme = ConfigureApiSecurityScheme(options);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { basicSecurityScheme, Array.Empty<string>() }
            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });
    }
    
    private static OpenApiSecurityScheme ConfigureApiSecurityScheme(SwaggerGenOptions options)
    {
        var basicSecurityScheme = new OpenApiSecurityScheme
        {
            Scheme = "api-key",
            Name = "api-key",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Description = "Put **_ONLY_** your authentications credentials on textbox below!",
            Reference = new OpenApiReference
            {
                Id = "api-key",
                Type = ReferenceType.SecurityScheme
            }
        };
        options.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
        return basicSecurityScheme;
    }

    private static void ConfigureSwaggerDoc(IServiceCollection services, SwaggerGenOptions options)
    {
        var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc($"v{description.ApiVersion}",
                new OpenApiInfo
                {
                    Title = "Veterinary Manager", 
                    Version = $"v{description.ApiVersion}",
                    Description = "Service developed to manage users"
                });
        }
    }

    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        
    }
}