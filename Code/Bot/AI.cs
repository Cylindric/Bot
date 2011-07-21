using System;
using Microsoft.SPOT;
using System.Threading;

namespace Bot
{
    class AI
    {
        public enum AIState
        {
            dead = 0,
            idle = 1,
            cruising = 2,
            approach = 3
        }

        private const int MAX_DISTANCE = 1000;
        private const int MIN_DISTANCE = 0;
        private const int SCAN_ANGLE = 5;

        private WheelsController MyWheels;
        private EyesController MyEyes;
        private NeckController MyNeck;

        private AIState CurrentState = AIState.idle;
        private DateTime LastUpdate = DateTime.Now;
        
        public AI()
        {
        }


        #region Private Properties

        public AIState State
        {
            get
            {
                return CurrentState;
            }
        }

        public WheelsController Wheels
        {
            get
            {
                return MyWheels;
            }
            set
            {
                MyWheels = value;
            }
        }

        public EyesController Eyes
        {
            get
            {
                return MyEyes;
            }
            set
            {
                MyEyes = value;
            }
        }

        public NeckController Neck
        {
            get
            {
                return MyNeck;
            }
            set
            {
                MyNeck = value;
            }
        }

        #endregion


        public void wake()
        {
            MyWheels.Wake();
            MyEyes.Wake();
            MyNeck.Wake();
            CurrentState = AIState.cruising;
        }


        public void Update()
        {
            // update inputs
            MyEyes.Update();

            // process data
            Think();

            // update outputs
            MyWheels.Update();
        }


        public void Sleep()
        {
            MyWheels.Sleep();
        }

        /// <summary>
        /// Process the incoming data and update the state.
        /// 
        /// States are:
        /// * IDLE:     Bot is idle.
        /// * CRUISING: Bot is moving forwards.
        ///             May be accelerating due to ease-in.
        /// * APPROACH: Bot is aproaching an obstacle.
        ///             Response depends on rate-of-approach.
        /// </summary>
        private void Think()
        {
            if (CurrentState == AIState.cruising)
            {
                double distance = MyEyes.Distance;
                if (distance < 20)
                {
                    MyWheels.Stop();
                    FindClosestBearing();
                }
                else
                {
                    MyWheels.SetSpeed(100);
                }
            }
        }


        /// <summary>
        /// Perform a sensor-sweep to locate the nearest object, and return it's bearing
        /// </summary>
        /// <returns>Angle to nearest object</returns>
        public int FindClosestBearing()
        {
            int closestAngle = 0;
            double distance = 0;
            double closestDistance = MAX_DISTANCE;

            for (int angle = -90; angle <= 90; angle += SCAN_ANGLE)
            {
                MyNeck.SetAngle(angle);
                Thread.Sleep(50);
                distance = MyEyes.Ping();
                if (distance < closestDistance)
                {
                    Debug.Print("Closer object found at " + angle + " bearing and " + distance + " range");
                    closestDistance = distance;
                    closestAngle = angle;
                }
            }

            // return to previous position
            MyNeck.SetAngle(closestAngle);

            Debug.Print("Closest object found at " + closestAngle + " bearing and " + closestDistance + " range");
            return closestAngle;
        }

    }
}