using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem
{
    internal static class Helper
    {
        private static List<Cars> _cars;
        public static List<Cars> FillDummyCars()
        {
            _cars = new List<Cars>();

            _cars.Add(new Cars() { PlateNumber = string.Empty, Size = Sizes.Large });
            _cars.Add(new Cars() { PlateNumber = string.Empty, Size = Sizes.Medium });
            _cars.Add(new Cars() { PlateNumber = string.Empty, Size = Sizes.Small });

            return _cars;
        }

        public static List<Slots> FillDummySlots()
        {
            var slots = new List<Slots>();

            _cars.ForEach(car => slots.Add(new Slots() { Car = car, Sizes = Sizes.Large }));

            return slots;
        }
    }
}
