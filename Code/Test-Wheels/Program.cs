using System.Threading;
using Bot;
using Microsoft.SPOT;

namespace Test_Wheels
{
    public class Program
    {
        static Wheel leftWheel = new Wheel(GlobalPins.LEFT_WHEEL_PIN_A, GlobalPins.LEFT_WHEEL_PIN_B, GlobalPins.LEFT_WHEEL_PIN_P);
        static Wheel rightWheel = new Wheel(GlobalPins.RIGHT_WHEEL_PIN_A, GlobalPins.RIGHT_WHEEL_PIN_B, GlobalPins.RIGHT_WHEEL_PIN_P);
        
        public static void Main()
        {

            FindMin();

            // rotate right
            leftWheel.SetSpeed(100);
            rightWheel.SetSpeed(-100);
            leftWheel.Update();
            rightWheel.Update();
            Thread.Sleep(1000);

            // rotate left
            leftWheel.SetSpeed(-100);
            rightWheel.SetSpeed(100);
         
            leftWheel.Update();
            rightWheel.Update();
            Thread.Sleep(2000);

            // rotate right
            leftWheel.SetSpeed(100);
            rightWheel.SetSpeed(-100);
            leftWheel.Update();
            rightWheel.Update();
            Thread.Sleep(1000);

            // stop
            leftWheel.SetSpeed(0);
            rightWheel.SetSpeed(0);
            leftWheel.Update();
            rightWheel.Update();
        }

        private static void FindMin()
        {
            leftWheel.SetSpeed(0);
            rightWheel.SetSpeed(0);
            leftWheel.Update();
            rightWheel.Update();

            for (int speed = 42; speed < 100; speed += 1)
            {
                leftWheel.SetSpeed(speed);
                leftWheel.Update();
                Debug.Print("Trying left speed " + speed);
                Thread.Sleep(500);
            }

            leftWheel.SetSpeed(0);
            leftWheel.Update();

            for (int speed = 42; speed < 100; speed += 1)
            {
                rightWheel.SetSpeed(speed);
                rightWheel.Update();
                Debug.Print("Trying right speed " + speed);
                Thread.Sleep(500);
            }

            rightWheel.SetSpeed(0);
            rightWheel.Update();
            Thread.Sleep(2000);

        }

    }
}
