using MTControl.DAO;

namespace MTControl.Services.Interface
{
    public interface ICategoryService
    {
        List<Category> GetCategories ();
        Category GetCategoryById ( int id );
        Category GetMaxCategory();
    }
}
