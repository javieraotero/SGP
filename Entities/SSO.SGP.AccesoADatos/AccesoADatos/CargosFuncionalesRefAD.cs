
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
	public partial class CargosFuncionalesRefAD
	{
		private BDEntities db = new BDEntities();

		public CargosFuncionalesRef ObtenerPorId(int Id)
		{
			return db.CargosFuncionalesRef.Single(c => c.Id == Id);
		}

		public DbQuery<CargosFuncionalesRef> ObtenerTodo()
		{
			return (DbQuery<CargosFuncionalesRef>)db.CargosFuncionalesRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CargosFuncionalesRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CargosFuncionalesRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CargosFuncionalesRef
					select new CargosFuncionalesRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Licencia = c.Licencia,
					};
			return (DbQuery<CargosFuncionalesRefView>)x;
		}

		public void Guardar(CargosFuncionalesRef Objeto)
		{
			try
			{
				db.CargosFuncionalesRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CargosFuncionalesRef Objeto)
		{
			try
			{
				db.CargosFuncionalesRef.Attach(Objeto);
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
				CargosFuncionalesRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CargosFuncionalesRef.Remove(Objeto);
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

		public DbQuery<CargosFuncionalesRefViewT> JsonT(string term)
		{
			var x = from c in db.CargosFuncionalesRef
					select new CargosFuncionalesRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Licencia = c.Licencia,
					};
			return (DbQuery<CargosFuncionalesRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
