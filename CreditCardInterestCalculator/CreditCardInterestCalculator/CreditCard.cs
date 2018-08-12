using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterestCalculator
{
    /// <summary>
    /// Interface for credit card, to be implemented by the other credit card types
    /// </summary>
    public interface ICreditCard
    {
        //accept and return the card balance
        double Balance { get; set; }
        //for card type  - not needed for the exercise really
        string CardType{get;}
        //get the interest
        double GetCardInterest();

    }

    public class MasterCard : ICreditCard
    {
        private double balance;
        //I was kind of playing around with this, displaying it, it's in the other card classes too
        private const string cardType = "MasterCard"; 


        public MasterCard()
        {
        }

        public MasterCard(double initBalance)
        {
            Balance = initBalance;
        }

        public string CardType
        {
            get { return cardType; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public double GetCardInterest()
        {
            //put some error handling in here later - at the least
            double interest = .05 * Balance;
            return interest;
        }
    }

    public class Visa : ICreditCard
    {
        private double balance;
        private const string cardType = "Visa";

        public Visa()
        {
        }

        public Visa(double initBalance)
        {
            Balance = initBalance;
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public string CardType
        {
            get { return cardType; }
        }

        public double GetCardInterest()
        {
            //put some error handling in here later - at the least
            double interest = .10 * Balance;
            return interest;
        }
    }

    public class Discover : ICreditCard
    {
        private double balance;
        private const string cardType = "Discover";


        public Discover()
        {
        }

        public Discover(double initBalance)
        {
            Balance = initBalance;
        }

        public string CardType
        {
            get { return cardType; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public double GetCardInterest()
        {
            //put some error handling in here later - at the least
            double interest = .01 * Balance;
            return interest;
        }
    }
}
