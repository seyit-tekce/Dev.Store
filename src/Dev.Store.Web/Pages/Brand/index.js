//$(function () {

//    var l = abp.localization.getResource('Store');

//    var service = dev.store.brand;
//    var createModal = new abp.ModalManager(abp.appPath + 'Dev/Store/Brand/CreateModal');
//    var editModal = new abp.ModalManager(abp.appPath + 'Dev/Store/Brand/EditModal');

//    var dataTable = $('#BrandTable').DataTable(abp.libs.datatables.normalizeConfiguration({
//        processing: true,
//        serverSide: true,
//        paging: true,
//        searching: false,
//        autoWidth: false,
//        scrollCollapse: true,
//        order: [[0, "asc"]],
//        ajax: abp.libs.datatables.createAjax(service.getList),
//        columnDefs: [
//            {
//                rowAction: {
//                    items:
//                        [
//                            {
//                                text: l('Edit'),
//                                visible: abp.auth.isGranted('Store.Brand.Update'),
//                                action: function (data) {
//                                    editModal.open({ id: data.record.id });
//                                }
//                            },
//                            {
//                                text: l('Delete'),
//                                visible: abp.auth.isGranted('Store.Brand.Delete'),
//                                confirmMessage: function (data) {
//                                    return l('BrandDeletionConfirmationMessage', data.record.id);
//                                },
//                                action: function (data) {
//                                    service.delete(data.record.id)
//                                        .then(function () {
//                                            abp.notify.info(l('SuccessfullyDeleted'));
//                                            dataTable.ajax.reload();
//                                        });
//                                }
//                            }
//                        ]
//                }
//            },
//            {
//                title: l('BrandName'),
//                data: "name"
//            },
//            {
//                title: l('BrandCode'),
//                data: "code"
//            },
//            {
//                title: l('BrandDescription'),
//                data: "description"
//            },
//        ]
//    }));

//    createModal.onResult(function () {
//        dataTable.ajax.reload();
//    });

//    editModal.onResult(function () {
//        dataTable.ajax.reload();
//    });

//    $('#NewBrandButton').click(function (e) {
//        e.preventDefault();
//        createModal.open();
//    });
//});
