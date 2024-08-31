using Microsoft.EntityFrameworkCore;

namespace ContactlistDatabase.Models
{
    public class ContactsContext : DbContext
    {
        //sets up database options
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options) { }

        //create contact dbset
        public DbSet<Contacts> Contacts { get; set; }

        //method to create data set on creation of the table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contacts>().HasData(
                new Contacts {ContactsId = 1, Name = "Tommy Wells", PhoneNumber = "515-350-9070", Address = "6924 Chaffee Rd.", Note ="CIS 174 student" },
                new Contacts {ContactsId = 2, Name = "Amanda Christie", PhoneNumber = "515-657-0416", Address ="6924 Chaffee Rd.", Note = "N/A"},
                new Contacts {ContactsId = 3, Name = "Billy Bob", PhoneNumber = "515-555-5555", Address = "1234 University Dr.", Note = "He's just a guy" }
                );
        }
    }
}
