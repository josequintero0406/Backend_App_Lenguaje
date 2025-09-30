using Api.Inyecciones;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCors", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AgregarDependencias(configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer("Bearer", options =>
//    {
//        options.Authority = "https://dev-il1rfxnypnw64cnu.us.auth0.com";
//        options.Audience = "https://localhost:7187/swagger/index.html/api";
//    });

builder.Services.AddAuthorization();

// Add authenticator
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-il1rfxnypnw64cnu.us.auth0.com";
    options.Audience = "https://localhost:7187";
    //options.Events = new JwtBearerEvents()
    //{
    //    OnAuthenticationFailed = result =>
    //    {
    //        result.NoResult();
    //        result.Response.StatusCode = 401;
    //        result.Response.ContentType = "text/plain";
    //        return result.Response.WriteAsync(result.Exception.ToString());
    //    },
    //};
});

//builder.Services.AddAuthorization(options =>
//{
//    // By default, all incoming requests will be authorized according to the default policy.
//    options.FallbackPolicy = options.DefaultPolicy;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("PoliticaCors");

//app.MapGet("/", context =>
//{
//    context.Response.Redirect("/swagger");
//    return Task.CompletedTask;
//});

app.MapGet("/api/usuario", [Authorize] () => "Autorizado");

app.Run();
