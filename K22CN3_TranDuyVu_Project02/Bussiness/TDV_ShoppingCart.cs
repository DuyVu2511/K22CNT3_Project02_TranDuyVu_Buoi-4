using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using K22CN3_TranDuyVu_Project02.Models;

namespace K22CN3_TranDuyVu_Project02.Bussiness
{
    public class TDV_ShoppingCart
    {
        public List<TDVCartItem> Items { get; set; }
        public TDV_ShoppingCart() {
            Items = new List<TDVCartItem>();
        }

        // Chuc nang them san pham vao gio hang
        public void AddToCart(TDVCartItem item)
        {
            var existingItem = Items.FirstOrDefault(x => x.ID == item .ID);
            if(existingItem != null)
            {
                existingItem.SoLuongMua += item.SoLuongMua;
            }
            else
            {
                Items.Add(item);
            }
        }
        // Xóa sản phẩm trong giỏ hàng
        public void RemoveCartItem(int id)
        {
            var itemToRemove = Items.FirstOrDefault(x => x.ID == id);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        // Tính tổng trị giá của hóa đơn
        public float GetTongThanhTien()
        {
            return Items.Sum(x => x.SoLuongMua * x.DonGiaMua);
        }

        // Cập nhật Shopping cart
        public void UpdateFromCart(int id, int qty)
        {
            var existingItem = Items.FirstOrDefault(x => x.ID == id);
            if (existingItem != null)
            {
                existingItem.SoLuongMua = qty;
            }
        }


    }
}