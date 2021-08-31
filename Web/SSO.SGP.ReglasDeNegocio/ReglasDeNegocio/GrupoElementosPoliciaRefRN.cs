
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
	public partial class GrupoElementosPoliciaRefRN
	{
		GrupoElementosPoliciaRefAD oGrupoElementosPoliciaRefAD = new GrupoElementosPoliciaRefAD();

		public GrupoElementosPoliciaRef ObtenerPorId(int Id)
		{
			return this.oGrupoElementosPoliciaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<GrupoElementosPoliciaRef> ObtenerTodo()
		{
			return this.oGrupoElementosPoliciaRefAD.ObtenerTodo();
		}


		public DbQuery<GrupoElementosPoliciaRefView> ObtenerParaGrilla()
		{
			return this.oGrupoElementosPoliciaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oGrupoElementosPoliciaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(GrupoElementosPoliciaRef Objeto)
		{
			try
			{
			this.oGrupoElementosPoliciaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GrupoElementosPoliciaRef Objeto)
		{
			try
			{
			this.oGrupoElementosPoliciaRefAD.Actualizar(Objeto);
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
			this.oGrupoElementosPoliciaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oGrupoElementosPoliciaRefAD.Dispose();
		}
		public DbQuery<GrupoElementosPoliciaRefViewT> JsonT(string term)
		{
			return (DbQuery<GrupoElementosPoliciaRefViewT>)this.oGrupoElementosPoliciaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
