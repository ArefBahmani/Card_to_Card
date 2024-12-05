using CardBankTransaction_HW_15.Entities;
using CardBankTransaction_HW_15.Resualt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardBankTransaction_HW_15.InterFaceRepository
{
    public interface ICardServices
    {
        Result PasswordIsValid(string cardNumber, string password);
       Card GetUserIdByCardNumber(string cardNumber);
        float ShowBalanceUser(string cardNumber);
        void ChangePass(string cardNumber,string oldpassword, string newpassword);

      



    }
}
