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
var swaggerSettings = new SwaggerSettings();
builder.Configuration.GetSection(swaggerSettings.GetType().Name).Bind(swaggerSettings);

Services();

var app = builder.Build();

PipeLine();

void Services()
{
    builder.Services.InstallServices(builder.Configuration, Assembly.GetExecutingAssembly());
}

void PipeLine()
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    using (var scope = app.Services.CreateScope())
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        UpdateDatabase(dataContext);

        SetupSwagger(app);

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        SeedData(userManager, roleManager);
    }




    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.UseExceptions();
    app.MapControllers();

    app.Run();
}

void SetupSwagger(IApplicationBuilder app)
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint(swaggerSettings.UIEndpoint, swaggerSettings.Title));
}

void UpdateDatabase(AppDbContext dataContext)
{
    dataContext.Database.Migrate();
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