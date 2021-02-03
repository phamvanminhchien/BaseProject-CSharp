using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.model {

    public class UserTbl : BaseModel {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}