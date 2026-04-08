using System;

class Q4_Appointment
{
    public int AppointmentId;
    public string PatientName;
    public string DoctorName;
    public DateTime AppointmentDate;

    public Q4_Appointment()
    {
        DoctorName = "General Physician";
        AppointmentDate = DateTime.Today;
    }

    public void Display()
    {
        Console.WriteLine("Appointment Id: " + AppointmentId);
        Console.WriteLine("Patient Name: " + PatientName);
        Console.WriteLine("Doctor Name: " + DoctorName);
        Console.WriteLine("Appointment Date: " + AppointmentDate.ToShortDateString());
        Console.WriteLine();
    }
}
