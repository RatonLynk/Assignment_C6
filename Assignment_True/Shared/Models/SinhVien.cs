using System;
using System.Collections.Generic;

namespace Assignment_True.Shared.Models
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            Diems = new HashSet<Diem>();
        }

        public string MaSv { get; set; } = null!;
        public string TenSv { get; set; } = null!;
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MaTruong { get; set; } = null!;
        public string MaNganh { get; set; } = null!;
        public string? MaLop { get; set; }
        public string? Anh { get; set; }
        public bool Status { get; set; }

        public virtual Lop? MaLopNavigation { get; set; }
        public virtual Nganh? MaNganhNavigation { get; set; }
        public virtual Truong? MaTruongNavigation { get; set; }
        public virtual ICollection<Diem> Diems { get; set; }
    }
}
