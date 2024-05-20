using EventsWeb122.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventsWeb122.Data
{
    public class ApplictionDbContext : IdentityDbContext
    {
        public ApplictionDbContext(DbContextOptions<ApplictionDbContext> options) : base(options)
        {

        }
        public DbSet<Events> Events { get; set; }
		public DbSet<Users> Users { get; set; }
	}
}