using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterestCalculator
{
    public interface IWallet
    {
        IList<ICreditCard> CreditCards { get; set; }
        double GetWalletInterest();

    }

    public class Wallet : IWallet
    {
        IList<ICreditCard> creditCards;
        public IList<ICreditCard> CreditCards
        {
            get { return creditCards; }
            set { creditCards = value; }
        }
        //get the interest of all the cards in the wallet, summed up
        public double GetWalletInterest()
        {
            double totalInterest = 0;
            foreach (var cc in creditCards)
            {
                totalInterest += cc.GetCardInterest();
            }

            return totalInterest;
        }



    }
}
