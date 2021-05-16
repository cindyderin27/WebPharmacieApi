using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebPharmacieApi.Models.Entities;

namespace WebPharmacieApi.Controllers
{
    public class MedicamentController : ApiController
    {
        protected readonly PharmacieAspEntities db;

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var medicaments = await db.Medicaments
                   .OrderByDescending(x => x.DateFabrication)
                    .ToArrayAsync();
                //foreach (var p in medicaments)
                //{
                //    p.Photo = Url.Content("~/Uploads/" + p.Photo).ToString();
                //}
                return Ok(await db.Medicaments.ToArrayAsync());
            }
            catch (DbUpdateException ex)
            {
                var exception = ex.InnerException?.InnerException as SqlException;
                return BadRequest(exception?.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return Ok(await db.Medicaments.ToArrayAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Details(int id)
        {
            try
            {
                var medicaments = await db.Medicaments.FindAsync(id);
                //medicaments.Photo = Request.RequestUri.GetLeftPart(UriPartial.Authority) +
                //    "/Uploads/" + medicaments.Photo;
                return Ok(await db.Medicaments.ToArrayAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //var medicament = await db.Medicaments.FindAsync(id);
            //medicament.Photo = Request.RequestUri.GetLeftPart(UriPartial.Authority) +
            //    "/Content/Uploads" + medicament.Photo;
            //return Ok(medicament);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put()
        {

            try
            {
                var json = HttpContext.Current.Request.Form["data"];
                Medicament newMedicament = JsonConvert.DeserializeObject<Medicament>(json);

                var oldMedicament = db.Medicaments.AsNoTracking().FirstOrDefault(x => x.IdMedicament == newMedicament.IdMedicament);
                if (oldMedicament == null)
                    return Content(HttpStatusCode.NotFound, "Le medicament " + newMedicament.IdMedicament + " n'existe pas.");

                //string uploadFolder = HttpContext.Current.Server.MapPath("~/Uploads");
                //if (!Directory.Exists(uploadFolder))
                //    Directory.CreateDirectory(uploadFolder);

                //if (HttpContext.Current.Request.Files.Count > 0)
                //{
                //    if (!string.IsNullOrEmpty(newMedicament.Photo) &&
                //        File.Exists(Path.Combine(uploadFolder, oldMedicament.Photo)))
                //    {
                //        File.Delete(Path.Combine(uploadFolder, oldMedicament.Photo));
                //    }
                //    var file = HttpContext.Current.Request.Files[0];
                //    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                //    file.SaveAs(Path.Combine(uploadFolder, filename));
                //    newMedicament.Photo = filename;
                //}
                //else
                //{
                //    newMedicament.Photo = oldMedicament.Photo;
                //}
                newMedicament.DateFabrication = oldMedicament.DateFabrication;
                db.Entry(newMedicament).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok(newMedicament);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //var olditem = await db.Medicaments.AsNoTracking().FirstOrDefaultAsync(x => x.IdMedicament == item.IdMedicament);

            //if (olditem != null)
            //{
            //    item.DateFabrication = olditem.DateFabrication;
            //    db.Entry(item).State = EntityState.Modified;
            //    await db.SaveChangesAsync();
            //}

            //return Ok(item);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            try
            {
                var json = HttpContext.Current.Request.Form["data"];
                Medicament medicament = JsonConvert.DeserializeObject<Medicament>(json);

                //string uploadFolder = HttpContext.Current.Server.MapPath("~/Uploads");
                //if (!Directory.Exists(uploadFolder))
                //    Directory.CreateDirectory(uploadFolder);

                //if (HttpContext.Current.Request.Files.Count > 0)
                //{
                //    var file = HttpContext.Current.Request.Files[0];
                //    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                //    file.SaveAs(Path.Combine(uploadFolder, filename));
                //    medicament.Photo = filename;
                //}


                medicament.IdMedicament = 0;
                medicament.DateFabrication = DateTime.Now;
                db.Medicaments.Add(medicament);
                await db.SaveChangesAsync();
                return Ok(medicament);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



            //try
            //{
            //    var json = HttpContext.Current.Request.Form["data"];
            //    Medicament medicament = JsonConvert.DeserializeObject<Medicament>(json);

            //    string uploadFolder = HttpContext.Current.Server.MapPath("~/Uploads");
            //    if (!Directory.Exists(uploadFolder))
            //        Directory.CreateDirectory(uploadFolder);

            //    if (HttpContext.Current.Request.Files.Count > 0)
            //    {
            //        var file = HttpContext.Current.Request.Files[0];
            //        string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            //        file.SaveAs(Path.Combine(uploadFolder, filename));
            //        medicament.Photo = filename;
            //    }


            //    medicament.IdMedicament = 0;
            //    medicament.DateFabrication = DateTime.Now;
            //    db.Medicaments.Add(medicament);
            //    await db.SaveChangesAsync();
            //    return Ok(medicament);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }



        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var medicament = db.Medicaments.Find(id);
                if (medicament == null)
                    return Content(HttpStatusCode.NotFound, "Le medicament" + id + " n'existe pas.");
                db.Medicaments.Remove(medicament);
                await db.SaveChangesAsync();

                //string uploadFolder = HttpContext.Current.Server.MapPath("~/Uploads");
                //if (!string.IsNullOrEmpty(medicament.Photo) &&
                //        File.Exists(Path.Combine(uploadFolder, medicament.Photo)))
                //{
                //    File.Delete(Path.Combine(uploadFolder, medicament.Photo));
                //}


                return Ok(medicament);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //var item = await db.Medicaments.FindAsync(id);
            //if (item != null)
            //{
            //    db.Medicaments.Remove(item);
            //    await db.SaveChangesAsync();
            //}
            //return Ok(item);
        }
    }

}

