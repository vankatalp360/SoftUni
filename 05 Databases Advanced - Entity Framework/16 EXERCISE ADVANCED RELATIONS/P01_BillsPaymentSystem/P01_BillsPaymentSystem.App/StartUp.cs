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

            DatabaseInitializer.ResetDatabase();

            ManualSeed.ReadDetails();

            UserPaymentMethods.ReadDetails();

            PayBills.ReadDetails();
        }
    }
}
