//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5032AssVer2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class EventRegister
    {
        public int Id { get; set; }
        public string RegisterDate { get; set; }
        public int CustomerId { get; set; }
        public int EventId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Event Event { get; set; }
    }
}
