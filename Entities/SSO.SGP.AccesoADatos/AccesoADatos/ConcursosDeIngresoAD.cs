
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
	public partial class ConcursosDeIngresoAD
	{
		private BDEntities db = new BDEntities();

		public ConcursosDeIngreso ObtenerPorId(int Id)
		{
            var c = db.ConcursosDeIngreso.Where(x => x.Id == Id);

            if (c.Count() > 0)
                return c.FirstOrDefault();
            else
                return null;
		}

		public DbQuery<ConcursosDeIngreso> ObtenerTodo()
		{
			return (DbQuery<ConcursosDeIngreso>)db.ConcursosDeIngreso.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ConcursosDeIngreso
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ConcursosDeIngresoView> ObtenerParaGrilla()
		{
            var x = from c in db.ConcursosDeIngreso
                    where c.Activo == true
                    select new ConcursosDeIngresoView
                    {
                        Id = c.Id,
                        Nombre = c.Nombre,
                        Descripcion = c.Descripcion,
                        FechaInicio = c.FechaInicio,
                        FechaFin = c.FechaFin,
                        Organismo = c.Organismos.Descripcion,
                        Cargo = c.Cargos.Descripcion,
                        Tipo = c.Tipo == eTiposDeConcursos.Ascenso ? "Ascenso" : "Ingreso"
					};
			return (DbQuery<ConcursosDeIngresoView>)x;
		}

		public void Guardar(ConcursosDeIngreso Objeto)
		{
			try
			{
				db.ConcursosDeIngreso.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ConcursosDeIngreso Objeto)
		{
			try
			{
				db.ConcursosDeIngreso.Attach(Objeto);
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
				ConcursosDeIngreso Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
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

		public DbQuery<ConcursosDeIngresoViewT> JsonT(string term)
		{
			var x = from c in db.ConcursosDeIngreso
					where c.Activo == true
					select new ConcursosDeIngresoViewT
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 Descripcion = c.Descripcion,
						 FechaInicio = c.FechaInicio,
						 FechaFin = c.FechaFin,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 Organismo = c.Organismo,
						 Cargo = c.Cargo,
						 Activo = c.Activo,
					};
			return (DbQuery<ConcursosDeIngresoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
