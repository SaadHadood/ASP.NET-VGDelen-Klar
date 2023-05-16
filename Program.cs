using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Identity;
using WebApp.Repositories;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ShowcaseService>();

builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("merketo")));
builder.Services.AddDbContext<ProductContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql"))); // Sql finns i appsetting.json filen.
builder.Services.AddDbContext<FormContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Form")));
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<TagRepo>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductTagRepository>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<NProductService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ContactFormService>();

builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
