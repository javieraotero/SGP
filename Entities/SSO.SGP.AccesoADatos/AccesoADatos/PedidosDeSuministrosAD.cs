
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
	public partial class PedidosDeSuministrosAD
	{
		private BDEntities db = new BDEntities();

		public PedidosDeSuministros ObtenerPorId(int Id)
		{
			return db.PedidosDeSuministros.Single(c => c.Id == Id);
		}

		public DbQuery<PedidosDeSuministros> ObtenerTodo()
		{
			return (DbQuery<PedidosDeSuministros>)db.PedidosDeSuministros;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PedidosDeSuministros
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PedidosDeSuministrosView> ObtenerParaGrilla()
		{
			var x = from c in db.PedidosDeSuministros
                    where c.FechaDeBaja == null
					select new PedidosDeSuministrosView                    
					{
						 Id = c.Id,
						 Organismo = c.Organismos.Descripcion,
						 FechaDePedido = c.FechaDePedido,
						 FechaDeCarga = c.FechaDeCarga,
						 Entregado = c.Entregado ? "SI" : "NO",
					};
			return (DbQuery<PedidosDeSuministrosView>)x;
		}

		public void Guardar(PedidosDeSuministros Objeto)
		{
			try
			{
				db.PedidosDeSuministros.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PedidosDeSuministros Objeto)
		{
			try
			{
				db.PedidosDeSuministros.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto, int usuario)
		{
			try
			{
				PedidosDeSuministros Objeto = this.ObtenerPorId(IdObjeto);
                Objeto.FechaDeBaja = DateTime.Now;
                Objeto.UsuarioBaja = usuario;
                db.Entry(Objeto).State = EntityState.Modified;

                foreach (var a in Objeto.ArticulosDePedidoDeSuministros.ToList())
                {
                    var art = a.Articulos;
                    art.Stock = art.Stock + a.CantidadEntregada;

                    db.Entry(art).State = EntityState.Modified;
                }


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

		public DbQuery<PedidosDeSuministrosViewT> JsonT(string term)
		{
			var x = from c in db.PedidosDeSuministros
					select new PedidosDeSuministrosViewT
					{
						 Id = c.Id,
						 Organismo = c.Organismo,
						 FechaDePedido = c.FechaDePedido,
						 Usuario = c.Usuario,
						 FechaDeCarga = c.FechaDeCarga,
						 Entregado = c.Entregado,
						 FechaDeBaja = c.FechaDeBaja,
						 UsuarioBaja = c.UsuarioBaja,
					};
			return (DbQuery<PedidosDeSuministrosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
