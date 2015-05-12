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
    
    public partial class request_slots
    {
        public request_slots()
        {
            this.handshakes = new HashSet<handshake>();
            this.proposed_handshakes = new HashSet<proposed_handshakes>();
        }
    
        public int id { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public decimal range { get; set; }
        public System.DateTime request_datetime_start { get; set; }
        public System.DateTime request_datetime_end { get; set; }
        public int car_id { get; set; }
        public byte[] active { get; set; }
    
        public virtual car car { get; set; }
        public virtual ICollection<handshake> handshakes { get; set; }
        public virtual ICollection<proposed_handshakes> proposed_handshakes { get; set; }
    }
}
