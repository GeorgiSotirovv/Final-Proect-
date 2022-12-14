using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Infrastructure.Extensions;
using CigarWorld.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CigarWorldDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;

})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CigarWorldDbContext>();



builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
    options.LoginPath = "/User/Logout";
});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAshtrayService, AshtrayService>();
builder.Services.AddScoped<ICigarService, CigarService>();
builder.Services.AddScoped<ICigarilloService, CigarilloService>();
builder.Services.AddScoped<ICutterService, CutterService>();
builder.Services.AddScoped<ILighterService, LighterService>();
builder.Services.AddScoped<IHumidorsService, HumidorService>();
builder.Services.AddScoped<ICigarCaseService, CigarCaseService>();
builder.Services.AddScoped<IMyProfileService, MyProfileService>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MyPolicy", policy =>
    {
        policy.RequireRole("Admin");
    });
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    endpoints.MapDefaultAreaRoute();
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();
