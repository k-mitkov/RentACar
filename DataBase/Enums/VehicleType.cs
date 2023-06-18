using System.ComponentModel;

namespace DataBase.Enums
{
    public enum VehicleType
    {
        [Description("strCars")]
        Car,
        [Description("strECars")]
        Electric,
        [Description("strCargo")]
        Freight
    }
}
