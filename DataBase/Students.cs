//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wpf_DataBase_Hostel_App.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            this.CheckInOut = new HashSet<CheckInOut>();
            this.Pays = new HashSet<Pays>();
        }
    
        public int ID_Stud { get; set; }
        public string F { get; set; }
        public string I { get; set; }
        public string O { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string PassInfo { get; set; }
        public Nullable<int> ID_Exemption { get; set; }
        public Nullable<int> ID_Room { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckInOut> CheckInOut { get; set; }
        public virtual Exemptions Exemptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pays> Pays { get; set; }
        public virtual Rooms Rooms { get; set; }
    }
}
