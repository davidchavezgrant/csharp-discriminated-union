using Microsoft.EntityFrameworkCore;


namespace Hackathon.DAL;

internal sealed class AppDbContext: DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { this.Database.EnsureCreated(); }

	public DbSet<User> Users => Set<User>();
}

internal sealed record User(Guid Id, string Username)
{
	public User(): this(Guid.Empty, string.Empty) {} // required for admin panel
}