//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp_kafedra
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sub_statement
    {
        public int Sub_statementID { get; set; }
        public Nullable<int> StatementID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public string Score { get; set; }
    
        public virtual Statement Statement { get; set; }
        public virtual Students Students { get; set; }
    }
}
