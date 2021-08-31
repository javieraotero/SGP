using Quartz;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SSO.SGP.AccesoADatos;
using SSO.SGP.Web.Controllers;
using SSO.SGP.Web.Areas.RRHH.Models;

namespace SSO.SGP.Web.Jobs
{
    public class RecordatorioDeExamenes : IJob
    {

        private ConcursosDeIngresoEvaluacionesAD oEvaluaciones = new ConcursosDeIngresoEvaluacionesAD();
        private ConcursosDeIngresoInscripcionesAD oInscripciones = new ConcursosDeIngresoInscripcionesAD();

        void IJob.Execute(IJobExecutionContext context)
        {
            var evaluaciones = oEvaluaciones.ObtenerTodo().ToList();
            var ahora = DateTime.Now.Date;

            foreach (var e in evaluaciones) {

                if ((e.FechaInicio.Value - ahora).Hours <= 24) {

                    var inscriptos = oInscripciones.ObtenerPorConcurso(e.Concurso).ToList();

                    var n = new Notificaciones() {
                        Concurso = e.Concurso,
                        Mensaje = "Che, acordate que tenés que hacer la evaluación!",
                        Titulo = "Recordatorio de evaluación desde Job"
                    };

                    foreach (var i in inscriptos) {
                        try
                        {
                            new MailController().NotificacionConcurso(n, i.Email).Deliver();
                            //ok++;
                        }
                        catch (Exception ex)
                        {
                            //error++;
                        }
                    }

                }

            }



        }
    }
}