
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
	public partial class ModelosEscritoAD
	{
		private BDEntities db = new BDEntities();

		public ModelosEscrito ObtenerPorId(int Id)
		{
			return db.ModelosEscrito.Single(c => c.Id == Id);
		}

		public DbQuery<ModelosEscrito> ObtenerTodo()
		{
			return (DbQuery<ModelosEscrito>)db.ModelosEscrito;
		}

        public DbQuery<ModelosEscrito> ObtenerPorOficina(int oficina)
        {
            return (DbQuery<ModelosEscrito>)db.ModelosEscrito.Where(a => a.Oficina == oficina);
        }

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ModelosEscrito
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ModelosEscritoView> ObtenerParaGrilla()
		{
			var x = from c in db.ModelosEscrito
					select new ModelosEscritoView
					{
						 Id = c.Id,
						 Oficina = c.Oficina,
						 Titulo = c.Titulo,
						 Contenido = c.Contenido,
						 FechaAlta = c.FechaAlta,
						 Usuario = c.Usuario,
						 Tipo = c.Tipo,
						 TipoActuacion = c.TipoActuacion,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
					};
			return (DbQuery<ModelosEscritoView>)x;
		}

		public void Guardar(ModelosEscrito Objeto)
		{
			try
			{
				db.ModelosEscrito.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ModelosEscrito Objeto)
		{
			try
			{
				db.ModelosEscrito.Attach(Objeto);
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
				ModelosEscrito Objeto = this.ObtenerPorId(IdObjeto);
				db.ModelosEscrito.Remove(Objeto);
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

		public DbQuery<ModelosEscritoViewT> JsonT(string term)
		{
			var x = from c in db.ModelosEscrito
					select new ModelosEscritoViewT
					{
						 Id = c.Id,
						 Oficina = c.Oficina,
						 Titulo = c.Titulo,
						 Contenido = c.Contenido,
						 FechaAlta = c.FechaAlta,
						 Usuario = c.Usuario,
						 Tipo = c.Tipo,
						 TipoActuacion = c.TipoActuacion,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
					};
			return (DbQuery<ModelosEscritoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
