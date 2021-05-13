using System;
using UIKit;

namespace ToDoApp.iOS.Extensions
{
    public static class UiColorExtensions
    {
        public static UIColor ToUiColor(this string hex) =>
            UIColor.FromRGB(
                HexadecimalToDecimal(hex.Substring(0, 2)),
                HexadecimalToDecimal(hex.Substring(2, 2)),
                HexadecimalToDecimal(hex.Substring(4, 2)));

        private static int HexadecimalToDecimal(string hex)
        {
            hex = hex.ToUpper();

            int hexLength = hex.Length;
            double dec = 0;

            for (int i = 0; i < hexLength; ++i)
            {
                byte b = (byte)hex[i];

                if (b >= 48 && b <= 57)
                    b -= 48;
                else if (b >= 65 && b <= 70)
                    b -= 55;

                dec += b * Math.Pow(16, hexLength - i - 1);
            }

            return (int)dec;
        }
    }
}
