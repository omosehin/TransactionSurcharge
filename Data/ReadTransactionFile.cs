using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TRANSACTIONSURCHARGE
{
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
            long TransferAmount = 0;

            var fileJson = File.ReadAllText(@"C:\Users\ayobami.omosehin\Documents\TRANSACTIONSURCHARGE\Data\transactionFile.Json");
            var readFile = JsonConvert.DeserializeObject<List<TransferFee>>(fileJson);

            foreach (var item in readFile)
            {
                if (_amount >= item.MinAmount && _amount <= item.MaxAmount)
                {
                    TotalAmount = _amount;
                    charge = item.FeeAmount;
                    TransferAmount = _amount - item.FeeAmount;


                }
            }
            return new TransferDetails {
                DebitAmount = TotalAmount,
                TransferAmount = TransferAmount,
                TransferCharge = charge, 
                TotalTransfer = TotalAmount };
        }
       
    }
}
