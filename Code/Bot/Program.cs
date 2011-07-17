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

            MovementController movement = new MovementController(Pins.GPIO_PIN_D2, Pins.GPIO_PIN_D3, Pins.GPIO_PIN_D5, Pins.GPIO_PIN_D4, Pins.GPIO_PIN_D7, Pins.GPIO_PIN_D6);
            NeckController neck = new NeckController(Pins.GPIO_PIN_D9);
            EyesController eyes = new EyesController(Pins.GPIO_PIN_D8);

            movement.wake();
            neck.wake();
            eyes.wake();

            while (true)
            {
                led.Write(true);               
                movement.update();
               
                led.Write(false);
                Thread.Sleep(1000);
            }

        }

    }
}
