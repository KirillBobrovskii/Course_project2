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
    
    public partial class Pays
    {
        public int ID_P { get; set; }
        public Nullable<int> ID_Stud { get; set; }
        public Nullable<decimal> Pay { get; set; }
        public Nullable<System.DateTime> P_Date { get; set; }
    
        public virtual Students Students { get; set; }
    }
}
