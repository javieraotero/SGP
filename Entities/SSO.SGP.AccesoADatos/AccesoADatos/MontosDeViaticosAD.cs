
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class MontosDeViaticosAD
	{
		private BDEntities db = new BDEntities();

		public MontosDeViaticos ObtenerPorId(int Id)
		{
			return db.MontosDeViaticos.Single(c => c.Id == Id);
		}

        //public DbQuery<AutocompleteView> ObtenerOptions(string filtro)
        //{
        //    var res = from x in db.MontosDeViaticos
        //              select new SelectOptionsView { text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
        //    return (DbQuery<SelectOptionsView>)res;
        //}

        public MontosDeViaticos ObtenerVigente() {

            var res = (from x in db.MontosDeViaticos
                       where x.FechaInicioVigencia <= DateTime.Now
                       select x
                       ).OrderByDescending(x=>x.FechaInicioVigencia).FirstOrDefault();

            return res;

        }

		public DbQuery<MontosDeViaticos> ObtenerTodo()
		{
			return (DbQuery<MontosDeViaticos>)db.MontosDeViaticos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MontosDeViaticos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MontosDeViaticosView> ObtenerParaGrilla()
		{
			var x = from c in db.MontosDeViaticos
					select new MontosDeViaticosView
					{
						 Id = c.Id,
						 FechaInicioVigencia = c.FechaInicioVigencia,
						 FuncionarioProvinciaUnDia = c.FuncionarioProvinciaUnDia,
						 FuncionarioProvinciaMasUnDia = c.FuncionarioProvinciaMasUnDia,
						 FuncionarioFueraUnDia = c.FuncionarioFueraUnDia,
						 FuncionarioFueraMasUnDia = c.FuncionarioFueraMasUnDia,
						 FuncionarioProvincia25Mayo = c.FuncionarioProvincia25Mayo,
						 AgenteProvinciaUnDia1 = c.AgenteProvinciaUnDia1,
						 AgenteProvinciaMasUnDia1 = c.AgenteProvinciaMasUnDia1,
						 AgenteFueraUnDia1 = c.AgenteFueraUnDia1,
					};
			return (DbQuery<MontosDeViaticosView>)x;
		}

		public void Guardar(MontosDeViaticos Objeto)
		{
			try
			{
				db.MontosDeViaticos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
                Syncrosoft.Framework.Utils.Logs.Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MontosDeViaticos Objeto)
		{
			try
			{
				db.MontosDeViaticos.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
				MontosDeViaticos Objeto = this.ObtenerPorId(IdObjeto);
				db.MontosDeViaticos.Remove(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			db.Dispose();
		}

		//public DbQuery<MontosDeViaticosViewT> JsonT(string term)
		//{
		//	var x = from c in db.MontosDeViaticos
		//			select new MontosDeViaticosViewT
		//			{
		//				 Id = c.Id,
		//				 FechaInicioVigencia = c.FechaInicioVigencia,
		//				 FuncionarioProvinciaUnDia = c.FuncionarioProvinciaUnDia,
		//				 FuncionarioProvinciaMasUnDia = c.FuncionarioProvinciaMasUnDia,
		//				 FuncionarioFueraUnDia = c.FuncionarioFueraUnDia,
		//				 FuncionarioFueraMasUnDia = c.FuncionarioFueraMasUnDia,
		//				 FuncionarioProvincia25Mayo = c.FuncionarioProvincia25Mayo,
		//				 AgenteProvinciaUnDia1 = c.AgenteProvinciaUnDia1,
		//				 AgenteProvinciaMasUnDia1 = c.AgenteProvinciaMasUnDia1,
		//				 AgenteFueraUnDia1 = c.AgenteFueraUnDia1,
		//				 AgenteProvincia25Mayo1 = c.AgenteProvincia25Mayo1,
		//			};
		//	return (DbQuery<MontosDeViaticosViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
