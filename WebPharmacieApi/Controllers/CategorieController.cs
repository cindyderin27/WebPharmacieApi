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
    public class CategorieController : ApiController
    {
        protected readonly PharmacieAspEntities db;
        [HttpGet]

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await db.Categories.ToArrayAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Details(int id)
        {
            return Ok(await db.Categories.FindAsync(id));
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] Categorie item)
        {
            var olditem = await db.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.IdCategorie == item.IdCategorie);
            if (olditem != null)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Categorie item)
        {

            db.Categories.Add(item);
            await db.SaveChangesAsync();
            return Ok();
        }


       
        public async Task<IHttpActionResult> Delete(int id)
        {
            var item = await db.Categories.FindAsync(id);
            if (item != null)
            {
                db.Categories.Remove(item);
                await db.SaveChangesAsync();
            }
            return Ok(item);
        }

    }
}
