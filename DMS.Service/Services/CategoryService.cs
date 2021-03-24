using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Data;
using System.Security.Claims;

namespace DMS.Service
{
    /*
     * CATEGORY SERVICE MAIN CLASS
     */
    public class CategoryService
    {
        private readonly DMSContext _context;
        public CategoryService(DMSContext db)
        {
           _context = db;
        }

        /*
         * GET LIST OF CATEGORY
         */
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        /*
         * CREATE CATEGORY
         */
        public bool CreateCategory(Category Cat)
        {
            bool status;

            Category item = new Category();
            item.CategoryName = Cat.CategoryName;
           
            try
            {
                _context.Categories.Add(item);
                _context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                var exp = ex;
                status = false;
            }
            return status;
        }

        /*
         * DELETE CATEGORY
         */
        public bool DeleteCategory(int id)
        {
            bool status;
            var item = _context.Categories.Find(id);
            
            try
            {
                _context.Categories.Remove(item);
                _context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                var exp = ex;
                status = false;
            }
            return status;
        }

    }
}
