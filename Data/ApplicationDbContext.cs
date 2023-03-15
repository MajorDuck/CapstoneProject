using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;

namespace CapstoneProject.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Capstone.Models.Document>? Document { get; set; }
		public DbSet<Capstone.Models.DocumentStatus>? DocumentStatus { get; set; }
		public DbSet<Capstone.Models.DocumentType>? DocumentType { get; set; }
		public DbSet<Capstone.Models.Llc>? Llc { get; set; }
		public DbSet<Capstone.Models.Role>? Role { get; set; }
	}
}