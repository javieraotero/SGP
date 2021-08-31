
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
	public partial class PresentacionesCausaConexionRN
	{
		PresentacionesCausaConexionAD oPresentacionesCausaConexionAD = new PresentacionesCausaConexionAD();

		public PresentacionesCausaConexion ObtenerPorId(int Id)
		{
			return this.oPresentacionesCausaConexionAD.ObtenerPorId(Id);
		}

		public DbQuery<PresentacionesCausaConexion> ObtenerTodo()
		{
			return this.oPresentacionesCausaConexionAD.ObtenerTodo();
		}


		public DbQuery<PresentacionesCausaConexionView> ObtenerParaGrilla()
		{
			return this.oPresentacionesCausaConexionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPresentacionesCausaConexionAD.ObtenerOptions(filtro);
		}

		public void Guardar(PresentacionesCausaConexion Objeto)
		{
			try
			{
			this.oPresentacionesCausaConexionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresentacionesCausaConexion Objeto)
		{
			try
			{
			this.oPresentacionesCausaConexionAD.Actualizar(Objeto);
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
			this.oPresentacionesCausaConexionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPresentacionesCausaConexionAD.Dispose();
		}
		public DbQuery<PresentacionesCausaConexionViewT> JsonT(string term)
		{
			return (DbQuery<PresentacionesCausaConexionViewT>)this.oPresentacionesCausaConexionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
