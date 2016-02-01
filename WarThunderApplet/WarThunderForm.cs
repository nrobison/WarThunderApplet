using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

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

        private WarThunderInfoHelper _infoHelper;
        private bool getNewMap = true;
        private Dictionary<string, string> stateInfo;
        private Dictionary<string, string> indicatorInfo;
        public WarThunderForm()
        {
            InitializeComponent();
            _infoHelper = new WarThunderInfoHelper();
            
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
                        LoadTimer.Interval = 100;
                        LoadTimer.Enabled = true;


                    }
                }
            }

        }
        public void cfgCallback(int cfgConnection)
        {
            config = cfgConnection;
        }

        private async void LoadTimer_Tick(object sender, EventArgs e)
        {
            if (await _infoHelper.IsConnectedToWarThunder())
            {
                await ProcessStateInfo();
                if (stateInfo["valid"] == "false")
                {
                    //End of Match stop trying to update and Grab new map when we get valid info
                    getNewMap = true;
                    return;
                }
                await ProcessIndicatorInfo();
                if (getNewMap)
                {
                    var mapImage = await _infoHelper.GetMap();
                    getNewMap = false;
                    if (mapImage != null) Map.Image = mapImage;
                }
                    Screen = new Bitmap(320, 240);
                    Graphics g = Graphics.FromImage(Screen);
                    mainPanel.DrawToBitmap(Screen, new Rectangle(0, 0, Screen.Width, Screen.Height));
                    DMcLgLCD.LcdUpdateBitmap(device, Screen.GetHbitmap(), DMcLgLCD.LGLCD_DEVICE_QVGA);
            }
         }

        private async Task ProcessStateInfo()
        {

            stateInfo = await _infoHelper.GetInfo("state");
            if (stateInfo["valid"] == "false")
            {
                //End of Match stop trying to update and Grab new map when we get valid info
                getNewMap = true;
                return;
            }
            speedOutput.Text = (stateInfo["TAS, km/h"] + " km/h");
            throttleOutput.Text = stateInfo["throttle 1, %"] + "%";

        }

        private async Task ProcessIndicatorInfo()
        {
            indicatorInfo = await _infoHelper.GetInfo("indicators");
            if (indicatorInfo["valid"] == "true")
            {
                if (indicatorInfo.ContainsKey("altitude_10k"))
                {
                    var kmAltitudeInfo = Math.Round(Convert.ToDouble(indicatorInfo["altitude_10k"])/1.60934, 2,
                        MidpointRounding.AwayFromZero);
                    altitudeOutput.Text = (kmAltitudeInfo + " km");
                }
                else
                {
                    var kmAltitudeInfo = Math.Round(Convert.ToDouble(indicatorInfo["altitude_hour"]) / 1.60934, 2,
                       MidpointRounding.AwayFromZero);
                    altitudeOutput.Text = (kmAltitudeInfo + " m");
                }
                aircraftOutput.Text = indicatorInfo["type"];

            }
            else
            {
                aircraftOutput.Text = "N/A";
                altitudeOutput.Text = "N/A";
            }
        }
    }
}

