
using System;
using System.Data.Entity.Infrastructure;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;


namespace SSO.SGP.ReglasDeNegocio
{
	/// <summary>
	/// Reglas De Negocio Generada por el Generador de codigo.
	/// </summary>
	public partial class DenegatoriasrrhhRN
	{
		DenegatoriasrrhhAD oDenegatoriasrrhhAD = new DenegatoriasrrhhAD();

		public Denegatoriasrrhh ObtenerPorId(int Id)
		{
			return this.oDenegatoriasrrhhAD.ObtenerPorId(Id);
		}

		public DbQuery<Denegatoriasrrhh> ObtenerTodo()
		{
			return this.oDenegatoriasrrhhAD.ObtenerTodo();
		}


		public DbQuery<DenegatoriasrrhhView> ObtenerParaGrilla()
		{
			return this.oDenegatoriasrrhhAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oDenegatoriasrrhhAD.ObtenerOptions(filtro);
		}

		public void Guardar(Denegatoriasrrhh Objeto)
		{
			try
			{
			this.oDenegatoriasrrhhAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Denegatoriasrrhh Objeto)
		{
			try
			{
			this.oDenegatoriasrrhhAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
			this.oDenegatoriasrrhhAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oDenegatoriasrrhhAD.Dispose();
		}
		public DbQuery<DenegatoriasrrhhViewT> JsonT(string term)
		{
			return (DbQuery<DenegatoriasrrhhViewT>)this.oDenegatoriasrrhhAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
