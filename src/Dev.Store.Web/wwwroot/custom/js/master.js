var l = abp.localization.getResource("Dev.Store");
if (abp.localization.currentCulture.cultureName == "tr") {
    kendo.culture("tr-TR");
} else {
    kendo.culture("en-EN");
}
kendo.culture("tr-TR");
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
            //mobil değil ise
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
            var grid = $(e.sender.element).data("kendoGrid");
            var heigth = window.innerHeight - 240;
            if (grid != undefined) {
                $(e.sender.element).height(heigth);
                grid.resize();
            }
            if (grid != undefined && grid.options.toolbar != undefined && grid.options.toolbar?.filter(a => a.name == "Search").length == 1) {
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
                            grid.dataSource.filter(defaultFilter == undefined ? {} : defaultFilter);
                        } else {
                            var newFilter = { logic: "or", filters: searchFields.fields.map(a => ({ field: a, operator: "contains", value: searchValue })) }
                            var filters = defaultFilter != undefined ? [newFilter].concat(defaultFilter) : [newFilter];
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
$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
    if ($(e.target.attributes["href"].value).find(".tab-content").length > 0) {
        $(e.target.attributes["href"].value).find(".tab-content").find(".show.active").find(".k-grid").each(function (e) {
            var handler = $(this).data("kendoGrid");
            if (handler) {
                if (handler.element.find(".k-pager-refresh").attr("data-refresh") != "true" && handler.options.autoBind == false) {
                    handler.element.find(".k-pager-refresh").attr("data-refresh", "true");
                    handler.element.find(".k-pager-refresh").trigger("click");
                }
                handler.resize();
            }
        });
    } else {
        $(e.target.attributes["href"].value).find(".k-grid").each(function (e) {
            var handler = $(this).data("kendoGrid");
            if (handler) {
                if (handler.element.find(".k-pager-refresh").attr("data-refresh") != "true" && handler.options.autoBind == false) {
                    handler.element.find(".k-pager-refresh").attr("data-refresh", "true");
                    handler.element.find(".k-pager-refresh").trigger("click");
                }
                handler.resize();
            }
        });
    }
    $(e.target.attributes["href"].value).find('[data-role="Harita"]').each(function (e) {
        var harita = $(this).data("InfolineHarita");
        if (harita) {
            harita.map.updateSize();
        }
    });
    $(e.target.attributes["href"].value).find('[data-role="chart"]').each(function (e) {
        var chart = $(this).data("kendoChart");
        if (chart) {
            chart.resize();
        }
    });
});
$(document).livequery('[data-text="long"]', function (e) {
    var $elem = $(this);
    var toolTipPlacement = $elem.data("placement") ?? "top";
    var textLength = $elem.data("textsize") ?? 15;
    var intTextLength = parseInt(textLength);
    textLength = intTextLength != NaN ? intTextLength : 15;
    var text = $elem.text().trim();
    var shortText = text;
    if (shortText.length > textLength) {
        shortText = shortText.slice(0, textLength);
        $elem.text(shortText + "...");
    }
    $elem.attr("data-toggle", "tooltip");
    $elem.attr("data-placement", toolTipPlacement);
    $elem.attr("title", text);
    $elem.tooltip();
});
$(document).on("keyup", '[data-toggle="slugify"]', function (e) {
    debugger
    var target = $(this).data("target");
    var thisVal = $(this);
    var slugit = function (c) {
        if (target.split(',').length > 1) {
            target.split(',').forEach(function (item, index) {
                $(item).val(getSlug($(thisVal).val(), {
                    lang: 'en',
                    separator: "_"
                }));
            });
        }
        else {
            $(target).slugify(thisVal, {
                separator: '-'
            });
        }
    };
    slugit();
});
$('[data-cascade]').livequery('*',function (e) {
    var $this = $(this);
    var cascadeElem = $($this.attr('data-cascade'));
    var values = ($this.attr('data-show') || "").split(",");
    if (cascadeElem.length == 0) {
        return;
    }
    $this.find('input[required], textarea[required], select[required]').attr('data-required', 'required');
    $this.find('input[disabled], textarea[disabled], select[disabled]').attr('data-disabled', 'disabled');
    function toggle(elem) {
        var value = ($(elem).attr("type") == "checkbox" ? ($(elem).is(":checked") ? 1 : 0) : $(elem).val()).toString();
        if (values.indexOf(value) > -1) {
            $this.show();
            $this.find('input[data-required], textarea[data-required], select[data-required]').attr('required', 'required');
            $this.find('input:not([data-disabled]), textarea:not([data-disabled]), select:not([data-disabled])').removeAttr('disabled');
        }
        else {
            $this.hide();
            $this.find('input[data-required], textarea[data-required]').removeAttr('required');
            $this.find('input:not([data-disabled]), textarea:not([data-disabled]), select:not([data-disabled])').attr('disabled', 'disabled');
        }
    }
    cascadeElem
        .on('change', function (e) {
            toggle($(this));
        });
    toggle(cascadeElem);
})
$(document).livequery('[data-toggle="slugifyUpper"]', function (e) {
    function getSlug(text) {
        var separator = /[^a-z0-9]+/ig;
        var drop = /^-|-$/g;
        return text
            .replace(separator, '_')
            .replace(drop, '')
            .replace(/\s/g, '')
            .replace(/^[0-9]/, '')
    }
    var target = $(this).data("target");
    var thisVal = $(this);
    var slugit = function (c) {
        if (target.split(',').length > 1) {
            target.split(',').forEach(function (item, index) {
                $(item).val(getSlug($(thisVal).val(), {
                    lang: 'en',
                }));
            });
        }
        else {
            $(target).val(getSlug($(this).val(), {
                lang: 'en',
            }));
        }
    };
    $(this).on("keyup", slugit);
    $(this).on("focus", slugit);
    $(this).on("blur", slugit);
});
$('.lp-footer').remove();
Date.prototype.addDays = function (days) {
    this.setDate(this.getDate() + days);
    return this;
}
Date.prototype.addHours = function (hours) {
    this.setHours(this.getHours() + hours);
    return this;
}
Date.prototype.addYears = function (years) {
    this.setFullYear(this.getFullYear() + years);
    return this;
}
Number.prototype.ToFixed = function (fixNumber) {
    return parseFloat((this).toFixed(fixNumber)).toLocaleString();
}
Date.prototype.addMinutes = function (minutes) {
    this.setMinutes(this.getMinutes() + minutes);
    return this;
}
Date.prototype.GetMonday = function () {
    var d = this;
    var day = d.getDay();
    var diff = d.getDate() - day + (day == 0 ? -6 : 1);
    var nd = new Date(d.getFullYear(), d.getMonth(), diff);
    return nd;
}
Date.prototype.addSeconds = function (seconds) {
    this.setSeconds(this.getSeconds() + seconds);
    return this;
}
Date.prototype.getHourly = function () {
    this.setSeconds(0);
    this.setMinutes(0);
    this.getMilliseconds(0);
    return this;
}
Date.prototype.getDaily = function () {
    this.setHours(0);
    this.setSeconds(0);
    this.setMinutes(0);
    this.getMilliseconds(0);
    return this;
}
Date.prototype.getYearly = function () {
    return new Date(this.getFullYear(), 0, 1, 0, 0, 0, 0);
}
Date.prototype.getMontly = function () {
    this.addDays(-1 * (this.getDate() - 1));
    this.setHours(0);
    this.setSeconds(0);
    this.setMinutes(0);
    this.getMilliseconds(0);
    return this;
}
Array.prototype.groupBy = function (field) {
    let groupedArr = [];
    this.forEach(function (e) {
        let group = groupedArr.find(g => g['field'] === e[field]);
        if (group == undefined) {
            group = { field: e[field], groupList: [] };
            groupedArr.push(group);
        }
        group.groupList.push(e);
    });
    return groupedArr;
}
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
            kendo.ui.progress(this.target, true)
        }
    }
    Done() {
        this.target.removeAttr("disabled");
        $("#toast-container").remove();
        this.target.removeClass("spinner-border");
        this.target.html(this.oldHtml);
        kendo.ui.progress(this.target, false)
        delete this;
    }
}