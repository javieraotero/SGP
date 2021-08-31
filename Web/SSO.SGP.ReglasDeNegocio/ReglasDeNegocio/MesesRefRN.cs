
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
	public partial class MesesRefRN
	{
		MesesRefAD oMesesRefAD = new MesesRefAD();

		public MesesRef ObtenerPorId(int Id)
		{
			return this.oMesesRefAD.ObtenerPorId(Id);
		}

		public DbQuery<MesesRef> ObtenerTodo()
		{
			return this.oMesesRefAD.ObtenerTodo();
		}


		public DbQuery<MesesRefView> ObtenerParaGrilla()
		{
			return this.oMesesRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMesesRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(MesesRef Objeto)
		{
			try
			{
			this.oMesesRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MesesRef Objeto)
		{
			try
			{
			this.oMesesRefAD.Actualizar(Objeto);
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
			this.oMesesRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMesesRefAD.Dispose();
		}
		public DbQuery<MesesRefViewT> JsonT(string term)
		{
			return (DbQuery<MesesRefViewT>)this.oMesesRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
