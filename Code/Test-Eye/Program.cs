using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Bot;

namespace Test_Eye
{

    public class PingTest
    {
        private TristatePort _port;

        // Pass in the pin to which the rangefinder is attached.
        public PingTest(Cpu.Pin pin)
        {
            _port = new TristatePort(pin, false, false, ResistorModes.Disabled);
        }

        // Returns distance in mm
        public int mm_Distance()
        {

            // First we need to pulse the port ... high, low.  It seems to work fine, without adding any delay.
            _port.Active = true;                // Put port in write mode
            _port.Write(true);                  // Pulse pin
            _port.Write(false);

            _port.Active = false;                        // Put port in read mode;    
            bool v1 = false;
            while (v1 == false) { v1 = _port.Read(); }   // Wait for line to go high.
            long tick1 = System.DateTime.Now.Ticks;      // Save start ticks.

            bool v2 = true;
            while (v2 == true) { v2 = _port.Read(); }    // Wait for line to go low.
            long tick2 = System.DateTime.Now.Ticks;      // Save end ticks. 

            int ticks = (int)(tick2 - tick1);
            // Now, just have to convert ticks to mm
            //   Per wikipedia: speed of sound, dry air, 20 deg C, 343 m /s
            //   Per msdn: one .NET "Tick" = 0.1 micro seconds.
            // Which works out to ... 
            // ... 1 mm of travel each 29.15 ticks
            // ... divide by 2 for round-trip ... 58.3 ticks per mm

            return ticks * 10 / 583;
        }
    }

    public class Program
    {
        public static void Main()
        {
            //PingTest ping = new PingTest(GlobalPins.EYE_PIN);
            //while(true)
            //{
            //    int cm = ping.mm_Distance() / 10;
            //    Debug.Print(cm.ToString() + "cm");
            //    Thread.Sleep(1000);
            //}
            EyesController ping = new EyesController(GlobalPins.EYE_PIN);
            while (true)
            {
                ping.Update();
                double cm = ping.Distance;// ping.mm_Distance() / 10;
                Debug.Print(cm.ToString() + "cm");
                Thread.Sleep(1000);
            }
        }

    }
}
