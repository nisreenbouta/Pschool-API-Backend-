using Microsoft.EntityFrameworkCore;
using PschoolAPI.Models;

namespace PschoolAPI.Data
{
    public class PschoolContext : DbContext
    {
        public PschoolContext(DbContextOptions<PschoolContext> options) : base(options) { }

        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
