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

                    endpoint: '/api/app/product-image/upload/' + productId,


                }).on('complete', (result) => {
                    productImage.defines.createModal.close();
                    productImage.functions.createImages();
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
                                abp.notify.success(l("SuccessfullyDeleted"));
                                productImage.functions.createImages();
                            });
                    }
                });
        },
        createImages: function () {
            $("#imageGrid").html(null);
            return dev.store.productImages.productImage.dataSource({ pageSize: 99999, filter: "productId~eq~'" + productId + "'" }).then(x => {
                debugger

                if (x.Data.length == 0) {
                    $("#imageGrid").html('<b class="text-center">Lütfen Resim Eklemek İçin Sağ Üstteki Butonu Kullanın</b>');
                    return;
                }
                var template = $("#imageTemplate").html();
                $.each(x.Data, function (i, item) {
                    var _template = template.replaceAll("{{src}}", item.UploadFile.FilePath)
                    _template = _template.replaceAll("{Id}", item.Id)
                    _template = _template.replaceAll("{i}", i)
                    _template = _template.replaceAll("{{checked}}", item.IsMain?"checked":"")
                    $("#imageGrid").append(_template);
                });


            });
        },
        create: function () {
            productImage.defines.createModal.open();
        },
        setMain: function (id) {
            var recordId = id;
            dev.store.productImages.productImage.setMain(recordId, productId).then(x => {
                abp.notify.success(l("SuccessfullyUpdated"));
                productImage.functions.createImages();
            })
        }
    },
    init: function () {
        productImage.functions.createImages();

    }
}
productImage.defines.createModal.onOpen(function () {
    productImage.functions.uppy();

});

productImage.init();