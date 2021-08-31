
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
	public partial class ElementosSecuestradosAD
	{
		private BDEntities db = new BDEntities();

		public ElementosSecuestrados ObtenerPorId(int Id)
		{
			return db.ElementosSecuestrados.Single(c => c.Id == Id);
		}

		public DbQuery<ElementosSecuestrados> ObtenerTodo()
		{
			return (DbQuery<ElementosSecuestrados>)db.ElementosSecuestrados;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ElementosSecuestrados
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ElementosSecuestradosView> ObtenerParaGrilla()
		{
			var x = from c in db.ElementosSecuestrados
					select new ElementosSecuestradosView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Codigo = c.Codigo,
						 Deposito = c.Deposito,
						 NroEstanteria = c.NroEstanteria,
						 NroEstante = c.NroEstante,
						 DescirpcionDetallada = c.DescirpcionDetallada,
						 Estado = c.Estado,
						 FechaAlta = c.FechaAlta,
						 Usuario = c.Usuario,
						 Observaciones = c.Observaciones,
						 Caja = c.Caja,
					};
			return (DbQuery<ElementosSecuestradosView>)x;
		}

		public void Guardar(ElementosSecuestrados Objeto)
		{
			try
			{
				db.ElementosSecuestrados.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ElementosSecuestrados Objeto)
		{
			try
			{
				db.ElementosSecuestrados.Attach(Objeto);
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
				ElementosSecuestrados Objeto = this.ObtenerPorId(IdObjeto);
				db.ElementosSecuestrados.Remove(Objeto);
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

		public DbQuery<ElementosSecuestradosViewT> JsonT(string term)
		{
			var x = from c in db.ElementosSecuestrados
					select new ElementosSecuestradosViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Codigo = c.Codigo,
						 Deposito = c.Deposito,
						 NroEstanteria = c.NroEstanteria,
						 NroEstante = c.NroEstante,
						 DescirpcionDetallada = c.DescirpcionDetallada,
						 Estado = c.Estado,
						 FechaAlta = c.FechaAlta,
						 Usuario = c.Usuario,
						 Observaciones = c.Observaciones,
						 Caja = c.Caja,
					};
			return (DbQuery<ElementosSecuestradosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
