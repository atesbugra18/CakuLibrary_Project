using MaterialSkin.Controls;
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
    internal class GizleHelper
    {
        private static int rotateclose = 0;
        public static async Task HideButtonAnimation(object sender, EventArgs e, Button btn, Form gecerliform)
        {
            await Task.Delay(1);
            btn.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            btn.Refresh();
            rotateclose += 90;
            if (rotateclose == (90 * 20))
            {
                timer.Stop();
                rotateclose = 0;
                gecerliform.Hide();
                string gizlenenform = gecerliform.Name;
                ToolStripButton formButton = new ToolStripButton
                {
                    Name = gizlenenform,
                    Text = gizlenenform,
                    DisplayStyle = ToolStripItemDisplayStyle.Text
                };
                formButton.Click += (s, args) =>
                {
                    gecerliform.Show();
                    Home.Instance.durumcubugu.Items.Remove(formButton);
                };
                Home.Instance.durumcubugu.Items.Add(formButton);
            }
        }
    }
}
