
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
	public partial class ImputacionesContablesDetalleAD
	{
		private BDEntities db = new BDEntities();

		public ImputacionesContablesDetalle ObtenerPorId(int Id)
		{
			return db.ImputacionesContablesDetalle.Single(c => c.Id == Id);
		}

		public DbQuery<ImputacionesContablesDetalle> ObtenerTodo()
		{
			return (DbQuery<ImputacionesContablesDetalle>)db.ImputacionesContablesDetalle;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ImputacionesContablesDetalle
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ImputacionesContablesDetalleView> ObtenerParaGrilla()
		{
			var x = from c in db.ImputacionesContablesDetalle
					select new ImputacionesContablesDetalleView
					{
						 Id = c.Id,
						 ImputacionContable = c.ImputacionContable,
						 AnioContable = c.AnioContable,
						 Division = c.Division,
                        // Partida = c.Partida,
						 Importe = c.Importe,
					};
			return (DbQuery<ImputacionesContablesDetalleView>)x;
		}

		public void Guardar(ImputacionesContablesDetalle Objeto)
		{
			try
			{
				db.ImputacionesContablesDetalle.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ImputacionesContablesDetalle Objeto)
		{
			try
			{
				db.ImputacionesContablesDetalle.Attach(Objeto);
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
				ImputacionesContablesDetalle Objeto = this.ObtenerPorId(IdObjeto);
				db.ImputacionesContablesDetalle.Remove(Objeto);
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

		public DbQuery<ImputacionesContablesDetalleViewT> JsonT(string term)
		{
			var x = from c in db.ImputacionesContablesDetalle
					select new ImputacionesContablesDetalleViewT
					{
						 Id = c.Id,
						 ImputacionContable = c.ImputacionContable,
						
						 Division = c.Division,
						 Importe = c.Importe,
						 Usuario = c.Usuario,
						 Fecha = c.Fecha,
						 FechaElimina = c.FechaElimina,
						 UsuarioElimina = c.UsuarioElimina,
					};
			return (DbQuery<ImputacionesContablesDetalleViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
