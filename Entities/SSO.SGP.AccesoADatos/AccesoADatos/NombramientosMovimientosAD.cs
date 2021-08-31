
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
	public partial class NombramientosMovimientosAD
	{
		private BDEntities db = new BDEntities();

		public NombramientosMovimientos ObtenerPorId(int Id)
		{
			return db.NombramientosMovimientos.Single(c => c.Id == Id);
		}

		public DbQuery<NombramientosMovimientos> ObtenerTodo()
		{
			return (DbQuery<NombramientosMovimientos>)db.NombramientosMovimientos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.NombramientosMovimientos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<NombramientosMovimientosView> ObtenerParaGrilla()
		{
			var x = from c in db.NombramientosMovimientos
					select new NombramientosMovimientosView
					{
						 Id = c.Id,
						 Nombramiento = c.Nombramiento,
						 Desde = c.Desde,
						 Hasta = c.Hasta,
						 Cargo = c.Cargo,
						 SituacionRevista = c.SituacionRevista,
						 Organismo = c.Organismo,
					};
			return (DbQuery<NombramientosMovimientosView>)x;
		}

		public void Guardar(NombramientosMovimientos Objeto)
		{
			try
			{
                //List<Nombramientos> n = new List<Nombramientos>();
                var n = (from x in db.Nombramientos
                        where x.Id == Objeto.Nombramiento
                        select x).FirstOrDefault();

                if (n.NombramientosMovimientos.Count > 0)
                {
                    var ultimo = n.NombramientosMovimientos.OrderBy(nm => nm.Id).Last();
                    Objeto.Desde = ultimo.Hasta.Value;
                }
                else
                    Objeto.Desde = n.FechaDeAlta;


				db.NombramientosMovimientos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(NombramientosMovimientos Objeto)
		{
			try
			{
				db.NombramientosMovimientos.Attach(Objeto);
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
				NombramientosMovimientos Objeto = this.ObtenerPorId(IdObjeto);
				db.NombramientosMovimientos.Remove(Objeto);
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

		public DbQuery<NombramientosMovimientosViewT> JsonT(int nombramiento)
		{
			var x = from c in db.NombramientosMovimientos
                    where c.Nombramiento == nombramiento
					select new NombramientosMovimientosViewT
					{
						 Id = c.Id,
						 Nombramiento = c.Nombramiento,
						 Desde = c.Desde,
						 Hasta = c.Hasta,
						 Cargo = c.Cargos.Descripcion,
						 SituacionRevista = c.SituacionRevista,
						 Organismo = c.Organismos.Descripcion,
					};
			return (DbQuery<NombramientosMovimientosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
