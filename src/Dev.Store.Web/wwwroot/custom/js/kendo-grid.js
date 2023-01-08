//$(document).ready(function () {
//    $("button:contains(Export to PDF)").html('<span class="k-icon k-i-pdf"></span>').removeClass("hide");
//    $("button:contains(Export to Excel)").html('<span class="k-icon k-i-excel"></span>').removeClass("hide");

//    _kendoGrid.binder.onChange();
//    _kendoGrid.binder.onLoad();
//}).on("click", '.k-grid .k-grid-toolbar .k-button:not(.k-grid-pdf,[data-task="pdf"] .k-grid-excel,[data-task="excel"]),[data-task="Insert"]', function (e) {

//    //  data-href = URL

//    //  data-show = select, single, always
//    //      select > seçilince ( tek veya çoklu seçim )     //  default
//    //      single > yalnızca tekil seçimlerde görünsün
//    //      always > her türlü görünsün

//    //  data-modal = true, false
//    //      true  > modalda açılır                          //  default
//    //      false > yönlendirme şeklinde sayfaya gider

//    //  data-ask = İşlem gerçekleşmeden önce sweetalert ile evet/hayır şeklinde onay sorusu gerçekleştirir

//    //  data-modalType = info, warning, success, default
//    //      modal açılma şekilleri                          //  default = info

//    //  data-blank = Açılacak ekran yeni sekmede mi açılsın ayarı
//    //      eğer bu method varsa ve method yeni sekmede açılsın modal degil ise yeni sekmede acılır

//    //  data-type =button ise modal acılmaz



//    e.preventDefault();

//    var _this = $(this);
//    if (_this.attr("disabled") == "disabled") { return false; }
//    if (_this.attr("data-type") !== undefined && _this.attr("data-type") == "button") { return; }
//    if (_this.attr('data-href') === undefined) { return false; }

//    var _blank = _this.attr("data-blank") != undefined;
//    var _data = {};
//    var _grid = _this.parents('.k-grid').eq(0).data('kendoGrid');
//    var _multiple = _grid && _grid.options.selectable.mode.indexOf("Muliptle") > -1;
//    var _postArray = _multiple == false ? false : (_this.attr('data-show') == 'single' ? false : true);
//    var _modal = _this.attr("data-modal") != 'false';
//    var idColumnKey = _this.attr("data-idColumnKey") || "id";

//    if (_this.attr("data-show") != 'always') {
//        var postData = _grid ? $.Enumerable.From(_grid.select().map(function (i, elem) {
//            var selectColumn = _this.attr("data-idColumn") || _grid.wrapper.attr('data-selection') || "id";
//            return _grid.dataItem(elem)[selectColumn];
//        }).toArray()).GroupBy(a => a).Select(a => a.Key()).ToArray() : (_this.attr('data-id') ? [_this.attr('data-id')] : '');

//        if (postData && postData != "") {
//            _data[idColumnKey] = _postArray == false ? postData[0] : postData;
//        }
//    }
//    var _ask = _this.attr('data-ask');

//    var isApi = _this.attr('data-api') != undefined;

//    if (_ask != null ) {
//        Swal.fire({
//            title: _ask,
//            icon: "question",
//            showCancelButton: true,
//            confirmButtonText: l('Yes'),
//            denyButtonText: l('No')
//        }).then((result) => {
//            /* Read more about isConfirmed, isDenied below */
//            if (result.isConfirmed) {
//                if (isApi) {
//                    var href = _this.attr('data-href').split(".");
//                    var jApi = dev.store;
//                    $.each(href, function (i, item) {
//                        jApi = jApi[item];
//                    });
//                    jApi(_data[idColumnKey]).then(function () {
//                        abp.notify.info(l('SuccessfullyDeleted'));
//                        if (_grid != null) {
//                            _grid.dataSource.read();
//                        }
//                    });
//                }

//                else if (_modal) {
//                    var modalManager = new abp.ModalManager(_this.attr('data-href'));
//                    modalManager.open(_data);
//                    modalManager.onResult(function (e, a) {
//                        if (_grid != null) {
//                            _grid.dataSource.read();
//                        }
//                    });
//                    modalManager.onOpen(function () {
//                        loading.Remove();

//                    });
//                } else {
//                    var __data = '';
//                    $.each(_data, function (i, item) { if (item != '' && item != null) { __data += '&' + i + '=' + item; } });
//                    var tUrl = window.encodeURI(_this.attr('data-href') + (__data.length > 0 ? (_this.attr('data-href').indexOf('?') > -1 ? '&' : '?') + __data.substring(1) : ''));
//                    if (_blank) {
//                        window.open(tUrl, '_blank');
//                    } else {
//                        window.location.href = tUrl;
//                    }
//                }
//            }
//        })


//    }
//    else {
//        var loading = new Loading(this);
//        loading.Add();
//        if (_modal) {
//            var modalManager = new abp.ModalManager(_this.attr('data-href'));
//            modalManager.open(_data);
//            modalManager.onResult(function (e, a) {
//                if (_grid != null) {
//                    _grid.dataSource.read();
//                }
//            });
//            modalManager.onOpen(function () {
//                loading.Remove();

//            });
//        } else {
//            var __data = '';
//            $.each(_data, function (i, item) { if (item != '' && item != null) { __data += '&' + i + '=' + item; } });
//            var tUrl = window.encodeURI(_this.attr('data-href') + (__data.length > 0 ? (_this.attr('data-href').indexOf('?') > -1 ? '&' : '?') + __data.substring(1) : ''));
//            if (_blank) {
//                window.open(tUrl, '_blank');
//            } else {
//                window.location.href = tUrl;
//            }
//        }

//    }

//    return false;
//});

//function removeDuplicateElementsFromArrayByProp(myArr, prop) {
//    return myArr.filter((obj, pos, arr) => {
//        return arr.map(mapObj => mapObj[prop]).indexOf(obj[prop]) === pos;
//    });
//}
//var _kendoGrid = {
//    events: {
//        onChange: function (e) {
//            debugger
//            var _this = this;
//            var _name = _this.wrapper.attr('id');
//            var _buttons = _this.wrapper.find('.k-grid-toolbar .k-button:not(.k-grid-pdf,[data-task="pdf"], .k-grid-excel,[data-task="excel"])');
//            var _selectedObjects = _this.select().map(function (i, elem) { return _this.dataItem(elem) }).toArray();
//            _buttons.addClass('hide');
//            _selectedObjects = removeDuplicateElementsFromArrayByProp(_selectedObjects, "id");
//            if (_selectedObjects.length == 0) {
//                _buttons.map(function (i, item) { if ($(item).attr('data-show') == 'always') { return item; } }).removeClass('hide');
//            } else if (_selectedObjects.length == 1) {
//                _buttons.removeClass('hide');
//            } else {
//                _buttons.map(function (i, item) { if ($(item).attr('data-show') == 'always' || $(item).attr('data-show') == 'default') { return item; } }).removeClass('hide');
//            }
//            $("#" + _name).trigger("selected:grid", _selectedObjects);
//            if (location.href.indexOf('localhost') > -1) { console.log(_selectedObjects); console.log('selected:grid'); }
//        },
//        onLoad: function (e) {

//            var _this = this;
//            var _name = _this.wrapper.attr('id');
//            var _datasource = _this.dataSource.data();
//            var _buttons = _this.wrapper.find('.k-grid-toolbar .k-button:not(.k-grid-pdf,[data-task="pdf"], .k-grid-excel,[data-task="excel"])');
//            _this.wrapper.attr('data-selection', typeof (_this.wrapper.attr('data-selection')) != 'undefined' ? _this.wrapper.attr('data-selection') : 'Id');

//            $.each(_buttons, function (i, item) {

//                $(item).addClass('hide');
//                if ($(item).attr('data-show') == 'always') { $(item).removeClass('hide'); }
//                $(item).attr('data-href', (typeof ($(item).attr('href')) == 'undefined' ? $(item).attr('data-href') : $(item).attr('href')));
//                $(item).attr('data-show', (typeof ($(item).attr('data-show')) != 'undefined' ? $(item).attr('data-show') : 'default'));
//                $(item).attr('data-method', (typeof ($(item).attr('data-method')) != 'undefined' ? $(item).attr('data-method') : 'POST'));

//                $(item).removeAttr('href');

//            });
//            _this.wrapper.removeAttr("tabIndex");
//            _this.wrapper.off("dblclick");
//            _this.wrapper.on('dblclick', 'tbody [role="row"]', function (evnt) {

//                if ($(evnt.target).parents('tr[role="row"][data-uid]').eq(0).length == 1) {
//                    var defaultButton = _buttons.map(function (i, item) { if (typeof ($(item).attr('data-default')) != 'undefined') return item; }).eq(0);
//                    if (defaultButton.length == 1) {
//                        defaultButton.trigger('click');
//                    }
//                }

//            })
//            _this.wrapper.off("change");
//            _this.wrapper.on("change", '[data-event="GridSelector"]', function (event) {
//                var gridSelectedRows = _this.select();
//                var gridSelectedRow = $(this).parents("tr");
//                var gridSelectedNotElem = gridSelectedRows.filter(function (i, elem) {
//                    return $(elem).attr("data-uid") != gridSelectedRow.attr("data-uid");
//                });

//                if (this.checked) {
//                    _this.select([$(this).parents("tr")]);
//                } else {
//                    _this.clearSelection();
//                    _this.select(gridSelectedNotElem);
//                }
//            });

//            $("#" + _name).trigger("load:grid", _datasource);
//            if (location.href.indexOf('localhost') > -1) { console.log(_datasource); console.log('load:grid'); }
//        }
//    },
//    finder: {
//        grid: function () {
//            var _grids = $(".k-grid");
//            var gridArray = [];
//            $.each(_grids, function (i, item) {
//                var grid = $(item).data("kendoGrid");
//                if (grid == null || grid.length == 0) {
//                    return;
//                }
//                gridArray.push(grid);
//            });
//            return gridArray;
//        }
//    },
//    binder: {
//        onChange: function () {
//            var grids = _kendoGrid.finder.grid();
//            $.each(grids, function (i, item) {
//                if (item == null) {
//                    return;
//                }
//                item.bind("change", _kendoGrid.events.onChange)
//            });
//        },
//        onLoad: function () {

//            var grids = _kendoGrid.finder.grid();
//            $.each(grids, function (i, item) {
//                if (item == null) {
//                    return;
//                }
//                item.bind("dataBound", _kendoGrid.events.onLoad)
//            });

//        },
//        tooltip: function () {
//            setTimeout(() => {

//                var tooltips = $('[data-original-title]');
//                $.each(tooltips, function (i, item) {
//                    var title = $(item).attr("data-original-title");
//                    if (title == null) {
//                        return;
//                    }
//                    $(item).attr("title", title);
//                    var placement = $(item).attr("data-placement");
//                    if (placement == null || placement.length == 0) {

//                        $(item).attr("data-placement", "top");
//                    }
//                    new bootstrap.Tooltip(item);
//                });


//            });


//        }
//    }
//};