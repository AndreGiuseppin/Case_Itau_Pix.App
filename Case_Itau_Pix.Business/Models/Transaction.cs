namespace Case_Itau_Pix.Business.Models
{
    public class Transaction
    {
        public Guid CorrelationId { get; set; }
        public string SenderAccount { get; set; } = string.Empty;
        public string RecipientAccount { get; set; } = string.Empty;
        public double TransactionValue { get; set; }
        public DateTime TransactionDate { get; set; }

        public Balance? SenderBalance { get; private set; }
        public Balance? RecipientBalance { get; private set; }
        public bool HasError { get; private set; } = false;

        public void WithSenderBalance(Balance balance) => SenderBalance = balance;
        public void WithRecipientBalance(Balance balance) => RecipientBalance = balance;
        public void WithError() => HasError = true;

        public List<Transaction> PopulateModel()
        {
            return new List<Transaction> {
                new() {
                    CorrelationId = Guid.NewGuid(),
                    TransactionDate = DateTime.Now.AddDays(1),
                    SenderAccount = "938485762",
                    RecipientAccount = "2147483649",
                    TransactionValue = 150
                },
                new() {
                    CorrelationId = Guid.NewGuid(),
                    TransactionDate = DateTime.Now.AddDays(2),
                    SenderAccount = "2147483649",
                    RecipientAccount = "210385733",
                    TransactionValue = 149
                },
                new() {
                    CorrelationId = Guid.NewGuid(),
                    TransactionDate = DateTime.Now.AddDays(3),
                    SenderAccount = "347586970",
                    RecipientAccount = "238596054",
                    TransactionValue = 1100
                },
                new() {
                    CorrelationId = Guid.NewGuid(),
                    TransactionDate = DateTime.Now.AddDays(4),
                    SenderAccount = "675869708",
                    RecipientAccount = "210385733",
                    TransactionValue = 5300
                },
                new() {
                    CorrelationId = Guid.NewGuid(),
                    TransactionDate = DateTime.Now.AddDays(5),
                    SenderAccount = "238596054",
                    RecipientAccount = "674038564",
                    TransactionValue = 1489
                },
                new() {
                    CorrelationId = Guid.NewGuid(),
                    TransactionDate = DateTime.Now.AddDays(6),
                    SenderAccount = "573659065",
                    RecipientAccount = "563856300",
                    TransactionValue = 49
                },
                new() { CorrelationId = Guid.NewGuid(),
                    TransactionDate = DateTime.Now.AddDays(7),
                    SenderAccount = "938485762",
                    RecipientAccount = "2147483649",
                    TransactionValue = 44
                },
                new() { CorrelationId = Guid.NewGuid(),
                    TransactionDate = DateTime.Now.AddDays(8),
                    SenderAccount = "573659065",
                    RecipientAccount = "675869708",
                    TransactionValue = 150
                }
            };
        }
    }
}
