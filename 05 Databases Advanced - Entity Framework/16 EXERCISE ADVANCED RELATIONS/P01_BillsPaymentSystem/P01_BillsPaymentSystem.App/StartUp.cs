namespace P01_BillsPaymentMethodsystem.App
{
    using System;
    using P01_BillsPaymentDatabaseInitializer;
    using P01_BillsPayment_UserPaymentMethods;
    using P01_BillsPayment_ManualSeed;
    using P01_BillsPayment_PayBills;

    class StartUp
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            int orderId;

            while (true)
            {
                Console.WriteLine(new string('-', 15));
                Console.WriteLine("///Write 'no digit' to exit.///");
                Console.WriteLine(new string('-', 15));
                Console.WriteLine("Please choose from following options:");
                Console.WriteLine("1. Database Initializer (Note: It reset the database and seed it again!) - use '1';");
                Console.WriteLine("2. Manual seed - use '2';");
                Console.WriteLine("3. Read user payment methods - use '3';");
                Console.WriteLine("4. Pay user bills - use '4';");
                Console.WriteLine(new string('-', 15));

                if (!int.TryParse(Console.ReadLine(), out orderId))
                {
                    break;
                }
                Console.Clear();

                switch (orderId)
                {
                    case 1:
                        DatabaseInitializer.ResetDatabase();
                        break;
                    case 2:
                        ManualSeed.ReadDetails();
                        break;
                    case 3:
                        UserPaymentMethods.ReadDetails();
                        break;
                    case 4:
                        PayBills.ReadDetails();
                        break;
                    default:
                        Console.WriteLine("Incorect index. Try again.");
                        break;
                }
            }           
        }
    }
}
