using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardInterestCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Test2();
            Test3();


        }

        static void Test1()
        {
            //test case 1 - 1 person, 1 wallet and 3 cards
            Person testPerson1 = new Person();

            IList<ICreditCard> tC1Cards = new List<ICreditCard>();
            tC1Cards.Add(new MasterCard(100)); //add MC
            tC1Cards.Add(new Visa(100)); //add Visa
            tC1Cards.Add(new Discover(100)); //add Discover
            testPerson1.AddWallet(tC1Cards); //add cards to wallet

            //print card interest
            //I know this string stuff is a little old school, probably.  Ha.  
            //I've got screaming kids in the background, so I have to quit on this soon anyway.
            string sOutput = "";
            foreach (var cc in tC1Cards)
            {
                sOutput += cc.CardType + " = $" + cc.GetCardInterest().ToString() + "\r\n";
            }
            sOutput += "Total For Person = $" + testPerson1.GetPersonTotalInterest().ToString() + "\r\n";

            Console.WriteLine(sOutput);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        static void Test2()
        {
            //test case 2 - 1 person, 2 wallets, one with 2 cards, one with 1 card
            Person testPerson1 = new Person();

            IList<ICreditCard> tC1Cards = new List<ICreditCard>();
            tC1Cards.Add(new Visa(100)); //add Visa
            tC1Cards.Add(new Discover(100)); //add Discover
            testPerson1.AddWallet(tC1Cards); //add cards to wallet

            IList<ICreditCard> tC2Cards = new List<ICreditCard>();
            tC2Cards.Add(new MasterCard(100)); //add MC
            testPerson1.AddWallet(tC2Cards); //add cards to wallet

            //print interest
            string sOutput = "";
            int i =1;
            foreach (var wallet in testPerson1.MyWallets)
            {
                sOutput +=  "Wallet " + i.ToString() + " $" + wallet.GetWalletInterest().ToString() + "\r\n";
                i++;
            }
            sOutput += "Total For Person = $" + testPerson1.GetPersonTotalInterest().ToString() + "\r\n";

            Console.WriteLine(sOutput);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }


        static void Test3()
        {
            //test case 3 - 2 people, 1 wallet each, one with 2 cards, one with 1 card
            Person testPerson1 = new Person();
            IList<ICreditCard> tP1C1Cards = new List<ICreditCard>();
            tP1C1Cards.Add(new MasterCard(100)); //add Visa
            tP1C1Cards.Add(new Visa(100)); //add Discover
            testPerson1.AddWallet(tP1C1Cards); //add cards to wallet


            Person testPerson2 = new Person();
            IList<ICreditCard> tP2C1Cards = new List<ICreditCard>();
            tP2C1Cards.Add(new Visa(100)); //add Visa
            tP2C1Cards.Add(new MasterCard(100)); //add Discover
            testPerson2.AddWallet(tP2C1Cards); //add cards to wallet


            //print interest - Person 1
            string sOutput = "";
            int i = 1;
            foreach (var wallet in testPerson1.MyWallets)
            {
                sOutput += "Wallet " + i.ToString() + " $" + wallet.GetWalletInterest().ToString() + "\r\n";
                i++;
            }
            sOutput += "Total For Person 1 = $" + testPerson1.GetPersonTotalInterest().ToString() + "\r\n";

            Console.WriteLine(sOutput);
            sOutput = "";
            //print interest - Person 2
            sOutput = "";
            i = 1;
            foreach (var wallet in testPerson2.MyWallets)
            {
                sOutput += "Wallet " + i.ToString() + " $" + wallet.GetWalletInterest().ToString() + "\r\n";
                i++;
            }
            sOutput += "Total For Person 2 = $" + testPerson2.GetPersonTotalInterest().ToString() + "\r\n";

            Console.WriteLine(sOutput);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

    }
}
