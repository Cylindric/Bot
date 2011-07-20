using System;
using Microsoft.SPOT;
using System.Threading;

namespace Bot
{
    class AI
    {
        private enum State
        {
            IDLE = 0,
            CRUISING = 1,
            APPROACH = 2
        }

        private const int MAX_DISTANCE = 1000;
        private const int MIN_DISTANCE = 0;
        private const int SCAN_ANGLE = 5;

        private WheelsController MyWheels;
        private EyesController MyEyes;
        private NeckController MyNeck;

        private bool KeepAlive = false;

        private State CurrentState = State.IDLE;
        private DateTime LastUpdate = DateTime.Now;
        
        public AI()
        {
        }


        #region Private Properties

        public bool Alive
        {
            get
            {
                return this.KeepAlive;
            }
            set
            {
                this.KeepAlive = true;
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
                return this.MyEyes;
            }
            set
            {
                this.MyEyes = value;
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
                this.MyNeck = value;
            }
        }

        #endregion


        public void wake()
        {
            this.MyWheels.wake();
            this.MyEyes.wake();
            this.MyNeck.wake();
            this.CurrentState = State.CRUISING;
            this.KeepAlive = true;
        }


        public void update()
        {
            // update inputs
            this.MyEyes.update();

            // process data
            this.think();

            // update outputs
            this.MyNeck.update();
            this.MyWheels.update();
        }


        public void sleep()
        {
            this.MyWheels.sleep();
            this.MyEyes.sleep();
            this.MyNeck.sleep();
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
        private void think()
        {
            if (this.CurrentState == State.CRUISING)
            {
                double distance = this.MyEyes.distance();
                if (distance < 20)
                {
                    this.MyWheels.stop();
                    this.findClosestBearing();
                }
                else
                {
                    this.MyWheels.forward(100);
                }
            }
        }


        public int findClosestBearing()
        {
            int closestAngle = 0;
            double distance = MAX_DISTANCE;
            double closestDistance = MAX_DISTANCE;

            for (int angle = -90; angle <= 90; angle += SCAN_ANGLE)
            {
                MyNeck.setAngle(angle);
                Thread.Sleep(50);
                distance = MyEyes.ping();
                if (distance < closestDistance)
                {
                    Debug.Print("Closer object found at " + angle + " bearing and " + distance + " range");
                    closestDistance = distance;
                    closestAngle = angle;
                }
            }

            // return to previous position
            MyNeck.setAngle(closestAngle);

            Debug.Print("Closest object found at " + closestAngle + " bearing and " + closestDistance + " range");
            return closestAngle;
        }

    }
}