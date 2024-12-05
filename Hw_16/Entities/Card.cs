using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardBankTransaction_HW_15.Entities
{
    public class Card
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public float Balance { get; set; }
        public int FalsePassword { get; set; } = 0;
        public List<Transactionn> TransactionnsAsSource { get; set; }
        public List<Transactionn> TransactionnsAsDestination { get; set; }
        public  User User { get; set; }
        public int UserId { get; set; }

    }
}
