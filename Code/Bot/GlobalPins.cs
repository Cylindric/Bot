using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Bot
{
    public static class GlobalPins
    {
        public const Cpu.Pin LEFT_WHEEL_PIN_A = Pins.GPIO_PIN_D7;
        public const Cpu.Pin LEFT_WHEEL_PIN_B = Pins.GPIO_PIN_D8;
        public const Cpu.Pin LEFT_WHEEL_PIN_P = Pins.GPIO_PIN_D6;

        public const Cpu.Pin RIGHT_WHEEL_PIN_A = Pins.GPIO_PIN_D3;
        public const Cpu.Pin RIGHT_WHEEL_PIN_B = Pins.GPIO_PIN_D4;
        public const Cpu.Pin RIGHT_WHEEL_PIN_P = Pins.GPIO_PIN_D5;

        public const Cpu.Pin EYE_PIN = Pins.GPIO_PIN_D10;
        public const Cpu.Pin NECK_PIN = Pins.GPIO_PIN_D9;
    }
}
