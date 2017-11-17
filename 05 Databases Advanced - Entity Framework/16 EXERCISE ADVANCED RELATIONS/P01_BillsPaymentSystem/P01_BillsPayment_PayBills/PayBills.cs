namespace P01_BillsPayment_PayBills
{
    using P01_BillsPaymentMethodsystem.Data;
    using System;

    public class PayBills
    {
        public static void ReadDetails()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Pay Bills");
                Console.WriteLine(new string('-', 15));

                string answer = "Y";
                while (true)
                {
                    if (answer == "N")
                    {
                        break;
                    }
                    else if (answer == "Y")
                    {
                        Console.WriteLine("Please insert user Id:");

                        int userId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Please insert amount:");

                        decimal amount = decimal.Parse(Console.ReadLine());

                        Console.Clear();

                        using (var context = new BillsPaymentSystemContext())
                        {
                            ExecuteTransactions.PayBills(userId, amount, context);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorect answer. Please use 'Y' or 'N' to answer.");
                    }
                    Console.Clear();
                    Console.WriteLine(new string('-', 15));
                    Console.WriteLine("Do you want to continue?");
                    Console.WriteLine("///Use 'Y' or 'N' to answer///");
                    Console.WriteLine(new string('-', 15));
                    answer = Console.ReadLine().ToUpper();
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
