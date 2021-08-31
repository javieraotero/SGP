
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
	public partial class SectoresPoliciaRefRN
	{
		SectoresPoliciaRefAD oSectoresPoliciaRefAD = new SectoresPoliciaRefAD();

		public SectoresPoliciaRef ObtenerPorId(int Id)
		{
			return this.oSectoresPoliciaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<SectoresPoliciaRef> ObtenerTodo()
		{
			return this.oSectoresPoliciaRefAD.ObtenerTodo();
		}


		public DbQuery<SectoresPoliciaRefView> ObtenerParaGrilla()
		{
			return this.oSectoresPoliciaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oSectoresPoliciaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(SectoresPoliciaRef Objeto)
		{
			try
			{
			this.oSectoresPoliciaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SectoresPoliciaRef Objeto)
		{
			try
			{
			this.oSectoresPoliciaRefAD.Actualizar(Objeto);
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
			this.oSectoresPoliciaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oSectoresPoliciaRefAD.Dispose();
		}
		public DbQuery<SectoresPoliciaRefViewT> JsonT(string term)
		{
			return (DbQuery<SectoresPoliciaRefViewT>)this.oSectoresPoliciaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
