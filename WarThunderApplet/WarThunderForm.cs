using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarThunderApplet
{
    public partial class WarThunderForm : Form
    {
        private Bitmap Screen;
        public int connection = DMcLgLCD.LGLCD_INVALID_CONNECTION;
        public int device = DMcLgLCD.LGLCD_INVALID_DEVICE;
        public int deviceType = DMcLgLCD.LGLCD_INVALID_DEVICE;

        private uint buttons = 0;
        private int config = 0;
        private int cnt = 0;
        private bool direction = false;
        private bool continueRun = true;
        public WarThunderForm()
        {
            InitializeComponent();
        }

        private void WarThunderForm_Load(object sender, EventArgs e)
        {

            if (DMcLgLCD.ERROR_SUCCESS == DMcLgLCD.LcdInit())
            {
                connection = DMcLgLCD.LcdConnectEx("War Thunder Applet", 0, 0);

                if (connection != DMcLgLCD.LGLCD_INVALID_CONNECTION)
                {
                    device = DMcLgLCD.LcdOpenByType(connection, DMcLgLCD.LGLCD_DEVICE_QVGA);

                    if ( device == DMcLgLCD.LGLCD_INVALID_DEVICE)
                    {
                        device = DMcLgLCD.LcdOpenByType(connection, DMcLgLCD.LGLCD_DEVICE_BW);
                        if (DMcLgLCD.LGLCD_INVALID_DEVICE != device)
                        {
                            deviceType = DMcLgLCD.LGLCD_DEVICE_BW;
                        }
                    }
                    else
                    {
                        deviceType = DMcLgLCD.LGLCD_DEVICE_QVGA;
                    }

                    if (deviceType == DMcLgLCD.LGLCD_DEVICE_BW)
                    {
                        Screen = new Bitmap(160, 43);
                        Graphics g = Graphics.FromImage(Screen);
                        g.Clear(Color.White);
                        g.Dispose();
                        mainPanel.DrawToBitmap(Screen, new Rectangle(0, 0, Screen.Width, Screen.Height));
                        DMcLgLCD.LcdUpdateBitmap(device, Screen.GetHbitmap(), DMcLgLCD.LGLCD_DEVICE_BW);
                        DMcLgLCD.LcdSetAsLCDForegroundApp(device, DMcLgLCD.LGLCD_FORE_YES);


                    }
                    else
                    {
                        Screen = new Bitmap(320, 240);
                        Graphics g = Graphics.FromImage(Screen);
                        g.Clear(Color.White);
                        g.Dispose();
                        mainPanel.DrawToBitmap(Screen, new Rectangle(0,0,Screen.Width,Screen.Height));
                        DMcLgLCD.LcdUpdateBitmap(device, Screen.GetHbitmap(), DMcLgLCD.LGLCD_DEVICE_QVGA);
                        DMcLgLCD.LcdSetAsLCDForegroundApp(device, DMcLgLCD.LGLCD_FORE_YES);

                    }

                    if (deviceType > 0)
                    {

                        DMcLgLCD.LcdSetConfigCallback(cfgCallback);

                    }
                }
            }

        }
        public void cfgCallback(int cfgConnection)
        {
            config = cfgConnection;
        }

        private bool IsConnectedToWarThunder()
        {
            
            return true;
        }

        private void GetMap()
        {
            
        }

        private void LoadTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
