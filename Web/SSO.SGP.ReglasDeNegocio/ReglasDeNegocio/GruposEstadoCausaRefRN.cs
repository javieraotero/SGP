
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
	public partial class GruposEstadoCausaRefRN
	{
		GruposEstadoCausaRefAD oGruposEstadoCausaRefAD = new GruposEstadoCausaRefAD();

		public GruposEstadoCausaRef ObtenerPorId(int Id)
		{
			return this.oGruposEstadoCausaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<GruposEstadoCausaRef> ObtenerTodo()
		{
			return this.oGruposEstadoCausaRefAD.ObtenerTodo();
		}


		public DbQuery<GruposEstadoCausaRefView> ObtenerParaGrilla()
		{
			return this.oGruposEstadoCausaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oGruposEstadoCausaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(GruposEstadoCausaRef Objeto)
		{
			try
			{
			this.oGruposEstadoCausaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposEstadoCausaRef Objeto)
		{
			try
			{
			this.oGruposEstadoCausaRefAD.Actualizar(Objeto);
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
			this.oGruposEstadoCausaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oGruposEstadoCausaRefAD.Dispose();
		}
		public DbQuery<GruposEstadoCausaRefViewT> JsonT(string term)
		{
			return (DbQuery<GruposEstadoCausaRefViewT>)this.oGruposEstadoCausaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
