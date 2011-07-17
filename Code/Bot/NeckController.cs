using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.Threading;

namespace Bot
{
    class NeckController : iController
    {
        private const int AHEAD = 95;
        private const int LEFT = 50;
        private const int RIGHT = 140;

        private Servo_API.Servo NeckServo;

        public NeckController(Cpu.Pin controlPort)
        {
            NeckServo = new Servo_API.Servo(controlPort);
        }

        public void wake()
        {
            NeckServo.Degree = AHEAD;
            Thread.Sleep(200);

            NeckServo.Degree = LEFT;
            Thread.Sleep(400);
            NeckServo.Degree = RIGHT;
            Thread.Sleep(400);
            NeckServo.Degree = AHEAD;
        }

        public void update()
        {
        }

        public void sleep()
        {
            NeckServo.Degree = AHEAD;
        }

    }
}
