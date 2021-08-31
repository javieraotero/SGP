
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Collections.Generic;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class ImputacionesContablesAD
	{
		private BDEntities db = new BDEntities();

		public ImputacionesContables ObtenerPorId(int Id)
		{
			return db.ImputacionesContables.Single(c => c.Id == Id);
		}

		public DbQuery<ImputacionesContables> ObtenerTodo()
		{
			return (DbQuery<ImputacionesContables>)db.ImputacionesContables;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ImputacionesContables
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ImputacionesContablesView> ObtenerParaGrilla()
		{
			var x = from c in db.ImputacionesContables
					select new ImputacionesContablesView
					{
						 Id = c.Id,
						 ExpedienteAImputar = c.ExpedienteAImputar,
						 Fecha = c.Fecha,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaElimina = c.FechaElimina.Value,
						 Operacion = c.Operacion,
						 ExpedienteIndirecto = c.ExpedienteIndirecto,
					};
			return (DbQuery<ImputacionesContablesView>)x;
		}

		public void Guardar(ImputacionesContables Objeto)
		{
			try
			{
				db.ImputacionesContables.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ImputacionesContables Objeto)
		{
			try
			{
				db.ImputacionesContables.Attach(Objeto);
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
				ImputacionesContables Objeto = this.ObtenerPorId(IdObjeto);
				db.ImputacionesContables.Remove(Objeto);
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

		public DbQuery<ImputacionesContablesViewT> JsonT(string term)
		{
			var x = from c in db.ImputacionesContables
					select new ImputacionesContablesViewT
					{
						 Id = c.Id,
						 ExpedienteAImputar = c.ExpedienteAImputar,
						 Fecha = c.Fecha,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaElimina = c.FechaElimina.Value,
						 Operacion = c.Operacion,
						 ExpedienteIndirecto = c.ExpedienteIndirecto,
					};
			return (DbQuery<ImputacionesContablesViewT>)x;
		}
        /*********************************************
		* Seccion Particular
		* *******************************************/
        public DbQuery<ImputacionesContables> ObtenerPorExpediente(int expediente)
        {
            var res = from x in db.ImputacionesContables
                      where x.ExpedienteAImputar == expediente
                      select x;

            return (DbQuery<ImputacionesContables>)res;
        }

        public decimal obtenerSaldoDeOperacion(int expediente, int operacion) {

            var res = (from x in db.ImputacionesContablesDetalle
                      where x.ImputacionContables.ExpedienteAImputar == expediente
                      && x.ImputacionContables.Operacion == operacion
                      select x).Sum(i=>i.Importe);

            return res;
        }

        public List<ImputacionesContablesDetalle> obtenerImputaciones(int expediente, int operacion) {

            var res = (from x in db.ImputacionesContablesDetalle
                      where x.ImputacionContables.ExpedienteAImputar == expediente
                      && x.ImputacionContables.Operacion == operacion
                      select x).ToList();

            return res;

        }

    }
}
