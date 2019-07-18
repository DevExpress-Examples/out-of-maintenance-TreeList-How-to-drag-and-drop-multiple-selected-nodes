using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeListDragDropMultipleNodes.Models
{
    public class Data
    {
        public int ID { set; get; }
        public int ParentID { set; get; }
        public string Title { set; get; }
    }

    public static class DataHelper
    {
        public static List<Data> GetData()
        {
            List<Data> data = HttpContext.Current.Session["Data"] as List<Data>;

            if (data == null)
            {
                data = new List<Data>();

                data.Add(new Data { ID = 1, ParentID = 0, Title = "Root" });

                data.Add(new Data { ID = 2, ParentID = 1, Title = "A" });
                data.Add(new Data { ID = 3, ParentID = 1, Title = "B" });
                data.Add(new Data { ID = 4, ParentID = 1, Title = "C" });

                data.Add(new Data { ID = 5, ParentID = 2, Title = "A1" });
                data.Add(new Data { ID = 6, ParentID = 2, Title = "A2" });
                data.Add(new Data { ID = 7, ParentID = 2, Title = "A3" });

                data.Add(new Data { ID = 8, ParentID = 3, Title = "B1" });
                data.Add(new Data { ID = 9, ParentID = 3, Title = "B2" });

                data.Add(new Data { ID = 10, ParentID = 4, Title = "C1" });

                data.Add(new Data { ID = 11, ParentID = 8, Title = "B1A" });
                data.Add(new Data { ID = 12, ParentID = 8, Title = "B1B" });

                HttpContext.Current.Session["Data"] = data;
            }

            return data;
        }

        public static void MoveNodes(int[] nodeKeys, int parentID)
        {
            var data = GetData();
            var processedNodes = data.Join(nodeKeys, x => x.ID, y => y, (x, y) => x);

            foreach(var node in processedNodes)
            {
                if (processedNodes.Where(x => x.ID == node.ParentID).Count() == 0)
                {
                    if (node.ParentID == 0)
                    {
                        MakeParentNodeRoot(parentID);
                    }
                    node.ParentID = parentID;
                }
            }
        }

        public static void MoveNode(int nodeID, int parentID)
        {
            var data = GetData();

            var node = data.Find(x => x.ID == nodeID);

            if (node.ParentID == 0)
            {
                MakeParentNodeRoot(parentID);
            }

            node.ParentID = parentID;
        }

        public static void MakeParentNodeRoot(int id)
        {
            GetData().Find(x => x.ID == id).ParentID = 0;
        }
    }
}