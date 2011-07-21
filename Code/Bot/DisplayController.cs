using System;
using Bot.Libs;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using System.Threading;

namespace Bot
{
    class DisplayController
    {
        private ShiftRegister LEDShifter;
        private int LEDStates;

        public enum LEDs
        {
            LED0 = 1,
            LED1 = 2,
            LED2 = 4,
            LED3 = 8,
            LED4 = 16,
            LED5 = 32,
            LED6 = 64,
            LED7 = 128
        }


        public DisplayController(Cpu.Pin latchPin, Cpu.Pin clockPin, Cpu.Pin dataPin)
        {
            LEDShifter = new ShiftRegister(1, latchPin, clockPin, dataPin);
        }


        public void SetLED(LEDs led, bool state)
        {
            if (state)
            {
                LEDStates = (LEDStates | (int)led);
            }
            else
            {
                LEDStates = (LEDStates & ~((int)led));
            }
        }


        public void Wake()
        {
            // Turn all LEDs on in sequence
            for (int i = 1; i < 128; i *= 2)
            {
                SetLED((LEDs)i, true);
                Update();
                Thread.Sleep(200);
            }
            // Turn them off again
            for (int i = 1; i < 128; i *= 2)
            {
                SetLED((LEDs)i, false);
                Update();
                Thread.Sleep(200);
            }
            // Turn them all on
            LEDStates = 127;
            Update();
            Thread.Sleep(300); 
            
            // Turn them all off
            LEDStates = 0;
            Update();
        }


        public void Update()
        {
            LEDShifter.WriteInt(LEDStates);
        }

    }
}
