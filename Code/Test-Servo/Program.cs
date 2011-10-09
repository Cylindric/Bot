using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Bot.Libs;

namespace Test_Servo
{
    public class Program
    {
        public static void Main()
        {
            Servo_API.Servo servo = new Servo_API.Servo(Cpu.Pin.GPIO_Pin9);
            while (false)
            {
                for (int i = 0; i <= 180; i++)
                {
                    servo.Degree = i;
                    Thread.Sleep(10);
                }

                for (int i = 180; i >= 0; i--)
                {
                    servo.Degree = i;
                    Thread.Sleep(10);
                }
            }
        }

    }
}
