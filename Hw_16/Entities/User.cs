using System.ComponentModel.DataAnnotations.Schema;

namespace CardBankTransaction_HW_15.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string Code { get; set; }
        public DateTime DateTimeAdd { get; set; }

        public List<Card> Cards { get; set; }
       
       

    }
}
