
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
	public partial class MotivosPostergacionCivilRefRN
	{
		MotivosPostergacionCivilRefAD oMotivosPostergacionCivilRefAD = new MotivosPostergacionCivilRefAD();

		public MotivosPostergacionCivilRef ObtenerPorId(int Id)
		{
			return this.oMotivosPostergacionCivilRefAD.ObtenerPorId(Id);
		}

		public DbQuery<MotivosPostergacionCivilRef> ObtenerTodo()
		{
			return this.oMotivosPostergacionCivilRefAD.ObtenerTodo();
		}


		public DbQuery<MotivosPostergacionCivilRefView> ObtenerParaGrilla()
		{
			return this.oMotivosPostergacionCivilRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMotivosPostergacionCivilRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(MotivosPostergacionCivilRef Objeto)
		{
			try
			{
			this.oMotivosPostergacionCivilRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosPostergacionCivilRef Objeto)
		{
			try
			{
			this.oMotivosPostergacionCivilRefAD.Actualizar(Objeto);
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
			this.oMotivosPostergacionCivilRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMotivosPostergacionCivilRefAD.Dispose();
		}
		public DbQuery<MotivosPostergacionCivilRefViewT> JsonT(string term)
		{
			return (DbQuery<MotivosPostergacionCivilRefViewT>)this.oMotivosPostergacionCivilRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
