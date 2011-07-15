using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Bot
{
    public class Program
    {
        public static void Main()
        {
            MovementController movement = new MovementController(0, 0, 0, 0, 0, 0);

            movement.wakeup();

            while (true)
            {
                movement.update();
            }
        }

    }
}
