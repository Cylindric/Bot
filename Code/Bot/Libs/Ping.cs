using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Bot.Libs
{
    public enum DistanceUnits
    {
        mm,
        cm,
        dm,
        m,
        feet,
        inch,
        yard
    }

    public class Ping
    {
        // Max hold-off for the ping to go high is 750 microseconds, round that up to 800 and convert to ticks.
        private const long PING_ECHO_HOLDOFF = 10000;

        // Max high-time for the ping return pulse is 18.5 milliseconds, round that up to 20 and convert to ticks.
        private const long PING_ECHO_MAXIMUM = 200000;

        private const long PING_MAX_TICKS = 220000;

        TristatePort _port;
        DistanceUnits _unit = DistanceUnits.mm;

        double _soundSpeed = 343, _convertion = (10000 / 343) * 2; // default values 

        public Ping(Cpu.Pin pin)
        {
            _port = new TristatePort(pin, false, false, ResistorModes.Disabled);
        }

        /// <summary> 
        /// Automaticly adjust the convertion factor depending on air temperature. 
        /// </summary> 
        /// <param name="degC">The temperature in degrees celsius</param> 
        public void AdjustSoundSpeed(double degC)
        {
            /* Speed of Sound (at 20 degrees celsius): 343 m/s 
             * or 
             * _soundSpeed = 331.4 + 0.6 * degC 
             *  
             * There are 10,000,000 ticks per second. 
             * 10,000,000 / _soundSpeed * 1000 can be simplyfied into: 
             * 10,000 / _soundSpeed 
             * times it by 2 because of round trip 
             * then you get about 58.309 ticks per mm 
             *  
             * then multiply if other unit is needed 
             *  
             */
            _soundSpeed = 331.4 + 0.6 * degC;
            _convertion = (10000 / _soundSpeed) * 2;
        }

        /// <summary> 
        /// Return the Ping))) sensor's reading in millimeters. 
        /// </summary> 
        /// <param name="usedefault">Set true to return value in the unit specified by the "Unit" property. 
        /// Set false to return value in mm.</param> 
        public double GetDistance()
        {
            bool low = true, high = true;
            long t0, t1, t2;

            // Set it to an putput 
            _port.Active = true;

            //Send a quick HIGH pulse 
            _port.Write(true);
            _port.Write(false);

            // Set it as an input 
            _port.Active = false;

            t1 = System.DateTime.Now.Ticks;
            while (low)
            {
                low = !_port.Read();
                t0 = System.DateTime.Now.Ticks - t1;
                if (t0 > PING_ECHO_HOLDOFF)
                {
                    return Convert(((PING_MAX_TICKS) / _convertion), _unit);
                }
            }
            t1 = System.DateTime.Now.Ticks;

            while (high)
            {
                high = _port.Read();
                t0 = System.DateTime.Now.Ticks - t1;
                if (t0 > PING_ECHO_MAXIMUM)
                {
                    return Convert(((PING_MAX_TICKS) / _convertion), _unit);
                }
            }
            t2 = System.DateTime.Now.Ticks;

            t0 = t2 - t1;
            return Convert((t0 / _convertion), _unit);
        }

        /// <summary> 
        /// Convert the millimeters into other units. 
        /// </summary> 
        /// <param name="millimeters">The Ping))) sensor's mm reading.</param> 
        /// <param name="outputUnit">The desired output unit.</param> 
        public double Convert(double millimeters, DistanceUnits outputUnit)
        {
            double result = millimeters;

            switch (outputUnit)
            {
                case DistanceUnits.cm:
                    result = millimeters * 0.1F;
                    break;
                case DistanceUnits.dm:
                    result = millimeters * 0.01F;
                    break;
                case DistanceUnits.m:
                    result = millimeters * 0.001F;
                    break;
                case DistanceUnits.inch:
                    result = millimeters * 0.0393700787;
                    break;
                case DistanceUnits.feet:
                    result = millimeters * 0.0032808399;
                    break;
                case DistanceUnits.yard:
                    result = millimeters * 0.0010936133;
                    break;
            }

            return result;
        }

        public DistanceUnits Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
    }
}
