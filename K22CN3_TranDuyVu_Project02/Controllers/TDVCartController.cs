using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K22CN3_TranDuyVu_Project02.Models;
using K22CN3_TranDuyVu_Project02.Bussiness;

namespace K22CN3_TranDuyVu_Project02.Controllers
{
    public class TDVCartController : Controller
    {
        private const string TDVCartSessionKey = "TDVCartSessionKey";
        TDVDbEntities dbEntities = new TDVDbEntities();

        private TDV_ShoppingCart GetCart()
        {
            var cart = Session[TDVCartSessionKey] as TDV_ShoppingCart;
            if (cart == null)
            {
                cart = new TDV_ShoppingCart();
                Session[TDVCartSessionKey] = cart;
            }

            return cart;
        }
        // Add to cart: them mot san pham vao gio hang
        public ActionResult AddToCart(int id, string TenGame, String HinhAnh, int SoLuongMua, float DonGiaMua)
        {
            var cart = GetCart();
            var item = new TDVCartItem
            {
                ID = id,
                TenGame = TenGame,
                HinhAnh = HinhAnh,
                SoLuongMua = SoLuongMua,
                DonGiaMua = DonGiaMua,
                ThanhTien = SoLuongMua * DonGiaMua
            };

            cart.AddToCart(item);
            return RedirectToAction("Index");

        }

        // GET: DVHCart - Hiển thị các sản phẩm trong giỏ hàng
        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart.Items);
        }

        // Trang thong tin thanh toan
        public ActionResult ThongTinThanhToan()
        {
            var cart = GetCart();
            ViewBag.TongTriGia = cart.GetTongThanhTien();
            DateTime dt = DateTime.Now;
            var MaHoaDon = "DH-" + dt.ToString("yyyyMMdd-HHmmss");
            ViewBag.MaHoaDon = MaHoaDon;
            return View(cart.Items);
        }
        // Cập nhật và thanh toán
        public ActionResult ThanhToan(FormCollection form)
        {
            var cart = GetCart();

            // Lấy các thông tin trên form để cập nhật bảng hóa đơn
            var HoTenKhachHang = form["HoTenKhachHang"];
            var Email = form["Email"];
            var DienThoai = form["DienThoai"];
            var DiaChi = form["DiaChi"];

            // Thông tin đơn hàng
            DateTime dt = DateTime.Now;
            var MaHoaDon = "DH-" + dt.ToString("yyyyMMdd-HHmmss");
            var NgayNhan = form["NgayNhan"];
            var TriGia = cart.GetTongThanhTien();

            // Thêm mới vào bảng HoaDon
            var hoaDon = new HOA_DON();
            hoaDon.MaHoaDon = MaHoaDon;
            hoaDon.KhachHangID = 1;
            hoaDon.NgayHoaDon = dt;
            hoaDon.NgayNhan = DateTime.Parse(NgayNhan);
            hoaDon.TongTriGia = TriGia;
            hoaDon.HoTenKhachHang = HoTenKhachHang;
            hoaDon.Email = Email;
            hoaDon.DienThoai = DienThoai;
            hoaDon.DiaChi = DiaChi;
            hoaDon.TrangThai = 0;

            dbEntities.HOA_DON.Add(hoaDon);
            dbEntities.SaveChanges();

            // Lấy id hóa đơn vừa thêm
            int hoaDonId = dbEntities.HOA_DON.Max(x => x.ID);

            // Thêm vào chi tiết hóa đơn
            foreach (var item in cart.Items)
            {
                CT_HOA_DON ct = new CT_HOA_DON();
                ct.HoaDonID = hoaDonId;
                ct.GameID = item.ID;
                ct.SoLuongMua = item.SoLuongMua;
                ct.DonGiaMua = item.DonGiaMua;
                ct.ThanhTien = item.ThanhTien;

                dbEntities.CT_HOA_DON.Add(ct);
                dbEntities.SaveChanges();
            }

            return RedirectToAction("CamOn");

        }
        public ActionResult CamOn()
        {
            return View();
        }
        // Cập nhật giỏ hàng
        public ActionResult UpdateFromCart(FormCollection form)
        {
            var cart = GetCart();
            var ids = form["ID"].Split(',');
            var qtys = form["SoLuongMua"].Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                int id = int.Parse(ids[i]);
                int qty = int.Parse(qtys[i]);
                cart.UpdateFromCart(id, qty);
            }
            return RedirectToAction("Index");
        }
        // Cap nhat item in cart
        public ActionResult UpdateItemCart(int id, int qty)
        {
            var cart = GetCart();
            cart.UpdateFromCart(id, qty);
            return RedirectToAction("Index");
        }

        // Xoa san pham trong gio hang
        public ActionResult DeleteItemCart(int id)
        {
            var cart = GetCart();
            cart.RemoveCartItem(id);
            return RedirectToAction("Index");
        }

    }
}