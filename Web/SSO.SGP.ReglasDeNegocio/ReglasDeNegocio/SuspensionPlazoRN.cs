
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
	public partial class SuspensionPlazoRN
	{
		SuspensionPlazoAD oSuspensionPlazoAD = new SuspensionPlazoAD();

		public SuspensionPlazo ObtenerPorId(int Id)
		{
			return this.oSuspensionPlazoAD.ObtenerPorId(Id);
		}

		public DbQuery<SuspensionPlazo> ObtenerTodo()
		{
			return this.oSuspensionPlazoAD.ObtenerTodo();
		}


		public DbQuery<SuspensionPlazoView> ObtenerParaGrilla()
		{
			return this.oSuspensionPlazoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oSuspensionPlazoAD.ObtenerOptions(filtro);
		}

		public void Guardar(SuspensionPlazo Objeto)
		{
			try
			{
			this.oSuspensionPlazoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SuspensionPlazo Objeto)
		{
			try
			{
			this.oSuspensionPlazoAD.Actualizar(Objeto);
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
			this.oSuspensionPlazoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oSuspensionPlazoAD.Dispose();
		}
		public DbQuery<SuspensionPlazoViewT> JsonT(string term)
		{
			return (DbQuery<SuspensionPlazoViewT>)this.oSuspensionPlazoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
