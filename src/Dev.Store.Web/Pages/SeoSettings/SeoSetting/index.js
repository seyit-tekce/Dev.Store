$(function () {

    $("#SeoSettingFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    $('#SeoSettingFilter div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#SeoSettingFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/SeoSettingFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('Store');

    var service = dev.store.seoSettings.seoSetting;
    var createModal = new abp.ModalManager(abp.appPath + 'SeoSettings/SeoSetting/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'SeoSettings/SeoSetting/EditModal');

    var dataTable = $('#SeoSettingTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Store.SeoSetting.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Store.SeoSetting.Delete'),
                                confirmMessage: function (data) {
                                    return l('SeoSettingDeletionConfirmationMessage', data.record.id);
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
                title: l('SeoSettingTitle'),
                data: "title"
            },
            {
                title: l('SeoSettingDescription'),
                data: "description"
            },
            {
                title: l('SeoSettingKeywords'),
                data: "keywords"
            },
            {
                title: l('SeoSettingProductId'),
                data: "productId"
            },
            {
                title: l('SeoSettingProduct'),
                data: "product"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewSeoSettingButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
