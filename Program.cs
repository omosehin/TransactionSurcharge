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
            var inputedAmount = Convert.ToInt64(Console.ReadLine());
            var calculateTransaction = new ReadTransactionFile(inputedAmount);
            var result = calculateTransaction.CalculateFee();
            Console.WriteLine($"Amount {"\t"} {"\t"} Transfer Amount {"\t"}  Charge  {"\t"} Debit Amount {"\n"} N{String.Format("{0:n}", result.TotalTransfer)} {"\t"} N{String.Format("{0:n}", result.TransferAmount)} {"\t"} {"\t"} N{String.Format("{0:n}",  result.TransferCharge)} {"\t"} N{String.Format("{0:n}", result.DebitAmount)}" );
        }
    }
}
