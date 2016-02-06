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
using WarThunderApplet.Models;

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
        private Image returnImage;
        private Bitmap MapBitmap;
        private Graphics graphics;
        public WarThunderForm()
        {
            this.Hide();   
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
            try
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
                        returnImage = await _infoHelper.GetMap();
                        getNewMap = false;
                        if (returnImage != null)
                        {               
                          //  MapBitmap = new Bitmap(returnImage);
                            Map.Image = returnImage;
                        }
                    }
                    await ProcessMapLocations();
                    Screen = new Bitmap(320, 240);
                    mainPanel.DrawToBitmap(Screen, new Rectangle(0, 0, Screen.Width, Screen.Height));
                    DMcLgLCD.LcdUpdateBitmap(device, Screen.GetHbitmap(), DMcLgLCD.LGLCD_DEVICE_QVGA);
                    
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
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
            if (stateInfo.ContainsKey("oil temp 1, C")) oil1TempOutput.Text = stateInfo["oil temp 1, C"] + " °C";
            else oilTemp1Label.Text = "N/A";
            if (stateInfo.ContainsKey("oil temp 2, C")) oil2TempOutput.Text = stateInfo["oil temp 2, C"] + " °C";
            else oil2TempOutput.Text = "N/A";
            if (stateInfo.ContainsKey("water temp 1, C")) water1TempOutput.Text = stateInfo["water temp 1, C"] + " °C";
            else water1TempOutput.Text = "N/A";
            if(stateInfo.ContainsKey("water temp 2, C")) water2TempOutput.Text = stateInfo["water temp 2, C"] + " °C";
            flapsOutput.Text = stateInfo["flaps, %"] + "%";


        }

        private async Task ProcessIndicatorInfo()
        {
            indicatorInfo = await _infoHelper.GetInfo("indicators");
            if (!indicatorInfo.ContainsKey("valid")) return;
            if (indicatorInfo["valid"] == "true")
            {
                if (indicatorInfo.ContainsKey("altitude_10k"))
                {
                    var kmAltitudeInfo = Math.Round(Convert.ToDouble(indicatorInfo["altitude_10k"])/1.60934, 2,
                        MidpointRounding.AwayFromZero);
                    altitudeOutput.Text = (kmAltitudeInfo + " km");
                }
//                else
//                {
//                    //This isn't what we want. 
//                    if (indicatorInfo.ContainsKey("altitude_hour"))
//                    {
//                        var kmAltitudeInfo = Math.Round(Convert.ToDouble(indicatorInfo["altitude_hour"])/1.60934, 2,
//                            MidpointRounding.AwayFromZero);
//                        altitudeOutput.Text = (kmAltitudeInfo + " m");
//                    }
                    else altitudeOutput.Text = "N/A";

//                }
                if (indicatorInfo.ContainsKey("water_temperature"))
                {
                    var waterTemp =
                        Math.Round(Convert.ToDouble(indicatorInfo["water_temperature"]), 0, MidpointRounding.AwayFromZero);
                    water1TempOutput.Text = waterTemp.ToString() +  " °C";
                }
                if (indicatorInfo.ContainsKey("oil_temperature"))
                {
                    var oilTemp = Math.Round(Convert.ToDouble(indicatorInfo["oil_temperature"]), 0, MidpointRounding.AwayFromZero);
                   oil1TempOutput.Text = oilTemp.ToString() + " °C";
                }
                aircraftOutput.Text = indicatorInfo["type"];

            }
            else
            {
                aircraftOutput.Text = "N/A";
                altitudeOutput.Text = "N/A";
                oil1TempOutput.Text = "N/A";
                water1TempOutput.Text = "N/A";
            }

        }

        private async Task ProcessMapLocations()
        {
            var mapObjects = await _infoHelper.GetMapObjects();
            //Return if not in match
            if (mapObjects.Count == 0) return;
            foreach (var mapObject in mapObjects)
            {
                if (mapObject.Type == "airfield") await DrawAirfieldOnMap(mapObject);

            }
            //Get Player Location then get section of Map
            MapBitmap = new Bitmap(returnImage);
            var playerInfo = mapObjects.FirstOrDefault(z => z.Icon.Equals("Player"));
            if (playerInfo == null) return;
            var xCords = Convert.ToInt32(returnImage.Width * playerInfo.X) - (155/2);
            var yCords = Convert.ToInt32(returnImage.Height *playerInfo.Y) - (133 /2);
            var areaOfMap = new Rectangle(xCords,yCords,Map.Width,Map.Height);
            Map.Image = MapBitmap.Clone(areaOfMap, MapBitmap.PixelFormat);
            MapBitmap.Dispose();
       

        }

        private async Task DrawAirfieldOnMap(MapObjectModel model)
        {
            graphics = Graphics.FromImage(returnImage);
            var colorOfAirfield = ColorTranslator.FromHtml(model.Color);
            var brush = new SolidBrush(colorOfAirfield);
            var xCords = (float)(returnImage.Width*model.SX);
            var yCords = (float)(returnImage.Height*model.SY);
            var rect = new RectangleF(xCords,yCords,5,20);
            graphics.FillRectangle(brush,rect);
            graphics.Dispose();
            brush.Dispose();
        }



    }
}

