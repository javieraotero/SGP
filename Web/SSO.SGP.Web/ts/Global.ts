/// <reference path="Model/SolicitudesDeViaticosAgentes.ts" />
module Global {
    export class variables {

        constructor() {
            this.partidas = [];
            this.conceptos = [];
            this.id_servicios_generales = 785;
        }

        public Organismo: number;
        public nombreUsuario: string;
        public organismo_descripcion: string;
        public partidas: Array<model.Partidas>;
        public conceptos: Array<model.ConceptosDeGasto>;
        public id_servicios_generales: number;
        public appexterna: boolean;
        public email_agente: string;

    }
}

var global = new Global.variables();