using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.Threading;

namespace Bot
{
    class MovementController : iController
    {
        private Wheel LeftWheel;
        private Wheel RightWheel;
        private DateTime LastUpdate;


        public MovementController(Cpu.Pin PinLA, Cpu.Pin PinLB, Cpu.Pin PinLP, Cpu.Pin PinRA, Cpu.Pin PinRB, Cpu.Pin PinRP)
        {
            LeftWheel = new Wheel(PinLA, PinLB, PinLP);
            RightWheel = new Wheel(PinRA, PinRB, PinRP);
        }


        public void wake()
        {
            LeftWheel.setSpeed(10);
            RightWheel.setSpeed(10);
            LeftWheel.update();
            RightWheel.update();
            Thread.Sleep(200);

            LeftWheel.setSpeed(-10);
            RightWheel.setSpeed(-10);
            LeftWheel.update();
            RightWheel.update();
            Thread.Sleep(200);

            LeftWheel.setSpeed(0);
            RightWheel.setSpeed(0);
            LeftWheel.update();
            RightWheel.update();
        }


        public void update()
        {
            LeftWheel.update();
            RightWheel.update();
            LastUpdate = DateTime.Now;
        }


        public void stop()
        {
            LeftWheel.setSpeed(0);
            RightWheel.setSpeed(0);
        }


        public void forward(int speed)
        {
            LeftWheel.setSpeed(speed);
            RightWheel.setSpeed(speed);
        }

    }
}
