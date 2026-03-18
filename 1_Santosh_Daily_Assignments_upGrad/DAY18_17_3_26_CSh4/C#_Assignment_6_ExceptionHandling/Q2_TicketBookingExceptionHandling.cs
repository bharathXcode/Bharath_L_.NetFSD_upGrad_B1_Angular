using System;
using System.Collections.Generic;
using System.Text;

// Custom Exception
class TicketLimitExceededException : Exception
{
    public TicketLimitExceededException(string message) : base(message) { }
}

// ------------------- MAIN -------------------
class Q2_TicketBookingExceptionHandling
{
    static void Main()
    {
        int availableTickets = 15;

        try
        {
            Console.Write("Do you want to book tickets? (yes/no): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                Console.Write("Enter number of tickets: ");
                int tickets = Convert.ToInt32(Console.ReadLine());

                if (tickets > availableTickets)
                {
                    throw new TicketLimitExceededException("Booking exceeds available tickets!");
                }
                else
                {
                    availableTickets -= tickets;
                    Console.WriteLine("Tickets booked successfully!");
                    Console.WriteLine("Remaining tickets: " + availableTickets);
                }
            }
            else
            {
                Console.WriteLine("Booking cancelled.");
            }
        }
        catch (TicketLimitExceededException ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Exception: " + ex.Message);
        }
    }
}
