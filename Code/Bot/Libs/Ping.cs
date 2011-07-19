using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Bot.Libs
{
    class Ping
    {
        private TristatePort PingPort;
        private const int TICKS_TO_CM = 583;


        public Ping(Cpu.Pin port)
        {
            PingPort = new TristatePort(port, false, false, Port.ResistorMode.Disabled);
        }

        /// <summary>
        /// Sends out a Ping))) and returns the current distance in cm.
        /// </summary>
        /// <returns>Distance in cm</returns>
        public int Distance()
        {
            bool portState;

            // Send a ping out to the sensor
            PingPort.Active = true;
            PingPort.Write(true);
            PingPort.Write(false);
            PingPort.Active = false;

            // Port will read low until a response is ready, so wait for the port to read HIGH
            portState = false;
            while (portState == false)
            {
                portState = PingPort.Read();
            }
            long startOfPulse = System.DateTime.Now.Ticks;

            // Port is now HIGH, so now wait for it to go LOW - that gives the distance
            portState = true;
            while (portState == true)
            {
                portState = PingPort.Read();
            }
            long endOfPulse = System.DateTime.Now.Ticks;

            // Distance is end-time - start-time
            int ticks = (int)(endOfPulse - startOfPulse);

            return (ticks / TICKS_TO_CM);
        }

    }
}
