var createModal = {
    defines: {
    },
    functions: {
        uppy: function () {
            var uppy = new Uppy.Uppy({
                debug: true,
                autoProceed: false,
                locale: Uppy.locales.tr_TR,
                allowMultipleUploadBatches: false,
                restrictions: {
                    maxNumberOfFiles: 1,
                    minNumberOfFiles: 1,
                    allowedFileTypes: ["image/*"],
                    requiredMetaFields: [],
                }
            });
            uppy.use(Uppy.Dashboard, {
                inline: true,
                locale: Uppy.locales.tr_TR,
                target: '#drag-drop-area',
                showProgressDetails: true,
                browserBackButtonClose: false,
                hideUploadButton: true
            }).use(Uppy.XHRUpload, {
                locale: Uppy.locales.tr_TR,
                endpoint: '/Categories/CreateModal/',
                formData: true,
                fieldName: 'Files',
            }).use(Uppy.ImageEditor, { target: Uppy.Dashboard })
                .use(Uppy.DropTarget, { target: document.body })
                .use(Uppy.Compressor)
            uppy.use(Uppy.Form, {
                locale: Uppy.locales.tr_TR,
                target: '#categoryForm',
                resultName: 'Files',
                getMetaFromForm: true,
                addResultToForm: true,
                submitOnSuccess: false,
                triggerUploadOnSubmit: true,
            }).on('upload-success', function () {
                categories.defines.createModal.setResult();
            });

            window.uppy = uppy;
        }
    },
    init: function () {
        createModal.functions.uppy();

    }
}
createModal.init();