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
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Data\\transactionFile.Json");
            
            //var fileJson = File.ReadAllText(@"C:\Users\ayobami.omosehin\Documents\TRANSACTIONSURCHARGE\Data\transactionFile.Json");
            string relativePath = "..\\Data\\transactionFile.Json";
            string fullPathToFirstFile = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(relativePath), "transactionFile.Json"));
            string filePath = fullPathToFirstFile.Replace("\\bin\\Debug", "");
            var fileJson = File.ReadAllText(filePath);
            var readFile = JsonConvert.DeserializeObject<List<TransferFee>>(fileJson);
            
           return getAmountDetails(readFile);
        }

        private TransferDetails getAmountDetails(List<TransferFee> readFile)
        {
            int charge = 0;
            long TotalAmount = 0;
            long TransferAmount = 0;
            foreach (var item in readFile)
            {
                if (_amount >= item.MinAmount && _amount <= item.MaxAmount)
                {
                    TotalAmount = _amount;
                    charge = item.FeeAmount;
                    TransferAmount = _amount - item.FeeAmount;
                }
            }
            return new TransferDetails
            {
                DebitAmount = TotalAmount,
                TransferAmount = TransferAmount,
                TransferCharge = charge,
                TotalTransfer = TotalAmount
            };
        }
    }
}
