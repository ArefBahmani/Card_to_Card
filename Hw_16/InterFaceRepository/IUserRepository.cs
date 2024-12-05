using CardBankTransaction_HW_15.Entities;
using Hw_16.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardBankTransaction_HW_15.InterFaceRepository
{
    public interface IUserRepository
    {
        public void GenerateAndSaveVerificationCode(int userId, string fullName, int verificationCode, DateTime expirationTime);
        public VerificationDto GetVerificationDataById(int userId);
        public void SaveVerificationData(VerificationDto verificationDto);



    }
}
