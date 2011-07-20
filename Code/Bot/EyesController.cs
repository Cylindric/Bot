using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Bot.Libs;
using System.Threading;

namespace Bot
{
    class EyesController: iController
    {
        private Ping Eye;
        private double LastDistance = 0;
        private DateTime LastUpdate = DateTime.MinValue;
        private TimeSpan UPDATE_FREQUENCY = new TimeSpan(0, 0, 1);
        private double RateOfChange = 0.0F; // the rate-of-change, in cm/s

        public EyesController(Cpu.Pin controlPin)
        {
            this.Eye = new Ping(controlPin);
            this.Eye.Unit = DistanceUnits.cm;
        }

        #region Public Properties

        /// <summary>
        /// The rate-of-change of distance, in cm/s
        /// </summary>
        public double Rate
        {
            get
            {
                return this.RateOfChange;
            }
        }

        #endregion

        public void wake()
        {
            Thread.Sleep(100);
            this.Eye.GetDistance();
        }


        public void update()
        {
            if ((DateTime.Now - LastUpdate) > UPDATE_FREQUENCY)
            {
                this.ping();
            }
        }


        /// <summary>
        /// Send a ping and return the distance to the nearest object
        /// </summary>
        /// <returns>Distance in cm</returns>
        public double ping()
        {
            double newDistance = Eye.GetDistance();
            double deltaDist = (LastDistance - newDistance);
            double deltaTime = (LastUpdate - DateTime.Now).Milliseconds;

            this.RateOfChange = (deltaDist / deltaTime);
            this.LastDistance = newDistance;
            Debug.Print("EYES: Distance: " + newDistance + ", Rate: " + this.RateOfChange);
            this.LastUpdate = DateTime.Now;
            return newDistance;
        }


        public void sleep()
        {
        }


        public double distance()
        {
            return LastDistance;
        }

    }
}
