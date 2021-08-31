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
using SSO.SGP.ReglasDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;

namespace SSO.SGP.Web.WebApi
{
    public class AgentesController : ApiController
    {
        //private BDEntities db = new BDEntities();
        private AgentesRN oAgentes = new AgentesRN();

        //// GET api/Agentes
        //public IEnumerable<Agentes> GetAgentes()
        //{
        //    var agentes = db.Agentes.Include(a => a.Personas).Include(a => a.UltimoCargos);
        //    return agentes.AsEnumerable();
        //}

        // GET api/Agentes/5
        [HttpGet]
        public dynamic GetAgentes(int id)
        {
            Agentes agentes = oAgentes.ObtenerPorLegajo(id);//db.Agentes.Where(a=>a.Legajo == id).FirstOrDefault();
            if (agentes == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new { nombre=agentes.Personas.Nombres};
        }

        [HttpGet]
        public dynamic Dias(int id)
        {
            ResumenLicenciasPorOrganismoViewT resumen = oAgentes.Resumen(id);//db.Agentes.Where(a=>a.Legajo == id).FirstOrDefault();
            if (resumen == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new { nombre = resumen.Agente, particulares = resumen.Particulares, ordinarias = resumen.Ordinaria };
        }

        //// PUT api/Agentes/5
        //public HttpResponseMessage PutAgentes(int id, Agentes agentes)
        //{
        //    if (ModelState.IsValid && id == agentes.Id)
        //    {
        //        db.Entry(agentes).State = EntityState.Modified;

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound);
        //        }

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

        //// POST api/Agentes
        //public HttpResponseMessage PostAgentes(Agentes agentes)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Agentes.Add(agentes);
        //        db.SaveChanges();

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, agentes);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = agentes.Id }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

        //// DELETE api/Agentes/5
        //public HttpResponseMessage DeleteAgentes(int id)
        //{
        //    Agentes agentes = db.Agentes.Find(id);
        //    if (agentes == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.Agentes.Remove(agentes);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, agentes);
        //}

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            base.Dispose(disposing);
        }
    }
}