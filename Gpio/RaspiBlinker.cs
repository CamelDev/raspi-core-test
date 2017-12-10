using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;
using Raspi.Gpio;

namespace Raspi.Gpio
{
    public class RaspiBlinker : IGpioBlinker
    {
        public void Blink(int gpioNumber, int count)
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

        private GpioPin GetPin(int gpioNumber)
        {
            var pinNumber = Enum.Parse(typeof(RasPin), gpioNumber.ToString() );

            switch(pinNumber)
            {
                case RasPin.Bcm1: return Pi.Gpio.Pin01;
                case RasPin.Bcm2: return Pi.Gpio.Pin08;

                case RasPin.Bcm12: return Pi.Gpio.Pin26;                    
                default: throw new ApplicationException("Incorect PIN number");
            }
        }
    }
}
