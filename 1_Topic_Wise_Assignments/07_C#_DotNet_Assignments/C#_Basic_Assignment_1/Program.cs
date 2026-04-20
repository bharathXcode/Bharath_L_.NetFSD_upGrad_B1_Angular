using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Question Number (1-19): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1: Q1_DisplayMessage.Run(); break;
            case 2: Q2_CommandLineGreeting.Run(); break;
            case 3: Q3_NumbersBetweenTwoNumbers.Run(); break;
            case 4: Q4_OddOrEven.Run(); break;
            case 5: Q5_CountOddEvenNumbers.Run(); break;
            case 6: Q6_FahrenheitToCelsius.Run(); break;
            case 7: Q7_ProductPriceCalculation.Run(); break;
            case 8: Q8_SquareSeries.Run(); break;
            case 9: Q9_Factorial.Run(); break;
            case 10: Q10_FibonacciSeries.Run(); break;
            case 11: Q11_MultiplicationTable.Run(); break;
            case 12: Q12_DivisibleBy7.Run(); break;
            case 13: Q13_LargestOfThreeNumbers.Run(); break;
            case 14: Q14_SmallestOfFiveNumbers.Run(); break;
            case 15: Q15_MarksAnalysis.Run(); break;
            case 16: Q16_WordLength.Run(); break;
            case 17: Q17_ReverseWord.Run(); break;
            case 18: Q18_CompareTwoWords.Run(); break;
            case 19: Q19_PalindromeCheck.Run(); break;
            default: Console.WriteLine("Invalid choice"); break;
        }
    }
}