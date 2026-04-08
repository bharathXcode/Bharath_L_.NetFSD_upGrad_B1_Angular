using System;

class Q5_MedicalTest
{
    public int TestId;
    public string TestName;
    public double TestCost;

    public Q5_MedicalTest(int id, string name, double cost)
    {
        TestId = id;
        TestName = name;
        TestCost = cost;
    }

    public void Display()
    {
        Console.WriteLine("Test Id: " + TestId);
        Console.WriteLine("Test Name: " + TestName);
        Console.WriteLine("Test Cost: " + TestCost);
        Console.WriteLine();
    }
}
