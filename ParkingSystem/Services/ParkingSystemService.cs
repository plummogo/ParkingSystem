using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingSystem.Services
{
    internal class ParkingSystemService
    {
        private Cars _incomingCar;
        private List<Slots> _slots;
        private bool _freeSpace;

        public ParkingSystemService(Cars incomingCar, List<Slots> slots)
        {
            _incomingCar = incomingCar;
            _slots = slots;
            _freeSpace = false;
        }

        public bool IsCarValid()
        {
            return _incomingCar.PlateNumber.Any() && _incomingCar.Size.ToString().Any();
        }

        public bool ValidateSpace()
        {
            foreach (var slot in _slots)
            {
                if (slot.Car.PlateNumber.Any())
                {
                    return !_freeSpace;
                }
            }

            return _freeSpace;
        }

        public Slots ValidateSize()
        {
            switch (_incomingCar.Size)
            {
                case Sizes.Large:
                    return _slots.Find(x => x.Sizes == Sizes.Large && !x.Car.PlateNumber.Any());
                case Sizes.Medium:
                    return _slots.Find(x => (x.Sizes == Sizes.Large || x.Sizes == Sizes.Medium)
                                                && !x.Car.PlateNumber.Any());
                case Sizes.Small:
                    return _slots.Find(x => !x.Car.PlateNumber.Any());
                default:
                    return new Slots();
            }
        }

        public void ParkSlot(Slots parkingSlot)
        {
            if (_freeSpace)
            {
                parkingSlot.Car = _incomingCar;
            }
        }

    }
}
