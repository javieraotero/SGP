
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
	public partial class UsuariosOrganismosGruposRN
	{
		UsuariosOrganismosGruposAD oUsuariosOrganismosGruposAD = new UsuariosOrganismosGruposAD();

		public UsuariosOrganismosGrupos ObtenerPorId(int Id)
		{
			return this.oUsuariosOrganismosGruposAD.ObtenerPorId(Id);
		}

		public DbQuery<UsuariosOrganismosGrupos> ObtenerTodo()
		{
			return this.oUsuariosOrganismosGruposAD.ObtenerTodo();
		}


		public DbQuery<UsuariosOrganismosGruposView> ObtenerParaGrilla()
		{
			return this.oUsuariosOrganismosGruposAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oUsuariosOrganismosGruposAD.ObtenerOptions(filtro);
		}

		public void Guardar(UsuariosOrganismosGrupos Objeto)
		{
			try
			{
			this.oUsuariosOrganismosGruposAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(UsuariosOrganismosGrupos Objeto)
		{
			try
			{
			this.oUsuariosOrganismosGruposAD.Actualizar(Objeto);
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
			this.oUsuariosOrganismosGruposAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oUsuariosOrganismosGruposAD.Dispose();
		}
		public DbQuery<UsuariosOrganismosGruposViewT> JsonT(string term)
		{
			return (DbQuery<UsuariosOrganismosGruposViewT>)this.oUsuariosOrganismosGruposAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
