/// <reference path="../types/jquery.contextMenu.d.ts" />
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/editable.d.ts"/>
var SyncroBlock = (function () {
    function SyncroBlock(container) {
        var that = this;
        this.container = container;
    }
    SyncroBlock.prototype.Bloquear = function (container) {
        var centerY;
        var el;
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
    };

    SyncroBlock.prototype.Desbloquear = function () {
        var el;
        el = this.container;
        $(this.container).unblock({
            onUnblock: function () {
                $(el).css('position', '');
                jQuery(el).css('zoom', '');
            }
        });
    };
    return SyncroBlock;
})();
