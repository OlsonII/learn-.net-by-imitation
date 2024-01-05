using VeterinaryManager.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureApiUtils();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(swaggerOptions =>
    {
        swaggerOptions.RouteTemplate = "veterinary-manager/swagger/{documentname}/swagger.json";
    });
    app.UseSwaggerUI(swaggerUiOptions =>
    {
        swaggerUiOptions.SwaggerEndpoint("/veterinary-manager/swagger/v1/swagger.json", "v1");
        swaggerUiOptions.RoutePrefix = "veterinary-manager/swagger";
    });
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.MapHealthChecks("/ping");
app.MapControllers();
app.Run();

// TODO: Configure Dependency Injection
// TODO: Complete the program