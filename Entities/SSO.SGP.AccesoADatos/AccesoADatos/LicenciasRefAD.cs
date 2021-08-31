
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
	public partial class LicenciasRefAD
	{
		private BDEntities db = new BDEntities();

		public LicenciasRef ObtenerPorId(int Id)
		{
			return db.LicenciasRef.Single(c => c.Id == Id);
		}

		public DbQuery<LicenciasRef> ObtenerTodo()
		{
			return (DbQuery<LicenciasRef>)db.LicenciasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.LicenciasRef
                      //where x.CodigoRRHH
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<LicenciasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.LicenciasRef
					select new LicenciasRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 PorAnio = c.PorAnio,
						 PorLicencia = c.PorLicencia,
						 CodigoRRHH = c.CodigoRRHH,
                         PorAgente = c.PorAgente ? "SI" : "NO",
                         Contexto = c.UnidadDeContextoPorLicencias.Descripcion
					};
			return (DbQuery<LicenciasRefView>)x;
		}

		public void Guardar(LicenciasRef Objeto)
		{
			try
			{
				db.LicenciasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LicenciasRef Objeto)
		{
			try
			{
				db.LicenciasRef.Attach(Objeto);
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
				LicenciasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.LicenciasRef.Remove(Objeto);
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

		public DbQuery<LicenciasRefViewT> JsonT(string term)
		{
			var x = from c in db.LicenciasRef
					select new LicenciasRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 PorAnio = c.PorAnio,
						 PorLicencia = c.PorLicencia,
						 Observaciones = c.Observaciones,
						 DiasAcumulables = c.DiasAcumulables,
						 CodigoRRHH = c.CodigoRRHH,
					};
			return (DbQuery<LicenciasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/

        public DbQuery<SelectOptionsView> ObtenerUnidadesTemporales()
        {
            var res = from x in db.UnidadTemporalRef
                      //where x.CodigoRRHH
                      select new SelectOptionsView { text =x.Descripcion, value = x.Id };
            return (DbQuery<SelectOptionsView>)res;
        
        }

        public DbQuery<SelectOptionsView> ObtenerUnidadesDeContexto()
        {
            var res = from x in db.UnidadDeContextoRef
                      //where x.CodigoRRHH
                      select new SelectOptionsView { text = x.Descripcion, value = x.Id };
            return (DbQuery<SelectOptionsView>)res;

        }

	}
}
