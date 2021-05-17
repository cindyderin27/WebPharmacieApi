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
    public class PanierController : BaseController
    {

        [HttpGet]

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await db.Paniers.OrderByDescending(x => x.PanierId).ToArrayAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Details(int id)
        {
            return Ok(await db.Paniers.FindAsync(id));
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] Panier item)
        {
            var olditem = await db.Paniers.AsNoTracking().FirstOrDefaultAsync(x => x.IdPanier == item.IdPanier);
            if (olditem != null)
            {

            
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Panier item)
        {
           
            db.Paniers.Add(item);
            await db.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var item = await db.Paniers.FindAsync(id);
            if (item != null)
            {
                db.Paniers.Remove(item);
                await db.SaveChangesAsync();
            }
            return Ok(item);
        }
    }
}
