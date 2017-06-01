using System;
using System.Collections.Generic;

using Windows.Devices.Enumeration;
using Windows.Devices.I2c;

using jcHAP.Library.TransportObjects.SensorData;

using Newtonsoft.Json;

namespace jcHAP.SensorNode.Sensors
{
    public class TemperatureSensor : BaseSensor<TemperatureData>
    {
        private I2cDevice _sensor;

        public override string Name() => "TemperatureHumidity";

        public override async void Initialize()
        {
            var aqs = I2cDevice.GetDeviceSelector("I2C1");

            IReadOnlyList<DeviceInformation> dis = await DeviceInformation.FindAllAsync(aqs);

            _sensor = await I2cDevice.FromIdAsync(dis[0].Id, new I2cConnectionSettings(0x40));
        }

        private double getHumidity()
        {
            var humidityCommand = new byte[1] { 0xE5 };
            var humidityData = new byte[2];

            try
            {
                _sensor.WriteRead(humidityCommand, humidityData);

                var rawHumidityReading = humidityData[0] << 8 | humidityData[1];
                var humidityRatio = rawHumidityReading / (float)65536;

                return -6 + (125 * humidityRatio);
            }
            catch (Exception)
            {
                return 0.0;
            }
        }

        private double getTemperature()
        {
            try
            {
                var tempCommand = new byte[1] { 0xE3 };
                var tempData = new byte[2];

                _sensor.WriteRead(tempCommand, tempData);

                var rawTempReading = tempData[0] << 8 | tempData[1];
                var tempRatio = rawTempReading / (float)65536;
                
                return -46.85 + (175.72 * tempRatio);
            }
            catch (Exception)
            {
                return 0.0;
            }
        }

        public override string GetData()
        {
            var temperatureData = new TemperatureData
            {
                Temperature = getTemperature(),
                Humidity = getHumidity()
            };
            
            return JsonConvert.SerializeObject(temperatureData);
        }
    }
}