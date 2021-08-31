
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class ParametrosTrabajoRefAD
	{
		private BDEntities db = new BDEntities();

		public ParametrosTrabajoRef ObtenerPorId(int Id)
		{
			return db.ParametrosTrabajoRef.Single(c => c.Id == Id);
		}

		public DbQuery<ParametrosTrabajoRef> ObtenerTodo()
		{
			return (DbQuery<ParametrosTrabajoRef>)db.ParametrosTrabajoRef.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ParametrosTrabajoRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ParametrosTrabajoRefView> ObtenerParaGrilla()
		{
			var x = from c in db.ParametrosTrabajoRef
					where c.Activo == true
					select new ParametrosTrabajoRefView
					{
						 Id = c.Id,
						 CantidadRegistrosGrilla = c.CantidadRegistrosGrilla,
						 CantidadDiasAlertaPreventivo = c.CantidadDiasAlertaPreventivo,
						 CantidadDiasAlertaSumarioPrevencion = c.CantidadDiasAlertaSumarioPrevencion,
						 CantidadMinutosBloqueoExpediente = c.CantidadMinutosBloqueoExpediente,
						 CantidadMinutosBloqueoActuacion = c.CantidadMinutosBloqueoActuacion,
						 CantidadMinutosBloqueoUsuario = c.CantidadMinutosBloqueoUsuario,
						 TipoActuacionInicioExpedienteFiscal = c.TipoActuacionInicioExpedienteFiscal,
						 Activo = c.Activo,
						 CantMaxDefensor = c.CantMaxDefensor,
						 OficioLibertadComun = c.OficioLibertadComun,
						 OficioLibertadConRestricciones = c.OficioLibertadConRestricciones,
						 ActaConstitucionDomicilio = c.ActaConstitucionDomicilio,
						 ActaConstitucionDomicilioConRestricciones = c.ActaConstitucionDomicilioConRestricciones,
						 OficioComisariaMujer = c.OficioComisariaMujer,
						 OficioCapturayDetencion = c.OficioCapturayDetencion,
						 OficioInmediataLibertad = c.OficioInmediataLibertad,
						 TimerMensajes = c.TimerMensajes,
						 ExtensionesPermitidasArchivos = c.ExtensionesPermitidasArchivos,
						 TamanoMaximoArchivos = c.TamanoMaximoArchivos,
						 RedireccionarPorMantenimiento = c.RedireccionarPorMantenimiento,
						 CantidadMinutosGrabadoAutomaticoActuaciones = c.CantidadMinutosGrabadoAutomaticoActuaciones,
						 ModeloPoliciaDenuncia = c.ModeloPoliciaDenuncia,
						 PlantillaDenunciaPolicial = c.PlantillaDenunciaPolicial,
						 ModeloDeclaracionImputados = c.ModeloDeclaracionImputados,
					};
			return (DbQuery<ParametrosTrabajoRefView>)x;
		}

		public void Guardar(ParametrosTrabajoRef Objeto)
		{
			try
			{
				db.ParametrosTrabajoRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ParametrosTrabajoRef Objeto)
		{
			try
			{
				db.ParametrosTrabajoRef.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
				ParametrosTrabajoRef Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			db.Dispose();
		}

		public DbQuery<ParametrosTrabajoRefViewT> JsonT(string term)
		{
			var x = from c in db.ParametrosTrabajoRef
					where c.Activo == true
					select new ParametrosTrabajoRefViewT
					{
						 Id = c.Id,
						 CantidadRegistrosGrilla = c.CantidadRegistrosGrilla,
						 CantidadDiasAlertaPreventivo = c.CantidadDiasAlertaPreventivo,
						 CantidadDiasAlertaSumarioPrevencion = c.CantidadDiasAlertaSumarioPrevencion,
						 CantidadMinutosBloqueoExpediente = c.CantidadMinutosBloqueoExpediente,
						 CantidadMinutosBloqueoActuacion = c.CantidadMinutosBloqueoActuacion,
						 CantidadMinutosBloqueoUsuario = c.CantidadMinutosBloqueoUsuario,
						 TipoActuacionInicioExpedienteFiscal = c.TipoActuacionInicioExpedienteFiscal,
						 Activo = c.Activo,
						 CantMaxDefensor = c.CantMaxDefensor,
						 OficioLibertadComun = c.OficioLibertadComun,
						 OficioLibertadConRestricciones = c.OficioLibertadConRestricciones,
						 ActaConstitucionDomicilio = c.ActaConstitucionDomicilio,
						 ActaConstitucionDomicilioConRestricciones = c.ActaConstitucionDomicilioConRestricciones,
						 OficioComisariaMujer = c.OficioComisariaMujer,
						 OficioCapturayDetencion = c.OficioCapturayDetencion,
						 OficioInmediataLibertad = c.OficioInmediataLibertad,
						 TimerMensajes = c.TimerMensajes,
						 ExtensionesPermitidasArchivos = c.ExtensionesPermitidasArchivos,
						 TamanoMaximoArchivos = c.TamanoMaximoArchivos,
						 RedireccionarPorMantenimiento = c.RedireccionarPorMantenimiento,
						 CantidadMinutosGrabadoAutomaticoActuaciones = c.CantidadMinutosGrabadoAutomaticoActuaciones,
						 ModeloPoliciaDenuncia = c.ModeloPoliciaDenuncia,
						 PlantillaDenunciaPolicial = c.PlantillaDenunciaPolicial,
						 ModeloDeclaracionImputados = c.ModeloDeclaracionImputados,
					};
			return (DbQuery<ParametrosTrabajoRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
