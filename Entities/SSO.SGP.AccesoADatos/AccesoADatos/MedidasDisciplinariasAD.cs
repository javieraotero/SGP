
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
	public partial class MedidasDisciplinariasAD
	{
		private BDEntities db = new BDEntities();

		public MedidasDisciplinarias ObtenerPorId(int Id)
		{
			return db.MedidasDisciplinarias.Single(c => c.Id == Id);
		}

		public DbQuery<MedidasDisciplinarias> ObtenerTodo()
		{
			return (DbQuery<MedidasDisciplinarias>)db.MedidasDisciplinarias;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MedidasDisciplinarias
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MedidasDisciplinariasView> ObtenerParaGrilla()
		{
			var x = from c in db.MedidasDisciplinarias
					select new MedidasDisciplinariasView
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Fecha = c.Fecha,
						 Causa = c.Causa,
					};
			return (DbQuery<MedidasDisciplinariasView>)x;
		}

		public void Guardar(MedidasDisciplinarias Objeto)
		{
			try
			{
				db.MedidasDisciplinarias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MedidasDisciplinarias Objeto)
		{
			try
			{
				db.MedidasDisciplinarias.Attach(Objeto);
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
				MedidasDisciplinarias Objeto = this.ObtenerPorId(IdObjeto);
				db.MedidasDisciplinarias.Remove(Objeto);
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

		public DbQuery<MedidasDisciplinariasViewT> JsonT(int agente)
		{
			var x = from c in db.MedidasDisciplinarias
                    where c.Agente == agente
					select new MedidasDisciplinariasViewT
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Causa = c.Causa,
					};
			return (DbQuery<MedidasDisciplinariasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
