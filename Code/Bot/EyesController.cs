using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Bot.Libs;
using System.Threading;

namespace Bot
{
    class EyesController
    {
        private Ping Eye;
        private double LastDistance = 0;
        private DateTime LastUpdate = DateTime.MinValue;
        private TimeSpan UPDATE_FREQUENCY = new TimeSpan(0, 0, 0, 0, 500);
        private double RateOfChange = 0.0F;

        public EyesController(Cpu.Pin controlPin)
        {
            Eye = new Ping(controlPin);
            Eye.Unit = DistanceUnits.cm;
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

        public double Distance
        {
            get
            {
                return this.LastDistance;
            }
        }

        #endregion

        /// <summary>
        /// Wake up the eye, and perform an initial ping.
        /// </summary>
        public void Wake()
        {
            Eye.GetDistance();
        }


        /// <summary>
        /// Perform an update; sends a ping if time since last ping exceeds UPDATE_FREQUENCY
        /// </summary>
        public void Update()
        {
            if ((DateTime.Now - LastUpdate) > UPDATE_FREQUENCY)
            {
                Ping();
            }
        }


        /// <summary>
        /// Send a ping and return the distance to the nearest object.
        /// </summary>
        /// <returns>Distance in cm</returns>
        public double Ping()
        {
            double newDistance = Eye.GetDistance();
            double deltaDist = (LastDistance - newDistance);
            double deltaTime = Tools.TotalMilliseconds(LastUpdate - DateTime.Now);

            RateOfChange = (deltaDist / deltaTime)*1000;
            LastDistance = newDistance;
            Debug.Print("EYES: Distance: " + newDistance + ", Rate: " + RateOfChange);
            LastUpdate = DateTime.Now;
            return newDistance;
        }

    }
}
