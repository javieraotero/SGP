
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
	public partial class AdministracionPedidosAD
	{
		private BDEntities db = new BDEntities();

		public AdministracionPedidos ObtenerPorId(int Id)
		{
			return db.AdministracionPedidos.Single(c => c.Id == Id);
		}

		public DbQuery<AdministracionPedidos> ObtenerTodo()
		{
			return (DbQuery<AdministracionPedidos>)db.AdministracionPedidos ;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AdministracionPedidos 
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<AdministracionPedidos> GetJson(string filtro)
        {
            var res = from x in db.AdministracionPedidos 
                      where x.Activo == true
                      //where x.Personas.Apellidos.Contains(filtro)
                      //select new { text = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(), value = x.Id, dni = x.Personas.NroDocumento, legajo = x.Legajo};
                      select x;
            return (DbQuery<AdministracionPedidos>)res;
        }

        public DbQuery<AdministracionPedidosView> ObtenerParaGrilla(int Organismo)
		{
			var x = from c in db.AdministracionPedidos 
                    where c.Activo
                    && c.OrganismoOrigen==Organismo                     
                    orderby c.Numero descending  
					select new AdministracionPedidosView                    
					{
						 Id = c.Id,
						 //Organismo = c.Organismos.Descripcion,
                         OrganismoOrigen_Hide=c.OrganismoOrigen,
                         OrganismoDestino=c.OrganismosRef.Descripcion , 
                         Descripcion=c.Descripcion ,
                         FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
                         Numero=c.Numero ,
						 //Activo = c.Activo,
					};
			return (DbQuery<AdministracionPedidosView>)x;
		}

        public DbQuery<AdministracionPedidosSolicitudesView> ObtenerParaGrillaRecepcionSolicitudes(int Organismo)
        {
            var x = from c in db.AdministracionPedidos
                    where c.Activo 
                    && c.OrganismoDestino == Organismo  
                    && c.FechaRecepcion == null
                    && c.FechaRechazado == null
                    orderby c.Numero descending
                    select new AdministracionPedidosSolicitudesView
                    {
                        Id = c.Id,
                        //Organismo = c.Organismos.Descripcion,
                        OrganismoOrigen =  c.OrganismosOrigenRef.Descripcion,
                        OrganismoDestino_Hide = c.OrganismoDestino,
                        Descripcion = c.Descripcion,
                        FechaAlta = c.FechaAlta,
                        UsuarioAlta = c.UsuarioAlta,
                        Numero = c.Numero,
                        //Activo = c.Activo,
                    };
            return (DbQuery<AdministracionPedidosSolicitudesView>)x;
        }

        public DbQuery<AdministracionPedidosSolicitudesView> ObtenerParaGrillaSolicitudes(int Organismo)
        {
            var x = from c in db.AdministracionPedidos
                    where c.Activo
                    && c.OrganismoDestino == Organismo
                    && c.FechaRecepcion.HasValue 
                    //&& c.FechaRechazado == null
                    orderby c.Numero descending
                    select new AdministracionPedidosSolicitudesView
                    {
                        Id = c.Id,
                        //Organismo = c.Organismos.Descripcion,
                        OrganismoOrigen = c.OrganismosOrigenRef.Descripcion,
                        OrganismoDestino_Hide = c.OrganismoDestino,
                        Descripcion = c.Descripcion,
                        FechaAlta = c.FechaAlta,
                        UsuarioAlta = c.UsuarioAlta,
                        Numero = c.Numero,
                        //Activo = c.Activo,
                    };
            return (DbQuery<AdministracionPedidosSolicitudesView>)x;
        }

        public void Guardar(AdministracionPedidos Objeto)
		{
			try
			{
				db.AdministracionPedidos .Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AdministracionPedidos  Objeto)
		{
			try
			{
				db.AdministracionPedidos .Attach(Objeto);
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
				AdministracionPedidos  Objeto = this.ObtenerPorId(IdObjeto);
                Objeto.Activo  = false;
                
                db.Entry(Objeto).State = EntityState.Modified;

                /*foreach (var a in Objeto.ArticulosDePedidoDeSuministros.ToList())
                {
                    var art = a.Articulos;
                    art.Stock = art.Stock + a.CantidadEntregada;

                    db.Entry(art).State = EntityState.Modified;
                }*/


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

		public DbQuery<AdministracionPedidosViewT> JsonT(string term)
		{
			var x = from c in db.AdministracionPedidos 
					select new AdministracionPedidosViewT
					{
						 Id = c.Id,
						 OrganismoOrigen = c.OrganismoOrigen,
                         OrganismoDestino=c.OrganismoDestino ,
                         Descripcion=c.Descripcion ,
                         FechaAlta=c.FechaAlta ,
                         UsuarioAlta=c.UsuarioAlta ,
                         Numero=c.Numero ,
                         Activo=c.Activo ,
						 
					};
			return (DbQuery<AdministracionPedidosViewT>)x;
		}
        /*********************************************
		* Seccion Particular
		* *******************************************/

        public int UltimoNumeroPedido()
        {
            var x = from c in db.AdministracionPedidos
                    where c.Activo
                    orderby c.Numero descending 
                    select new AdministracionPedidosView
                    {
                        Id = c.Id,
                        Numero = c.Numero,
                        /*Organismo = c.Organismos.Descripcion,
                        OrganismoOrigen = c.OrganismoOrigen,
                        OrganismoDestino = c.OrganismoDestino,
                        Descripcion = c.Descripcion,
                        FechaAlta = c.FechaAlta,
                        UsuarioAlta = c.UsuarioAlta,
                        
                        Activo = c.Activo,*/
                    };
            return x.FirstOrDefault().Numero;

        }


    }
}
