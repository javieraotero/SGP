
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
	public partial class MotivosCancelacionRefRN
	{
		MotivosCancelacionRefAD oMotivosCancelacionRefAD = new MotivosCancelacionRefAD();

		public MotivosCancelacionRef ObtenerPorId(int Id)
		{
			return this.oMotivosCancelacionRefAD.ObtenerPorId(Id);
		}

		public DbQuery<MotivosCancelacionRef> ObtenerTodo()
		{
			return this.oMotivosCancelacionRefAD.ObtenerTodo();
		}


		public DbQuery<MotivosCancelacionRefView> ObtenerParaGrilla()
		{
			return this.oMotivosCancelacionRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMotivosCancelacionRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(MotivosCancelacionRef Objeto)
		{
			try
			{
			this.oMotivosCancelacionRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosCancelacionRef Objeto)
		{
			try
			{
			this.oMotivosCancelacionRefAD.Actualizar(Objeto);
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
			this.oMotivosCancelacionRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMotivosCancelacionRefAD.Dispose();
		}
		public DbQuery<MotivosCancelacionRefViewT> JsonT(string term)
		{
			return (DbQuery<MotivosCancelacionRefViewT>)this.oMotivosCancelacionRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
