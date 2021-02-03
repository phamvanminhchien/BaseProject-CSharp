using CommonUtils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BaseProject.Api {

    public class TestApiController : ApiController {
        private IRandomUtil random;

        public TestApiController(IRandomUtil random) {
            this.random = random;
        }

        [HttpGet]
        public int Method() {
            var x = random.RandomNumber();
            var y = random.RandomNumber(10);
            var z = random.RandomNumber(1, 10);
            return 0;
        }
    }
}