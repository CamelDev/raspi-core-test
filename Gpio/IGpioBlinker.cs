using CamelDev.AutoCtrl.Device.Gpio;

namespace CamelDev.AutoCtrl
{
    public interface IGpioBlinker
    {
        void TestBlink(BcmIo pin, int count);   
    }
}