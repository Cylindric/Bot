using System;
using Microsoft.SPOT;
using System.Threading;

namespace Bot
{
    public class AI
    {
        public enum AIState
        {
            dead = 0,
            idle = 1,
            cruising = 2,
            approach = 3,
            backup = 4,
            backup_turn = 5,
            scanning = 6
        }

        private const int MAX_DISTANCE = 1000;
        private const int MIN_DISTANCE = 0;
        private const int SCAN_ANGLE = 90;
        private const int COLLIDE_DISTANCE = 20;
        private const int CLEAR_DISTANCE = 25;
        private const int TURN_TIME = 1000;

        private WheelsController MyWheels;
        private EyesController MyEyes;
        private NeckController MyNeck;
        //private DisplayController MyDisplay;

        private AIState CurrentState = AIState.idle;
        private DateTime LastUpdate = DateTime.Now;
        private DateTime BackupTurnStarted = DateTime.MinValue;
        
        public AI()
        {
        }


        #region Public Properties

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

        //public DisplayController Display
        //{
        //    get
        //    {
        //        return MyDisplay;
        //    }
        //    set
        //    {
        //        MyDisplay = value;
        //    }
        //}

        #endregion


        public void wake()
        {
            MyWheels.Wake();
            MyEyes.Wake();
            MyNeck.Wake();
            //MyDisplay.Wake();
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
            //MyDisplay.Update();
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
        /// * SCANNING: Looking for nearest obstacle.
        /// * APPROACH: Bot is aproaching an obstacle.
        ///             Response depends on rate-of-approach.
        /// </summary>
        private void Think()
        {
            switch (CurrentState)
            {
                case AIState.cruising:
                    if (MyEyes.Distance < COLLIDE_DISTANCE)
                    {
                        Debug.Print("Obstacle detected! Backing up");
                        MyWheels.Stop();
                        CurrentState = AIState.backup;
                        MyWheels.SetSpeed(-25);
                    }
                    else
                    {
                        MyWheels.SetSpeed(100);
                    }
                    break;

                case AIState.backup:
                    // reverse to clear object
                    if (MyEyes.Distance > CLEAR_DISTANCE)
                    {
                        Debug.Print("Obstacle cleared! turning");
                        CurrentState = AIState.backup_turn;
                        BackupTurnStarted = DateTime.MinValue;
                    }
                    break;

                case AIState.backup_turn:
                    if (BackupTurnStarted == DateTime.MinValue)
                    {
                        Debug.Print("Starting turn");
                        BackupTurnStarted = DateTime.Now;
                        MyWheels.SetSpeed(WheelsController.Direction.left, -25);
                    }
                    else if (BackupTurnStarted.AddMilliseconds(TURN_TIME) < DateTime.Now)
                    {
                        Debug.Print("Done turning");
                        CurrentState = AIState.cruising;
                    }

                    break;


                case AIState.scanning:
                    FindClosestBearing();
                    CurrentState = AIState.cruising;
                    break;
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
                Thread.Sleep(250);
                distance = MyEyes.Ping();
                if (distance < closestDistance)
                {
                    Debug.Print("Closer object found at " + angle + " bearing and " + distance + " range");
                    closestDistance = distance;
                    closestAngle = angle;
                }
            }

            // look at closest
            MyNeck.SetAngle(closestAngle);

            Debug.Print("Closest object found at " + closestAngle + " bearing and " + closestDistance + " range");
            return closestAngle;
        }

    }
}