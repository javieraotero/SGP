
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
	public partial class ModelosEscritoRN
	{
		ModelosEscritoAD oModelosEscritoAD = new ModelosEscritoAD();

		public ModelosEscrito ObtenerPorId(int Id)
		{
			return this.oModelosEscritoAD.ObtenerPorId(Id);
		}

		public DbQuery<ModelosEscrito> ObtenerTodo()
		{
			return this.oModelosEscritoAD.ObtenerTodo();
		}


		public DbQuery<ModelosEscritoView> ObtenerParaGrilla()
		{
			return this.oModelosEscritoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oModelosEscritoAD.ObtenerOptions(filtro);
		}

		public void Guardar(ModelosEscrito Objeto)
		{
			try
			{
			this.oModelosEscritoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ModelosEscrito Objeto)
		{
			try
			{
			this.oModelosEscritoAD.Actualizar(Objeto);
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
			this.oModelosEscritoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oModelosEscritoAD.Dispose();
		}
		public DbQuery<ModelosEscritoViewT> JsonT(string term)
		{
			return (DbQuery<ModelosEscritoViewT>)this.oModelosEscritoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
