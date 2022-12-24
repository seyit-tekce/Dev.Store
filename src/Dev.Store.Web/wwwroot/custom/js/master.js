var l = abp.localization.getResource('Store');

(function () {
    [].slice.call(document.querySelectorAll('[data-original-title]')).map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    });
})();

$('[data-task="insert"]').on("click", function (e) {
    var _this = $(this);
    var _href = _this.attr("data-href");
    var _modal = _this.attr("data-modal");
    var _grid = _this.attr("data-grid");
    if (_href == null || _href.length == 0) {
        swal.fire("Hatayla karşılaşıldı", "Lütfen yetklilere başvurunuz", "error");
        return;
    }
    var loading = new Loading(this);
    loading.Add();
    if (_modal == true || _modal.toLowerCase() == "true") {
        var modalManager = new abp.ModalManager(_href);
        modalManager.open();
        modalManager.onResult(function (e, a) {
            var grid = $("#" + _grid).data("kendoGrid");
            if (grid != null) {
                grid.dataSource.read();
            }
        });
        modalManager.onOpen(function () {
            loading.Remove();

        });

    }
    else {
        window.location.href = _href;
    }

});

class Loading {

    constructor(target) {
        this.target = $(target);
        this.loadingText = l("Loading");
        this.oldHtml = $(target).html();
    }
    Add() {
        this.target.attr("disabled", "")
        var newHtml = '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>  ' + this.loadingText;
        this.target.html(newHtml);

    }
    Remove() {
        this.target.removeAttr("disabled");
        this.target.removeClass("spinner-border");
        this.target.html(this.oldHtml);
        delete this;
    }

}