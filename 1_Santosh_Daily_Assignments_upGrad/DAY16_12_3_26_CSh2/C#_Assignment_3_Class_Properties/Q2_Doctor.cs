using System;

class Q2_Doctor
{
    public int DoctorId;
    public string DoctorName;
    public string Specialization;
    public double ConsultationFee;

    public void Display()
    {
        Console.WriteLine("Doctor Id: " + DoctorId);
        Console.WriteLine("Doctor Name: " + DoctorName);
        Console.WriteLine("Specialization: " + Specialization);
        Console.WriteLine("Consultation Fee: " + ConsultationFee);
        Console.WriteLine();
    }
}