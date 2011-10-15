using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Bot;

namespace Test_AI_Proximity
{
    public class Program
    {
        public static void Main()
        {
            AI ai = new AI();
            ai.Neck = new NeckController(GlobalPins.NECK_PIN);
            ai.Eyes = new EyesController(GlobalPins.EYE_PIN);

            while (true)
            {
                ai.FindClosestBearing();
                Thread.Sleep(2000);
            }

        }

    }
}
