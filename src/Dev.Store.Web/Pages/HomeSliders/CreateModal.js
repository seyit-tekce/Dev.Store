var createModal = {
    defines: {

    },
    function: {
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
                    productImage.functions.createImages();
                    abp.notify.success(l("SuccessfullyCreated"));

                })
            window.uppy = uppy;
        },
    },
    init: function () {

    }



}