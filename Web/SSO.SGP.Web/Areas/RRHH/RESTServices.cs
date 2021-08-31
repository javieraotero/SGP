using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SSO.SGP.EntidadesDeNegocio;

namespace SSO.SGP.Web.Areas.RRHH
{
    public class RESTServices : ApiController
    {
        private BDEntities db = new BDEntities();

        // GET api/RESTServices
        public IEnumerable<Agentes> GetAgentes()
        {
            var agentes = db.Agentes.Include(a => a.Personas).Include(a => a.UltimoCargos);
            return agentes.AsEnumerable();
        }

        // GET api/RESTServices/5
        public Agentes GetAgentes(int id)
        {
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return agentes;
        }

        // PUT api/RESTServices/5
        public HttpResponseMessage PutAgentes(int id, Agentes agentes)
        {
            if (ModelState.IsValid && id == agentes.Id)
            {
                db.Entry(agentes).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/RESTServices
        public HttpResponseMessage PostAgentes(Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                db.Agentes.Add(agentes);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, agentes);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = agentes.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/RESTServices/5
        public HttpResponseMessage DeleteAgentes(int id)
        {
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Agentes.Remove(agentes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, agentes);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}