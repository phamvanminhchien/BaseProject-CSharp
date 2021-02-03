using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.model {

    /// <summary>
    /// Base Model
    /// </summary>
    public class BaseModel {
        public string Uuid { get; set; }
        public string Status { get; set; }
        public double CreatedDate { get; set; }
        public double ModifiedDate { get; set; }
    }
}