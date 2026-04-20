using System;

class Staff
{
    public int StaffId;
    public string Name;
    public double BaseSalary;

    public Staff(int id, string name, double salary)
    {
        StaffId = id;
        Name = name;
        BaseSalary = salary;
    }

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

class Doctor : Staff
{
    public double ConsultationFee;

    public Doctor(int id, string name, double salary, double fee)
        : base(id, name, salary)
    {
        ConsultationFee = fee;
    }

    public override double CalculateSalary()
    {
        return BaseSalary + ConsultationFee;
    }
}

class Nurse : Staff
{
    public double NightShiftAllowance;

    public Nurse(int id, string name, double salary, double allowance)
        : base(id, name, salary)
    {
        NightShiftAllowance = allowance;
    }

    public override double CalculateSalary()
    {
        return BaseSalary + NightShiftAllowance;
    }
}

class LabTechnician : Staff
{
    public double EquipmentAllowance;

    public LabTechnician(int id, string name, double salary, double allowance)
        : base(id, name, salary)
    {
        EquipmentAllowance = allowance;
    }

    public override double CalculateSalary()
    {
        return BaseSalary + EquipmentAllowance;
    }
}

class Q1_HealthcareSalarySystem
{
    static void Main()
    {
        Staff s1 = new Doctor(1, "Doctor", 50000, 10000);
        Staff s2 = new Nurse(2, "Nurse", 30000, 5000);
        Staff s3 = new LabTechnician(3, "Tech", 25000, 3000);

        Console.WriteLine(s1.CalculateSalary());
        Console.WriteLine(s2.CalculateSalary());
        Console.WriteLine(s3.CalculateSalary());
    }
}
