using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TreeNodeSample.Data;
using TreeNodeSample.Logic.Utilities;
using TreeNodeSample.Logic.Utilities.Interfaces;
using System.Data.Entity.Core.Objects;

namespace TreeNodeSample.Logic
{
    public class TaxHandler
    {


        //ITax _tax;
        public TaxHandler()
        {

        }

        public decimal ApplyBetStrikeTax(Client clientData)
        {
           // var tree = GetData();
             //var json = JsonConvert.SerializeObject(tree);


            var singleBet = new TaxSingleBetHandler();


            var countryTaxMetaData = GetContryTaxMetaData(88);
            var extractedFormulae = ExtractTaxFormulae(countryTaxMetaData);

            foreach (var extractedFormula in extractedFormulae)
            {
                var desSerializedClass = JsonConvert.DeserializeObject<CountryBettingTax>(extractedFormula);

                var formulas = new List<string>();

                for (int i = 0; i < desSerializedClass.Formulae.Count; i++)
                {
                    formulas.Add(desSerializedClass.Formulae[i].ExciseTax);
                    formulas.Add(desSerializedClass.Formulae[i].NetStake);
                    formulas.Add(desSerializedClass.Formulae[i].WithHoldingTax);
                    formulas.Add(desSerializedClass.Formulae[i].NetWinnings);
                }

                //var exciseTax = desSerializedClass.Formulae[].ExciseTax
                //var enet = desSerializedClass.Formulae[1];
                //var exciseTaxzzc = desSerializedClass.Formulae[2];
                //var exciseTazczx = desSerializedClass.Formulae[3];

            }


            //// https://social.msdn.microsoft.com/Forums/vstudio/en-US/aa267e26-f5a1-4958-b4ae-e1b1dfff4390/extracting-part-of-json-object-from-json-string?forum=csharpgeneral
            //     var token = (JArray)obj.SelectToken("result");
            //     //your event logs in list instance
            //     var list = new List<Event>();
            //     foreach (var item in token)
            //     {
            //         string json = JsonConvert.SerializeObject(item.SelectToken("event"));
            //         list.Add(JsonConvert.DeserializeObject<Event>(json));
            //     }
            //var extractedFormulae = ExtractTaxFormulae(countryTaxMetaData);


            return 1; // singleBet.ComputeTax(clientData.Stake, json);


            // [  { "id": 1,    "type": "Sport",    "formulae": [      { "id": 0,        "name": "All",        "exciseTax": "#stake#*(7.5/100)",        "netStake": "#stake#-#excisetax#",        "withHoldingTax": "#payout#*(20/100)",        "netWinnings": "#payout#-#withholdingtax#",    	"isEnabled":true      }    ]  }]
            //2021-10-08 13:59:13.383
        }

        private JArray GetContryTaxMetaData(short countryId)
        {
            using (var db = new TestDBEntities())
            {
               var results = db.GetCountryBettingTax(countryId).FirstOrDefault();

                return JArray.Parse(results);
            }


        }

        private List<string> ExtractTaxFormulae(JArray countryTaxMetaData)
        {
            var formulaeCatagories = new List<string>();

            foreach (var countryTaxData in countryTaxMetaData.Values<JObject>())
            {
                formulaeCatagories.Add(countryTaxData.ToString());

            }

            return formulaeCatagories;
        }
        private Tree GetData()
        {

            var tree = new Tree();

            using (var db = new TestDBEntities())
            {

                tree.Nodes = db.TaxEntities
                    .Select(t => new TreeNode { Id = t.Id, ParentId = (int)t.ParentId, Type = t.Name })
                    .ToDictionary(t => t.Id);


                tree.RootNode = new TreeNode { Id = 0, Type = "TaxCountry" };

                tree.BuildTree();
            }

            return tree;


        }
    }
}







