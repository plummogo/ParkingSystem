using ParkingSystem.Services;
using System;

namespace ParkingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Fill Test Data
            var cars = Helper.FillDummyCars();
            Helper.FillDummySlots();
            #endregion

            var parkingSystemService = new ParkingSystemService();
        }
    }
}
