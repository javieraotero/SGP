public enum eTiposArchivosAdjuntos : int
{
    Carpetas_Medicas = 6,
    Otros_Certificados = 3
}

public enum eTiposDeConcursos : int
{
    Ingreso,
    Ascenso
}

public enum eRoles : int
{
    Administrador = 1,
    Empleado = 2
}

public enum eOperacionesContables : int
{

    Asignacion = 1,
    Afectacion = 2,
    Compromiso = 3,
    OrdenadoAPagar = 4,
    SobreAfectacion = 5,
    Desafectacion = 6

}

public enum eEstadosProveedores : int
{
    Pendiente = 0,
    Confirmado = 1,
    Revisar = 2,
    Rechazado = 3
}

public enum eTipoRubro : int
{
    Bienes = 0,
    Servicios = 1
}


public enum eEstadosTurnos : int
{

    Pendiente = 0,
    Confirmado = 1,
    Cancelado = 2,
    Finalizado = 3,
    Eliminado = 4

}

public enum eTipoSocioProveedores : int
{

    Socio = 0,
    Sucesor = 1

}

public enum eTiposProveedores : int
{

    Fisica = 0,
    Juridica = 1,
    Cooperativa = 2

}

public enum eVacunasCovid : int
{

    Sinopharm = 0,
    SputnikV = 1,
    Astrazeneca = 2

}



public enum e : int
{

    Socio = 0,
    Sucesor = 1

}

public enum eDocumentosProveedores : int
{

    PH_DNI_Frente = 1,
    PH_DNI_Dorso = 2,
    PH_Poder_Vigente_Apoderado_Y_DNI_Apoderado = 3,
    Constancia_de_inscripcion_proveedores_de_la_pampa = 4,
    PJ_Sociedades_Contrato_social_o_estatuto_inscripto_en_la_Dirección_General_de_Superintendencia_de_Personas_Jurídicas_y_Registro_Público_de_Comercio_o_Registro_Público_pertinente = 5,
    PJ_Sociedades_Ampliaciones_estatutarias_y_o_actualizaciones_inscriptos_en_la_Dirección_General_de_Superintendencia_de_Personas_Jurídicas_y_Registro_Público_de_Comercio_o_Registro_Público_correspondiente = 6,
    PJ_Sociedades_Ultima_acta_de_designación_de_autoridades_y_distribución_de_cargos_y_o_designación_de_gerente_de_SRL_inscripta_en_la_Dirección_General_de_Superintendencia_de_Personas_Jurídicas_y_Registro_Público_de_Comercio_o_Registro_Público_correspondiente = 7,
    PJ_Sociedades_Documento_donde_conste_el_último_domicilio_real_inscripto_en_la_Dirección_General_de_Superintendencia_de_Personas_Jurídicas_y_Registro_Público_de_Comercio_o_Registro_Público_correspondiente = 8,
    PJ_Sociedades_En_caso_de_acreditar_apoderados_poder_suficiente_vigente_y_Documento_Nacional_de_Identidad_Frente_y_Dorso = 9,
    Certificado_de_inscripción_vigente_extendido_por_la_Dirección_General_de_Superintendencia_de_Personas_Jurídicas_y_Registro_Público_de_Comercio_u_organismo_oficial_correspondiente_según_la_jurisdicción_a_la_que_pertenezca = 10,
    PJ_Coop_Acta_de_asamblea_constitutiva_estatutos_u_otros_y_sus_actualizaciones = 11,
    PJ_Coop_Documento_Nacional_de_Identidad_Frente_y_Dorso = 12,
    PJ_Coop_En_caso_de_acreditar_apoderados_poder_suficiente_vigente_y_Documento_Nacional_de_Identidad = 13,
    PJ_Constancia_Sucesiones_Indivisas = 14

}

public enum eTiposDeReestructura : int
{

    Habilitacion = 1,
    Refuerzo = 2,
    Compensasion = 3,
    Incorporacion = 4

}

public enum eEstadosDeViaticos : int
{

    Borrador = 1,
    Solicitado = 2,
    Rechazado = 3,
    Solicitud_Aprobada = 4,
    Anticipo_Depositado = 7,
    Borrador_Rendicion = 8,
    Rendicion_Presentada = 9,
    Rendicion_Rechazada = 10,
    Rendicion_Aprobada = 11,
    Asignar_Chofer = 12,
    Cancelado_Por_Solicitante = 13

}

public enum eMediosDeTransporte : int
{
    Auto_Poder_Judicial = 1,
    Auto_Propio = 2,
    Colectivo = 3,
    Avion = 4,
    Auto_Poder_Judicial_Asignado_Organismo = 5
}

public enum eServiciosGenerales : int
{
    Servicios_Generales_SR = 830,
    Servicios_Generales_Pico = 952,
    Servicios_Generales_Acha = 993,
    Servicios_Generales_Victorica = 1008
}

public enum eOrganismos : int
{
    DGA = 308,
    Procuracion = 75
}
