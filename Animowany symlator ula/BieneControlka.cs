using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animowany_symlator_ula
{
    public partial class BieneControlka : UserControl
    {
        public BieneControlka()
        {
            InitializeComponent();
            BackColor = System.Drawing.Color.Transparent;
            BackgroundImageLayout = ImageLayout.Stretch;
            ZmieńRozmiary();
        }
        private int cell = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            cell++;
            switch (cell)
            {
                case 1: BackgroundImage = fotkiPszczoły[0]; break;
                case 2: BackgroundImage = fotkiPszczoły[1]; break;
                case 3: BackgroundImage = fotkiPszczoły[2]; break;
                case 4: BackgroundImage = fotkiPszczoły[3]; break;
                case 5: BackgroundImage = fotkiPszczoły[2]; break;
                default: BackgroundImage = fotkiPszczoły[1]; cell = 0; break;
            }
        }
        private Bitmap[] fotkiPszczoły = new Bitmap[4];
        private void ZmieńRozmiary()
        {
            fotkiPszczoły[0] = Renderer.SkalujObraz(Properties.Resources.Pszczoła_1, Width, Height);
            fotkiPszczoły[1] = Renderer.SkalujObraz(Properties.Resources.Pszczoła_2, Width, Height);
            fotkiPszczoły[2] = Renderer.SkalujObraz(Properties.Resources.Pszczoła_3, Width, Height);
            fotkiPszczoły[3] = Renderer.SkalujObraz(Properties.Resources.Pszczoła_4, Width, Height);

        }

        private void BieneControlka_Resize(object sender, EventArgs e)
        {
            ZmieńRozmiary();
        }
    }
}
