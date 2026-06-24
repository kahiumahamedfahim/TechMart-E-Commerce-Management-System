using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechMart_E_Commerce_Management_System.Data;
using TechMart_E_Commerce_Management_System.Data.Entities;
using TechMart_E_Commerce_Management_System.Repositories.Implementations;
using TechMart_E_Commerce_Management_System.Repositories.Interfaces;
using TechMart_E_Commerce_Management_System.Services.Auth.implementations;
using TechMart_E_Commerce_Management_System.Services.Auth.interfaces;
using TechMart_E_Commerce_Management_System.Services.Email;
using TechMart_E_Commerce_Management_System.Services.File.Implementations;
using TechMart_E_Commerce_Management_System.Services.File.Interfaces;
using TechMart_E_Commerce_Management_System.Services.Profile.implementations;
using TechMart_E_Commerce_Management_System.Services.Profile.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//dependence inject
builder.Services.AddScoped(
    typeof(IGenericeRepository<>),
    typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<
    IPasswordHasher<User>,
    PasswordHasher<User>>();
builder.Services.AddScoped<
    IEmailVerificationRepository,
    EmailVerificationRepository>();
builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection(
        "EmailSettings"));
builder.Services.AddScoped<
    IEmailService,
    EmailService>();
builder.Services.AddScoped<
    IFileService,
    FileService>();
builder.Services.AddScoped<
    IPasswordResetRepository,
    PasswordResetRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
//session cookies part
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromDays
        (7);
        options.SlidingExpiration = true;

    });


//database connection 
builder.Services.AddDbContext<AppDbcontext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
