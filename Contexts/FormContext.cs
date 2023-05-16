using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Contexts;

public class FormContext : DbContext
{
    public FormContext(DbContextOptions <FormContext> options) : base(options)
    {
    }

    public DbSet<ContactEntity> Contacts { get; set; }
}
