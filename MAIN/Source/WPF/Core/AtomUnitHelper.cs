#if NETFX_CORE
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Core
{

    /// <summary>
    /// Helps with basic unit conversion.
    /// </summary>
    public class AtomUnitHelper
    {

        /// <summary>
        /// Converts foot and inch value to centimeter.
        /// </summary>
        /// <param name="footValue"></param>
        /// <param name="inchValue"></param>
        /// <returns></returns>
        public static double ConvertToCM(double footValue, double inchValue) {
            double c = footValue * 30.48 + inchValue * 2.54;
            c = Math.Round(c);
            return c;
        }

        /// <summary>
        /// Converts centimeters to foot and inch values.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="foot"></param>
        /// <param name="inch"></param>
        public static void ConvertToFoot(double value, ref double foot, ref double inch) {
            double cm = value;
            double f = Math.Floor(cm / 30.48);
            double i = Math.Round((cm / 2.54) - f * 12);
            if (i < 0 || i > 11)
            {
                f += 1;
                i = 0;
            }
            foot = f;
            inch = i;
        }

        /// <summary>
        /// Converts pounds to kilograms.
        /// </summary>
        /// <param name="lbs"></param>
        /// <returns></returns>
        public static double ConvertToKG(double lbs) {
            return lbs / 2.2;
        }


        /// <summary>
        /// Converts kilogram to pounds.
        /// </summary>
        /// <param name="kg"></param>
        /// <returns></returns>
        public static double ConvertToLBS(double kg) {
            return kg * 2.2;
        }

    }
}
