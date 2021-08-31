
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
	public partial class ParametrosTrabajoCivilRefAD
	{
		private BDEntities db = new BDEntities();

		public ParametrosTrabajoCivilRef ObtenerPorId(int Id)
		{
			return db.ParametrosTrabajoCivilRef.Single(c => c.Id == Id);
		}

		public DbQuery<ParametrosTrabajoCivilRef> ObtenerTodo()
		{
			return (DbQuery<ParametrosTrabajoCivilRef>)db.ParametrosTrabajoCivilRef.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ParametrosTrabajoCivilRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ParametrosTrabajoCivilRefView> ObtenerParaGrilla()
		{
			var x = from c in db.ParametrosTrabajoCivilRef
					where c.Activo == true
					select new ParametrosTrabajoCivilRefView
					{
						 Id = c.Id,
						 CantidadRegistrosGrilla = c.CantidadRegistrosGrilla,
						 Activo = c.Activo,
						 TimerMensajes = c.TimerMensajes,
						 ExtensionesPermitidasArchivos = c.ExtensionesPermitidasArchivos,
						 TamanoMaximoArchivos = c.TamanoMaximoArchivos,
						 RedireccionarPorMantenimiento = c.RedireccionarPorMantenimiento,
						 CantidadMinutosGrabadoAutomaticoActuaciones = c.CantidadMinutosGrabadoAutomaticoActuaciones,
						 InscMedComedXCircunscripcion = c.InscMedComedXCircunscripcion,
						 MateriasConCategoriaUnica = c.MateriasConCategoriaUnica,
					};
			return (DbQuery<ParametrosTrabajoCivilRefView>)x;
		}

		public void Guardar(ParametrosTrabajoCivilRef Objeto)
		{
			try
			{
				db.ParametrosTrabajoCivilRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ParametrosTrabajoCivilRef Objeto)
		{
			try
			{
				db.ParametrosTrabajoCivilRef.Attach(Objeto);
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
				ParametrosTrabajoCivilRef Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<ParametrosTrabajoCivilRefViewT> JsonT(string term)
		{
			var x = from c in db.ParametrosTrabajoCivilRef
					where c.Activo == true
					select new ParametrosTrabajoCivilRefViewT
					{
						 Id = c.Id,
						 CantidadRegistrosGrilla = c.CantidadRegistrosGrilla,
						 Activo = c.Activo,
						 TimerMensajes = c.TimerMensajes,
						 ExtensionesPermitidasArchivos = c.ExtensionesPermitidasArchivos,
						 TamanoMaximoArchivos = c.TamanoMaximoArchivos,
						 RedireccionarPorMantenimiento = c.RedireccionarPorMantenimiento,
						 CantidadMinutosGrabadoAutomaticoActuaciones = c.CantidadMinutosGrabadoAutomaticoActuaciones,
						 InscMedComedXCircunscripcion = c.InscMedComedXCircunscripcion,
						 MateriasConCategoriaUnica = c.MateriasConCategoriaUnica,
					};
			return (DbQuery<ParametrosTrabajoCivilRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
