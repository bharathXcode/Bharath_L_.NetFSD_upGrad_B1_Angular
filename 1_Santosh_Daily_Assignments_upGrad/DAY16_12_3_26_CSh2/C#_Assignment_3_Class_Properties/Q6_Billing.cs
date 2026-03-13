using System;

class Q6_Billing
{
    public string PatientName;
    public double ConsultationFee;
    public double TestCharges;

    public double CalculateTotalBill()
    {
        return ConsultationFee + TestCharges;
    }

    public void Display()
    {
        Console.WriteLine("Patient Name: " + PatientName);
        Console.WriteLine("Total Bill: " + CalculateTotalBill());
        Console.WriteLine();
    }
}