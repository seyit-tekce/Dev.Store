$(function () {

    $("#ProductSizeFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    $('#ProductSizeFilter div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#ProductSizeFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/ProductSizeFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('Store');

    var service = dev.store.productSizes.productSize;
    var createModal = new abp.ModalManager(abp.appPath + 'ProductSizes/ProductSize/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ProductSizes/ProductSize/EditModal');

    var dataTable = $('#ProductSizeTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList,getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('Store.ProductSize.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Store.ProductSize.Delete'),
                                confirmMessage: function (data) {
                                    return l('ProductSizeDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('ProductSizeProductId'),
                data: "productId"
            },
            {
                title: l('ProductSizeProduct'),
                data: "product"
            },
            {
                title: l('ProductSizeHeight'),
                data: "height"
            },
            {
                title: l('ProductSizeWidth'),
                data: "width"
            },
            {
                title: l('ProductSizePrice'),
                data: "price"
            },
            {
                title: l('ProductSizeIsDefault'),
                data: "isDefault"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewProductSizeButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
