interface IControlador {

    form: JQuery;
    datatables: DataTables.DataTable[];
    fnRegistrarDataTable(d: DataTables.DataTable): void;
    fnRefrescarDataTables(): void;
    //fnInitHandler(): void;
    //fnRefrescarDataTables(index: number): void;


} 