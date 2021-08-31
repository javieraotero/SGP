
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
	public partial class ModelosEscritoadmRN
	{
		ModelosEscritoadmAD oModelosEscritoadmAD = new ModelosEscritoadmAD();

		public ModelosEscritoadm ObtenerPorId(int Id)
		{
			return this.oModelosEscritoadmAD.ObtenerPorId(Id);
		}

		public DbQuery<ModelosEscritoadm> ObtenerTodo()
		{
			return this.oModelosEscritoadmAD.ObtenerTodo();
		}


		public DbQuery<ModelosEscritoadmView> ObtenerParaGrilla(int Organismo)
		{
			return this.oModelosEscritoadmAD.ObtenerParaGrilla(Organismo);
		}

        public DbQuery<ModelosEscritoadmView> ModelosDeLaOficina(int oficina)
        {
            return this.oModelosEscritoadmAD.ModelosDeLaOficina(oficina);
        }

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oModelosEscritoadmAD.ObtenerOptions(filtro);
		}

		public void Guardar(ModelosEscritoadm Objeto)
		{
			try
			{
			this.oModelosEscritoadmAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ModelosEscritoadm Objeto)
		{
			try
			{
			this.oModelosEscritoadmAD.Actualizar(Objeto);
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
			this.oModelosEscritoadmAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oModelosEscritoadmAD.Dispose();
		}
		public DbQuery<ModelosEscritoadmViewT> JsonT(string term)
		{
			return (DbQuery<ModelosEscritoadmViewT>)this.oModelosEscritoadmAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
