using System;
using System.Collections.Generic;

namespace Assignment_True.Shared.Models
{
    public partial class Nganh
    {
        public Nganh()
        {
            MonHocs = new HashSet<MonHoc>();
            SinhViens = new HashSet<SinhVien>();
        }

        public string MaNganh { get; set; } = null!;
        public string TenNganh { get; set; } = null!;
        public string? MaTruong { get; set; }
        public bool Status { get; set; }

        public virtual Truong? MaTruongNavigation { get; set; }
        public virtual ICollection<MonHoc> MonHocs { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
