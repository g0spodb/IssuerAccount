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
    
    public partial class AccountOpeningApplication
    {
        public int Id { get; set; }
        public Nullable<int> Id_Issuer { get; set; }
        public Nullable<bool> RegistrationStatus { get; set; }
        public Nullable<System.DateTime> DateOfApplication { get; set; }
        public Nullable<System.DateTime> DateApprovalApplication { get; set; }
        public Nullable<int> Id_Registrar { get; set; }
    
        public virtual Issuer Issuer { get; set; }
        public virtual Registrar Registrar { get; set; }
    }
}