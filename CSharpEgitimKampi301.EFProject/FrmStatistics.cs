﻿using System;
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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text=db.Location.Count().ToString();

            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity ).ToString();

            lblGuideCount.Text = db.Guide.Count().ToString();

            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity)?.ToString("0.00")+" Kişi";

            lvlAvgLocationPrice.Text = db.Location.Average(x => x.Price)?.ToString("0.00")+"TL";

            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountry.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y=>y.Country).FirstOrDefault();

            lblCappadocciaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y=>y.Capacity).FirstOrDefault().ToString();

            lblTurkeyAvgTourCapacity.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y=>y.Capacity).ToString()+" Kişi";

            var romeGuideId = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.GuideId).FirstOrDefault();
            lblRomaGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName +" "+ y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            var aliGuideId = db.Guide.Where(x => x.GuideName == "Ali" && x.GuideSurname=="Yıldız" ).Select(y => y.GuideId).FirstOrDefault();
            label17.Text = db.Location.Where(x => x.GuideId == aliGuideId).Count().ToString();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
