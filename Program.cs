using MTControl.Models;

using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MtcontrolContext> ( options =>
options.UseSqlServer ( builder.Configuration.GetConnectionString ( "ConexionSQL" ) )

);
builder.Services.AddScoped<MTControl.Services.Interface.IImageService, MTControl.Services.ImageService> ();
builder.Services.AddScoped<MTControl.Services.Interface.IProfilesService, MTControl.Services.ProfileService> ();
builder.Services.AddScoped<MTControl.Services.Interface.IActivityService, MTControl.Services.ActivityService> ();
builder.Services.AddScoped<MTControl.Services.Interface.ICategoryService, MTControl.Services.CategoryService> ();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Profile}/{action=Profiles}/{id?}");

app.Run();
