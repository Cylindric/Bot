using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Bot.Libs;

namespace Bot
{
    class EyesController: iController
    {
        private Ping Eye;
        private int LastDistance = 0;
        private DateTime LastUpdate = DateTime.MinValue;
        private TimeSpan UPDATE_FREQUENCY = new TimeSpan(0, 0, 1);
        private float RateOfChange = 0.0F; // the rate-of-change, in cm/s

        public EyesController(Cpu.Pin controlPin)
        {
            Ping Eye = new Ping(controlPin);
        }

        #region Public Properties

        /// <summary>
        /// The rate-of-change of distance, in cm/s
        /// </summary>
        public readonly float Rate
        {
            get
            {
                return this.RateOfChange;
            }
        }

        #endregion

        public void wake()
        {
        }


        public void update()
        {
            if ((DateTime.Now - LastUpdate) > UPDATE_FREQUENCY)
            {
                int newDistance = Eye.Distance();
                int deltaDist = (LastDistance - newDistance);
                int deltaTime = (LastUpdate - DateTime.Now).Seconds;

                this.RateOfChange = ((float)deltaDist / (float)deltaTime);
                this.LastDistance = newDistance;
                this.LastUpdate = DateTime.Now;
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
