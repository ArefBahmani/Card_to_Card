using CardBankTransaction_HW_15.Dto;
using CardBankTransaction_HW_15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardBankTransaction_HW_15.InterFaceRepository
{
    public interface ITransactionRepository
    {
        List<GetTransactionDto> GetListOfTransaction(string cardNumber);
        float DailyTransAction(string cardNumber);
        void AddTransaction(Transactionn transactionn);
        float GetAmount(int amount);
        
    }
}
