using Microsoft.EntityFrameworkCore;
using MySimpleMessageService.Models;

namespace MySimpleMessageService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}