
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
	public partial class CompraDeSuministrosRN
	{
		CompraDeSuministrosAD oCompraDeSuministrosAD = new CompraDeSuministrosAD();

		public CompraDeSuministros ObtenerPorId(int Id)
		{
			return this.oCompraDeSuministrosAD.ObtenerPorId(Id);
		}

		public DbQuery<CompraDeSuministros> ObtenerTodo()
		{
			return this.oCompraDeSuministrosAD.ObtenerTodo();
		}


		public DbQuery<CompraDeSuministrosView> ObtenerParaGrilla()
		{
			return this.oCompraDeSuministrosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCompraDeSuministrosAD.ObtenerOptions(filtro);
		}

		public void Guardar(CompraDeSuministros Objeto)
		{
			try
			{
			this.oCompraDeSuministrosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CompraDeSuministros Objeto)
		{
			try
			{
			this.oCompraDeSuministrosAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto, int usuario)
		{
			try
			{
			this.oCompraDeSuministrosAD.Eliminar(IdObjeto, usuario);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCompraDeSuministrosAD.Dispose();
		}
		public DbQuery<CompraDeSuministrosViewT> JsonT(string term)
		{
			return (DbQuery<CompraDeSuministrosViewT>)this.oCompraDeSuministrosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
