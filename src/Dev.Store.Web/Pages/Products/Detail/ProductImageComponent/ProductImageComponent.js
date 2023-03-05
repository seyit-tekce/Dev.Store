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
                    productImage.defines.grid().dataSource.read();
                    abp.notify.success(l("SuccessfullyCreated"));

                })
            window.uppy = uppy;
        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("DeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        dev.store.productImages.productImage.delete(recordId)
                            .then(function () {
                                abp.notify.success(l("SuccessfullyDeleted"));
                                productImage.defines.grid().dataSource.read();
                            });
                    }
                });
        },
        create: function () {
            productImage.defines.createModal.open();
         

        }
    },
    init: function () {
        
    }
}
productImage.defines.createModal.onOpen(function () {
    productImage.functions.uppy();
});

function isMain(data) {
    var aa =` 
        <div data-role="switchbox" class=" p-2" style="cursor:pointer;text-align: center;position: relative;">
            <div class="">
         <span>${l("Passive")}</span>
                <div class="custom-control custom-switch d-inline-block">
                    <input switchtype="parameter" type="checkbox" class="custom-control-input" onchange="thingParameters.actions.changeStatus('${data.Id}')"  id="${data.Id}" value="${data.Id}"  ${data.IsMain ? "checked" : ""}>
                        <label class="custom-control-label" for="${data.Id}"></label>
                </div>
                 <span>${l("Active")}</span>
            </div>
    </div>`

    return aa;
}