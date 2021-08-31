
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
	public partial class AgentesDocenciaAD
	{
		private BDEntities db = new BDEntities();

		public AgentesDocencia ObtenerPorId(int Id)
		{
			return db.AgentesDocencia.Single(c => c.Id == Id);
		}

		public DbQuery<AgentesDocencia> ObtenerTodo()
		{
			return (DbQuery<AgentesDocencia>)db.AgentesDocencia;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AgentesDocencia
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AgentesDocenciaView> ObtenerParaGrilla(int agente)
		{
			var x = from c in db.AgentesDocencia
                    where c.Agente == agente
					select new AgentesDocenciaView
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Institucion = c.Institucion,
						 CargaHoraria = c.CargaHoraria,
						 HorasCatedra = c.HorasCatedra,
						 HorasSemanales = c.HorasSemanales,
						 Observaciones = c.Observaciones,
					};
			return (DbQuery<AgentesDocenciaView>)x;
		}

		public void Guardar(AgentesDocencia Objeto)
		{
			try
			{
				db.AgentesDocencia.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AgentesDocencia Objeto)
		{
			try
			{
				db.AgentesDocencia.Attach(Objeto);
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
				AgentesDocencia Objeto = this.ObtenerPorId(IdObjeto);
				db.AgentesDocencia.Remove(Objeto);
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

		public DbQuery<AgentesDocenciaViewT> JsonT(string term)
		{
			var x = from c in db.AgentesDocencia
					select new AgentesDocenciaViewT
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Fecha = c.Fecha,
						 Institucion = c.Institucion,
						 CargaHoraria = c.CargaHoraria,
						 HorasCatedra = c.HorasCatedra,
						 HorasSemanales = c.HorasSemanales,
						 Observaciones = c.Observaciones,
					};
			return (DbQuery<AgentesDocenciaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
