//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22CN3_TranDuyVu_Project02.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GAME
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GAME()
        {
            this.CT_HOA_DON = new HashSet<CT_HOA_DON>();
            this.DANH_GIA = new HashSet<DANH_GIA>();
        }
    
        public int ID { get; set; }
        public string MaGame { get; set; }
        public string TenGame { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> DonGia { get; set; }
        public Nullable<int> MaLoai { get; set; }
        public Nullable<byte> TrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOA_DON> CT_HOA_DON { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANH_GIA> DANH_GIA { get; set; }
        public virtual LOAI_GAME LOAI_GAME { get; set; }
    }
}
