
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
	public partial class OrganismosSecuenciaModelosRefRN
	{
		OrganismosSecuenciaModelosRefAD oOrganismosSecuenciaModelosRefAD = new OrganismosSecuenciaModelosRefAD();

		public OrganismosSecuenciaModelosRef ObtenerPorId(int Id)
		{
			return this.oOrganismosSecuenciaModelosRefAD.ObtenerPorId(Id);
		}

		public DbQuery<OrganismosSecuenciaModelosRef> ObtenerTodo()
		{
			return this.oOrganismosSecuenciaModelosRefAD.ObtenerTodo();
		}


		public DbQuery<OrganismosSecuenciaModelosRefView> ObtenerParaGrilla()
		{
			return this.oOrganismosSecuenciaModelosRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oOrganismosSecuenciaModelosRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(OrganismosSecuenciaModelosRef Objeto)
		{
			try
			{
			this.oOrganismosSecuenciaModelosRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(OrganismosSecuenciaModelosRef Objeto)
		{
			try
			{
			this.oOrganismosSecuenciaModelosRefAD.Actualizar(Objeto);
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
			this.oOrganismosSecuenciaModelosRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oOrganismosSecuenciaModelosRefAD.Dispose();
		}
		public DbQuery<OrganismosSecuenciaModelosRefViewT> JsonT(string term)
		{
			return (DbQuery<OrganismosSecuenciaModelosRefViewT>)this.oOrganismosSecuenciaModelosRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
