using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ManageCategoriesApp
{
    public sealed class ManageCategories
    {
        private static ManageCategories instance = null;
        private static readonly object instanceLock = new object();
        private ManageCategories() { }
        public static ManageCategories Instance
        {
            get {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new ManageCategories();
                    }
                    return instance;
                }            
            }
        }


        public List<Category> GetCategories()
        {
            List<Category> categories;

            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                categories = stock.Categories.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return categories;
        }

        public void InsertCategory(Category category)
        {
            try
            {
                using MyStockDBContext stock = new MyStockDBContext();
                stock.Categories.Add(category);
                stock.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }


}
