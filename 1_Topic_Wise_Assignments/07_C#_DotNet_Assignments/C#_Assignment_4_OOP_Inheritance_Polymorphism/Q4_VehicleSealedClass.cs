using System;
using System.Collections.Generic;
using System.Text;

class Vehicle
{
    public string VehicleNumber;
    public string Brand;

    public void StartVehicle()
    {
        Console.WriteLine("Vehicle Started");
    }
}

class Car : Vehicle
{
    public string FuelType;
}

sealed class ElectricCar : Car
{
}

// ❌ Not allowed
// class Tesla : ElectricCar {}

class Q4_VehicleSealedClass
{
    static void Main()
    {
        ElectricCar car = new ElectricCar();
        car.StartVehicle();

        Console.WriteLine("ElectricCar is sealed and cannot be inherited");
    }
}
