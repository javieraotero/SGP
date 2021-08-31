
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
	public partial class PeritosInscripcionAD
	{
		private BDEntities db = new BDEntities();

		public PeritosInscripcion ObtenerPorId(int Id)
		{
			return db.PeritosInscripcion.Single(c => c.Id == Id);
		}

		public DbQuery<PeritosInscripcion> ObtenerTodo()
		{
			return (DbQuery<PeritosInscripcion>)db.PeritosInscripcion.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PeritosInscripcion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PeritosInscripcionView> ObtenerParaGrilla()
		{
			var x = from c in db.PeritosInscripcion
					where c.Activo == true
					select new PeritosInscripcionView
					{
						 Id = c.Id,
						 Circunscripcion1 = c.Circunscripcion1,
						 Circunscripcion2 = c.Circunscripcion2,
						 Circunscripcion3 = c.Circunscripcion3,
						 Circunscripcion4 = c.Circunscripcion4,
						 FechaInscripcion = c.FechaInscripcion,
						 UsuarioCarga = c.UsuarioCarga,
						 Especialidad = c.Especialidad,
						 Periodo = c.Periodo,
						 Perito = c.Perito,
						 DomicilioLegal1 = c.DomicilioLegal1,
						 DomicilioLegal2 = c.DomicilioLegal2,
						 DomicilioLegal3 = c.DomicilioLegal3,
						 DomicilioLegal4 = c.DomicilioLegal4,
						 Telefono1 = c.Telefono1,
						 Telefono2 = c.Telefono2,
						 Telefono3 = c.Telefono3,
						 Telefono4 = c.Telefono4,
						 Activo = c.Activo,
					};
			return (DbQuery<PeritosInscripcionView>)x;
		}

		public void Guardar(PeritosInscripcion Objeto)
		{
			try
			{
				db.PeritosInscripcion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosInscripcion Objeto)
		{
			try
			{
				db.PeritosInscripcion.Attach(Objeto);
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
				PeritosInscripcion Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<PeritosInscripcionViewT> JsonT(string term)
		{
			var x = from c in db.PeritosInscripcion
					where c.Activo == true
					select new PeritosInscripcionViewT
					{
						 Id = c.Id,
						 Circunscripcion1 = c.Circunscripcion1,
						 Circunscripcion2 = c.Circunscripcion2,
						 Circunscripcion3 = c.Circunscripcion3,
						 Circunscripcion4 = c.Circunscripcion4,
						 FechaInscripcion = c.FechaInscripcion,
						 UsuarioCarga = c.UsuarioCarga,
						 Especialidad = c.Especialidad,
						 Periodo = c.Periodo,
						 Perito = c.Perito,
						 DomicilioLegal1 = c.DomicilioLegal1,
						 DomicilioLegal2 = c.DomicilioLegal2,
						 DomicilioLegal3 = c.DomicilioLegal3,
						 DomicilioLegal4 = c.DomicilioLegal4,
						 Telefono1 = c.Telefono1,
						 Telefono2 = c.Telefono2,
						 Telefono3 = c.Telefono3,
						 Telefono4 = c.Telefono4,
						 Activo = c.Activo,
					};
			return (DbQuery<PeritosInscripcionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
