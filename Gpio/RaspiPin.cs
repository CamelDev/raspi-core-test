using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace CamelDev.AutoCtrl.Device.Gpio
{
    public class RaspiPin : IDevicePin
    {       

        public void SetPinValue(BcmIo pin, PinValue value)
        {
             var gpioPin = GetGpioPinByBcmNumber(pin);
             
             if(gpioPin.PinMode == GpioPinDriveMode.Input)
                gpioPin.PinMode = GpioPinDriveMode.Output;

             gpioPin.Write(value == PinValue.High ? true : false);
        }

        public PinValue GetPinValue(BcmIo pin)
        {
            return GetGpioPinByBcmNumber(pin).Read() ? PinValue.High : PinValue.Low;
        }

        private GpioPin GetGpioPinByBcmNumber(BcmIo bcmPinNumber) 
        {
            var pinNumber = Enum.Parse(typeof(BcmIo), bcmPinNumber.ToString() );

            switch(pinNumber)
            {
                // case BcmIo.Pin1: return SCL.0 IN
                case BcmIo.Pin2: return Pi.Gpio.Pin08;                
                // case BcmIo.Pin3: return SDA.1 IN
                case BcmIo.Pin4: return Pi.Gpio.Pin07;
                case BcmIo.Pin5: return Pi.Gpio.Pin21;
                case BcmIo.Pin6: return Pi.Gpio.Pin22;
                // case BcmIo.Pin7: return CE1 IN
                // case BcmIo.Pin8: return CE0 OUT
                // case BcmIo.Pin9: return MOS0 IN;
                // case BcmIo.Pin10: return MOSI OUT;
                // case BcmIo.Pin11: return SCLK IN;
                case BcmIo.Pin12: return Pi.Gpio.Pin26;                    
                case BcmIo.Pin13: return Pi.Gpio.Pin23;
                // case BcmIo.Pin14: return TxD ALT0
                // case BcmIo.Pin15: return RxD ALT0;
                case BcmIo.Pin16: return Pi.Gpio.Pin27;
                case BcmIo.Pin17: return Pi.Gpio.Pin00;
                case BcmIo.Pin18: return Pi.Gpio.Pin01;
                case BcmIo.Pin19: return Pi.Gpio.Pin24;
                case BcmIo.Pin20: return Pi.Gpio.Pin28;
                case BcmIo.Pin21: return Pi.Gpio.Pin29;
                case BcmIo.Pin22: return Pi.Gpio.Pin03;
                case BcmIo.Pin23: return Pi.Gpio.Pin04;
                case BcmIo.Pin24: return Pi.Gpio.Pin05;
                case BcmIo.Pin25: return Pi.Gpio.Pin04;
                case BcmIo.Pin26: return Pi.Gpio.Pin25;
                
                default: throw new ApplicationException("Incorect BCM pin number");
            }
        }
    }
}