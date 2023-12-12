using EStore.Data.Base;
using EStore.Data.ViewModels;
using EStore.Models;

namespace EStore.Data.Services
{
    public class CategoriesService: EntityBaseRepository<Category>, ICategoriesService
    {
        private readonly AppDbContext _context;

        public CategoriesService(AppDbContext context) : base(context)
        {
        }
        
    }
}
