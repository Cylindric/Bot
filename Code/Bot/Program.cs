using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Bot.Libs;

namespace Bot
{
    public class Program
    {
        public static void Main()
        {
            OutputPort led = new OutputPort(Pins.ONBOARD_LED,false);

            AI ai = new AI();
            ai.Wheels = new WheelsController(Pins.GPIO_PIN_D2, Pins.GPIO_PIN_D3, Pins.GPIO_PIN_D5, Pins.GPIO_PIN_D4, Pins.GPIO_PIN_D7, Pins.GPIO_PIN_D6);
            ai.Neck = new NeckController(Pins.GPIO_PIN_D9);
            ai.Eyes = new EyesController(Pins.GPIO_PIN_D8);

            ai.wake();

            // test ping
            //while (true)
            //{
            //    ai.Eyes.ping();
            //    Thread.Sleep(1000);
            //}

            while (ai.Alive)
            {
                ai.update();
            }

            ai.sleep();

        }

    }
}
