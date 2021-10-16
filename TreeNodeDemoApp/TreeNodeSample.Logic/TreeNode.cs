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

        public string Name;

        public List<TreeNode> Children = new List<TreeNode>();

    }
}
