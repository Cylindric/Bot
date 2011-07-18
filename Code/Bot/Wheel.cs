using System;
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
            RequestedTargetSpeed = Constrain(speed, -100, 100);
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
                float progress = ((float)ElapsedMillis / (float)TotalMillis);
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
            realPower = Map(realPower, 0, 100, MinPower, MaxPower);

            ControlPortP.SetDutyCycle((uint)realPower);
        }

        
        /// <summary>
        /// Constrains the value to the specified bounds.
        /// Anything lower than <paramref name="low"/> returns <paramref name="low"/>.
        /// Anything higher than <paramref name="high"/> returns <paramref name="high"/>.
        /// </summary>
        /// <param name="value">The value to clamp</param>
        /// <param name="low">The lower bound</param>
        /// <param name="high">The upper bound</param>
        /// <returns>value clamped between low and high</returns>
        private int Constrain(int value, int low, int high)
        {
            if (value <= low) return low;
            if (value >= high) return high;
            return value;
        }


        /// <summary>
        /// Scales value to a range, based on it's position in a different range.
        /// </summary>
        /// <example>If value is 5 in a range of 0 to 10, and the equivalent
        /// position in a range of 0 to 100 is required, this will return 50:
        /// Map(5, 0, 10, 0, 100)</example>
        /// <param name="value">the value to map</param>
        /// <param name="fromLow">the original lower bound</param>
        /// <param name="fromHigh">the original upper bound</param>
        /// <param name="toLow">the target lower bound</param>
        /// <param name="toHigh">the target upper bound</param>
        /// <returns>value mapped to new range</returns>
        private int Map(int value, int fromLow, int fromHigh, int toLow, int toHigh)
        {
            value = Constrain(value, fromLow, fromHigh);
            int OldRange = (fromLow - fromHigh);
            int NewRange = (toLow - toHigh);
            return (((value - fromHigh) * NewRange) / OldRange) + toHigh;
        }
    }
}
