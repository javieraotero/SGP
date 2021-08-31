
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
module PedidosDeSuministros.ts {
	
	export class Editar implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
		public datatables: DataTables.DataTable[];
		
		 
		public Id:JQuery; 
		public Organismo:JQuery; 
		public FechaDePedido:JQuery; 
		public Usuario:JQuery; 
		public FechaDeCarga:JQuery; 
		public Entregado:JQuery; 
		public FechaDeBaja:JQuery; 
		public UsuarioBaja:JQuery;
		public Cancelar: JQuery;
		public Guardar: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];
			
		 
			this.Id = $("#Id"+hash); 
			this.Organismo = $("#Organismo"+hash); 
			this.FechaDePedido = $("#FechaDePedido"+hash); 
			this.Usuario = $("#Usuario"+hash); 
			this.FechaDeCarga = $("#FechaDeCarga"+hash); 
			this.Entregado = $("#Entregado"+hash); 
			this.FechaDeBaja = $("#FechaDeBaja"+hash); 
			this.UsuarioBaja = $("#UsuarioBaja"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
			
			//Establece el foco
			this.Id.focus();
		}
		
		public limpiar():void {
			
			this.Id.val("");
			this.Organismo.val('').trigger("liszt:updated");
			this.FechaDePedido.val("");
			this.Usuario.val('').trigger("liszt:updated");
			this.FechaDeCarga.val("");
			this.Entregado.removeAttr('checked');
			this.FechaDeBaja.val("");
			this.UsuarioBaja.val("");
		}
		
		//--- Funciones para seteo de Datatables ---/
		
		public getData(col: number): any {
            return(this.Agentes.fnGetData(this.index)[col]); 
        }
		//--- /Funciones para seteo de Datatables ---/
		
		public fnRegistrarDataTable(d: DataTables.DataTable): void {
			this.datatables.push(d);
		}

		public fnRefrescarDataTables():void {
			var that = this;
			this.datatables.forEach(function (d) {
				d.fnDraw();
			});    
		}
	} //JS
} // module
