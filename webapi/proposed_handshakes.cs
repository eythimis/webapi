//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webapi
{
    using System;
    using System.Collections.Generic;
    
    public partial class proposed_handshakes
    {
        public int id { get; set; }
        public int request_id { get; set; }
        public int offer_id { get; set; }
    
        public virtual offer_slots offer_slots { get; set; }
        public virtual request_slots request_slots { get; set; }
    }
}