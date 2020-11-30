using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using wf.abp.Domain.Books;

namespace wf.abp.EntityFrameworkCore
{
    public class BookStoreDbContext : AbpDbContext<BookStoreDbContext>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}