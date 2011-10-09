using System.Threading;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace TestLED
{
    public class Program
    {
        public static void Main()
        {
            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
            OutputPort shieldLed = new OutputPort(Pins.GPIO_PIN_D13, true);
            while (false)
            {
                led.Write(true);
                shieldLed.Write(false);
                Thread.Sleep(250);
                led.Write(false);
                shieldLed.Write(true);
                Thread.Sleep(250);
            }
        }

    }
}
