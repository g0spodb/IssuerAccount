//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IssuerAccount.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deal
    {
        public int Id { get; set; }
        public Nullable<int> Id_Security { get; set; }
        public Nullable<int> Id_Investor { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Investor Investor { get; set; }
        public virtual Security Security { get; set; }
    }
}
