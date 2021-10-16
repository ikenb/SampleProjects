using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeNodeSample.Logic
{
    public class Tree
    {
        private TreeNode rootNode;
        public TreeNode RootNode
        {
            get { return rootNode; }
            set
            {
                if (RootNode != null)
                    Nodes.Remove(RootNode.Id);

                Nodes.Add(value.Id, value);
                rootNode = value;
            }
        }

        public Dictionary<int, TreeNode> Nodes { get; set; }


        public void BuildTree()
        {
            TreeNode parent;
            foreach (var node in Nodes.Values)
            {
                if (Nodes.TryGetValue(node.ParentId, out parent) &&
                    node.Id != node.ParentId)
                {
                    node.Parent = parent;
                    parent.Children.Add(node);
                }
            }
        }
    }
}
