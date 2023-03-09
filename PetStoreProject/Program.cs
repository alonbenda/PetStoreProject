using Microsoft.EntityFrameworkCore;
using PetStoreProject.Data;
using PetStoreProject.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IStoreServices, StoreServices>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<StoreContext>();
    //ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=HomePage}");
});

app.Run();
