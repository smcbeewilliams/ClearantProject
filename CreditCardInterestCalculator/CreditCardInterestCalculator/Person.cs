using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterestCalculator
{
    public class Person
    {
        private IList<IWallet> wallets = new List<IWallet>();

        public Person()
        {
        }

        //add a new wallet for the person, since we can have multiple wallets per person
        public void AddWallet(IList<ICreditCard> creditCards)
        {
            //add a new wallet with the credit cards that go into the new wallet
            Wallet wallet = new Wallet();
            //add credit cards to wallet
            wallet.CreditCards = creditCards;
            //add wallet to list of wallets in case there are more than one
            wallets.Add(wallet);

        }

        //get the total interest for the person
        public double GetPersonTotalInterest()
        {
            double totalInterest = 0;
            foreach (var wallet in wallets)
            {
                totalInterest += wallet.GetWalletInterest();
            }

            return totalInterest;
        }

        public IList<IWallet> MyWallets
        {
            get { return wallets; }
            set { wallets = value; }
        }
    }
}
