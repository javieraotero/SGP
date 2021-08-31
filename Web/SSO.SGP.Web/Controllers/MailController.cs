using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActionMailer.Net.Mvc;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Results;
using SSO.SGP.ReglasDeNegocio;

namespace SSO.SGP.Web.Controllers
{
    public class MailController : MailerBase
    {
        private AgentesRN oAgentes = new AgentesRN();
        private SolicitudesDeViaticosAD oSolicitudes = new SolicitudesDeViaticosAD();
        private LocalidadesRefAD oLocalidades = new LocalidadesRefAD();

        public EmailResult ConfirmarTurno(TurnosWeb model)
        {
            var o = new OrganismosRefAD().ObtenerPorId(model.Organismo);

            ViewBag.Organismo = o.Descripcion;

            To.Add(model.Email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Confirmación de Turno - Poder Judicial de La Pampa";
            return Email("ConfirmarTurno", model);
        }

        public EmailResult VerificationEmail(Usuarios model, string confirmationToken)
        {
            //To.Add(model.Email);
            From = "avisos@mycoolsite.com";
            Subject = "Gracias por registrarse en el sistema!";
            ViewBag.Token = confirmationToken;
            return Email("VerificationEmail", model);
        }

        public EmailResult SolicitudDeLicencia(LicenciasResult model, int agente_destinatario, string token)
        {
            var a = oAgentes.ObtenerPorId(agente_destinatario);

            switch (model.Id_Cargo)
            {
                case 43:
                case 44:
                case 45:
                    ViewBag.Subrogante = "0";
                    break;
                default:
                    ViewBag.Subrogante = "1";
                    break;
            }

            ViewBag.Subrogante = "";

            if (model.Subrogante.HasValue) {
                var s = oAgentes.ObtenerPorId(model.Subrogante.Value);
                ViewBag.Subrogante = s.Personas.Apellidos.Trim() + ", " + s.Personas.Nombres.Trim();
                ViewBag.SubroganteCargo = s.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Descripcion;
                ViewBag.SubroganteOrganismo = s.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Organismos.Descripcion;
            }

            ViewBag.aprueba = false;
            ViewBag.viene_de = model.viene_de.HasValue ? model.viene_de : 0;

            if (a.Nombramientos.Where(x => x.Organismos.UnidadOrganizacionRRHH == 2 && !x.FechaDeBaja.HasValue && (x.Cargo == 5)).Count() > 0)
                ViewBag.aprueba = true;

            if (a.Nombramientos.Where(x => x.Organismos.UnidadOrganizacionRRHH == 2 && !x.FechaDeBaja.HasValue && (x.Cargo == 8) && model.viene_de == 526).Count() > 0)
                ViewBag.aprueba = true;

            if (a.Nombramientos.Where(x => x.Organismos.UnidadOrganizacionRRHH != 2 && !x.FechaDeBaja.HasValue).Count() > 0)
                ViewBag.aprueba = true;

            ViewBag.Aprobaciones = new SSO.SGP.AccesoADatos.LicenciasAgenteAD().GetAprobacionesResult(model.Id);
            ViewBag.Dias = (model.Hasta - model.Desde).Days + 1;
            To.Add(a.Email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Solicitud de licencia - " + model.Agente;
            ViewBag.Nombre = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
            ViewBag.Token = token;
            return Email("SolicitudDeLicencia", model);
        }
    
        public EmailResult SolicitudDeLicenciaCancelada(LicenciasResult model, int agente_destinatario, string token)
        {
            var a = oAgentes.ObtenerPorId(agente_destinatario);
            ViewBag.Aprobaciones = new SSO.SGP.AccesoADatos.LicenciasAgenteAD().GetAprobacionesResult(model.Id);
            ViewBag.Dias = (model.Hasta - model.Desde).Days + 1;
            To.Add(a.Email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Solicitud de licencia CANCELADA - " + model.Agente;
            ViewBag.Nombre = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
            ViewBag.Token = token;
            return Email("SolicitudDeLicenciaCancelada", model);

        }


        public EmailResult SolicitudDeLicenciaFuncionario(LicenciasResult model, string email, string funcionario, string subrogante, string organismo, string token)
        {

            ViewBag.aprueba = false;

            if (model.Subrogante.HasValue)
            {
                var s = oAgentes.ObtenerPorId(model.Subrogante.Value);
                ViewBag.Subrogante = s.Personas.Apellidos.Trim() + ", " + s.Personas.Nombres.Trim();
                ViewBag.SubroganteCargo = s.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Descripcion;
                ViewBag.SubroganteOrganismo = s.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Organismos.Descripcion;
            }

            switch (model.Id_Cargo)
            {
                case 43:
                case 44:
                case 45:
                    ViewBag.Subrogante = "0";
                    break;
                default:
                    ViewBag.Subrogante = "1";
                    break;
            }

            if (model.agente_aprueba.HasValue)
            {
                var a = oAgentes.ObtenerPorId(model.agente_aprueba.Value);

                if (a.Nombramientos.Where(x => x.Organismos.UnidadOrganizacionRRHH == 2 && !x.FechaDeBaja.HasValue && (x.Cargo == 5)).Count() > 0)
                    ViewBag.aprueba = true;

                if (a.Nombramientos.Where(x => x.Organismos.UnidadOrganizacionRRHH != 2 && !x.FechaDeBaja.HasValue).Count() > 0)
                    ViewBag.aprueba = true;
            }
                    
            To.Add(email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Solicitud de licencia - " + funcionario;
            ViewBag.Nombre = funcionario;
            ViewBag.Subrogante = subrogante;
            ViewBag.Token = token;
            ViewBag.OrganismoDestino = organismo;
            return Email("SolicitudDeLicenciaFuncionario", model);

        }

        public EmailResult RechazoSubrogante(LicenciasAgente model, string email, string funcionario, string subrogante, string token)
        {
            //var a = oAgentes.ObtenerPorId(agente_destinatario);

            switch (model.Nombramientos.Cargo)
            {
                case 43:
                case 44:
                case 45:
                    ViewBag.Subrogante = "0";
                    break;
                default:
                    ViewBag.Subrogante = "1";
                    break;
            }

            To.Add(email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Solicitud de licencia - " + funcionario;
            ViewBag.Nombre = funcionario;
            ViewBag.Subrogante = subrogante;
            ViewBag.Token = token;
            return Email("RechazoSubrogante", model);

        }

        //public EmailResult SolicitudDeLicenciaFuncionario(LicenciasResult model, int agente_destinatario, string token)
        //{
        //    var a = oAgentes.ObtenerPorId(agente_destinatario);

        //    var subrogante = oAgentes.ObtenerPorId(model.Subrogante.Value);

        //    To.Add(a.Email);
        //    From = "notificaciones.rrhh.sgp@gmail.com";
        //    Subject = "Solicitud de licencia - " + model.Agente;
        //    ViewBag.Nombre = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
        //    ViewBag.Token = token;
        //    ViewBag.Subrogante = subrogante.Personas.Apellidos + ", " + subrogante.Personas.Nombres;
        //    return Email("SolicitudDeLicenciaFuncionario", model);

        //}

        public EmailResult NotificacionProveedor(ECO_Proveedores model)
        {           
            To.Add(model.DomicilioElectronico);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Confirmación de alta como proveedor del Poder Judicial de La Pampa";
            return Email("NotificacionProveedor", model);
        }

        public EmailResult RechazoProveedor(ECO_Proveedores model, string observaciones)
        {
            To.Add(model.DomicilioElectronico);
            ViewBag.Observaciones = observaciones;
            Subject = "Rechazo de ingreso como proveedor del Poder Judicial de La Pampa";
            From = "avisos@juslapampa.gob.ar";
            return Email("RechazoProveedor", model);
        }

        public EmailResult SolicitudDeSubrogante(LicenciasResult model, int agente_destinatario, string token)
        {
            var a = oAgentes.ObtenerPorId(agente_destinatario);

            switch (model.Id_Cargo)
            {
                case 43:
                case 44:
                case 45:
                    ViewBag.Subrogante = "0";
                    Subject = "Solicitud de Suplencia de " + model.Agente;
                    break;
                default:
                    ViewBag.Subrogante = "1";
                    Subject = "Solicitud de Subrogancia de " + model.Agente;
                    break;
            }

            To.Add(a.Email);
            From = "avisos@juslapampa.gob.ar";           
            ViewBag.Nombre = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
            ViewBag.Token = token;
            return Email("SolicitudDeSubrogante", model);
        }

        public EmailResult DepositoDeAnticipo(int anticipo, int agente_destinatario)
        {
            var a = oAgentes.ObtenerPorId(agente_destinatario);
            var s = oSolicitudes.ObtenerPorId(anticipo);
            var l = oLocalidades.ObtenerPorId(s.Destino);

            To.Add(a.Email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Depósito de anticipo - Poder Judicial de La Pampa";
            ViewBag.Nombre = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
            ViewBag.Identificador = s.Id;
            ViewBag.Destino = l.Descripcion;
            ViewBag.Dia = s.FechaDeInicio.ToShortDateString();
            return Email("ConfirmacionAnticipoDepositado");
        }

        public EmailResult ConfirmacionDeAprobacionDeLicencia(LicenciasAgente model, int agente_destinatario, string token)
        {
            var a = oAgentes.ObtenerPorId(agente_destinatario);           

            var es_mp = a.Nombramientos.Where(x=>!x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Organismos.UnidadOrganizacionRRHH == 2;

            To.Add(a.Email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Aprobación de licencia - " + model.Agente;
            ViewBag.Nombre = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
            ViewBag.Token = token;            
            return Email("ConfirmacionLicenciaAprobada", model);
        }

        public EmailResult LicenciaJuezDePaz(LicenciasAgente model, int agente_destinatario, string token, string email, string organismo)
        {
            var a = oAgentes.ObtenerPorId(agente_destinatario);

            To.Add(email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Aprobación de licencia a Juez de Paz " + a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
            ViewBag.Nombre = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
            ViewBag.Token = token;
            ViewBag.Organismo = organismo;
            ViewBag.Dias = (model.FechaHasta.Value - model.FechaDesde).Days + 1;
            ViewBag.Titular = a;

            var suplente = oAgentes.ObtenerPorId(model.SubroganteRRHH.Value);

            ViewBag.Suplente = suplente;

            return Email("LicenciaJuezDePaz", model);
        }

        public EmailResult ConfirmacionDeDesaprobacionDeLicencia(LicenciasAgente model, int agente_destinatario, string token)
        {
            var a = oAgentes.ObtenerPorId(agente_destinatario);

            To.Add(a.Email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Licencia Rechazada - " + model.Agente;
            ViewBag.Nombre = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
            ViewBag.Token = token;
            return Email("ConfirmacionLicenciaDesaprobada", model);
        }

        public EmailResult ConfirmacionLicenciaSubrogante(LicenciasAgente model, int agente_destinatario, string token)
        {
            var a = oAgentes.ObtenerPorId(agente_destinatario);
            var a1 = oAgentes.ObtenerPorId(model.AgenteRRHH.Value);

            To.Add(a.Email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Confirmación de subrogancia - "  +a1.Personas.Apellidos.TrimEnd() + ", " + a1.Personas.Nombres.Trim();
            ViewBag.Nombre = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
            ViewBag.Token = token;
            ViewBag.Agente = a1.Personas.Apellidos.Trim() + ", " + a1.Personas.Nombres.Trim();
            return Email("ConfirmacionLicenciaSubrogante", model);
        }

        public EmailResult ConfirmacionLicenciaSubroganteDesaprobada(LicenciasAgente model, int agente_destinatario, string token)
        {
            var a = oAgentes.ObtenerPorId(agente_destinatario);

            To.Add(a.Email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Subrogancia sin efecto - " + model.Agente;
            ViewBag.Nombre = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
            ViewBag.Token = token;
            return Email("ConfirmacionLicenciaSubroganteDesaprobada", model);
        }

        public EmailResult ConfirmacionSubrogante(LicenciasAgente model, int agente_destinatario, string token)
        {
            var a = oAgentes.ObtenerPorId(agente_destinatario);

            To.Add(a.Email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Aprobación de Subrogante " + model.AgenteRRHHs.Personas.Apellidos + ", " + model.AgenteRRHHs.Personas.Nombres;
            ViewBag.Nombre = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd();
            ViewBag.Token = token;
            ViewBag.Subrogante = model.AgenteRRHHs.Personas.Apellidos + ", " + model.AgenteRRHHs.Personas.Nombres;            
            return Email("ConfirmacionSubrogante", model);
        }

        public EmailResult RechazoSubrogante(LicenciasAgente model, int agente_destinatario, string token)
        {
            var a = oAgentes.ObtenerPorId(agente_destinatario);

            To.Add(a.Email);
            From = "avisos@juslapampa.gob.ar";
            Subject = "Rechazo de Subrogante " + model.AgenteRRHHs.Personas.Apellidos + ", " + model.AgenteRRHHs.Personas.Nombres;
            ViewBag.Nombre = model.AgenteRRHHs.Personas.Apellidos + ", " + model.AgenteRRHHs.Personas.Nombres;
            ViewBag.Token = token;
            ViewBag.Subrogante = a.Personas.Apellidos.TrimEnd() + ", " + a.Personas.Nombres.TrimEnd(); 
            return Email("RechazoSubrogante", model);
        }

        public EmailResult NotificacionConcurso(SSO.SGP.Web.Areas.RRHH.Models.Notificaciones model, string mail)
        {          
            To.Add(mail);
             
            From = "avisos@juslapampa.gob.ar";
            Subject = model.Titulo;           
            return Email("NotificacionConcurso", model);
        }

        public EmailResult RecordarEvaluacion(SSO.SGP.EntidadesDeNegocio.ConcursosDeIngresoEvaluaciones model, string mail, string concurso, string evaluacion)
        {
            To.Add(mail);
            From = "avisos@juslapampa.gob.ar";
            Subject = "RRHH - Poder Judicial de La Pampa - Recodatorio de exámen online";
            ViewBag.Concurso = concurso;
            ViewBag.Detalle = evaluacion;
            return Email("RecordatorioEvaluacion", model);
        }

    }
}
