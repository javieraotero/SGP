
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
	public partial class ModalidadesPoliciaRefRN
	{
		ModalidadesPoliciaRefAD oModalidadesPoliciaRefAD = new ModalidadesPoliciaRefAD();

		public ModalidadesPoliciaRef ObtenerPorId(int Id)
		{
			return this.oModalidadesPoliciaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<ModalidadesPoliciaRef> ObtenerTodo()
		{
			return this.oModalidadesPoliciaRefAD.ObtenerTodo();
		}


		public DbQuery<ModalidadesPoliciaRefView> ObtenerParaGrilla()
		{
			return this.oModalidadesPoliciaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oModalidadesPoliciaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(ModalidadesPoliciaRef Objeto)
		{
			try
			{
			this.oModalidadesPoliciaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ModalidadesPoliciaRef Objeto)
		{
			try
			{
			this.oModalidadesPoliciaRefAD.Actualizar(Objeto);
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
			this.oModalidadesPoliciaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oModalidadesPoliciaRefAD.Dispose();
		}
		public DbQuery<ModalidadesPoliciaRefViewT> JsonT(string term)
		{
			return (DbQuery<ModalidadesPoliciaRefViewT>)this.oModalidadesPoliciaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
