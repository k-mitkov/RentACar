using System.ComponentModel;

namespace Data.Enums
{
    public enum TypeVehicle
    {
        [Description("strCars")]
        Car,
        [Description("strECars")]
        Electric,
        [Description("strCargo")]
        Freight
    }
}
