using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        //ProductManager productManager = new ProductManager(new EfProductDal());
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;
        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int deletedValues = int.Parse(txtProductId.Text);
            var values = _productService.TGetById(deletedValues);
            _productService.TDelete(values);
            MessageBox.Show("Silme İşlemi Başarılı...");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductName = txtProductName.Text;
            product.ProductPrice = decimal.Parse(txtProductPrice.Text);
            product.ProductStok = int.Parse(txtProductStock.Text);
            product.ProductDescription = txtDescribtion.Text;
            product.CategoryId = int.Parse(cmbCategoryy.SelectedValue.ToString());
            _productService.TInsert(product);
            MessageBox.Show("Ekleme Başarılı");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var values = _productService.TGetById(id);
            dataGridView1.DataSource= values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var values = _productService.TGetById(id);
            values.ProductName = txtProductName.Text;
            values.ProductStok = int.Parse(txtProductStock.Text);
            values.ProductPrice = decimal.Parse(txtProductPrice.Text);
            values.ProductDescription = txtDescribtion.Text;
            values.CategoryId = int.Parse(cmbCategoryy.SelectedValue.ToString());
            _productService.TUpdate(values);
            MessageBox.Show("Güncelleme Başarılı");
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            cmbCategoryy.DataSource= values;
            cmbCategoryy.DisplayMember = "CategoryName";
            cmbCategoryy.ValueMember = "CategoryId";
        }
    }
}
