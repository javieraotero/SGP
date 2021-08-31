
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
	public partial class ProvinciasRefRN
	{
		ProvinciasRefAD oProvinciasRefAD = new ProvinciasRefAD();

		public ProvinciasRef ObtenerPorId(int Id)
		{
			return this.oProvinciasRefAD.ObtenerPorId(Id);
		}

		public DbQuery<ProvinciasRef> ObtenerTodo()
		{
			return this.oProvinciasRefAD.ObtenerTodo();
		}


		public DbQuery<ProvinciasRefView> ObtenerParaGrilla()
		{
			return this.oProvinciasRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oProvinciasRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(ProvinciasRef Objeto)
		{
			try
			{
			this.oProvinciasRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ProvinciasRef Objeto)
		{
			try
			{
			this.oProvinciasRefAD.Actualizar(Objeto);
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
			this.oProvinciasRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oProvinciasRefAD.Dispose();
		}
		public DbQuery<ProvinciasRefViewT> JsonT(string term)
		{
			return (DbQuery<ProvinciasRefViewT>)this.oProvinciasRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
