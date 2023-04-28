using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PA200_webapp.DB;
using PA200_webapp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBDatabase>(
    builder.Configuration.GetSection("MongoDBDatabase"));

builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();
builder.Services.ConfigureMapper();
builder.Services.AddScoped<IAuthService, JWTService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddSwaggerGen();
var app = builder.Build();

var x = builder.Configuration.GetSection("MongoDBDatabase").Get<MongoDBDatabase>();
MongoDBInitializer.Initliaze(x);


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

