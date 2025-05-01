using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Kutuphane.Utils
{
    internal class FormHelper
    {
        public static Form FormuAdinaGoreGetir(string formName)
        {
            var formType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.IsSubclassOf(typeof(Form)) && t.Name == formName);
            if (formType != null)
                return (Form)Activator.CreateInstance(formType);

            throw new Exception("Form bulunamadı: " + formName);
        }
        public FormHelper(string formAdi)
        {
            Form homeForm = Application.OpenForms["Home"];
            StatusStrip statusStrip = ((Home)homeForm).durumcubugu;
            Panel panel = ((Home)homeForm).panelebeveyn;
            Form hedefForm = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f.Name == formAdi);
            if (hedefForm != null)
            {
                hedefForm.BringToFront();
                hedefForm.WindowState = FormWindowState.Normal;
                return;
            }
            hedefForm = FormuAdinaGoreGetir(formAdi);
            hedefForm.MdiParent = homeForm;
            hedefForm.Dock = DockStyle.Fill;
            panel.Controls.Add(hedefForm);
            hedefForm.Show();
            hedefForm.BringToFront();
            ToolStripButton btn = new ToolStripButton(hedefForm.Text)
            {
                Tag = hedefForm.Name,
                Text = hedefForm.Name,
                ForeColor = Color.Gainsboro
            };
            btn.Click += (s, e) =>
            {
                var frm = Application.OpenForms[btn.Tag.ToString()];
                if (frm != null)
                {
                    frm.BringToFront();
                    frm.WindowState = FormWindowState.Normal;
                }
            };
            if (!statusStrip.Items.OfType<ToolStripButton>().Any(x => x.Tag.ToString() == hedefForm.Name))
            {
                statusStrip.Items.Add(btn);
            }
            hedefForm.FormClosed += (s, e) =>
            {
                var silinecek = statusStrip.Items
                    .OfType<ToolStripButton>()
                    .FirstOrDefault(x => x.Tag.ToString() == hedefForm.Name);
                if (silinecek != null)
                    statusStrip.Items.Remove(silinecek);
            };
        }
    }
}
