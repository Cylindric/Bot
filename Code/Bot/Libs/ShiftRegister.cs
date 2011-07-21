using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;


namespace Bot.Libs
{
    public class ShiftRegister : IDisposable
    {
        private readonly short _numRegisters;
        private readonly BitOrder _bitOrder;
        private readonly OutputPort _dataPort;
        private readonly OutputPort _clockPort;
        private readonly OutputPort _latchPort;

        public ShiftRegister(short numRegisters, Cpu.Pin latchPin, Cpu.Pin clockPin, Cpu.Pin dataPin)
            : this(numRegisters, latchPin, clockPin, dataPin, BitOrder.MSBFirst)
        { }


        /// <summary>
        /// Code for using a 74HC595 Shift Register
        /// </summary>
        /// <param name="numRegisters">Number of shift register connected in series</param>
        /// <param name="latchPin">Pin connected to ST_CP of 74HC595</param>
        /// <param name="clockPin">Pin connected to SH_CP of 74HC595</param>
        /// <param name="dataPin">Pin connected to DS of 74HC595</param>
        /// <param name="bitOrder"></param>
        public ShiftRegister(short numRegisters, Cpu.Pin latchPin, Cpu.Pin clockPin, Cpu.Pin dataPin, BitOrder bitOrder)
        {
            _numRegisters = numRegisters;
            _bitOrder = bitOrder;

            _latchPort = new OutputPort(latchPin, false);
            _clockPort = new OutputPort(clockPin, false);
            _dataPort = new OutputPort(dataPin, false);
        }

        public void WriteInt(int value)
        {
            byte low = (byte)(value & 0xFF);
            byte high = (byte)(value >> 8);

            Write(low, high);
        }

        public void Write(params byte[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (buffer.Length > _numRegisters) throw new ArgumentOutOfRangeException("buffer");

            // Ground latchPin and hold low for as long as you are transmitting
            _latchPort.Write(false);

            for (int i = 0; i < buffer.Length; i++)
            {
                ShiftOut(buffer[i]);
            }

            // Pulse the latch pin high to signal chip that it 
            // no longer needs to listen for information
            _latchPort.Write(true);
            _latchPort.Write(false);
        }

        private void ShiftOut(byte value)
        {
            // Lower Clock
            _clockPort.Write(false);

            byte mask;
            for (int i = 0; i < 8; i++)
            {
                if (_bitOrder == BitOrder.LSBFirst)
                    mask = (byte)(1 << i);
                else
                    mask = (byte)(1 << (7 - i));

                _dataPort.Write((value & mask) != 0);

                // Raise Clock
                _clockPort.Write(true);

                // Raise Data to prevent IO conflict 
                _dataPort.Write(true);

                // Lower Clock
                _clockPort.Write(false);
            }
        }

        public int OutputCount
        {
            get { return _numRegisters * 8; }
        }

        public enum BitOrder
        {
            MSBFirst,
            LSBFirst
        }

        public void Dispose()
        {
            _dataPort.Dispose();
            _clockPort.Dispose();
            _latchPort.Dispose();
        }
    }
}
