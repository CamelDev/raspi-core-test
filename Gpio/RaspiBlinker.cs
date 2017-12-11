using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;
using CamelDev.AutoCtrl.Device.Gpio;

namespace CamelDev.AutoCtrl.Device.Gpio
{
    public class RaspiBlinker : IGpioBlinker
    {
        public void TestBlink(BcmIo gpioNumber, int count)
        {
            
            while(count-- > 0)
            {               
                var gpioPin = GetPin(gpioNumber);
                gpioPin.PinMode = GpioPinDriveMode.Output;

                var value = count % 2 == 0;
                Console.WriteLine($"Setting pin {gpioPin.BcmPinNumber} to {value}!");
                gpioPin.Write(value ? GpioPinValue.High : GpioPinValue.Low);

                System.Threading.Thread.Sleep(700);
            }

            
        }

       
    }
}
