using System;
using System.Collections.Generic;

namespace Assignment_True.Shared.Models
{
    public partial class Truong
    {
        public Truong()
        {
            Lops = new HashSet<Lop>();
            MonHocs = new HashSet<MonHoc>();
            Nganhs = new HashSet<Nganh>();
            SinhViens = new HashSet<SinhVien>();
        }

        public string MaTruong { get; set; } = null!;
        public string TenTruong { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<Lop> Lops { get; set; }
        public virtual ICollection<MonHoc> MonHocs { get; set; }
        public virtual ICollection<Nganh> Nganhs { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
