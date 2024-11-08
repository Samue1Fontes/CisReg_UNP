using CisReg_Website.Domain;
using CisReg_Website.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN";
});

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<ProfessionalRepository>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.Use(async (context, next) =>
{
    context.Response.Headers["Content-Security-Policy"] = "default-src 'self'; " +
    "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com https://cdnjs.cloudflare.com; " +
    "font-src 'self' https://fonts.gstatic.com https://cdnjs.cloudflare.com; " +
    "script-src 'self' 'unsafe-inline' 'unsafe-eval' https://code.jquery.com; " +
    "connect-src 'self' ws://localhost:60870 wss://localhost:44349 http://localhost:60870;";

    context.Response.Headers["X-Content-Type-Options"] = "nosniff";

    context.Response.Headers["X-XSS-Protection"] = "1; mode=block";

    context.Response.Headers["X-Frame-Options"] = "DENY";

    context.Response.Headers["Strict-Transport-Security"] = "max-age=31536000; includeSubDomains";

    await next();
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
