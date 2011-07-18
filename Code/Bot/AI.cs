using System;
using Microsoft.SPOT;

namespace Bot
{
    class AI
    {
        private enum State
        {
            IDLE = 0,
            CRUISING = 1
        }

        private WheelsController MyWheels;
        private EyesController MyEyes;
        private NeckController MyNeck;

        private bool KeepAlive = false;

        private State CurrentState = State.IDLE;

        
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

        private think()
        {
        }

    }
}
