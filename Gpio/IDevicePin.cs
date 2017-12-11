
using CamelDev.AutoCtrl.Device.Gpio;

namespace CamelDev.AutoCtrl
{
    public interface IDevicePin
    {
        void SetPinValue(BcmIo pin, PinValue value);   
    }
}    