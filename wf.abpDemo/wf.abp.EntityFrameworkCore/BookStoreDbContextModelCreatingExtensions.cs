using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using wf.abp.Domain.Books;

namespace wf.abp.EntityFrameworkCore
{
    public static class BookStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureBookStore(this ModelBuilder builder)
        {
            builder.Entity<Book>(book =>
            {
                book.ConfigureByConvention();
            });
        }
    }
}