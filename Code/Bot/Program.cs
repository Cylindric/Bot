using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Bot.Libs;

namespace Bot
{
    public class Program
    {
        public static void Main()
        {
            bool ledState = true;
            OutputPort led = new OutputPort(Pins.ONBOARD_LED, ledState);

            // some counters for monitoring the "fps"
            ulong frameCount = 0;
            DateTime startTime = DateTime.Now;
            TimeSpan runningTime;
            float fps = 0;

            AI ai = new AI();
            ai.Wheels = new WheelsController(GlobalPins.LEFT_WHEEL_PIN_A, GlobalPins.LEFT_WHEEL_PIN_B, GlobalPins.LEFT_WHEEL_PIN_P, GlobalPins.RIGHT_WHEEL_PIN_A, GlobalPins.RIGHT_WHEEL_PIN_B, GlobalPins.RIGHT_WHEEL_PIN_P);
            ai.Neck = new NeckController(GlobalPins.NECK_PIN);
            ai.Eyes = new EyesController(GlobalPins.EYE_PIN);
            //ai.Display = new DisplayController(Pins.GPIO_PIN_D13, Pins.GPIO_PIN_D12, Pins.GPIO_PIN_D11);

            //ai.Wheels.SetSpeed(100); ai.Wheels.Update(); Thread.Sleep(1000);
            //ai.Wheels.SetSpeed(0); ai.Wheels.Update(); Thread.Sleep(1000);
            //ai.Wheels.SetSpeed(-100); ai.Wheels.Update(); Thread.Sleep(1000);
            //ai.Wheels.SetSpeed(0); ai.Wheels.Update(); Thread.Sleep(1000);
            //ai.Wheels.SetSpeed(WheelsController.Direction.left, 100); ai.Wheels.Update(); Thread.Sleep(1000);
            //ai.Wheels.SetSpeed(0); ai.Wheels.Update(); Thread.Sleep(1000);
            //while (true) ;

            ai.wake();

            while (ai.State != AI.AIState.dead)
            {
                ai.Update();
                frameCount++;

                // Every few frames spit out an FPS counter
                if ((frameCount % 100) == 0)
                {
                    runningTime = DateTime.Now - startTime;
                    fps = (float)frameCount / Tools.TotalMilliseconds(runningTime);
                    fps = fps * 1000;
                    //Debug.Print("FPS: " + frameCount + ": " + fps.ToString());
                    ledState = !ledState;
                }

                led.Write(ledState);
            }

            ai.Sleep();

        }



    }


 
}
