
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
	public partial class BarriosRefRN
	{
		BarriosRefAD oBarriosRefAD = new BarriosRefAD();

		public BarriosRef ObtenerPorId(int Id)
		{
			return this.oBarriosRefAD.ObtenerPorId(Id);
		}

		public DbQuery<BarriosRef> ObtenerTodo()
		{
			return this.oBarriosRefAD.ObtenerTodo();
		}


		public DbQuery<BarriosRefView> ObtenerParaGrilla()
		{
			return this.oBarriosRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oBarriosRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(BarriosRef Objeto)
		{
			try
			{
			this.oBarriosRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(BarriosRef Objeto)
		{
			try
			{
			this.oBarriosRefAD.Actualizar(Objeto);
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
			this.oBarriosRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oBarriosRefAD.Dispose();
		}
		public DbQuery<BarriosRefViewT> JsonT(string term)
		{
			return (DbQuery<BarriosRefViewT>)this.oBarriosRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
