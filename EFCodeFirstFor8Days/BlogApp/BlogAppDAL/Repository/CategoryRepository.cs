using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAppDAL.Entities;

namespace BlogAppDAL.Repository
{
    public class CategoryRepository:IRepository<Category>
    {
        private BlogAppContext _context = null;

        public CategoryRepository(BlogAppContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetAll(System.Linq.Expressions.Expression<Func<Category, bool>> predicate = null)
        {
            if (predicate==null)
            {
                return _context.Categories;
            }
            return _context.Categories.Where(predicate);
        }

        public Category Get(System.Linq.Expressions.Expression<Func<Category, bool>> predicate)
        {
            return _context.Categories.SingleOrDefault(predicate);
        }

        public void Insert(Category entity)
        {
            _context.Categories.Add(entity);
        }

        public void Delete(Category entity)
        {
            _context.Categories.Remove(entity);
        }

        public void Update(Category entity)
        {
            _context.Categories.Attach(entity);
            _context.Entry(entity).State=EntityState.Modified;
        }

        public long Count()
        {
           return _context.Categories.LongCount();
        }
    }
}
