using System;

class Program
{
    static void Main()
    {
        // Q1 Patient
        Q1_Patient p = new Q1_Patient();
        p.PatientId = 101;
        p.PatientName = "Ravi Kumar";
        p.Age = 45;
        p.Disease = "Diabetes";
        p.Display();

        // Q2 Doctor
        Q2_Doctor d1 = new Q2_Doctor();
        d1.DoctorId = 1;
        d1.DoctorName = "Dr. Sharma";
        d1.Specialization = "Cardiology";
        d1.ConsultationFee = 500;

        Q2_Doctor d2 = new Q2_Doctor();
        d2.DoctorId = 2;
        d2.DoctorName = "Dr. Mehta";
        d2.Specialization = "Neurology";
        d2.ConsultationFee = 700;

        d1.Display();
        d2.Display();

        // Q3 Hospital
        Q3_Hospital.HospitalName = "City Hospital";
        Q3_Hospital.HospitalAddress = "Bangalore";

        Q3_Hospital h1 = new Q3_Hospital();
        h1.PatientName = "Amit";

        Q3_Hospital h2 = new Q3_Hospital();
        h2.PatientName = "Ramesh";

        Q3_Hospital h3 = new Q3_Hospital();
        h3.PatientName = "Suresh";

        h1.Display();
        h2.Display();
        h3.Display();

        // Q4 Appointment
        Q4_Appointment a = new Q4_Appointment();
        a.AppointmentId = 1001;
        a.PatientName = "Kiran";
        a.Display();

        // Q5 Medical Test
        Q5_MedicalTest t1 = new Q5_MedicalTest(1, "Blood Test", 500);
        Q5_MedicalTest t2 = new Q5_MedicalTest(2, "X-Ray", 800);

        t1.Display();
        t2.Display();

        // Q6 Billing
        Q6_Billing b = new Q6_Billing();
        b.PatientName = "Ramesh";
        b.ConsultationFee = 500;
        b.TestCharges = 1000;
        b.Display();

        // Q7 Nurse
        Q7_Nurse n = new Q7_Nurse
        {
            NurseId = 201,
            NurseName = "Anita",
            Department = "Emergency"
        };

        n.Display();

        // Q8 Patient Record
        Q8_PatientRecord.HospitalName = "Apollo Hospital";

        Q8_PatientRecord pr1 = new Q8_PatientRecord(101, "Ravi", 40, "Fever");
        Q8_PatientRecord pr2 = new Q8_PatientRecord(102, "Aman", 35, "Cold");
        Q8_PatientRecord pr3 = new Q8_PatientRecord(103, "Raj", 50, "Diabetes");

        pr1.DisplayPatientRecord();
        pr2.DisplayPatientRecord();
        pr3.DisplayPatientRecord();
    }
}