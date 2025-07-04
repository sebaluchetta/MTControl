using Microsoft.EntityFrameworkCore;

using MTControl.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MtcontrolContext> ( options =>
options.UseSqlServer ( builder.Configuration.GetConnectionString ( "ConexionSQL" )));
builder.Services.AddSession ();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<MTControl.Services.Interface.IImageService, MTControl.Services.ImageService> ();
builder.Services.AddScoped<MTControl.Services.Interface.IProfilesService, MTControl.Services.ProfileService> ();
builder.Services.AddScoped<MTControl.Services.Interface.IActivityService, MTControl.Services.ActivityService> ();
builder.Services.AddScoped<MTControl.Services.Interface.ICategoryService, MTControl.Services.CategoryService> ();
builder.Services.AddScoped<MTControl.Services.Interface.IPurchaseService, MTControl.Services.PurchaseService> ();
builder.Services.AddScoped<MTControl.Services.Interface.ISaleService, MTControl.Services.SaleService> ();
builder.Services.AddScoped<MTControl.Services.Interface.ICalculationService, MTControl.Services.CalculationService>();
builder.Services.AddScoped<MTControl.Services.Interface.IProfileVMService, MTControl.Services.ProfileVMService> ();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession ();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Profile}/{action=Profiles}/{id?}");

app.Run();
