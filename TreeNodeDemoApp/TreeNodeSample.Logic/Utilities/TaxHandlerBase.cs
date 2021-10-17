using Jace;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TreeNodeSample.Data;
using TreeNodeSample.Logic.Utilities;

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

                //for (int i = 0; i < desSerializedClass.Formulae.Count; i++)
                //{
                //    //formulas.Add(desSerializedClass.Formulae[i].ExciseTax);
                //    //formulas.Add(desSerializedClass.Formulae[i].NetStake);
                //    //formulas.Add(desSerializedClass.Formulae[i].WithHoldingTax);
                //    //formulas.Add(desSerializedClass.Formulae[i].NetWinnings);


                //}    

                foreach (var formula in desSerializedClass.Formulae)
                {
                    ComputeExciseTax(clientData.Stake, formula.ExciseTax);
                    ComputeNetStake(clientData.Stake, formula.NetStake);
                    ComputeWithHoldingTax(clientData.Stake, formula.WithHoldingTax);
                    ComputeNetWinnings(clientData.Stake, formula.NetWinnings);
                }

            }

            return 1;
        }

        public decimal ComputeExciseTax(decimal stake, string formulaa)
        {
            char[] spearator = { '#', ' ' };
            var list = formulaa.Split(spearator,StringSplitOptions.RemoveEmptyEntries);

            var engine = new CalculationEngine();
            var exciseTaxFormula = string.Join(string.Empty, list);

            Func<Dictionary<string, double>, double> formula = engine.Build(exciseTaxFormula);

            Dictionary<string, double> variables = new Dictionary<string, double>();
            variables.Add(list[0], (double)stake);
           

            double result = formula(variables);

            return (decimal)result;

        }

        public decimal ComputeNetStake(decimal stake, string formula)
        {
            var variables = new Dictionary<string, double>();

            variables.Add("var1", 2.5);
            variables.Add("var2", 3.4);

            var engine = new CalculationEngine();

            double result = engine.Calculate("var1*var2", variables);

            return (decimal)result;

        }

        public decimal ComputeWithHoldingTax(decimal stake, string formula)
        {
            var variables = new Dictionary<string, double>();

            variables.Add("var1", 2.5);
            variables.Add("var2", 3.4);

            var engine = new CalculationEngine();

            double result = engine.Calculate("var1*var2", variables);

            return (decimal)result;

        }

        public decimal ComputeNetWinnings(decimal stake, string formula)
        {
            var variables = new Dictionary<string, double>();

            variables.Add("var1", 2.5);
            variables.Add("var2", 3.4);

            var engine = new CalculationEngine();

            double result = engine.Calculate("var1*var2", variables);

            return (decimal)result;

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
        //private Tree GetData()
        //{

        //    var tree = new Tree();

        //    using (var db = new TestDBEntities())
        //    {

        //        tree.Nodes = db.TaxEntities
        //            .Select(t => new TreeNode { Id = t.Id, ParentId = (int)t.ParentId, Type = t.Name })
        //            .ToDictionary(t => t.Id);


        //        tree.RootNode = new TreeNode { Id = 0, Type = "TaxCountry" };

        //        tree.BuildTree();
        //    }

        //    return tree;


        //}
    }
}







