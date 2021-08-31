
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
	public partial class JuecesContadoresAD
	{
		private BDEntities db = new BDEntities();

		public JuecesContadores ObtenerPorId(int Id)
		{
			return db.JuecesContadores.Single(c => c.Id == Id);
		}

		public DbQuery<JuecesContadores> ObtenerTodo()
		{
			return (DbQuery<JuecesContadores>)db.JuecesContadores;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.JuecesContadores
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<JuecesContadoresView> ObtenerParaGrilla()
		{
			var x = from c in db.JuecesContadores
					select new JuecesContadoresView
					{
						 Id = c.Id,
						 NivelPonderacion = c.NivelPonderacion,
						 Circunscripcion = c.Circunscripcion,
						 Contador = c.Contador,
						 Juez = c.Juez,
					};
			return (DbQuery<JuecesContadoresView>)x;
		}

		public void Guardar(JuecesContadores Objeto)
		{
			try
			{
				db.JuecesContadores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(JuecesContadores Objeto)
		{
			try
			{
				db.JuecesContadores.Attach(Objeto);
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
				JuecesContadores Objeto = this.ObtenerPorId(IdObjeto);
				db.JuecesContadores.Remove(Objeto);
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

		public DbQuery<JuecesContadoresViewT> JsonT(string term)
		{
			var x = from c in db.JuecesContadores
					select new JuecesContadoresViewT
					{
						 Id = c.Id,
						 NivelPonderacion = c.NivelPonderacion,
						 Circunscripcion = c.Circunscripcion,
						 Contador = c.Contador,
						 Juez = c.Juez,
					};
			return (DbQuery<JuecesContadoresViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
