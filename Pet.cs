
using System;

namespace JurassicParkColter
{
    class Dinosaur
    {
        public int EnclosureNumber { get; set; }

        public string DietType { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        public DateTime WhenAcquired { get; set; }

        public string Description()
        {
            var stringFormatForWhenAcquired = WhenAcquired.ToString("MM/dd/yyyy");
            var myOwnDescription = $"The {Name} is {Age} years old, a {DietType}, weights {Weight}lbs, was acquired on {stringFormatForWhenAcquired}, and is located in Enclosure {EnclosureNumber}.";

            return myOwnDescription;
        }

    }
}