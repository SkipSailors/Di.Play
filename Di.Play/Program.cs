using Di.Play.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
services
    .AddKeyedSingleton<IService, Service>(
        "this",
        (_, __) => new("this"))
    .AddKeyedSingleton<IService, Service>(
        "that",
        (_, __) => new("that") )
    .AddControllersWithViews();
WebApplication app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
