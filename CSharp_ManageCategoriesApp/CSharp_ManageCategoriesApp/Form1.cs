using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace CSharp_ManageCategoriesApp
{
    public partial class frmManageCategories : Form
    {
        public frmManageCategories()
        {
            InitializeComponent();
            CreateDatabase();

        }
        static void CreateDatabase()
        {
            using var dbcontext = new MyStockDBContext();

            String dbname = dbcontext.Database.GetDbConnection().Database;// mydata

            var rs = dbcontext.Database.EnsureCreated();

         
        }

        private void LoadCategory()
        {
            var categories = ManageCategories.Instance.GetCategories();
            txtCategoryID.DataBindings.Clear();
            txtCategoryName.DataBindings.Clear();

            txtCategoryID.DataBindings.Add("Text", categories, "CategoryID");
            txtCategoryName.DataBindings.Add("Text", categories, "CategoryName");

            dgvCategories.DataSource = categories;

        }
        private void frmManageCategories_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var category = new Category() { CategoryName = txtCategoryName.Text };
                ManageCategories.Instance.InsertCategory(category);
                LoadCategory();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Insert Category");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }


    }
}
