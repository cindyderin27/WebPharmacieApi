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
    public class StockController : ApiController
    {
        protected readonly PharmacieAspEntities db;


        [HttpGet]

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await db.Stocks.ToArrayAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Details(int id)
        {
            return Ok(await db.Stocks.FindAsync(id));
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] Stock item)
        {
            var olditem = await db.Stocks.AsNoTracking().FirstOrDefaultAsync(x => x.IdStock== item.IdStock);
            if (olditem != null)
            {


                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Stock item)
        {

            db.Stocks.Add(item);
            await db.SaveChangesAsync();
            return Ok();
        }



        public async Task<IHttpActionResult> Delete(int id)
        {
            var item = await db.Stocks.FindAsync(id);
            if (item != null)
            {
                db.Stocks.Remove(item);
                await db.SaveChangesAsync();
            }
            return Ok(item);
        }

    }


}

