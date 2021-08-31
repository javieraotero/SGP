
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
	public partial class SexosRefRN
	{
		SexosRefAD oSexosRefAD = new SexosRefAD();

		public SexosRef ObtenerPorId(int Id)
		{
			return this.oSexosRefAD.ObtenerPorId(Id);
		}

		public DbQuery<SexosRef> ObtenerTodo()
		{
			return this.oSexosRefAD.ObtenerTodo();
		}


		public DbQuery<SexosRefView> ObtenerParaGrilla()
		{
			return this.oSexosRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oSexosRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(SexosRef Objeto)
		{
			try
			{
			this.oSexosRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SexosRef Objeto)
		{
			try
			{
			this.oSexosRefAD.Actualizar(Objeto);
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
			this.oSexosRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oSexosRefAD.Dispose();
		}
		public DbQuery<SexosRefViewT> JsonT(string term)
		{
			return (DbQuery<SexosRefViewT>)this.oSexosRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
