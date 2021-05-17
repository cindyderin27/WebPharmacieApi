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
    public class MedicamentController : BaseController
    {

        [HttpGet]

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await db.Medicaments.OrderByDescending(x => x.IdMedicament).ToArrayAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Details(int id)
        {
            return Ok(await db.Medicaments.FindAsync(id));
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] Medicament item)
        {
            var olditem = await db.Medicaments.AsNoTracking().FirstOrDefaultAsync(x => x.IdMedicament == item.IdMedicament);
            if (olditem != null)
            {

                item.DateFabrication = olditem.DateFabrication;
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Medicament item)
        {
            item.DateFabrication = DateTime.Now;
            db.Medicaments.Add(item);
            await db.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var item = await db.Medicaments.FindAsync(id);
            if (item != null)
            {
                db.Medicaments.Remove(item);
                await db.SaveChangesAsync();
            }
            return Ok(item);
        }
    }
}
