using CardBankTransaction_HW_15.Entities;
using CardBankTransaction_HW_15.InterFaceRepository;
using CardBankTransaction_HW_15.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardBankTransaction_HW_15.Services
{
    public class UserService : IUserServis
    {
        private readonly IUserRepository _userRepository;
        private readonly ICardRepository _cardRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
            _cardRepository = new CardRepository();
        }



        public string GenerateVerificationCode(int userId, string fullName)
        {
            var existingVerification = _userRepository.GetVerificationDataById(userId);

            if (existingVerification != null && existingVerification.DateVerificationCode > DateTime.Now)
            {
                return "Code Already Sent";
            }

            var random = new Random();
            int verificationCode = random.Next(10000, 99999);
            DateTime expirationTime = DateTime.Now.AddMinutes(5);
            _userRepository.GenerateAndSaveVerificationCode(userId, fullName, verificationCode, expirationTime);
            return $"Code Send";
        }

        public bool ValidateVerificationCode(int userId, string fullName, int verificationCode)
        {
            var verificationDto = _userRepository.GetVerificationDataById(userId);
            if (verificationDto != null &&
                verificationDto.FullName == fullName &&
                verificationDto.VerificationCode == verificationCode)
            {
                if (verificationDto.DateVerificationCode > DateTime.Now)
                {
                    verificationDto.DateVerificationCode = DateTime.Now.AddMinutes(-1);
                    _userRepository.SaveVerificationData(verificationDto);
                    return true;
                }
            }
            return false;
        }






    }
}
