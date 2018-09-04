using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeListDragDropMultipleNodes.Models;

namespace TreeListDragDropMultipleNodes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TreeListPartial()
        {
            return PartialView("_TreeListPartial", DataHelper.GetData());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListDragDropAction(int id, object[] nodeKeys, int parentID)
        {
            if (nodeKeys == null)
                DataHelper.MoveNode(id, parentID);
            else
                DataHelper.MoveNodes(nodeKeys, parentID);

            return PartialView("_TreeListPartial", DataHelper.GetData());
        }
    }
}