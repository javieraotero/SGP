
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
	public partial class SucesosRN
	{
		SucesosAD oSucesosAD = new SucesosAD();

		public Sucesos ObtenerPorId(int Id)
		{
			return this.oSucesosAD.ObtenerPorId(Id);
		}

		public DbQuery<Sucesos> ObtenerTodo()
		{
			return this.oSucesosAD.ObtenerTodo();
		}


		public DbQuery<SucesosView> ObtenerParaGrilla()
		{
			return this.oSucesosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oSucesosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Sucesos Objeto)
		{
			try
			{
			this.oSucesosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Sucesos Objeto)
		{
			try
			{
			this.oSucesosAD.Actualizar(Objeto);
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
			this.oSucesosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oSucesosAD.Dispose();
		}
		public DbQuery<SucesosViewT> JsonT(string term)
		{
			return (DbQuery<SucesosViewT>)this.oSucesosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
