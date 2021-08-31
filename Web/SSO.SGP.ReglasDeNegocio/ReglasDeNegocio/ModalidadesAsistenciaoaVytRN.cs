
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
	public partial class ModalidadesAsistenciaoaVytRN
	{
		ModalidadesAsistenciaoaVytAD oModalidadesAsistenciaoaVytAD = new ModalidadesAsistenciaoaVytAD();

		public ModalidadesAsistenciaoaVyt ObtenerPorId(int Id)
		{
			return this.oModalidadesAsistenciaoaVytAD.ObtenerPorId(Id);
		}

		public DbQuery<ModalidadesAsistenciaoaVyt> ObtenerTodo()
		{
			return this.oModalidadesAsistenciaoaVytAD.ObtenerTodo();
		}


		public DbQuery<ModalidadesAsistenciaoaVytView> ObtenerParaGrilla()
		{
			return this.oModalidadesAsistenciaoaVytAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oModalidadesAsistenciaoaVytAD.ObtenerOptions(filtro);
		}

		public void Guardar(ModalidadesAsistenciaoaVyt Objeto)
		{
			try
			{
			this.oModalidadesAsistenciaoaVytAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ModalidadesAsistenciaoaVyt Objeto)
		{
			try
			{
			this.oModalidadesAsistenciaoaVytAD.Actualizar(Objeto);
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
			this.oModalidadesAsistenciaoaVytAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oModalidadesAsistenciaoaVytAD.Dispose();
		}
		public DbQuery<ModalidadesAsistenciaoaVytViewT> JsonT(string term)
		{
			return (DbQuery<ModalidadesAsistenciaoaVytViewT>)this.oModalidadesAsistenciaoaVytAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
