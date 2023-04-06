using IMSInterfaceLayer.DataContext;
using IMSInterfaceLayer.IService;
using IMSInterfaceLayer.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("IMSApp")));


// Add services to the container.
builder.Services.AddControllersWithViews();

#region Dependency Injection
builder.Services.AddScoped<IUserservice, UserService>();

builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<ILoginService, LoginService>();
#endregion
// Configure the HTTP request pipeline.

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Register}/{action=RegisterIndex}/{id?}");

app.Run();
