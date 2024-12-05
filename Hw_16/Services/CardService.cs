using CardBankTransaction_HW_15.Entities;
using CardBankTransaction_HW_15.InterFaceRepository;
using CardBankTransaction_HW_15.Repository;
using CardBankTransaction_HW_15.Resualt;
using Colors.Net;
using Colors.Net.StringColorExtensions;

namespace CardBankTransaction_HW_15.Services
{
    public class CardService : ICardServices
    {
        private readonly ICardRepository _cardRepository;
        public CardService()
        {
            _cardRepository = new CardRepository();
        }

        public void ChangePass(string cardNumber,string oldpassword, string newpassword)
        {
            try
            {
                var card = _cardRepository.GetCardBy(cardNumber);
                if (oldpassword != card.Password)
                {
                    ColoredConsole.WriteLine("Password is not correct".Red());
                }
                _cardRepository.Changepassword(card.CardNumber, oldpassword, newpassword);
                ColoredConsole.WriteLine("Change Successfully".Green());
                _cardRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Card GetUserIdByCardNumber(string cardNumber)
        {
            try
            {
                var card = _cardRepository.GetCardBy(cardNumber);

                return card;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Result PasswordIsValid(string cardNumber, string password)
        {
            try
            {
                var tryCount = _cardRepository.GetCardBy(cardNumber);
                if (tryCount.FalsePassword == 3)
                    return new Result() { IsSuccess = false, Massage = " Your Card is Blocked Beacuse You Over 3 time Trying Wrong Password " };
                var passwordIsvalid = _cardRepository.IsValidPassword(cardNumber, password);
                if (passwordIsvalid == false)
                {
                    _cardRepository.SetWrongPassword(cardNumber);
                    return new Result() { IsSuccess = false, Massage = "card Number Or Password Is Wrong..." };
                }
                else
                {
                    return new Result() { IsSuccess = true, Massage = "Wellcome" };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        public float ShowBalanceUser(string cardNumber)
        {
            try
            {
                var user = _cardRepository.GetBalance(cardNumber);
                if (user == null)
                {
                    throw new Exception("Error in Show Balance ");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}




