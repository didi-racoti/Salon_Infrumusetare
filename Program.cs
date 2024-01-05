using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Salon_Infrumusetare.Data;
using Microsoft.AspNetCore.Identity;
using Salon_Infrumusetare.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Servicii", "AdminPolicy");
    options.Conventions.AllowAnonymousToPage("/Servicii/Index");
    options.Conventions.AllowAnonymousToPage("/Servicii/Details");

    options.Conventions.AuthorizeFolder("/Specialisti", "AdminPolicy");
    options.Conventions.AllowAnonymousToPage("/Specialisti/Index");
    options.Conventions.AllowAnonymousToPage("/Specialisti/Details");

    options.Conventions.AuthorizeFolder("/Clienti", "AdminPolicy");

    options.Conventions.AuthorizeFolder("/Programari", "AdminPolicy");

    options.Conventions.AuthorizeFolder("/Recenzii");
    options.Conventions.AllowAnonymousToPage("/Recenzii/Index");
});
builder.Services.AddDbContext<Salon_InfrumusetareContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Salon_InfrumusetareContext") ?? throw new InvalidOperationException("Connection string 'Salon_InfrumusetareContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Salon_InfrumusetareContext") ?? throw new InvalidOperationException("Connection string 'Salon_InfrumusetareContext' not found.")));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
