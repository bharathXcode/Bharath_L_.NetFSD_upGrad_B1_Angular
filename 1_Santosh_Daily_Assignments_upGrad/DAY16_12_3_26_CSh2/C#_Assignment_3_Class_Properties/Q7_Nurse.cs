using System;

class Q7_Nurse
{
    public int NurseId { get; set; }
    public string NurseName { get; set; }
    public string Department { get; set; }

    public void Display()
    {
        Console.WriteLine("Nurse Id: " + NurseId);
        Console.WriteLine("Nurse Name: " + NurseName);
        Console.WriteLine("Department: " + Department);
        Console.WriteLine();
    }
}