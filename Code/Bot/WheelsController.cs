using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.Threading;

namespace Bot
{
    class WheelsController
    {
        private Wheel LeftWheel;
        private Wheel RightWheel;
        private DateTime LastUpdate;


        public WheelsController(Cpu.Pin PinLA, Cpu.Pin PinLB, Cpu.Pin PinLP, Cpu.Pin PinRA, Cpu.Pin PinRB, Cpu.Pin PinRP)
        {
            LeftWheel = new Wheel(PinLA, PinLB, PinLP);
            RightWheel = new Wheel(PinRA, PinRB, PinRP);
        }


        /// <summary>
        /// Wake up all wheels
        /// </summary>
        public void Wake()
        {
            LeftWheel.SetSpeed(10);
            RightWheel.SetSpeed(10);
            LeftWheel.Update();
            RightWheel.Update();
            Thread.Sleep(200);

            LeftWheel.SetSpeed(-10);
            RightWheel.SetSpeed(-10);
            LeftWheel.Update();
            RightWheel.Update();
            Thread.Sleep(200);

            LeftWheel.SetSpeed(0);
            RightWheel.SetSpeed(0);
            LeftWheel.Update();
            RightWheel.Update();
        }


        public void Update()
        {
            LeftWheel.Update();
            RightWheel.Update();
            LastUpdate = DateTime.Now;
        }


        /// <summary>
        /// Stop all wheels.
        /// </summary>
        /// <remarks>Takes effect at next Update().</remarks>
        public void Stop()
        {
            SetSpeed(0);
        }


        /// <summary>
        /// Put all wheels to sleep.  Stops all wheels.
        /// </summary>
        public void Sleep()
        {
            LeftWheel.Sleep();
            RightWheel.Sleep();
        }


        /// <summary>
        /// Set speed for all wheels.
        /// </summary>
        /// <param name="speed">Speed to apply.</param>
        /// <param name="time">Time to reach speed (millis)</param>
        public void SetSpeed(int speed, ulong time = 0)
        {
            LeftWheel.SetSpeed(speed, time);
            RightWheel.SetSpeed(speed, time);
        }

    }
}
