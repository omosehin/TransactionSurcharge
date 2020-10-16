using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
            Console.WriteLine(result) ;

        }
    }

    public class ReadTransactionFile
    {
        private readonly long _amount;

        public ReadTransactionFile( long amount)
        {
            _amount = amount;
        }
        public TransferDetails CalculateFee()
        {
            int charge = 0;
            long TotalAmount = 0;
            var fileJson = File.ReadAllText(@"C:\Users\ayobami.omosehin\Documents\TRANSACTIONSURCHARGE\Data\transactionFile.Json");
            dynamic readFile = JsonConvert.DeserializeObject<List<TransferFee>>(fileJson);

            foreach (var item in readFile)
            {
                if (_amount > item.MinAmount && _amount < item.MaxAmount)
                {
                    TotalAmount = _amount + item.FeeAmount;
                    charge = item.FeeAmount;
                }
            }
            return new TransferDetails { DebitAmount = TotalAmount, TransferAmount = _amount ,TransferCharge = charge, TotalTransfer = TotalAmount };
        }
       
    }
    public class TransferDetails
    {
        public long TransferAmount { get; set; }
        public long TotalTransfer { get; set; }
        public long DebitAmount { get; set; }
        public int TransferCharge { get; set; }

    }

    public class TransferFee
    {
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public int FeeAmount { get; set; }
    }
}
