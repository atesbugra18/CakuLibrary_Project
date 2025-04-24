using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.Utils
{
    internal class CloseHelper
    {
        private static int rotateclose = 0;
        public static async Task CloseButtonAnimation(object sender, EventArgs e, Timer timer, Button btn,Form gecerliform,bool calısıldı)
        {
            await Task.Delay(1);
            DialogResult res;
            btn.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            btn.Refresh();
            rotateclose += 90;
            if (rotateclose == (90 * 20))
            {
                timer.Stop();
                rotateclose = 0;
                if (gecerliform.Name == "Home")
                {
                    res = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
                else if (gecerliform.Name.Contains("Sil")&&!calısıldı)
                {
                    res = MessageBox.Show("Yaptığınız değişiklikler kaydedilmemiş olabilir. Devam etmek istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        gecerliform.Close();
                    }
                }
                else
                {
                    gecerliform.Close();
                }
            }
        }
    }
}
