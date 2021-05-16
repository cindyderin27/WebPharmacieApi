using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebPharmacieApi.Models.Entities;

namespace WebPharmacieApi.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly PharmacieAspEntities db;

        public BaseController(PharmacieAspEntities db)
        {
            this.db = db;
        }
    }
}
