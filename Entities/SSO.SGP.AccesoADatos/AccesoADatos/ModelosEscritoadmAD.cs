
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
	public partial class ModelosEscritoadmAD
	{
		private BDEntities db = new BDEntities();

		public ModelosEscritoadm ObtenerPorId(int Id)
		{
			return db.ModelosEscritoadm.Single(c => c.Id == Id);
		}

		public DbQuery<ModelosEscritoadm> ObtenerTodo()
		{
			return (DbQuery<ModelosEscritoadm>)db.ModelosEscritoadm;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ModelosEscritoadm
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ModelosEscritoadmView> ObtenerParaGrilla(int Organismo)
		{
			var x = from c in db.ModelosEscritoadm
                    where c.Oficina == Organismo && !c.FechaElimina.HasValue
					select new ModelosEscritoadmView
					{
						 Id = c.Id,
						 Oficina = c.Oficinas.Descripcion,
						 Titulo = c.Titulo,
						 FechaAlta = c.FechaAlta,
						 Tipo = c.Tipos.Descripcion,
					};
			return (DbQuery<ModelosEscritoadmView>)x;
		}

        public DbQuery<ModelosEscritoadmView> ModelosDeLaOficina(int oficina)
        {
            var x = from c in db.ModelosEscritoadm
                    where c.Oficina == oficina
                    select new ModelosEscritoadmView
                    {
                        Id = c.Id,
                        Oficina = c.Oficinas.Descripcion,
                        Titulo = c.Titulo,
                        FechaAlta = c.FechaAlta,
                        Tipo = c.Tipos.Descripcion,
                    };
            return (DbQuery<ModelosEscritoadmView>)x;
        }

		public void Guardar(ModelosEscritoadm Objeto)
		{
			try
			{
				db.ModelosEscritoadm.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ModelosEscritoadm Objeto)
		{
			try
			{
				db.ModelosEscritoadm.Attach(Objeto);
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
				ModelosEscritoadm Objeto = this.ObtenerPorId(IdObjeto);
                Objeto.FechaElimina = DateTime.Now;
                db.ModelosEscritoadm.Attach(Objeto);
                db.Entry(Objeto).State = EntityState.Modified;
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

		public DbQuery<ModelosEscritoadmViewT> JsonT(string term)
		{
			var x = from c in db.ModelosEscritoadm
					select new ModelosEscritoadmViewT
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
			return (DbQuery<ModelosEscritoadmViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
