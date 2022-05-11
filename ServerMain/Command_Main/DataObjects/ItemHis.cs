using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main.DataObjects
{
    [Serializable]
    public class ItemHis
    {
        public DataTable Data;
        public ItemHis(DataTable data)
        {
            this.Data = data;
           
        }
    }
}
