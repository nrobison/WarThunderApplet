using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarThunderApplet
{
    public partial class WarThunderForm : Form
    {
        public WarThunderForm()
        {
            InitializeComponent();
        }

        private void WarThunderForm_Load(object sender, EventArgs e)
        {
            var connection = LogitechGSDK.LogiLcdInit("War Thunder", LogitechGSDK.LOGI_LCD_TYPE_COLOR);
            if (connection)
            {
                
            }
        }

        private bool IsConnectedToWarThunder()
        {
            return false;
        }

        private void GetMap()
        {
            
        }
    }
}
