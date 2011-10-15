using System.Threading;
using Microsoft.SPOT.Hardware;
using Bot.Libs;
using System;

namespace Bot
{
    public class NeckController
    {
        // calibration constants
        private const int AHEAD = 80;

        private int CurrentAngle = 0;
        private int RequestedAngle = 0;

        private Servo_API.Servo NeckServo;

        
        public NeckController(Cpu.Pin controlPort)
        {
            NeckServo = new Servo_API.Servo(controlPort);
        }


        /// <summary>
        /// Wake up the neck, and perform a quick sweep to indicate functional status.
        /// </summary>
        public void Wake()
        {
            SetAngle(-30);
            Thread.Sleep(400);
            SetAngle(30);
            Thread.Sleep(400);
            SetAngle(0);
        }

        
        /// <summary>
        /// Set the neck to the required angle.
        /// Note that angle is negative for left, and positive for right.
        /// </summary>
        /// <param name="angle">The desired angle, between -90 and 90.</param>
        public void SetAngle(int angle)
        {
            RequestedAngle = DegreesToServo(angle);
            CurrentAngle = RequestedAngle;
            NeckServo.Degree = RequestedAngle;
        }


        /// <summary>
        /// Put the neck to sleep; parks the neck at zero angle.
        /// </summary>
        public void Sleep()
        {
            NeckServo.Degree = AHEAD;
        }


        /// <summary>
        /// Convert an angle given in the range -90 to 90, to an angle
        /// between 0 and 180 for the servo.
        /// Angle will be constrained to the calibration minima and maxima.
        /// </summary>
        /// <param name="angle">Centre-relative angle to convert</param>
        /// <returns>Absolute neck angle</returns>
        private int DegreesToServo(int angle)
        {
            return Tools.Constrain(angle + AHEAD, 0, 180);
        }

    }
}
