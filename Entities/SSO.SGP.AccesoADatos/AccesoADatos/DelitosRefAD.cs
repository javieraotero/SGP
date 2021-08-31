
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
	public partial class DelitosRefAD
	{
		private BDEntities db = new BDEntities();

		public DelitosRef ObtenerPorId(int Id)
		{
			return db.DelitosRef.Single(c => c.Id == Id);
		}

		public DbQuery<DelitosRef> ObtenerTodo()
		{
			return (DbQuery<DelitosRef>)db.DelitosRef.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.DelitosRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<DelitosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.DelitosRef
					where c.Activo == true
					select new DelitosRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Articulos = c.Articulos,
						 MesesPrescribe = c.MesesPrescribe,
						 MapaDelito = c.MapaDelito,
						 Capitulo = c.Capitulo,
						 Activo = c.Activo,
						 NivelPonderacion_CircI = c.NivelPonderacion_CircI,
						 NivelPonderacion_CircII = c.NivelPonderacion_CircII,
						 NivelPonderacion_CircIII = c.NivelPonderacion_CircIII,
						 NivelPonderacion_CircIV = c.NivelPonderacion_CircIV,
						 CondenaMinima = c.CondenaMinima,
						 TipoCondenaMinima = c.TipoCondenaMinima,
						 CondenaMaxima = c.CondenaMaxima,
						 TipoCondenaMaxima = c.TipoCondenaMaxima,
						 Ponderacion = c.Ponderacion,
						 Prescripcion = c.Prescripcion,
					};
			return (DbQuery<DelitosRefView>)x;
		}

		public void Guardar(DelitosRef Objeto)
		{
			try
			{
				db.DelitosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(DelitosRef Objeto)
		{
			try
			{
				db.DelitosRef.Attach(Objeto);
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
				DelitosRef Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<DelitosRefViewT> JsonT(string term)
		{
			var x = from c in db.DelitosRef
					where c.Activo == true
					select new DelitosRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Articulos = c.Articulos,
						 MesesPrescribe = c.MesesPrescribe,
						 MapaDelito = c.MapaDelito,
						 Capitulo = c.Capitulo,
						 Activo = c.Activo,
						 NivelPonderacion_CircI = c.NivelPonderacion_CircI,
						 NivelPonderacion_CircII = c.NivelPonderacion_CircII,
						 NivelPonderacion_CircIII = c.NivelPonderacion_CircIII,
						 NivelPonderacion_CircIV = c.NivelPonderacion_CircIV,
						 CondenaMinima = c.CondenaMinima,
						 TipoCondenaMinima = c.TipoCondenaMinima,
						 CondenaMaxima = c.CondenaMaxima,
						 TipoCondenaMaxima = c.TipoCondenaMaxima,
						 Ponderacion = c.Ponderacion,
						 Prescripcion = c.Prescripcion,
					};
			return (DbQuery<DelitosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
