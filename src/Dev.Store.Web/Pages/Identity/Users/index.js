var l = abp.localization.getResource("KontrolBulutu");
users = {
    const: {
        _identityUserAppService: volo.abp.identity.identityUser,
        _identityUserWithRolesAppService: window.infoline.kontrolBulutu.identity.user,
        _claimTypeEditModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/ClaimTypeEditModal', modalClass: 'claimTypeEdit' }),
        _editModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/EditModal', modalClass: 'editUser' }),
        _createModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/CreateModal', modalClass: 'createUser' }),
        _permissionsModal: new abp.ModalManager(abp.appPath + 'AbpPermissionManagement/PermissionManagementModal'),
        _changeUserPasswordModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/SetPassword', modalClass: 'changeUserPassword' }),
        _lockoutModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/Lock', modalClass: 'lock' }),
        _twoFactorModal: new abp.ModalManager({ viewUrl: abp.appPath + 'Identity/Users/TwoFactor', modalClass: 'twoFactor' }),
        grid: $("#UsersGrid")
    },
    actions: {
        create: function (e) {
            users.const._createModal.onOpen(function () {
                $("#UserInfo_Password").val("*");
                $("#UserInfo_Password").parents(".form-group").hide();
            });
            users.const._createModal.open();
            users.const._createModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        edit: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._editModal.open({
                id: recordId
            });

            users.const._editModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        claims: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._claimTypeEditModal.open({
                id: recordId
            });
            users.const._claimTypeEditModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        lock: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._lockoutModal.open({
                id: recordId
            });

            users.const._lockoutModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        unlock: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            users.const._identityUserAppService
                .unlock(recordId)
                .then(function () {
                    abp.notify.success(l("UserUnlocked"));
                    users.const.grid.data('kendoGrid').dataSource.read();
                    users.const.grid.data('kendoGrid').refresh();
                });

        },
        permissions: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._permissionsModal.open({
                providerName: 'U',
                providerKey: recordId
            });

            users.const._permissionsModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        setPassword: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._changeUserPasswordModal.open({
                id: recordId
            });

            users.const._changeUserPasswordModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },

        twoFactor: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            users.const._twoFactorModal.open({
                id: recordId
            });
            users.const._twoFactorModal.onResult(function () {
                users.const.grid.find(".k-pager-refresh").trigger("click");
            });
        },
        changeHistory: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            e.preventDefault();
            abp.auditLogging.openEntityHistoryModal(
                "Volo.Abp.Identity.IdentityUser",
                recordId
            );

        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("DeleteConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        users.const._identityUserAppService.delete(recordId)
                            .then(function () {
                                abp.notify.info(l("SuccessfullyDeleted"));
                                users.const.grid.find(".k-pager-refresh").trigger("click");
                            });
                    }
                });
        },
        bulkCreate: function (e) {

            $('<input type="file"  accept="*.xlsx,*.csv,*.xls"/>')
                .on("change", function (e) {
                    var dosya = this.files[0];
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        var data = e.target.result;
                        var workbook = XLSX.read(data, {
                            type: 'binary',
                            cellDates: true,
                            cellText: false,
                            cellNF: false,
                        });
                        var sheetData = [];
                        var sheet = workbook.Sheets[workbook.SheetNames[0]];
                        sheetData = XLSX.utils.sheet_to_row_object_array(sheet);
                        abp.ui.setBusy();
                        infoline.kontrolBulutu.identity.user.bulkCreate(sheetData).done(data => {
                            debugger;
                            if (data.length > 0) {
                                var errorList = [];
                                $.each(data, function (i, item) {
                                    var row = sheetData.filter(x => x["__rowNum__"] == item.rowNumber)[0];
                                    if (row == null) {
                                        return;
                                    }
                                    row["Error"] = item.message;
                                    errorList.push(row);
                                });
                                var columns = errorList.map(x => Object.keys(x)).sort(function (a, b) { return b.length - a.length; })[0];
                                var rows = [{
                                    cells: columns.map(function (c) {
                                        return {
                                            background: "#7a7a7a",
                                            colSpan: 1,
                                            color: "#fff",
                                            rowSpan: 1,
                                            value: c,
                                        }
                                    }),
                                    type: "header"
                                }];
                                errorList.forEach(function (d) {
                                    rows.push({
                                        cells: columns.map(function (c) { return { value: d[c] } }),
                                        type: "data"
                                    });
                                });
                                var workbook = {
                                    sheets: [{
                                        columns: columns.map(function (c) { return { autoWidth: true }; }),
                                        filter: null,
                                        freezePane: { rowSplit: 1, colSplit: 0 },
                                        rows: rows,
                                    }]
                                };

                                var c = new kendo.ooxml.Workbook(workbook);
                                kendo.saveAs({
                                    dataURI: c.toDataURL(),
                                    fileName: "Uncommited Datas.xlsx"
                                });

                            }


                            abp.ui.clearBusy();
                            $("#UsersGrid").data("kendoGrid").dataSource.read()

                        });
                    };
                    reader.onerror = function (ex) {
                        console.log(ex);
                    };
                    reader.readAsBinaryString(dosya);
                })
                .trigger("click")


        }

    },
    init: function () {


    }
};


