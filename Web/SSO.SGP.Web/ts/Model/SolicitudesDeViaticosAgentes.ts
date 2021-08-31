module model {
export class SolicitudesDeViaticosAgentes {
	
    public Id:number;
	
    public SolicitudDeViatico: number;
	
    public Agente:number;
	
    public Dias: number;
	
    public ImportePorDia: number;
	
    public Subtotal: number;
	
    public ImporteGastos: number;
	
    public ImporteTotal: number;

    public AgenteDescripcion: string;

    public CargoDescripcion: string;

    public Grupo: number;

    public Anticipo: boolean;

    public Afiliado: string;

    } 

export class DetallePartidas {
    public Id: number;

    public Partida: string;

    public Total: number;

} 
export class Partidas {

    public Id: number;

    public Partida: string;

} 

export class ConceptosDeGasto {

    public Id: number;

    public Descripcion: string;

    public Partida: number;

} 


}