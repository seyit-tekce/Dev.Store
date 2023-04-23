var homeSliders = {
    defines: {
        type: 0
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
                hideUploadButton: false,
                metaFields: homeSliders.functions.getMetaFields()
            })
                .use(Uppy.ImageEditor, { target: Uppy.Dashboard })
                .use(Uppy.DropTarget, { target: document.body })
                .use(Uppy.Compressor)
                .use(Uppy.XHRUpload, {
                    endpoint: '/api/app/home-slider?type=' + homeSliders.defines.type,

                }).on('complete', (result) => {
                    homeSliders.defines.createModal.close();
                    abp.notify.success(l("SuccessfullyCreated"));
                    location.reload();

                })
            window.uppy = uppy;
        },
        delete: function (id) {
            abp.message.confirm(l("DeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = id;
                        dev.store.homeSliders.homeSlider.delete(recordId)
                            .then(function () {
                                abp.notify.success(l("SuccessfullyDeleted"));
                                homeSliders.functions.createImages();
                            });
                    }
                });
        },
        getMetaFields: function () {
            return [this.createMetaFields("name","name",null,true)]
        },
        createMetaFields: function (id,name,placeholder,_required) {
            return {
                id: id,
                name: name,
                placeholder: placeholder,
                render({ value, onChange, required, form }, h) {
                    return h('input', {
                        type: 'text',
                        _required,
                        form,
                        onChange: (ev) => onChange(ev.target.checked ? 'on' : ''),
                        defaultChecked: value === 'on',
                    });
                },
            }
        }


    },
    init: function () {
        homeSliders.functions.uppy();


    }
}
homeSliders.init();