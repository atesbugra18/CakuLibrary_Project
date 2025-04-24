using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.ChildFormsKitap
{
    public partial class YazarlariListele : Form
    {
        public YazarlariListele()
        {
            InitializeComponent();
        }

        private async void Yazarlistele_Load(object sender, EventArgs e)
        {
            btnclose.BackgroundImage = Image.FromFile("Images\\closebutton.png");
            btngizle.BackgroundImage = Image.FromFile("Images\\hidebutton.png");
            btnclose.BringToFront();
            btngizle.BringToFront();
            await listeyidoldur();
        }
        private async Task listeyidoldur()
        {

        }
}
