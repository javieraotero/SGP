
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
	public partial class AdministracionPedidosActuacionesAD
	{
		private BDEntities db = new BDEntities();

		public AdministracionPedidosActuaciones ObtenerPorId(int Id)
		{
			return db.AdministracionPedidosActuaciones.Single(c => c.Id == Id);
		}

		public DbQuery<AdministracionPedidosActuaciones> ObtenerTodo()
		{
			return (DbQuery<AdministracionPedidosActuaciones>)db.AdministracionPedidosActuaciones ;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AdministracionPedidosActuaciones 
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<AdministracionPedidosActuaciones> GetJson(string filtro)
        {
            var res = from x in db.AdministracionPedidosActuaciones
                      where x.Activo == true
                      //where x.Personas.Apellidos.Contains(filtro)
                      //select new { text = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(), value = x.Id, dni = x.Personas.NroDocumento, legajo = x.Legajo};
                      select x;
            return (DbQuery<AdministracionPedidosActuaciones>)res;
        }

        public DbQuery<AdministracionPedidosActuacionesView> ObtenerParaGrilla(int Organismo)
		{
			var x = from c in db.AdministracionPedidosActuaciones
                    where c.Activo
                    //&& c.OrganismoOrigen==Organismo                     
                    orderby c.Id   
					select new AdministracionPedidosActuacionesView
                    {
						 Id = c.Id,
						 //Organismo = c.Organismos.Descripcion,
                         //OrganismoOrigen_Hide=c.OrganismoOrigen,
                         Pedido=c.Pedidos.Numero , 
                         Descripcion=c.Descripcion ,
                         FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
                         
					};
			return (DbQuery<AdministracionPedidosActuacionesView>)x;
		}
        
        public void Guardar(AdministracionPedidosActuaciones Objeto)
		{
			try
			{
				db.AdministracionPedidosActuaciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AdministracionPedidosActuaciones Objeto)
		{
			try
			{
				db.AdministracionPedidosActuaciones.Attach(Objeto);
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
                AdministracionPedidosActuaciones Objeto = this.ObtenerPorId(IdObjeto);
                Objeto.Activo  = false;
                
                db.Entry(Objeto).State = EntityState.Modified;
                
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

        public DbQuery<AdministracionPedidosActuacionesView> JsonT(int id)
		{
			var x = from c in db.AdministracionPedidosActuaciones
                    where c.Pedido == id
					select new AdministracionPedidosActuacionesView
					{
						 Id = c.Id,
						 Descripcion=c.Descripcion  ,   
                         FechaAlta =c.FechaAlta ,
                         Pedido =c.Pedido,
                         UsuarioAlta =c.UsuarioAlta ,                      
                         Activo=c.Activo 
						 
					};
			return (DbQuery<AdministracionPedidosActuacionesView>)x;
		}

        /*********************************************
		* Seccion Particular
		* *******************************************/

        /*
        public int UltimoNumeroPedido()
        {
            var x = from c in db.AdministracionPedidos
                    where c.Activo
                    orderby c.Numero descending 
                    select new AdministracionPedidosView
                    {
                        Id = c.Id,
                        Numero = c.Numero,
                       
                    };
            return x.FirstOrDefault().Numero;

        }
        */

    }
}
