using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VersionControlStressTest
{
    class My_Parse
    {
        /// <summary>
        /// Tries to parse the input value to a Int32.
        /// </summary>
        /// <param name="input">String input value</param>
        /// <returns>Parsed return value (Returns null if parse fails)</returns>
        public static Int32? ParseInt32OrNull(string input)
        {
            Int32 value;
            return Int32.TryParse(input, out value) ? (Int32?)value : null;
        }

        /// <summary>
        /// Tries to parse the input value to a Int32.
        /// </summary>
        /// <param name="input">String input value</param>
        /// <returns>Parsed return value (Returns 0 if parse fails)</returns>
        public static Int32 ParseInt32Or0(string input)
        {
            Int32 value;
            return Int32.TryParse(input, out value) ? value : 0;
        }

        /// <summary>
        /// Tries to parse the input value to a Int64.
        /// </summary>
        /// <param name="input">String input value</param>
        /// <returns>Parsed return value (Returns null if parse fails)</returns>
        public static Int64? ParseInt64OrNull(string input)
        {
            Int64 value;
            return Int64.TryParse(input, out value) ? (Int64?)value : null;
        }

        /// <summary>
        /// Tries to parse the input value to a Int64.
        /// </summary>
        /// <param name="input">String input value</param>
        /// <returns>Parsed return value (Returns 0 if parse fails)</returns>
        public static Int64 ParseInt64Or0(string input)
        {
            Int64 value;
            return Int64.TryParse(input, out value) ? value : 0;
        }

        /// <summary>
        /// Tries to parse the input value to a Int32.
        /// </summary>
        /// <param name="input">String input value</param>
        /// <returns>Parsed return value (Returns 0 if parse fails)</returns>
        public static Decimal ParseDecimalOr0(string input)
        {
            Decimal value;
            return Decimal.TryParse(input, out value) ? value : 0;
        }

        public static Boolean? ParseBoolOrNull(string input)
        {
            if (input.ToLower() == "false")
                return false;
            else if (input.ToLower() == "true")
                return true;
            else
                return null;
        }

        public static System.Drawing.Point ParsePointOrNewPoint(string input)
        {
            System.Drawing.Point p = new System.Drawing.Point(0, 0);

            // Validate input
            if (string.IsNullOrEmpty(input))
                return new System.Drawing.Point(0, 0);
            if (!input.Contains("X") || !input.Contains("Y"))
                return new System.Drawing.Point(0, 0);

            // Split passed in string into Array and declare X and Y variables
            string[] split = input.Split(',');
            int x = 0;
            int y = 0;

            // Validate input split length
            if (split.Length != 2)
                return new System.Drawing.Point(0, 0);

            // Loop through array elements and process
            for (int i = 0; i < split.Length; i++)
            {
                // Remove { and } that get added when saving a Point as a String
                split[i] = split[i].Replace("{", "");
                split[i] = split[i].Replace("}", "");

                // Search element for X and Y coordinates
                if (split[i].Contains("X="))
                    x = ParseInt32Or0(split[i].Replace("X=", ""));
                if (split[i].Contains("Y="))
                    y = ParseInt32Or0(split[i].Replace("Y=", ""));
            }

            // Create Point from X and Y coordinates
            p = new System.Drawing.Point(x, y);

            return p;
        }

        public static System.Drawing.Color ParseColorFromIntString(string input)
        {
            // Create return variable and assign a default value
            System.Drawing.Color returnValue = System.Drawing.Color.Empty;

            // Assign value to return variable based on passed in string value
            if (!string.IsNullOrEmpty(input))
            {
                // Color value is stored as an integer inside a string, here we convert the string
                // back to an integer value.
                int colorIntVal = ParseInt32Or0(input);

                // here we use Color.FromArbg() to turn our integer color value into a System.Drawing.Color value
                returnValue = System.Drawing.Color.FromArgb(colorIntVal);
            }

            return returnValue;
        }
    }
}
