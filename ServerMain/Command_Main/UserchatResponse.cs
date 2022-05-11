using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command_Main.DataObjects;
namespace Command_Main
{
    [Serializable]
    public class UserchatResponse
    {
        //    public InfoItemUserChat[] Items { get; set; }
        public DataTable data { get; set; }
        public UserchatResponse(DataTable DataTable)
        {
            this.data = DataTable;
        }
    }
}
