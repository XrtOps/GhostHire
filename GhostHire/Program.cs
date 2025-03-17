using Microsoft.EntityFrameworkCore;
using GhostHire.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(); // ✅ Enable session storage
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// TODO: Replace with real database when ready
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GhostHireDBContext")));

var app = builder.Build();

// Middleware configurations
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// Default route mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomePage}/{id?}"
);

// Handle 404 errors gracefully
app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

app.Run();
