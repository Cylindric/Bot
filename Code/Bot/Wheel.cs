using System;
using Bot.Libs;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;

namespace Bot
{
    class Wheel
    {
        private OutputPort ControlPortA;
        private OutputPort ControlPortB;
        private PWM ControlPortP;
        private int MinPower; // Anything less than this will be treated as zero.
        private int MaxPower; // Anthing more than this will be treated as 100.

        private int CurrentSpeed;
        private int RequestedStartSpeed;
        private int RequestedTargetSpeed;
        private DateTime SpeedRequestedAt;
        private DateTime SpeedRequestedFor;

        private DateTime LastUpdate;

        public Wheel(Cpu.Pin controlPortA, Cpu.Pin controlPortB, Cpu.Pin powerPort)
        {
            MinPower = 50;
            MaxPower = 100;
            ControlPortA = new OutputPort(controlPortA, false);
            ControlPortB = new OutputPort(controlPortB, false);
            ControlPortP = new PWM(powerPort);
            setSpeed(0, 0);
            update();
        }


        public void setSpeed(int speed, ulong time = 0)
        {
            SpeedRequestedAt = DateTime.Now;
            SpeedRequestedFor = SpeedRequestedAt.AddMilliseconds(time);
            RequestedStartSpeed = CurrentSpeed;
            RequestedTargetSpeed = Tools.Constrain(speed, -100, 100);
        }


        public void update()
        {
            // Calculate the required speed, based on the requested speed and when it was requested for.
            // If the requested time has elapsed, just do it now
            if (SpeedRequestedFor <= DateTime.Now)
            {
                CurrentSpeed = RequestedTargetSpeed;
            }
            else
            {
                long ElapsedMillis = (DateTime.Now - SpeedRequestedAt).Milliseconds;
                long TotalMillis = (SpeedRequestedFor - SpeedRequestedAt).Milliseconds;
                float progress = 1;
                if (TotalMillis == 0)
                {
                    progress = ((float)ElapsedMillis / (float)TotalMillis);
                }
                long delta = RequestedTargetSpeed - RequestedStartSpeed;
                CurrentSpeed = RequestedStartSpeed + (int)(delta * progress);
            }

            // Apply the calculated speed to the wheel
            setPower(CurrentSpeed);

            LastUpdate = DateTime.Now;
        }

        public void sleep()
        {
        }


        /// <summary>
        /// Sets the speed of the wheel.
        /// Specify a number in the range of -100 to 100, with negative being reverse
        /// and positive being forwards.
        /// Specifying zero will stop the wheel, and apply inductive breaking.
        /// </summary>
        /// <param name="power">The desired speed, from -100 to 100</param>
        private void setPower(int power)
        {
            // Set the direction of the wheels using the H-Bridge control lines
            if (power > 0) // forwards
            {
                ControlPortA.Write(true);
                ControlPortB.Write(false);
            }
            else if (power < 0) // reverse
            {
                ControlPortA.Write(false);
                ControlPortB.Write(true);
            }
            else // stop
            {
                ControlPortA.Write(false);
                ControlPortB.Write(false);
            }

            // Apply the requested power to the H-Bridge power line, after calibrating
            int realPower = System.Math.Abs(power);
            realPower = Tools.Map(realPower, 0, 100, MinPower, MaxPower);

            ControlPortP.SetDutyCycle((uint)realPower);
        }

    }
}
