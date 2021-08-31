
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
	public partial class ConcursosRN
	{
		ConcursosAD oConcursosAD = new ConcursosAD();

		public Concursos ObtenerPorId(int Id)
		{
			return this.oConcursosAD.ObtenerPorId(Id);
		}

		public DbQuery<Concursos> ObtenerTodo()
		{
			return this.oConcursosAD.ObtenerTodo();
		}


		public DbQuery<ConcursosView> ObtenerParaGrilla()
		{
			return this.oConcursosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oConcursosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Concursos Objeto)
		{
			try
			{
			this.oConcursosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Concursos Objeto)
		{
			try
			{
			this.oConcursosAD.Actualizar(Objeto);
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
			this.oConcursosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oConcursosAD.Dispose();
		}
		public DbQuery<ConcursosViewT> JsonT(string term)
		{
			return (DbQuery<ConcursosViewT>)this.oConcursosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
