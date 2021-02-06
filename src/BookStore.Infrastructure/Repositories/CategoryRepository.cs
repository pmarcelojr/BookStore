using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;

namespace BookStore.Infrastructure.Repositories
{
    public class CategoryReposity : Repository<Category>, ICategoryRepository
    {
        public CategoryReposity(BookStoreDbContext context) : base(context) { }
    }
}