(function ($) {
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
