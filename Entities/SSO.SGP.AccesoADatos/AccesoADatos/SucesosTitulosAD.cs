
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
	public partial class SucesosTitulosAD
	{
		private BDEntities db = new BDEntities();

		public SucesosTitulos ObtenerPorId(int Id)
		{
			return db.SucesosTitulos.Single(c => c.Id == Id);
		}

		public DbQuery<SucesosTitulos> ObtenerTodo()
		{
			return (DbQuery<SucesosTitulos>)db.SucesosTitulos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SucesosTitulos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SucesosTitulosView> ObtenerParaGrilla()
		{
			var x = from c in db.SucesosTitulos
					select new SucesosTitulosView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Ambito = c.Ambito,
						 TipoSuceso = c.TipoSuceso,
						 MostrarEnEdicion = c.MostrarEnEdicion,
						 AplicaSuspencionPlazo = c.AplicaSuspencionPlazo,
						 Circunscripcion = c.Circunscripcion,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
						 UsuarioElimina = c.UsuarioElimina,
						 FechaElimina = c.FechaElimina,
					};
			return (DbQuery<SucesosTitulosView>)x;
		}

		public void Guardar(SucesosTitulos Objeto)
		{
			try
			{
				db.SucesosTitulos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SucesosTitulos Objeto)
		{
			try
			{
				db.SucesosTitulos.Attach(Objeto);
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
				SucesosTitulos Objeto = this.ObtenerPorId(IdObjeto);
				db.SucesosTitulos.Remove(Objeto);
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

		public DbQuery<SucesosTitulosViewT> JsonT(string term)
		{
			var x = from c in db.SucesosTitulos
					select new SucesosTitulosViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Ambito = c.Ambito,
						 TipoSuceso = c.TipoSuceso,
						 MostrarEnEdicion = c.MostrarEnEdicion,
						 AplicaSuspencionPlazo = c.AplicaSuspencionPlazo,
						 Circunscripcion = c.Circunscripcion,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
						 UsuarioElimina = c.UsuarioElimina,
						 FechaElimina = c.FechaElimina,
					};
			return (DbQuery<SucesosTitulosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
