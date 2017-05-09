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
        }
        private int cell = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            cell++;
            switch (cell)
            {
                case 1: BackgroundImage = Properties.Resources.Pszczoła_1; break;
                case 2: BackgroundImage = Properties.Resources.Pszczoła_2; break;
                case 3: BackgroundImage = Properties.Resources.Pszczoła_3; break;
                case 4: BackgroundImage = Properties.Resources.Pszczoła_4; break;
                case 5: BackgroundImage = Properties.Resources.Pszczoła_3; break;
                default: BackgroundImage = Properties.Resources.Pszczoła_2; cell = 0; break;
            }
        }
    }
}
