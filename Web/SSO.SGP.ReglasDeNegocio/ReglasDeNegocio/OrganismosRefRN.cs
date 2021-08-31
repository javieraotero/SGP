
using System;
using System.Data.Entity.Infrastructure;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System.Collections.Generic;


namespace SSO.SGP.ReglasDeNegocio
{
	/// <summary>
	/// Reglas De Negocio Generada por el Generador de codigo.
	/// </summary>
	public partial class OrganismosRefRN
	{
		OrganismosRefAD oOrganismosRefAD = new OrganismosRefAD();

		public OrganismosRef ObtenerPorId(int Id)
		{
			return this.oOrganismosRefAD.ObtenerPorId(Id);
		}

		public DbQuery<OrganismosRef> ObtenerTodo()
		{
			return this.oOrganismosRefAD.ObtenerTodo();
		}

        public DbQuery<Agentes> ObtenerAgentes(int organismo) {
            return this.oOrganismosRefAD.ObtenerAgentes(organismo);
        }

        public DbQuery<OrganismosRef> ObtenerRRHH()
        {
            return this.oOrganismosRefAD.ObtenerSoloRRHH();
        }

		public DbQuery<OrganismosRefView> ObtenerParaGrilla()
		{
			return this.oOrganismosRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oOrganismosRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(OrganismosRef Objeto)
		{
			try
			{
			this.oOrganismosRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(OrganismosRef Objeto)
		{
			try
			{
			this.oOrganismosRefAD.Actualizar(Objeto);
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
			this.oOrganismosRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oOrganismosRefAD.Dispose();
		}
		public DbQuery<OrganismosRefViewT> JsonT(string term)
		{
			return (DbQuery<OrganismosRefViewT>)this.oOrganismosRefAD.JsonT(term);
		}

        public List<ResumenLicenciasPorOrganismoViewT> ResumenDeLicencias(int Organismo) {
            return this.oOrganismosRefAD.ResumenLicenciasPorOrganismo(Organismo);
        }
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
