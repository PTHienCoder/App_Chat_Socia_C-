using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
    public class BookingRequest
    {
        public int SoGhe { get; set; }
        public float GiaGhe { get; set; }
        public DateTime ThoiGianChay { get; set; }
        public string GaDi { get; set; }
        public string GaDen { get; set; }

        public BookingRequest(int soghe, float giaghe, DateTime thogianchay, string gadi, string gaden)
        {
            this.GaDen = gaden;
            this.GaDi = gadi;
            this.GiaGhe = giaghe;
            this.SoGhe = soghe;
            this.ThoiGianChay = DateTime.Today;
        }
    }
}
