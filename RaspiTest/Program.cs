using System;
using Raspi.Gpio;

namespace raspitest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Internet of Things!");

            var blinker = new RaspiBlinker();

            blinker.Blink(12, 20);
        }
    }
}
