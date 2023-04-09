(function ($) {
    function makeUppy() {
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
            metaFields: [
                { id: 'title', name: l("Title"), placeholder: l("EnterTitle"), },
                { id: 'subTitle', name: l("SubTitle"), placeholder: l("EnterSubTitle") },
                { id: 'buttonLink', name: l("ButtonLink"), placeholder: l("EnterButtonLink") },
                { id: 'buttonText', name: l("buttonText"), placeholder: l("EnterButtonText") },
            ]
        })
            .use(Uppy.ImageEditor, { target: Uppy.Dashboard })
            .use(Uppy.DropTarget, { target: document.body })
            .use(Uppy.Compressor)
            .use(Uppy.XHRUpload, {
                endpoint: '/api/app/home-slider',
                method: "PUT",
                bundle: true,
                formData: true,
                allowedMetaFields: null


            }).on('complete', (result) => {
                abp.notify.success(l("SuccessfullyCreated"));

            })
        window.uppy = uppy;
    }
    makeUppy();

    $("#SiteSetting").on('submit', function (event) {

        event.preventDefault();
        if (!$(this).valid()) {
            return;
        }
        var form = $(this).serializeFiles();
        $.ajax({
            url: abp.appPath + 'api/app/site-setting',
            type: 'PUT',
            dataType: "JSON",
            data: form,
            processData: false,
            contentType: false,
            success: function (data, status) {
                $(document).trigger("AbpSettingSaved");

            },
            error: function (xhr, desc, err) {


            }
        });
    });

})(jQuery);
