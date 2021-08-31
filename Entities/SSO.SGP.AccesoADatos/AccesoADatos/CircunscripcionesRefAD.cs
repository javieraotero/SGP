
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
	public partial class CircunscripcionesRefAD
	{
		private BDEntities db = new BDEntities();

		public CircunscripcionesRef ObtenerPorId(int Id)
		{
			return db.CircunscripcionesRef.Single(c => c.Id == Id);
		}

		public DbQuery<CircunscripcionesRef> ObtenerTodo()
		{
			return (DbQuery<CircunscripcionesRef>)db.CircunscripcionesRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CircunscripcionesRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CircunscripcionesRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CircunscripcionesRef
					select new CircunscripcionesRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Abreviatura = c.Abreviatura,
						 UltimoExpediente = c.UltimoExpediente,
						 CircunscripcionOJ = c.CircunscripcionOJ,
						 UltimaNotificacion = c.UltimaNotificacion,
						 ReceptoriaSorteaCausa = c.ReceptoriaSorteaCausa,
						 MediacionCivil = c.MediacionCivil,
						 CircunscripcionArchiva = c.CircunscripcionArchiva,
						 NotificaPolicia = c.NotificaPolicia,
						 ReceptoriaUnica = c.ReceptoriaUnica,
					};
			return (DbQuery<CircunscripcionesRefView>)x;
		}

		public void Guardar(CircunscripcionesRef Objeto)
		{
			try
			{
				db.CircunscripcionesRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CircunscripcionesRef Objeto)
		{
			try
			{
				db.CircunscripcionesRef.Attach(Objeto);
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
				CircunscripcionesRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CircunscripcionesRef.Remove(Objeto);
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

		public DbQuery<CircunscripcionesRefViewT> JsonT(string term)
		{
			var x = from c in db.CircunscripcionesRef
					select new CircunscripcionesRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Abreviatura = c.Abreviatura,
						 UltimoExpediente = c.UltimoExpediente,
						 CircunscripcionOJ = c.CircunscripcionOJ,
						 UltimaNotificacion = c.UltimaNotificacion,
						 ReceptoriaSorteaCausa = c.ReceptoriaSorteaCausa,
						 MediacionCivil = c.MediacionCivil,
						 CircunscripcionArchiva = c.CircunscripcionArchiva,
						 NotificaPolicia = c.NotificaPolicia,
						 ReceptoriaUnica = c.ReceptoriaUnica,
					};
			return (DbQuery<CircunscripcionesRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
