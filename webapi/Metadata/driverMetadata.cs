using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace webapi
{
    [MetadataType(typeof(driverMetadata))]
    public partial class driver
    {
        public class driverMetadata
        {
            [MinLength(5, ErrorMessageResourceName = "NickNameMinLength", ErrorMessageResourceType = typeof(Local))]
            public string nickname { get; set; }
        }
    }


    
}