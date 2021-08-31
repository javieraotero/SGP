
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
	public partial class PartidasPresupuestariasAD
	{
		private BDEntities db = new BDEntities();

		public PartidasPresupuestarias ObtenerPorId(int Id)
		{
			return db.PartidasPresupuestarias.Single(c => c.Id == Id);
		}

		public DbQuery<PartidasPresupuestarias> ObtenerTodo()
		{
			return (DbQuery<PartidasPresupuestarias>)db.PartidasPresupuestarias.Where(p=>!p.FechaElimina.HasValue);
		}

        public DbQuery<CustomPartidasMin> ObtenerMin()
        {
            var res = from x in db.PartidasPresupuestarias
                      where !x.FechaElimina.HasValue
                      select new CustomPartidasMin
                      {
                          Id = x.Id,
                          Partida = x.NumeroDePartida + " - " + x.Descripcion
                      };

            return (DbQuery<CustomPartidasMin>)res;
        }

        public DbQuery<PartidasPresupuestarias> ObtenerPorUnidadDeOrganizacion(int unidad)
        {
            return (DbQuery<PartidasPresupuestarias>)db.PartidasPresupuestarias.Where(u=>u.UnidadDeOrganizacion == unidad && !u.FechaElimina.HasValue);
        }

        public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PartidasPresupuestarias
                      where x.NumeroDePartida.Contains(filtro) && !x.FechaElimina.HasValue
				select new SelectOptionsView {text = x.NumeroDePartida+"-"+x.Descripcion, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PartidasPresupuestariasView> ObtenerParaGrilla()
		{
			var x = from c in db.PartidasPresupuestarias
                    where !c.FechaElimina.HasValue
					select new PartidasPresupuestariasView
					{
						 Id = c.Id,
						 NumeroDePartida = c.NumeroDePartida,
						 Descripcion = c.Descripcion,
						 Mnemo = c.Mnemo,
						 UnidadDeOrganizacion = c.UnidadDeOrganizacions.Nombre,
						 Prioridad = (c.Prioridad) ? "Si" : "No",
					};
			return (DbQuery<PartidasPresupuestariasView>)x;
		}

		public void Guardar(PartidasPresupuestarias Objeto)
		{
			try
			{
				db.PartidasPresupuestarias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PartidasPresupuestarias Objeto)
		{
			try
			{
				db.PartidasPresupuestarias.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto, int Usuario)
		{
			try
			{
				PartidasPresupuestarias Objeto = this.ObtenerPorId(IdObjeto);
                Objeto.FechaElimina = DateTime.Now;
                Objeto.UsuarioElimina = Usuario;
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

		public DbQuery<PartidasPresupuestariasViewT> JsonT(string term)
		{
			var x = from c in db.PartidasPresupuestarias
                    where !c.FechaElimina.HasValue
					select new PartidasPresupuestariasViewT
					{
						 Id = c.Id,
						 NumeroDePartida = c.NumeroDePartida,
						 Descripcion = c.Descripcion,
						 Mnemo = c.Mnemo,
						 UnidadDeOrganizacion = c.UnidadDeOrganizacion,
						 Prioridad = c.Prioridad,
					};
			return (DbQuery<PartidasPresupuestariasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
