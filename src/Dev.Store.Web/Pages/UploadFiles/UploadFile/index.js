$(function () {

    $("#UploadFileFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    $('#UploadFileFilter div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#UploadFileFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/UploadFileFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('Store');

    var service = dev.store.uploadFiles.uploadFile;
    var createModal = new abp.ModalManager(abp.appPath + 'UploadFiles/UploadFile/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'UploadFiles/UploadFile/EditModal');

    var dataTable = $('#UploadFileTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Store.UploadFile.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Store.UploadFile.Delete'),
                                confirmMessage: function (data) {
                                    return l('UploadFileDeletionConfirmationMessage', data.record.id);
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
                title: l('UploadFileFileName'),
                data: "fileName"
            },
            {
                title: l('UploadFileFilePath'),
                data: "filePath"
            },
            {
                title: l('UploadFilePublicId'),
                data: "publicId"
            },
            {
                title: l('UploadFileDescription'),
                data: "description"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewUploadFileButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
