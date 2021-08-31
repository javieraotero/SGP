
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
	public partial class FeriasRefRN
	{
		FeriasRefAD oFeriasRefAD = new FeriasRefAD();

		public FeriasRef ObtenerPorId(int Id)
		{
			return this.oFeriasRefAD.ObtenerPorId(Id);
		}

        public FeriasRef ObtenerPorIdyPaso(int Id, int paso)
        {
            return this.oFeriasRefAD.ObtenerPorIdyPaso(Id, paso);
        }


		public DbQuery<FeriasRef> ObtenerTodo()
		{
			return this.oFeriasRefAD.ObtenerTodo();
		}


		public DbQuery<FeriasRefView> ObtenerParaGrilla()
		{
			return this.oFeriasRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oFeriasRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(FeriasRef Objeto)
		{
			try
			{
			this.oFeriasRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FeriasRef Objeto)
		{
			try
			{
			this.oFeriasRefAD.Actualizar(Objeto);
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
			this.oFeriasRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oFeriasRefAD.Dispose();
		}
		public DbQuery<FeriasRefViewT> JsonT(string term)
		{
			return (DbQuery<FeriasRefViewT>)this.oFeriasRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/
        public int AsignacionDeFeriaJuzgadosDePaz(int Feria) {
            return(this.oFeriasRefAD.AsignacionDeFeriaJuzgadosDePaz(Feria));     
        }

	}
}
