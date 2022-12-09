using System;
using System.Collections.Generic;

namespace Assignment_True.Shared.Models
{
    public partial class Diem
    {
        public string MaSv { get; set; } = null!;
        public string MaMonHoc { get; set; } = null!;
        public double DiemDocument { get; set; }
        public double DiemPresentation { get; set; }
        public bool Status { get; set; }

        public virtual MonHoc? MaMonHocNavigation { get; set; }
        public virtual SinhVien? MaSvNavigation { get; set; }
    }
}
