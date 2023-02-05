const COMPANION_URL = "http://companion.uppy.io"
const COMPANION_ALLOWED_HOSTS = ['https://tekce.net.tr']
var createModal = {
    defines: {

    },
    functions: {
        uppy: function () {
            var uppy = new Uppy.Uppy({
                debug: true,
                autoProceed: false,
                locale: Uppy.locales.ru_RU
            });
            uppy.use(Uppy.Dashboard, {
                inline: true,
                target: '#drag-drop-area',
                showProgressDetails: true,
                note: '@T["input-library-file-uppy-note"]',
                height: 470,
                //metaFields: [
                //  { id: 'Title', name: 'Title', placeholder: 'file Title' },
                //  { id: 'description', name: 'description', placeholder: 'describe what the image is about' }
                //  { id: 'sourceInfo', name: 'sourceInfo', placeholder: 'sourceInfo' }
                //  { id: 'comments', name: 'comments', placeholder: 'comments' }
                //  { id: 'author', name: 'author', placeholder: 'author' }
                //  { id: 'language', name: 'language', placeholder: 'language' }
                //],
                browserBackButtonClose: false,
                hideUploadButton: true
            }).use(Uppy.XHRUpload, {
                endpoint: '/Categories/CreateModal/',
                formData: true,
                fieldName: 'files[]',
            }).use(Uppy.ImageEditor, { target: Uppy.Dashboard })
                .use(Uppy.DropTarget, { target: document.body })
                .use(Uppy.Compressor)
                .use(Uppy.RemoteSources, {
                    // You can manually specify `sources` here, by default all available are included. 
                    // See docs: https://uppy.io/docs/remote-sources/#sources.
                    companionUrl: COMPANION_URL,
                    companionAllowedHosts: COMPANION_ALLOWED_HOSTS,
                })
            uppy.use(Uppy.Form, {
                target: '#categoryForm',
                resultName: 'files',
                getMetaFromForm: true,
                addResultToForm: true,
                submitOnSuccess: false,
                triggerUploadOnSubmit: true,
            });

            window.uppy = uppy;
        }
    },
    init: function () {



        createModal.functions.uppy();

    }



}





createModal.init();