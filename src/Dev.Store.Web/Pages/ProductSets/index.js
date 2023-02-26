$(function () {

    $("#ProductSetFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    $('#ProductSetFilter div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#ProductSetFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/ProductSetFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('Store');

    var service = dev.store.productSets.productSet;
    var createModal = new abp.ModalManager(abp.appPath + 'ProductSets/ProductSet/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ProductSets/ProductSet/EditModal');

    var dataTable = $('#ProductSetTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Store.ProductSet.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Store.ProductSet.Delete'),
                                confirmMessage: function (data) {
                                    return l('ProductSetDeletionConfirmationMessage', data.record.id);
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
                title: l('ProductSetProductId'),
                data: "productId"
            },
            {
                title: l('ProductSetProduct'),
                data: "product"
            },
            {
                title: l('ProductSetPrice'),
                data: "price"
            },
            {
                title: l('ProductSetAmount'),
                data: "amount"
            },
            {
                title: l('ProductSetIsOptional'),
                data: "isOptional"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewProductSetButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
