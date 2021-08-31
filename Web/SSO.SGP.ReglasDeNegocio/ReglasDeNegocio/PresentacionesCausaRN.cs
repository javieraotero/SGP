
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
	public partial class PresentacionesCausaRN
	{
		PresentacionesCausaAD oPresentacionesCausaAD = new PresentacionesCausaAD();

		public PresentacionesCausa ObtenerPorId(int Id)
		{
			return this.oPresentacionesCausaAD.ObtenerPorId(Id);
		}

		public DbQuery<PresentacionesCausa> ObtenerTodo()
		{
			return this.oPresentacionesCausaAD.ObtenerTodo();
		}


		public DbQuery<PresentacionesCausaView> ObtenerParaGrilla()
		{
			return this.oPresentacionesCausaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPresentacionesCausaAD.ObtenerOptions(filtro);
		}

		public void Guardar(PresentacionesCausa Objeto)
		{
			try
			{
			this.oPresentacionesCausaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresentacionesCausa Objeto)
		{
			try
			{
			this.oPresentacionesCausaAD.Actualizar(Objeto);
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
			this.oPresentacionesCausaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPresentacionesCausaAD.Dispose();
		}
		public DbQuery<PresentacionesCausaViewT> JsonT(string term)
		{
			return (DbQuery<PresentacionesCausaViewT>)this.oPresentacionesCausaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
