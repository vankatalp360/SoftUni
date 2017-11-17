namespace P01_BillsPayment_ManualSeed
{
    using P01_BillsPayment_ManualSeed.Generators;
    using P01_BillsPaymentMethodsystem.Data;
    using System;

    public class ManualSeed
    {
        public static void ReadDetails()
        {
            try
            {
                int orderId;

                while (true)
                {
                    Console.WriteLine(new string('-', 15));
                    Console.WriteLine("///Write 'no digit' to exit.///");
                    Console.WriteLine(new string('-', 15));
                    Console.WriteLine("Please write what object you should like to seed as follow:");
                    Console.WriteLine("1. User - use '1';");
                    Console.WriteLine("2. Credit Card - use '2';");
                    Console.WriteLine("3. Bank Account - use '3';");
                    Console.WriteLine("4. Payment Method - use '4';");
                    Console.WriteLine(new string('-', 15));

                    if (!int.TryParse(Console.ReadLine(), out orderId))
                    {
                        break;
                    }
                    Console.Clear();

                    using (var context = new BillsPaymentSystemContext())
                    {
                        switch (orderId)
                        {
                            case 1:
                                UserGenerator.Create(context);
                                break;
                            case 2:
                                CreditCardGenerator.Create(context);
                                break;
                            case 3:
                                BankAccountGenerator.Create(context);
                                break;
                            case 4:
                                PaymentMethodGenerator.Create(context);
                                break;
                            default:
                                Console.WriteLine("Incorect index. Try again.");
                                break;
                        }
                    }
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
