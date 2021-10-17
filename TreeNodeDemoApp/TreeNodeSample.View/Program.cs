using System;
using TreeNodeSample.Logic;
using TreeNodeSample.Logic.Utilities;

namespace TreeNodeSample.View
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientData = new Client
            {
                Name = "Tshepiso",
                Stake = 7,
                BetType = BetType.SingleBet
            };

            var taxHandler = new TaxHandler();

            taxHandler.ApplyBetStrikeTax(clientData);

            //var calculatedTax = GetTax(clientData);



            Console.ReadKey();
        }

        //private static decimal GetTax(Client clientData)
        //{
        //    var taxHandler = new TaxHandler();

        //    switch (clientData.BetType)
        //    {
        //        case BetType.SingleBet:
        //            return taxHandler.ApplyBetStrikeTax();
        //            break;
        //        case BetType.MultiBet:
        //            _ = new TaxMultiBetHandler();
        //            break;
    }
}