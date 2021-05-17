using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebPharmacieApi.Models;

namespace WebPharmacieApi.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly PharmacieAspEntities1 db;

        public BaseController()
        {
            db = new PharmacieAspEntities1();
        }
    }
}
