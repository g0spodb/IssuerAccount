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
    
    public partial class Investor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Investor()
        {
            this.Deal = new HashSet<Deal>();
        }
    
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Id_Account { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deal { get; set; }
    }
}
