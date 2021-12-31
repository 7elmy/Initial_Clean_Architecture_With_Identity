using Initial_Clean_Architecture_With_Identity.API.Extensions;
using Initial_Clean_Architecture_With_Identity.Application.Seeds;
using Initial_Clean_Architecture_With_Identity.Application.Settings;
using Initial_Clean_Architecture_With_Identity.Data.Contexts;
using Initial_Clean_Architecture_With_Identity.Domain.Entities;
using Initial_Clean_Architecture_With_Identity.Helpers.ServicesInstallers.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices();

var app = builder.Build();

ConfigureDatabase();

ConfigurePipeLine();

void ConfigureServices()
{
    builder.Services.InstallServices(builder.Configuration, Assembly.GetExecutingAssembly());
    ConfigureOutServices();
}

void ConfigureOutServices()
{
    var otherAssemblies = new List<Initial_Clean_Architecture_With_Identity.Helpers.Interfaces.IStartup>()
    {
        new Initial_Clean_Architecture_With_Identity.Application.Startup(),
        new Initial_Clean_Architecture_With_Identity.Data.Startup(),
    };
    otherAssemblies.ForEach(x => x.ConfigureServices(builder.Services));
}

void ConfigurePipeLine()
{
    if (app.Environment.IsDevelopment())
    {
        ConfigureSwagger();
    }
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseExceptions();
    app.MapControllers();
    app.Run();
}

void ConfigureDatabase()
{
    using var scope = app.Services.CreateScope();

    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.Migrate();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    SeedData(userManager, roleManager);
}

void ConfigureSwagger()
{
    var swaggerSettings = new SwaggerSettings();
    builder.Configuration.GetSection(swaggerSettings.GetType().Name).Bind(swaggerSettings);

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint(swaggerSettings.UIEndpoint, swaggerSettings.Title));
}


void SeedData(UserManager<AppUser> userManager,
   RoleManager<IdentityRole> roleManager)
{
    RolesSeed.Seed(roleManager);
    SeedUsers(userManager);
}

void SeedUsers(UserManager<AppUser> userManager)
{
    var superAdminSettings = new SuperAdminSettings();
    builder.Configuration.GetSection(nameof(SuperAdminSettings)).Bind(superAdminSettings);
    UsersSeed.Seed(userManager, superAdminSettings);
}