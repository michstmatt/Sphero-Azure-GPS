using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
namespace SpheroFrontend
{
    class SpheroHelper
    {







        public static Point parseString(string command)
        {
            try
            {
                command = command.Replace("move to location", "");

            }
            catch { }
            command = command.Replace(" ", "");
            command = command.Replace(".", "");
            string[] arr = new string[2];
            if (command.Contains("comma"))
            {
                arr[0] = command.Substring(0, command.IndexOf("comma"));
                arr[1] = command.Remove(0, 5 + arr[0].Length);
            }
            else if (command.Contains(","))
            {
                arr = command.Split(',');
            }
            int xPos, yPos;
            try { xPos = int.Parse(arr[0]); }
            catch { xPos = getNumber(arr[0]); }
            try { yPos = int.Parse(arr[1]); }
            catch { yPos = getNumber(arr[1]); }

            Point p = new Point(xPos, yPos);
            AzureHelper.sendMessageToQueue(p);
            return p;

        }

        public static int getNumber(string num)
        {
            switch (num)
            {
                case "one":
                    return 1;
                case "two":
                    return 2;
                case "three":
                    return 3;
                case "four":
                    return 4;
                case "five":
                    return 5;
                case "six":
                    return 6;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
                case "nine":
                    return 9;
            }
            return 0;
        }
    }
   
}
