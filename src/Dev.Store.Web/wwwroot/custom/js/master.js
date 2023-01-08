var l = abp.localization.getResource('Store');

//(function () {
//    [].slice.call(document.querySelectorAll('[data-original-title]')).map(function (tooltipTriggerEl) {
//        return new bootstrap.Tooltip(tooltipTriggerEl)
//    });
//})();

//$('[data-task="insert"]').on("click", function (e) {
//    var _this = $(this);
//    var _href = _this.attr("data-href");
//    var _modal = _this.attr("data-modal");
//    var _grid = _this.attr("data-grid");
//    if (_href == null || _href.length == 0) {
//        swal.fire("Hatayla karşılaşıldı", "Lütfen yetklilere başvurunuz", "error");
//        return;
//    }
//    var loading = new Loading(this);
//    loading.Add();
//    if (_modal == true || _modal.toLowerCase() == "true") {
//        var modalManager = new abp.ModalManager(_href);
//        modalManager.open();
//        modalManager.onResult(function (e, a) {
//            var grid = $("#" + _grid).data("kendoGrid");
//            if (grid != null) {
//                grid.dataSource.read();
//            }
//        });
//        modalManager.onOpen(function () {
//            loading.Remove();

//        });

//    }
//    else {
//        window.location.href = _href;
//    }

//});

class Loading {

    constructor(target) {
        this.target = $(target);
        this.isbutton = $(target).prop("nodeName") == "BUTTON" ? true : false;
        this.loadingText = l("Loading");
        this.oldHtml = $(target).html();
    }
    Start() {
        if (this.isbutton) {
            this.target.attr("disabled", "")
            var newHtml = '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>  ' + this.loadingText;
            this.target.html(newHtml);
        }
        else {
            abp.notify.info("Lütfen Bekleyin", "Yükleniyor");
        }


    }
    Done() {
        this.target.removeAttr("disabled");
        $("#toast-container").remove();
        this.target.removeClass("spinner-border");
        this.target.html(this.oldHtml);
        delete this;
    }

}
var kendoGrid = {
    functions: {
        updateCommandButtons: function (e) {
            var gridSender = e.sender;
            e.sender.element.find('.k-command-cell').each(function (i, elem) {
                $(elem).parents("tr").on("dblclick", function () {
                    var dblClickItem = $(this).find('[data-dblclick="true"]');
                    var detailItem = $(this).find(".k-grid-Detay");
                    var updateItem = $(this).find(".k-grid-Düzenle");

                    if (dblClickItem.length > 0) {
                        dblClickItem.trigger("click");
                    } else if (detailItem.length > 0) {
                        detailItem.trigger("click");
                    } else if (updateItem.length > 0) {
                        updateItem.trigger("click");
                    }
                });

                var commandCell = $(this);
                var data = gridSender.dataSource.getByUid(commandCell.parent("tr").data("uid"));
                if (commandCell.find(".abp-action-button").length == 0) {
                    var newButton = $(`<div class="dropdown abp-action-button">
                    <ul class="dropdown-menu"></ul>
                    <button class="btn btn-primary btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa fa-cog mr-1"></i>İşlemler</button>
                    </div>`);

                    commandCell.find(".k-button").each(function (e, i) {
                        var clone = $(this).clone(true, true, true);
                        clone.data("row", JSON.stringify(data));
                        clone.attr("data-id", data["id"] ?? data["Id"]);
                        clone.removeClass("k-primary");
                        clone.attr("style", "width:95%;background-color:#fff;text-align:left;font-family: Poppins, sans-serif;font-size:11px;font-weight: 600;border-width:0;box-shadow:none;display: flow-root;");
                        $('<li/>')
                            .append(clone)
                            .appendTo(newButton.find("ul"));
                    });
                    commandCell.empty();
                    commandCell.append(newButton);
                }
            });
            if (!(/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent))) {
                if (e.sender.element.find('.k-command-cell').length > 0) {
                    var grid = $(e.sender.content).parents("[data-role='grid']").data("kendoGrid");
                    var td = e.sender.element.find('.k-command-cell')[0]
                    grid.hideColumn($(td).index());
                    $("[role='grid']").css("width", "");
                }
                var gridSender = e.sender;
                e.sender.element.find('.k-command-cell').each(function (i, elem) {

                    $(elem).parents("tr").on("contextmenu", function (e) {
                        $(".k-state-selected").removeClass("k-state-selected");
                        var row = e.currentTarget;
                        var data = gridSender.dataSource.getByUid($(row).data("uid"));
                        $(row).addClass("k-state-selected");

                        $("#actionsContextMenu").remove();
                        var contextMenu = $(`<div id="actionsContextMenu" class="dropdown" style="background-color:#fff;position:absolute; display:none;border-radius:5px;z-index:999;">
                                        <ul class="list-group border border-primary p-0" style="border-radius:inherit;"></ul>
                                        </div>`);
                        $(contextMenu).appendTo($(row).parents(".k-grid"));


                        var buttons = $(e.currentTarget).find(".k-button");
                        buttons.each(function (e, i) {
                            var clone = $(i).clone(true, true, true);
                            clone.data("row", JSON.stringify(data));
                            clone.attr("data-id", data["id"]);
                            clone.removeClass("k-primary");
                            clone.attr("style", "background-color:transparent;text-align:left;font-family: Poppins, sans-serif;font-size:11px;font-weight: 600;border-width:0;box-shadow:none;display:block;");

                            $('<li/>')
                                .hover(
                                    function () {
                                        $(this).attr("style", "background-color:#F5F5F5; cursor:pointer;");
                                    }, function () {
                                        $(this).removeAttr("style");
                                    }
                                )
                                .addClass("list-group-item p-0")
                                .append(clone)
                                .appendTo($(contextMenu).find("ul"));
                        });

                        var gridEelement = $(row).parents(".k-grid");
                        var gridEelementOffSet = gridEelement.offset();

                        var menuLeft = e.pageX - gridEelementOffSet.left;
                        var menuTop = e.pageY - gridEelementOffSet.top;

                        var contexMenuHeight = contextMenu.height();
                        var gridPageableArea = $(gridEelement).find(".k-pager-wrap");
                        menuTop = (menuTop + contexMenuHeight + 20 > gridEelement.height() - gridPageableArea.height()) ? (menuTop - contexMenuHeight) : menuTop;

                        $(contextMenu).css({
                            display: "block",
                            left: menuLeft,
                            top: menuTop
                        });

                        $('html').click(function () {
                            $(row).removeClass("k-state-selected");
                            $(contextMenu).hide();
                        });

                        return false;
                    });
                });
            }

        }
    },
    events: {
        databound: function (e) {

            //debugger;
            //var obj = e.sender.element.find('.k-header .k-link');

            //for (var i = 0; i < obj.length; i++) {
            //    debugger;
            //    obj[i].innerHTML = "p" + obj[i].innerHTML.split(".").join("_");
            //}

            var grid = $(e.sender.element).data("kendoGrid");
            if (grid != undefined && grid.options.toolbar.filter(a => a.name == "Search").length == 1) {
                var searchInput = $(e.sender.element).find(".k-grid-search input");
                if (searchInput.length > 0) {
                    $(e.sender.element).find(".k-grid-search").remove();

                    var newSerach = $('<input placeholder="' + l("Search") + '" style=" position: absolute;' +
                        'right: 0;' +
                        'width: 50%;' +
                        'padding: 0;' +
                        'padding-left: 10px;' +
                        'height: 31px;"' +
                        'class="form-control">');

                    $(newSerach).keyup(function (event) {
                        var defaultFilter = grid.options.dataSource.filter;
                        var searchFields = grid.options.search;
                        if (!searchFields) return;
                        var searchValue = event.target.value;
                        var newFilter = {};

                        if (searchValue.trim() == "") {
                            grid.dataSource.filter(defaultFilter);
                        } else {
                            var newFilter = { logic: "or", filters: searchFields.fields.map(a => ({ field: a, operator: "contains", value: searchValue })) }

                            var filters = [newFilter].concat(defaultFilter);
                            grid.dataSource.filter({
                                logic: "and",
                                filters: filters
                            });
                        }
                    });

                    $(e.sender.element).find(".k-grid-toolbar").append(newSerach);

                }
            }


            var _parameterMap = e.sender.dataSource.transport.parameterMap;
            e.sender.dataSource.transport.parameterMap = function (data, type) {
                if (type == "update" || type == "create") {
                    return JSON.stringify(data);
                } else {
                    return _parameterMap(data, type);
                }
            }
            kendoGrid.functions.updateCommandButtons(e);
        },
        beforeEdit: function (e) {
            kendoGrid.functions.updateCommandButtons(e);
        },
        edit: function (e) {
            kendoGrid.functions.updateCommandButtons(e);
        },
        cancel: function (e) {
            window.setTimeout(function (c) {
                kendoGrid.functions.updateCommandButtons(e);
            }, 10);
        },
    },
}


String.prototype.toLower = function () {
    var text = this.trim();
    var maps = {
        "İ": "I", "Ş": "S", "Ç": "C", "Ğ": "G", "Ü": "U", "Ö": "O",
        "ı": "i", "ş": "s", "ç": "c", "ğ": "g", "ü": "u", "ö": "o",
        " ": "-", "  ": "-", "+": "-"
    };
    Object.keys(maps).forEach(function (old) {
        text = text.replaceAll(old, maps[old]);
    });
    text = text.replaceAll(" ", "-");
    return text.toLowerCase();
}