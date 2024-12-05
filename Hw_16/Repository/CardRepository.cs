using CardBankTransaction_HW_15.Entities;
using CardBankTransaction_HW_15.InterFaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardBankTransaction_HW_15.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _dbContext;
        public CardRepository()
        {
            _dbContext = new AppDbContext();
        }

       
      
        
        public void Diposit(string cardNumber, float amount)
        {
            try
            {
                var card = _dbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber && x.IsActive);
                if (card == null)
                {
                    throw new Exception($"Sorry you Cant Deposit for This cardnumber{card}");
                }
                else
                {
                    card.Balance += amount;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Card GetCardBy(string cardNumber)
        {
            try
            {
                var card = _dbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
                if (card == null)
                {
                    throw new Exception($"This CardNumber{cardNumber}Not Found .");
                }
                else
                {
                    return card;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetWrongPasswordTrys(string cardNumber)
        {
            try
            {
                var card = _dbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);

                if (card == null)
                {
                    throw new Exception($"This CardNumber{cardNumber}Not Found .");
                }
                return card.FalsePassword;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public bool IsActiveCard(string cardNumber)
        {
            try
            {
                var card = _dbContext.Cards.Any(x => x.CardNumber == cardNumber && x.IsActive);

                if (card == null)
                {
                    throw new Exception($"This CardNumber{card}Not Found .");
                }
                return card;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public bool IsValidPassword(string cardNumber, string password)
        {
            try
            {
                var card = _dbContext.Cards.Any(x => x.CardNumber == cardNumber && x.Password == password);

                if (card == null)
                {
                    throw new Exception($"This CardNumber{card}Not Found .");
                }
                return card;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SetWrongPassword(string cardNumber)
        {
            try
            {
                var card = _dbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
                if (card == null)
                {
                    throw new Exception($"This CardNumber{card}Not Found .");
                }
                else
                {
                    card.FalsePassword++;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void WithDrow(string cardNumber, float amount)
        {
            try
            {
                var card = _dbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber && x.IsActive);
                if (card == null)
                {
                    throw new Exception($"Sorry you cant Withdrow this CardNumber{cardNumber}");
                }
                else
                {
                    var newbalance = card.Balance -= amount;

                    card = new Card()
                    {
                        Balance = newbalance
                    };

                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Changepassword(string cardNumber,string oldpassword, string newpassword)
        {
            try
            {
                var user = _dbContext.Cards.FirstOrDefault(x => x.Password == oldpassword);
                if (user == null)
                {
                    throw new Exception($"Password Is not true");
                }
                user.Password = newpassword;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public float GetBalance(string cardNumber)
        {
            try
            {
                var user = _dbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
                _dbContext.Entry(user).Reload();
                user = _dbContext.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);


                if (user == null)
                {
                    throw new Exception($"Error in Balance ");
                }
                return user.Balance;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
    }
}
