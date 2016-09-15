using System;
namespace KMC.Northwind.Demo.Tests.Common.Helpers
{
    public class StringHelper
    {
        public static string GenerateRandomNumber()
        {
            Random randnum = new Random();
            return ((long)randnum.Next(0, 100000) * (long)randnum.Next(0, 100000)).ToString().PadLeft(10, '0');
        }
    }
}
