
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
	public partial class MotivosCancelacionCivilRefRN
	{
		MotivosCancelacionCivilRefAD oMotivosCancelacionCivilRefAD = new MotivosCancelacionCivilRefAD();

		public MotivosCancelacionCivilRef ObtenerPorId(int Id)
		{
			return this.oMotivosCancelacionCivilRefAD.ObtenerPorId(Id);
		}

		public DbQuery<MotivosCancelacionCivilRef> ObtenerTodo()
		{
			return this.oMotivosCancelacionCivilRefAD.ObtenerTodo();
		}


		public DbQuery<MotivosCancelacionCivilRefView> ObtenerParaGrilla()
		{
			return this.oMotivosCancelacionCivilRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMotivosCancelacionCivilRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(MotivosCancelacionCivilRef Objeto)
		{
			try
			{
			this.oMotivosCancelacionCivilRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosCancelacionCivilRef Objeto)
		{
			try
			{
			this.oMotivosCancelacionCivilRefAD.Actualizar(Objeto);
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
			this.oMotivosCancelacionCivilRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMotivosCancelacionCivilRefAD.Dispose();
		}
		public DbQuery<MotivosCancelacionCivilRefViewT> JsonT(string term)
		{
			return (DbQuery<MotivosCancelacionCivilRefViewT>)this.oMotivosCancelacionCivilRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
