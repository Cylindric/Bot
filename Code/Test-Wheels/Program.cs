using System.Threading;
using Bot;

namespace Test_Wheels
{
    public class Program
    {
        public static void Main()
        {
            Wheel leftWheel = new Wheel(GlobalPins.LEFT_WHEEL_PIN_A, GlobalPins.LEFT_WHEEL_PIN_B, GlobalPins.LEFT_WHEEL_PIN_P);
            Wheel rightWheel = new Wheel(GlobalPins.RIGHT_WHEEL_PIN_A, GlobalPins.RIGHT_WHEEL_PIN_B, GlobalPins.RIGHT_WHEEL_PIN_P);

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

    }
}
