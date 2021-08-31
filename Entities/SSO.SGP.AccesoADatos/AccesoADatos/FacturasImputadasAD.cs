
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
	public partial class FacturasImputadasAD
	{
		private BDEntities db = new BDEntities();

		public FacturasImputadas ObtenerPorId(int Id)
		{
			return db.FacturasImputadas.Single(c => c.Id == Id);
		}

		public DbQuery<FacturasImputadas> ObtenerTodo()
		{
			return (DbQuery<FacturasImputadas>)db.FacturasImputadas;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.FacturasImputadas
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<FacturasImputadasView> ObtenerParaGrilla()
		{
			var x = from c in db.FacturasImputadas
					select new FacturasImputadasView
					{
						 Id = c.Id,
						 Factura = c.Factura,
						 Fecha = c.Fecha,
						 AnioContable = c.AnioContable,
						 Usuario = c.Usuario,
						 FechaElimina = c.FechaElimina,
						 UsuarioElimina = c.UsuarioElimina,
					};
			return (DbQuery<FacturasImputadasView>)x;
		}

		public void Guardar(FacturasImputadas Objeto)
		{
			try
			{
				db.FacturasImputadas.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FacturasImputadas Objeto)
		{
			try
			{
				db.FacturasImputadas.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

        public void LimpiarAsignacion(int factura, int usuario) {

            try
            {
                var fdad = new FacturasImputadasDetalleAD();

                var d = (from x in db.FacturasImputadas
                         where x.Factura == factura
                         select x).ToList();

                foreach (var fd in d)
                {
                    //foreach (var fid in fd.FacturasImputadasDetalle.ToList()) {
                    //    fdad.Eliminar(fid.Id);
                    //}
                    fd.FechaElimina = DateTime.Now;
                    fd.UsuarioElimina = usuario;
                    db.FacturasImputadas.Attach(fd);
                    db.Entry(fd).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception e) {

            }
        }

		public void Eliminar(int IdObjeto)
		{
			try
			{
                //var fd = new FacturasImputadasDetalleAD();
				FacturasImputadas Objeto = this.ObtenerPorId(IdObjeto);
                //var detalle = Objeto.FacturasImputadasDetalle.ToList();

                //foreach (var d in detalle) {
                //    fd.Eliminar(d.Id);
                //}

                db.FacturasImputadas.Remove(Objeto);
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

		public DbQuery<FacturasImputadasViewT> JsonT(string term)
		{
			var x = from c in db.FacturasImputadas
					select new FacturasImputadasViewT
					{
						 Id = c.Id,
						 Factura = c.Factura,
						 Fecha = c.Fecha,
						 AnioContable = c.AnioContable,
						 Usuario = c.Usuario,
						 FechaElimina = c.FechaElimina,
						 UsuarioElimina = c.UsuarioElimina,
					};
			return (DbQuery<FacturasImputadasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
