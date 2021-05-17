using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebPharmacieApi.Modeles;

namespace WebPharmacieApi.Controllers
{
    public class BaseController : ApiController
    {
         protected readonly PharmacieAspEntities db;

        public BaseController()
        {
            db = new PharmacieAspEntities();
        }
    }
}
