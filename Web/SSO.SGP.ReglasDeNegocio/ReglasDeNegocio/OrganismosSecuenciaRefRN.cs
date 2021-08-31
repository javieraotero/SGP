
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
	public partial class OrganismosSecuenciaRefRN
	{
		OrganismosSecuenciaRefAD oOrganismosSecuenciaRefAD = new OrganismosSecuenciaRefAD();

		public OrganismosSecuenciaRef ObtenerPorId(int Id)
		{
			return this.oOrganismosSecuenciaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<OrganismosSecuenciaRef> ObtenerTodo()
		{
			return this.oOrganismosSecuenciaRefAD.ObtenerTodo();
		}


		public DbQuery<OrganismosSecuenciaRefView> ObtenerParaGrilla()
		{
			return this.oOrganismosSecuenciaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oOrganismosSecuenciaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(OrganismosSecuenciaRef Objeto)
		{
			try
			{
			this.oOrganismosSecuenciaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(OrganismosSecuenciaRef Objeto)
		{
			try
			{
			this.oOrganismosSecuenciaRefAD.Actualizar(Objeto);
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
			this.oOrganismosSecuenciaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oOrganismosSecuenciaRefAD.Dispose();
		}
		public DbQuery<OrganismosSecuenciaRefViewT> JsonT(string term)
		{
			return (DbQuery<OrganismosSecuenciaRefViewT>)this.oOrganismosSecuenciaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
