using System;

class Q3_Hospital
{
    public static string HospitalName;
    public static string HospitalAddress;

    public string PatientName;

    public void Display()
    {
        Console.WriteLine("Hospital: " + HospitalName);
        Console.WriteLine("Address: " + HospitalAddress);
        Console.WriteLine("Patient: " + PatientName);
        Console.WriteLine();
    }
}
