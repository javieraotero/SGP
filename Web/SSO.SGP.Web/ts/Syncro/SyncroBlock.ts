/// <reference path="../types/jquery.contextMenu.d.ts" />
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/editable.d.ts"/>
class SyncroBlock {

    public container: JQuery;
    public cargar: boolean;
    public url: string;
    public urlupdate: string;
    public nuevo: boolean;
    public editable: boolean;
    public id: number;
    public seleccionable: boolean;
    public Id: string;
    public aSource: Array<any>;

    constructor(container: JQuery) {
        var that = this;
        this.container = container;
    }
    
    public Bloquear(container?:JQuery) {

        var centerY;
        var el: JQuery;
        el = (container != null) ? container : this.container;

        if (el.height() <= 400) {
            centerY = true;
        }

        el.block({
            message: '<img src="./assets/img/ajax-loading.gif" align="">',
            centerY: true,
            css: {
                top: '10%',
                border: 'none',
                padding: '2px',
                backgroundColor: 'none'
            },
            overlayCSS: {
                backgroundColor: '#000',
                opacity: 0.05,
                cursor: 'wait'
            }
        });
    }

    public Desbloquear() {
        var el: JQuery;
        el = this.container;
        $(this.container).unblock({
            onUnblock: function () {
                $(el).css('position', '');
                jQuery(el).css('zoom', '');
            }
        });
    }

}
