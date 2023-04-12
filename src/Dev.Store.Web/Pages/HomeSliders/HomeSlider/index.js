$(function () {

    $("#HomeSliderFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    $('#HomeSliderFilter div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#HomeSliderFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/HomeSliderFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('Store');

    var service = dev.store.homeSliders.homeSlider;
    var createModal = new abp.ModalManager(abp.appPath + 'HomeSliders/HomeSlider/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'HomeSliders/HomeSlider/EditModal');

    var dataTable = $('#HomeSliderTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Store.HomeSlider.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Store.HomeSlider.Delete'),
                                confirmMessage: function (data) {
                                    return l('HomeSliderDeletionConfirmationMessage', data.record.id);
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
                title: l('HomeSliderUploadFileId'),
                data: "uploadFileId"
            },
            {
                title: l('HomeSliderTitle'),
                data: "title"
            },
            {
                title: l('HomeSliderSubtitle'),
                data: "subtitle"
            },
            {
                title: l('HomeSliderButtonLink'),
                data: "buttonLink"
            },
            {
                title: l('HomeSliderButtonText'),
                data: "buttonText"
            },
            {
                title: l('HomeSliderOrder'),
                data: "order"
            },
            {
                title: l('HomeSliderType'),
                data: "type"
            },
            {
                title: l('HomeSliderUploadFile'),
                data: "uploadFile"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewHomeSliderButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
