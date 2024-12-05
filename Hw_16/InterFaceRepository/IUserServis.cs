using CardBankTransaction_HW_15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardBankTransaction_HW_15.InterFaceRepository
{
    public interface IUserServis
    {
        public bool ValidateVerificationCode(int userId, string fullName, int verificationCode);
        public string GenerateVerificationCode(int userId, string fullName);






    }
}
