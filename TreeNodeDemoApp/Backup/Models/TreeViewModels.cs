using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Sql2Tree.Models
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

        public Tree()
        {
        }

        public void BuildTree()
        {
            TreeNode parent;
            foreach (var node in Nodes.Values)
            {
                if (Nodes.TryGetValue(node.ParentId, out parent) && node.Id != node.ParentId)
                {
                    node.Parent = parent;
                    parent.Children.Add(node);
                }
            }
        }
    }

    public class TreeNode
    {
        public int Id;

        [ScriptIgnore]
        public int ParentId;

        [ScriptIgnore]
        public TreeNode Parent;

        public string Name;

        public List<TreeNode> Children = new List<TreeNode>();
    }
}