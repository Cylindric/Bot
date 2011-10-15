using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Bot;
using Bot.Libs;

namespace Test_Neck
{
    public class Program
    {
        public static void Main()
        {
            NeckController neck = new NeckController(GlobalPins.NECK_PIN);

            while (true)
            {
                for (int angle = -80; angle <= 80; angle += 10)
                {
                    Debug.Print("Setting neck to " + angle);
                    neck.SetAngle(angle);
                    Thread.Sleep(1000);
                }
            }

        }

    }
}
