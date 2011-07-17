using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Bot.Libs
{
    class EyesController: iController
    {
        private Ping Eye;
        private int LastDistance = 0;
        private DateTime LastUpdate = DateTime.MinValue;
        private const TimeSpan UPDATE_FREQUENCY = new TimeSpan(0, 0, 1);


        public EyesController(Cpu.Pin controlPin)
        {
            Ping ping = new Ping(controlPin);
        }


        public void wake()
        {
        }


        public void update()
        {
            if ((DateTime.Now - LastUpdate) > UPDATE_FREQUENCY)
            {
                LastDistance = Eye.Distance();
                LastUpdate = DateTime.Now;
            }
        }


        public void sleep()
        {
        }


        public int distance()
        {
            return LastDistance;
        }

    }
}
