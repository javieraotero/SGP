
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Data.Objects;
using System.Collections.Generic;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class CargosRefAD
	{
		private BDEntities db = new BDEntities();

		public CargosRef ObtenerPorId(int Id)
		{
			return db.CargosRef.Single(c => c.Id == Id);
		}

		public DbQuery<CargosRef> ObtenerTodo()
		{
			return (DbQuery<CargosRef>)db.CargosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CargosRef
				select new SelectOptionsView {text = x.Descripcion, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CargosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CargosRef
					select new CargosRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Orden = c.Orden,
						 Grupo = c.Grupo,
						 CodigoRRHH = c.CodigoRRHH,
						 Presupuesto = c.Presupuesto,
					};
			return (DbQuery<CargosRefView>)x;
		}

		public void Guardar(CargosRef Objeto)
		{
			try
			{
				db.CargosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CargosRef Objeto)
		{
			try
			{
				db.CargosRef.Attach(Objeto);
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
				CargosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CargosRef.Remove(Objeto);
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

		public DbQuery<CargosRefViewT> JsonT(string term)
		{
			var x = from c in db.CargosRef
					select new CargosRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Orden = c.Orden,
						 Grupo = c.Grupo,
						 CodigoRRHH = c.CodigoRRHH,
						 Presupuesto = c.Presupuesto,
					};
			return (DbQuery<CargosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/
        //Stored Procedures
        public List<PlantaDePersonalResult> PlantaDePersonal()
        {

            //var par1 = new SqlParameter();
            //par1.ParameterName = "@Organismo";
            //par1.Direction = System.Data.ParameterDirection.Input;
            //par1.Value = Organismo;
            //par1.SqlDbType = System.Data.SqlDbType.Int;

            //par2.TypeName = "INT";

            var x = ((IObjectContextAdapter)this.db).ObjectContext.ExecuteStoreQuery<PlantaDePersonalResult>("EXEC PlantaDePersonalRRHH");
            return x.ToList<PlantaDePersonalResult>();
            //var parames = new object[] {new SqlParameter("@FirstName", "Bob")};
        }

	}
}
