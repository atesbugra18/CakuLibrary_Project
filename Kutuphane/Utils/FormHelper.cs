using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.Utils
{
    public static class FormHelper
    {

        public static async Task FormuGetir(string tefa)
        {
            bool arananformbulundu = false;
            Form[] acikformlar = Application.OpenForms.Cast<Form>().ToArray();
            await Task.Delay(1);
            foreach (Form form in acikformlar)
            {
                if (form.Name == tefa)
                {
                    arananformbulundu = true;
                    form.BringToFront();
                    return;
                }
            }
            if (!arananformbulundu)
            {
                Form yeniForm = null;
                switch (tefa)
                {
                    case "KitapEkle":
                        yeniForm = new ChildFormsKitap.KitapEkle();
                        break;
                    case "KitapSilGuncelle":
                        yeniForm = new ChildFormsKitap.KitapSilGuncelle();
                        break;
                    case "MevcutKitaplariListele":
                        yeniForm = new ChildFormsKitap.MevcutKitaplariListele();
                        break;
                    case "TeslimAlinacakKitaplariListele":
                        yeniForm = new ChildFormsKitap.TeslimAlinacakKitaplariListele();
                        break;
                    case "KategoriEkle":
                        yeniForm = new ChildFormsKitap.KategoriEkle();
                        break;
                    case "KategoriSilDuzenle":
                        yeniForm = new ChildFormsKitap.KategoriSilDuzenle();
                        break;
                    case "KategorileriListele":
                        yeniForm = new ChildFormsKitap.KategorileriListele();
                        break;
                    case "YazarEkle":
                        yeniForm = new ChildFormsKitap.YazarEkle();
                        break;
                    case "YazarSilDuzenle":
                        yeniForm = new ChildFormsKitap.YazarSilDuzenle();
                        break;
                    case "YazarlariListele":
                        yeniForm = new ChildFormsKitap.YazarlariListele();
                        break;
                    default:
                        MessageBox.Show($"Form '{tefa}' bulunamadı ve oluşturulamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
        }
    }
}
