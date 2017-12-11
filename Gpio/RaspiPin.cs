using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace CamelDev.AutoCtrl.Device.Gpio
{
    public class RaspiPin : IDevicePin
    {       

        public void SetPinValue(BcmIo pin, PinValue value)
        {
            GetGpioPinByBcmNumber(pin).SetPinValue(val);
        }

        private GpioPin GetGpioPinByBcmNumber(BcmIo bcmPinNumber) 
        {
            var pinNumber = Enum.Parse(typeof(BcmIo), bcmPinNumber.ToString() );

            switch(pinNumber)
            {
                case BcmIo.Pin1: return Pi.Gpio.Pin01;
                case BcmIo.Pin2: return Pi.Gpio.Pin08;
                // TODO: implement missing
                case BcmIo.Pin12: return Pi.Gpio.Pin26;                    
                default: throw new ApplicationException("Incorect BCM pin number");
            }
        }
    }
}