using System;

class Q8_PatientRecord
{
    public static string HospitalName;

    public int PatientId;
    public string PatientName;
    public int Age;
    public string Disease;

    public Q8_PatientRecord(int id, string name, int age, string disease)
    {
        PatientId = id;
        PatientName = name;
        Age = age;
        Disease = disease;
    }

    public void DisplayPatientRecord()
    {
        Console.WriteLine("Hospital: " + HospitalName);
        Console.WriteLine("Patient Id: " + PatientId);
        Console.WriteLine("Name: " + PatientName);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Disease: " + Disease);
        Console.WriteLine();
    }
}
