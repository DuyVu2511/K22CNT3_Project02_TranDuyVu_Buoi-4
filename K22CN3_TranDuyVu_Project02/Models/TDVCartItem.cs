using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K22CN3_TranDuyVu_Project02.Models
{
    public class TDVCartItem
    {
        public int ID { get; set; }
        public string TenGame { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuongMua { get; set; }
        public float DonGiaMua { get; set; }
        public float ThanhTien { get; set; }
    }
}