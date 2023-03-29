using Microsoft.EntityFrameworkCore;
using PA200_webapp.DB;

var builder = WebApplication.CreateBuilder(args);

var x = builder.Configuration.GetConnectionString("NetworkContext");
builder.Services.AddDbContext<SocialNetworkContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("NetworkContext")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SocialNetworkContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}


app.MapGet("/", () => "Hello World!");

app.Run();
