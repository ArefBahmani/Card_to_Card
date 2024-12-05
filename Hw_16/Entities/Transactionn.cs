namespace CardBankTransaction_HW_15.Entities
{
    public class Transactionn
    {
        public int TransactionId { get; set; }
        public int SourceCardid { get; set; }
        public int DestinationCardid { get; set; }
        public DateTime AtTime { get; set; }
        public float Amount { get; set; }
        public bool IsSuccess { get; set; }

        public Card SourceCard { get; set; }
        public Card DestinationCard { get; set; }
       
       
    }
}
