using Windows.UI.Xaml.Controls;

namespace jcHAP.SensorNode
{
    public sealed partial class MainPage : Page
    {
        public double GetTemperature()
        {
            try
            {
                byte[] tempCommand = new byte[1] { 0xE3 };
                byte[] tempData = new byte[2];
                sensor.WriteRead(tempCommand, tempData);
                var rawTempReading = tempData[0] << 8 | tempData[1];
                var tempRatio = rawTempReading / (float)65536;
                double temperature = -46.85 + (175.72 * tempRatio);
                System.Diagnostics.Debug.WriteLine("Temp: " + temperature.ToString());
                return temperature;
            }
            catch (Exception)
            {
                return 0.0;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();


        }
    }
}
