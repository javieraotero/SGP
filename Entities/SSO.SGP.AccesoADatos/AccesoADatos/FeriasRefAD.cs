
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Data.SqlClient;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class FeriasRefAD
	{
		private BDEntities db = new BDEntities();

		public FeriasRef ObtenerPorId(int Id)
		{
			return db.FeriasRef.Single(c => c.Id == Id);
		}

        public FeriasRef ObtenerPorIdyPaso(int Id, int Paso)
        {
            return db.FeriasRef.Single(c => c.Id == Id);                                               
        }

		public DbQuery<FeriasRef> ObtenerTodo()
		{
			return (DbQuery<FeriasRef>)db.FeriasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.FeriasRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<FeriasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.FeriasRef
					select new FeriasRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 Anio = c.Anio,
						 Paso1 = c.Paso1,
						 Paso2 = c.Paso2,
					};
			return (DbQuery<FeriasRefView>)x;
		}

		public void Guardar(FeriasRef Objeto)
		{
			try
			{
				db.FeriasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FeriasRef Objeto)
		{
			try
			{
				db.FeriasRef.Attach(Objeto);
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
				FeriasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.FeriasRef.Remove(Objeto);
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

		public DbQuery<FeriasRefViewT> JsonT(string term)
		{
			var x = from c in db.FeriasRef
					select new FeriasRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 Anio = c.Anio,
						 DiaDesde = c.DiaDesde,
						 MesDesde = c.MesDesde,
						 DiaHasta = c.DiaHasta,
						 MesHasta = c.MesHasta,
						 Paso1 = c.Paso1,
						 Paso2 = c.Paso2,
					};
			return (DbQuery<FeriasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/
        public virtual int AsignacionDeFeriaJuzgadosDePaz(int Feria)
        {

            var par1 = new SqlParameter();
            par1.ParameterName = "@Feria";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = Feria;
            par1.SqlDbType = System.Data.SqlDbType.Int;


            return ((IObjectContextAdapter)this.db).ObjectContext.ExecuteStoreQuery<int>("EXEC AsignarFeriaAJuzgadosDePaz @Feria", par1).FirstOrDefault();

        }

	}
}
