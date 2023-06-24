$(function () {

    $("#OrderFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    $('#OrderFilter div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#OrderFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/OrderFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('Store');

    var service = dev.store.orders.order;
    var createModal = new abp.ModalManager(abp.appPath + 'Orders/Order/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Orders/Order/EditModal');

    var dataTable = $('#OrderTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Store.Order.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Store.Order.Delete'),
                                confirmMessage: function (data) {
                                    return l('OrderDeletionConfirmationMessage', data.record.id);
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
                title: l('OrderCode'),
                data: "code"
            },
            {
                title: l('OrderUserId'),
                data: "userId"
            },
            {
                title: l('OrderOrderAddressId'),
                data: "orderAddressId"
            },
            {
                title: l('OrderMethod'),
                data: "method"
            },
            {
                title: l('OrderProducts'),
                data: "products"
            },
            {
                title: l('OrderOrderAddress'),
                data: "orderAddress"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewOrderButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
