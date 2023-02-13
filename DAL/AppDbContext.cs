using Microsoft.EntityFrameworkCore;


namespace Hackathon.DAL;

internal sealed class AppDbContext: DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

	public DbSet<User> Users => Set<User>();
}

internal sealed record User(Guid Id, string Username)
{
	/// <summary>
	/// This parameterless constructor is needed for EF Core and the admin panel to work.
	/// </summary>
	public User(): this(Guid.Empty, string.Empty) {}
}