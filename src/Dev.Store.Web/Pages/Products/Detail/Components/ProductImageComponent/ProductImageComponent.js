var productImage = {
    defines: {
        productId: null,
        grid: () => { return $("#ProductImageGrid").data("handler") },
        createModal: new abp.ModalManager(abp.appPath + 'ProductImages/ProductImage/createmodal'),
    },
    functions: {
        uppy: function () {
            var uppy = new Uppy.Uppy({
                debug: false,
                autoProceed: false,
                locale: Uppy.locales.tr_TR,
                allowMultipleUploadBatches: true,
                restrictions: {
                    allowedFileTypes: ["image/*"],
                    requiredMetaFields: [],
                }
            });
            uppy.use(Uppy.Dashboard, {
                inline: true,
                locale: Uppy.locales.tr_TR,
                width: 100000,
                target: '#drag-drop-area',
                showProgressDetails: true,
                browserBackButtonClose: false,
                hideUploadButton: false
            })
                .use(Uppy.ImageEditor, { target: Uppy.Dashboard })
                .use(Uppy.DropTarget, { target: document.body })
                .use(Uppy.Compressor)
                .use(Uppy.XHRUpload, {

                    endpoint: '/api/app/product-image/upload/' + ImageProductId,


                }).on('complete', (result) => {
                    productImage.defines.createModal.close();
                    $("#ProductImageGrid").data("kendoListView").dataSource.read();
                    abp.notify.success(l("SuccessfullyCreated"));

                })
            window.uppy = uppy;
        },
        delete: function (id) {
            abp.message.confirm(l("DeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = id;
                        dev.store.productImages.productImage.delete(recordId)
                            .then(function () {
                                $("#ProductImageGrid").data("kendoListView").dataSource.read();
                                abp.notify.success(l("SuccessfullyDeleted"));
                            });
                    }
                });
        },
        create: function () {
            productImage.defines.createModal.open();
        },
        setMain: function (id) {
            var recordId = id;
            dev.store.productImages.productImage.setMain(recordId).then(x => {
                abp.notify.success(l("SuccessfullyUpdated"));
                $("#ProductImageGrid").data("kendoListView").dataSource.read();
            })
        }
    },
    init: function () {

    }
}
productImage.defines.createModal.onOpen(function () {
    productImage.functions.uppy();

});

productImage.init();
