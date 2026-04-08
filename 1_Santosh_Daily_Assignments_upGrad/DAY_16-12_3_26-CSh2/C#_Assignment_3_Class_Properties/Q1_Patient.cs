using System;

class Q1_Patient
{
    public int PatientId;
    public string PatientName;
    public int Age;
    public string Disease;

    public void Display()
    {
        Console.WriteLine("Patient Id: " + PatientId);
        Console.WriteLine("Patient Name: " + PatientName);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Disease: " + Disease);
        Console.WriteLine();
    }
}
