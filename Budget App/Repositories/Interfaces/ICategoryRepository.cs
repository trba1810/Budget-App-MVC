using Budget_App.Models;

namespace Budget_App.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
        void DeleteCategory(Category category);
        void Update(Category category);
        void Create(Category category);
    }
}
