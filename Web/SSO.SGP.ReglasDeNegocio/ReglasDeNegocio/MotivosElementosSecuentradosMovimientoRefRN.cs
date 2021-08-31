
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
	public partial class MotivosElementosSecuentradosMovimientoRefRN
	{
		MotivosElementosSecuentradosMovimientoRefAD oMotivosElementosSecuentradosMovimientoRefAD = new MotivosElementosSecuentradosMovimientoRefAD();

		public MotivosElementosSecuentradosMovimientoRef ObtenerPorId(int Id)
		{
			return this.oMotivosElementosSecuentradosMovimientoRefAD.ObtenerPorId(Id);
		}

		public DbQuery<MotivosElementosSecuentradosMovimientoRef> ObtenerTodo()
		{
			return this.oMotivosElementosSecuentradosMovimientoRefAD.ObtenerTodo();
		}


		public DbQuery<MotivosElementosSecuentradosMovimientoRefView> ObtenerParaGrilla()
		{
			return this.oMotivosElementosSecuentradosMovimientoRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMotivosElementosSecuentradosMovimientoRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(MotivosElementosSecuentradosMovimientoRef Objeto)
		{
			try
			{
			this.oMotivosElementosSecuentradosMovimientoRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosElementosSecuentradosMovimientoRef Objeto)
		{
			try
			{
			this.oMotivosElementosSecuentradosMovimientoRefAD.Actualizar(Objeto);
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
			this.oMotivosElementosSecuentradosMovimientoRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMotivosElementosSecuentradosMovimientoRefAD.Dispose();
		}
		public DbQuery<MotivosElementosSecuentradosMovimientoRefViewT> JsonT(string term)
		{
			return (DbQuery<MotivosElementosSecuentradosMovimientoRefViewT>)this.oMotivosElementosSecuentradosMovimientoRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
