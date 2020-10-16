using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TRANSACTIONSURCHARGE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kindly input the amount to transfer:");
            string res = Console.ReadLine();
            long value;

            if (long.TryParse(res, out value))
            {
                if (value == 0)
                {
                    Console.WriteLine("You cannot transfer 0");
                    return;
                }

                var calculateTransaction = new ReadTransactionFile(value);
                var result = calculateTransaction.CalculateFee();
                Console.WriteLine($"Amount {"\t"} {"\t"} Transfer Amount {"\t"}  Charge  {"\t"} Debit Amount {"\n"} N{String.Format("{0:n}", result.TotalTransfer)} {"\t"} N{String.Format("{0:n}", result.TransferAmount)} {"\t"} {"\t"} N{String.Format("{0:n}", result.TransferCharge)} {"\t"} N{String.Format("{0:n}", result.DebitAmount)}");
            }
            else
            {
                Console.WriteLine("Only numbers is allowed");
            }
           
        }
    }
}
