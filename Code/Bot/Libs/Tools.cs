using System;
using Microsoft.SPOT;

namespace Bot.Libs
{
    class Tools
    {
        /// <summary>
        /// Constrains the value to the specified bounds.
        /// Anything lower than <paramref name="low"/> returns <paramref name="low"/>.
        /// Anything higher than <paramref name="high"/> returns <paramref name="high"/>.
        /// </summary>
        /// <param name="value">The value to clamp</param>
        /// <param name="low">The lower bound</param>
        /// <param name="high">The upper bound</param>
        /// <returns>value clamped between low and high</returns>
        public static int Constrain(int value, int low, int high)
        {
            if (value <= low) return low;
            if (value >= high) return high;
            return value;
        }


        /// <summary>
        /// Scales value to a range, based on it's position in a different range.
        /// </summary>
        /// <example>If value is 5 in a range of 0 to 10, and the equivalent
        /// position in a range of 0 to 100 is required, this will return 50:
        /// Map(5, 0, 10, 0, 100)</example>
        /// <param name="value">the value to map</param>
        /// <param name="fromLow">the original lower bound</param>
        /// <param name="fromHigh">the original upper bound</param>
        /// <param name="toLow">the target lower bound</param>
        /// <param name="toHigh">the target upper bound</param>
        /// <returns>value mapped to new range</returns>
        public static int Map(int value, int fromLow, int fromHigh, int toLow, int toHigh)
        {
            value = Constrain(value, fromLow, fromHigh);
            int OldRange = (fromLow - fromHigh);
            int NewRange = (toLow - toHigh);
            return (((value - fromHigh) * NewRange) / OldRange) + toHigh;
        }

    }
}
