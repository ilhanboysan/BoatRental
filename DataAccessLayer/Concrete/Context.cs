using EntityLayer.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser, AppRole, int>
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-I0DNEJQ;initial Catalog=BoatRentalDb;integrated Security=true;TrustServerCertificate=True");
		}
		public DbSet<Boat> Boat { get; set; }
		public DbSet<BlogPost> BlogPost { get; set; }
		public DbSet<Location> Location { get; set; }
		public DbSet<Partner> Partner { get; set; }



	}
}
