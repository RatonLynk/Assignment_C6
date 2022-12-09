using System;
using System.Collections.Generic;

namespace Assignment_True.Shared.Models
{
    public partial class Lop
    {
        public Lop()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        public string MaLop { get; set; }
        public string TenLop { get; set; } = null!;
        public string? MaTruong { get; set; }
        public string? MaMonHoc { get; set; }
        public bool Status { get; set; }

        public virtual Truong? MaTruongNavigation { get; set; }
        public virtual MonHoc? MaMonHocNavigation { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
