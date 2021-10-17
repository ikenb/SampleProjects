using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeNodeSample.Logic
{
    public class TreeNode //: IEnumerable<TreeNode>
    {

        public int Id;

        [JsonIgnore]
        public int ParentId;

        [JsonIgnore]
        public TreeNode Parent;

        public string Type;
        public string Typeasdfa;
        public string Typesfsdf;
        public string Typsfsdfsdfse;

        public List<TreeNode> Formulae = new List<TreeNode>();

    }
}
