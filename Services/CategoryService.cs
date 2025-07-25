﻿using MTControl.Services.Interface;
using MTControl.DAO;
namespace MTControl.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MtcontrolContext _context;
        public CategoryService ( MtcontrolContext context )
        {
            _context = context;
        }
        public List<Category> GetCategories ()
        {
            return _context.Categories.ToList ();
        }

        public Category GetCategoryById ( int id )
        {
            return _context.Categories.FirstOrDefault ( x => x.Id == id );
        }
        public Category GetMaxCategory ()
        {
            return _context.Categories.FirstOrDefault ( x => x.UltimaCategoria==true );
        }

    }
}