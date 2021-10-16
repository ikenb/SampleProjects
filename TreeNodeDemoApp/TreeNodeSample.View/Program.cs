using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeSample.Data;
using TreeNodeSample.Logic;

namespace TreeNodeSample.View
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = GetData();

            var json = JsonConvert.SerializeObject(tree.RootNode);

            Console.ReadKey();
        }
        private static Tree GetData()
        {
           
           
            var tree = new Tree();

            using (var db = new TestDBEntities())
            {
                // Add each element as a tree node
                tree.Nodes = db.TaxEntities
                    .Select(t => new TreeNode { Id = t.Id, ParentId = (int)t.ParentId, Name = t.Name })
                    .ToDictionary(t => t.Id);

                // Create a new root node
                tree.RootNode = new TreeNode { Id = 0, Name = "Root" };

                // Build the tree, setting parent and children references for all elements
                tree.BuildTree();
            }

            return tree;


        }
    }
}
