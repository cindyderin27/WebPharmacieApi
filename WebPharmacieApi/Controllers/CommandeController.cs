using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebPharmacieApi.Modeles;

namespace WebPharmacieApi.Controllers
{
    public class CommandeController : BaseController
    {
        [HttpGet]

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await db.Commandes.OrderByDescending(x => x.IdCommande).ToArrayAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Details(int id)
        {
            return Ok(await db.Commandes.FindAsync(id));
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] Commande item)
        {
            var olditem = await db.Commandes.AsNoTracking().FirstOrDefaultAsync(x => x.IdCommande == item.IdCommande);
            if (olditem != null)
            {


                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Commande item)
        {

            db.Commandes.Add(item);
            await db.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var item = await db.Commandes.FindAsync(id);
            if (item != null)
            {
                db.Commandes.Remove(item);
                await db.SaveChangesAsync();
            }
            return Ok(item);
        }
    }
}
