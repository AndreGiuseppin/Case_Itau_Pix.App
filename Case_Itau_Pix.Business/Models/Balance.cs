namespace Case_Itau_Pix.Business.Models
{
    public class Balance
    {
        public string Account { get; set; } = string.Empty;
        public double AvailableBalance { get; set; }

        public Balance GetBalance(string account, IEnumerable<Balance> balances) => balances.Where(x => x.Account == account).FirstOrDefault();

        public List<Balance> PopulateModel()
        {
            return new List<Balance>
            {
                new()
                {
                    Account = "938485762",
                    AvailableBalance = 180
                },
                new()
                {
                    Account = "347586970",
                    AvailableBalance = 1200
                },
                new()
                {
                    Account = "2147483649",
                    AvailableBalance = 0
                },
                new()
                {
                    Account = "675869708",
                    AvailableBalance = 4900
                },
                new()
                {
                    Account = "238596054",
                    AvailableBalance = 478
                },
                new()
                {
                    Account = "573659065",
                    AvailableBalance = 787
                },
                new()
                {
                    Account = "210385733",
                    AvailableBalance = 10
                },
                new()
                {
                    Account = "674038564",
                    AvailableBalance = 400
                },
                new()
                {
                    Account = "563856300",
                    AvailableBalance = 1200
                }
            };
        }
    }
}