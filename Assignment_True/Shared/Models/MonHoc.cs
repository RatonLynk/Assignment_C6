using System;
using System.Collections.Generic;

namespace Assignment_True.Shared.Models
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            Diems = new HashSet<Diem>();
        }

        public string MaMonHoc { get; set; } = null!;
        public string TenMonHoc { get; set; } = null!;
        public string? MaTruong { get; set; }
        public string? MaNganh { get; set; }
        public bool Status { get; set; }

        public virtual Nganh? MaNganhNavigation { get; set; }
        public virtual Truong? MaTruongNavigation { get; set; }
        public virtual ICollection<Lop>? Lops { get; set; }
        public virtual ICollection<Diem> Diems { get; set; }
    }
}
