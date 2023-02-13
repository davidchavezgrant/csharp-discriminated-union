using Hackathon.DAL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

if (builder.Configuration["UseSqlite"] == "true")
	builder.Services.AddDbContext<AppDbContext>(opts => opts.UseSqlite("Data Source=app.db"));
else
	builder.Services.AddDbContext<AppDbContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

if (!builder.Environment.IsProduction())
{
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
	builder.Services.AddCoreAdmin(); // this line must come AFTER DbContext registration
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapGet(builder.Configuration["Urls:ApiRelative"], () => "Hello World!");

if (app.Environment.IsDevelopment())
{
	app.MapDefaultControllerRoute(); // this is needed for CoreAdmin to work
	app.UseCoreAdminCustomUrl("admin");
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.Run();