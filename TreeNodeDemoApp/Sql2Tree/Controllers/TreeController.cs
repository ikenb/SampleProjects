using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sql2Tree.Models;

namespace Sql2Tree.Controllers
{
    public class TreeController : Controller
    {
        private Tree GetData()
        {
            var tree = new Tree();

            using (var db = new TreeEntities())
            {
                // Add each element as a tree node
                tree.Nodes = db.TreeMenu
                    .Select(t => new TreeNode { Id = t.Id, ParentId = t.ParentId, Name = t.Name })
                    .ToDictionary(t => t.Id);

                // Create a new root node
                tree.RootNode = new TreeNode { Id = 0, Name = "Root" };

                // Build the tree, setting parent and children references for all elements
                tree.BuildTree();
            }

            return tree;
        }

        public ActionResult Index()
        {
            var model = GetData();
            return View(model);
        }

        public ActionResult NoRootNode()
        {
            var model = GetData();
            return View(model);
        }

        [HttpGet]
        public JsonResult WebService()
        {
            var model = GetData();
            return Json(model.RootNode, JsonRequestBehavior.AllowGet);
        }
    }
}
