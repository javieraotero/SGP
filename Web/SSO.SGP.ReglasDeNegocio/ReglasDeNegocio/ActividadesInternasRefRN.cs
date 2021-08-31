
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
	public partial class ActividadesInternasRefRN
	{
		ActividadesInternasRefAD oActividadesInternasRefAD = new ActividadesInternasRefAD();

		public ActividadesInternasRef ObtenerPorId(int Id)
		{
			return this.oActividadesInternasRefAD.ObtenerPorId(Id);
		}

		public DbQuery<ActividadesInternasRef> ObtenerTodo()
		{
			return this.oActividadesInternasRefAD.ObtenerTodo();
		}


		public DbQuery<ActividadesInternasRefView> ObtenerParaGrilla()
		{
			return this.oActividadesInternasRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oActividadesInternasRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(ActividadesInternasRef Objeto)
		{
			try
			{
			this.oActividadesInternasRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActividadesInternasRef Objeto)
		{
			try
			{
			this.oActividadesInternasRefAD.Actualizar(Objeto);
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
			this.oActividadesInternasRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oActividadesInternasRefAD.Dispose();
		}
		public DbQuery<ActividadesInternasRefViewT> JsonT(string term)
		{
			return (DbQuery<ActividadesInternasRefViewT>)this.oActividadesInternasRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
