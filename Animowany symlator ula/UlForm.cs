using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animowany_symlator_ula
{
    public partial class UlForm : Form
    {
        public Renderer Rysuj;
        public UlForm()
        {
            InitializeComponent();
            //BackgroundImage = Renderer.SkalujObraz(Properties.Resources.Ul___wewnątrz__, ClientRectangle.Width, ClientRectangle.Height);
        }

        private void UlForm_Paint(object sender, PaintEventArgs e)
        {
            Rysuj.RysujUl(e.Graphics);
        }

        private void UlForm_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location.ToString());
        }
    }
}
