using VoxTics.Data.UoW;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        public CategoryService(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<Category>> GetAllAsync() => await _uow.Categories.GetAllAsync();
        public async Task<Category?> GetByIdAsync(int id) => await _uow.Categories.GetByIdAsync(id);
        public async Task<Category?> GetByNameAsync(string name) => await _uow.Categories.GetByNameAsync(name);

        public async Task CreateAsync(Category category)
        {
            await _uow.Categories.AddAsync(category);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _uow.Categories.Update(category);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cat = await _uow.Categories.GetByIdAsync(id);
            if (cat == null) return;
            _uow.Categories.DeleteAsync(cat);
            await _uow.SaveAsync();
        }
    }

}
