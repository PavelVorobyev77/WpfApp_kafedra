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
    
    public partial class Kafedra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kafedra()
        {
            this.Disciplines = new HashSet<Disciplines>();
            this.Groups = new HashSet<Groups>();
            this.Teachers = new HashSet<Teachers>();
        }
    
        public int KafedratID { get; set; }
        public Nullable<int> FacultyID { get; set; }
        public string KafedraName { get; set; }
        public string HeadOfKafedraFIO { get; set; }
        public Nullable<int> KafedraOfficeRoomNumber { get; set; }
        public string KafedraOfficePhone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disciplines> Disciplines { get; set; }
        public virtual Faculties Faculties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Groups> Groups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
