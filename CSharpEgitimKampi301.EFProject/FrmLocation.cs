using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values=db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName = x.GuideName+ " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            txtGuide.DisplayMember = "FullName";
            txtGuide.ValueMember = "GuideId";
            txtGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(txtGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme Başarılı...");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deletedeValue = db.Location.Find(id);
            db.Location.Remove(deletedeValue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı...");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse((string)txtId.Text);
            var updatedeValue = db.Location.Find(id);
            updatedeValue.City = txtCity.Text;
            updatedeValue.Country = txtCountry.Text;
            updatedeValue.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updatedeValue.Price = decimal.Parse(txtPrice.Text);
            updatedeValue.DayNight = txtDayNight.Text;
            updatedeValue.GuideId = int.Parse(txtGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme Başarılı...");
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtId.Text);
            var value = db.Location.Where(x => x.LocationId == id).ToList();
            dataGridView1.DataSource = value;
            db.SaveChanges();
            MessageBox.Show("Tur başarıyla getirildi.");
        }
    }
}
