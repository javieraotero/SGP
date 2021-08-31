
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
	public partial class MotivosPostergacionRefRN
	{
		MotivosPostergacionRefAD oMotivosPostergacionRefAD = new MotivosPostergacionRefAD();

		public MotivosPostergacionRef ObtenerPorId(int Id)
		{
			return this.oMotivosPostergacionRefAD.ObtenerPorId(Id);
		}

		public DbQuery<MotivosPostergacionRef> ObtenerTodo()
		{
			return this.oMotivosPostergacionRefAD.ObtenerTodo();
		}


		public DbQuery<MotivosPostergacionRefView> ObtenerParaGrilla()
		{
			return this.oMotivosPostergacionRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMotivosPostergacionRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(MotivosPostergacionRef Objeto)
		{
			try
			{
			this.oMotivosPostergacionRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosPostergacionRef Objeto)
		{
			try
			{
			this.oMotivosPostergacionRefAD.Actualizar(Objeto);
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
			this.oMotivosPostergacionRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMotivosPostergacionRefAD.Dispose();
		}
		public DbQuery<MotivosPostergacionRefViewT> JsonT(string term)
		{
			return (DbQuery<MotivosPostergacionRefViewT>)this.oMotivosPostergacionRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
