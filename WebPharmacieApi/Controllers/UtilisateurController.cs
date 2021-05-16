using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebPharmacieApi.Models.Entities;

namespace WebPharmacieApi.Controllers
{
    public class UtilisateurController : ApiController
    {
        protected readonly PharmacieAspEntities db;

        [HttpGet]

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await db.Utilisateurs.ToArrayAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Details(int id)
        {
            return Ok(await db.Utilisateurs.FindAsync(id));
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] Utilisateur item)
        {
            var olditem = await db.Utilisateurs.AsNoTracking().FirstOrDefaultAsync(x => x.IdUtilisateur == item.IdUtilisateur);
            if (olditem != null)
            {


                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Utilisateur item)
        {

            db.Utilisateurs.Add(item);
            await db.SaveChangesAsync();
            return Ok();
        }


      
        public async Task<IHttpActionResult> Delete(int id)
        {
            var item = await db.Utilisateurs.FindAsync(id);
            if (item != null)
            {
                db.Utilisateurs.Remove(item);
                await db.SaveChangesAsync();
            }
            return Ok(item);
        }

    }
}

