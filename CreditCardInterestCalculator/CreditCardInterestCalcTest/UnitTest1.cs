using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CreditCardInterestCalculator;



namespace CreditCardInterestCalcTest
{

    /// <summary>
    /// I actually don't have a ton of experience with unit testing.  I wish we made time for it 
    /// at my current job.  But this is pretty cool.  Probably no where near what you guys would have done
    /// since you do it with all of your code, I assume.  But it's something. ;)
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCase1()
        {
            //test case 1 - 1 person, 1 wallet and 3 cards
            Person testPerson1 = new Person();

            IList<ICreditCard> tC1Cards = new List<ICreditCard>();
            tC1Cards.Add(new MasterCard(100)); //add MC
            tC1Cards.Add(new Visa(100)); //add Visa
            tC1Cards.Add(new Discover(100)); //add Discover
            testPerson1.AddWallet(tC1Cards); //add cards to wallet

            //test interest for each card
            int iCardTestNum = 0;
            double[] cardTotals = new double[] { 5, 10, 1 };//expected card interest for Mastercard, Visa, Discover

            foreach (var cc in tC1Cards)
            {
                Assert.AreEqual(cardTotals[iCardTestNum], cc.GetCardInterest());
                iCardTestNum++;
            }

            //test total interest for person
            Assert.AreEqual(16, testPerson1.GetPersonTotalInterest()); //total for person should be 16


        }

        [TestMethod]
        public void TestCase2()
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

            //test interest for each wallet
            int iWalletTestNum = 0;
            double[] walletTotals = new double[] { 11, 5 };//expected card interest for wallets

            foreach (var wallet in testPerson1.MyWallets)
            {
                Assert.AreEqual(walletTotals[iWalletTestNum], wallet.GetWalletInterest());
                iWalletTestNum++;
            }

            //test total interest for person
            Assert.AreEqual(16, testPerson1.GetPersonTotalInterest()); //total for person should be 16

        }

        [TestMethod]
        public void TestCase3()
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


            //test wallet interest - Person 1
            Assert.AreEqual(15, testPerson1.MyWallets[0].GetWalletInterest());
            //test total interest for person 1
            Assert.AreEqual(15, testPerson1.GetPersonTotalInterest()); //total for person should be 15

            //test wallet interest - Person 2
            Assert.AreEqual(15, testPerson2.MyWallets[0].GetWalletInterest());
            //test total interest for person 2
            Assert.AreEqual(15, testPerson2.GetPersonTotalInterest()); //total for person should be 15



        }
    }
}
