using Walter.Core;
using Walter.Infrastructure;
using Walter.Infrastructure.Initializers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Create connection sting
string connStr = builder.Configuration.GetConnectionString("DefaultConnection");
// Database context
builder.Services.AddDbContext(connStr);

// Add Core services
builder.Services.AddCoreServices();

// Add Infrastructure Service
builder.Services.AddInfrastructureService();

// Add Repositories
builder.Services.AddRepositories();

// Add Mapping
builder.Services.AddMapping();

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
app.UseStatusCodePagesWithRedirects("/Error/{0}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await UsersAndRolesInitializer.SeedUsersAndRoles(app);

app.Run();
