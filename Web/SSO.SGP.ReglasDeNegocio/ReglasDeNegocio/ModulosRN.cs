
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
	public partial class ModulosRN
	{
		ModulosAD oModulosAD = new ModulosAD();

		public Modulos ObtenerPorId(int Id)
		{
			return this.oModulosAD.ObtenerPorId(Id);
		}

		public DbQuery<Modulos> ObtenerTodo()
		{
			return this.oModulosAD.ObtenerTodo();
		}


		public DbQuery<ModulosView> ObtenerParaGrilla()
		{
			return this.oModulosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oModulosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Modulos Objeto)
		{
			try
			{
			this.oModulosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Modulos Objeto)
		{
			try
			{
			this.oModulosAD.Actualizar(Objeto);
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
			this.oModulosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oModulosAD.Dispose();
		}
		public DbQuery<ModulosViewT> JsonT(string term)
		{
			return (DbQuery<ModulosViewT>)this.oModulosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
