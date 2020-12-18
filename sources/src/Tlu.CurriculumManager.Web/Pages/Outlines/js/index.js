const ApproveStatus = {
    Reject: 0,
    Approve: 1
}

function OutlineViewModel(schoolYears) {
    var self = this;
    self.schoolYears = ko.observableArray(schoolYears);
    self.selectedSchoolYear = ko.observable();
}
var detailModal = new abp.ModalManager(abp.appPath + 'Outlines/DetailModal');

$(function () {
    var self = this;
    self.selectedId = ko.observable();
    var viewModel = new OutlineViewModel(allSchoolYears);
    ko.applyBindings(viewModel);

    var l = abp.localization.getResource('CurriculumManager');
    var selectDocumentModal = new abp.ModalManager(abp.appPath + 'Outlines/SelectDocumentModal');
    moment.locale(abp.localization.currentCulture.twoLetterIsoLanguageName);

    devmoba.datatables.enableIndividualColumnSearch('#OutlinesTable', [
        { name: "id" },
        { name: "subjectName" },
        { name: "approveStatus" },
        { searchDisabled: true }
    ]);

    var datatableConfig = abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: false,
        paging: true,
        lengthMenu: [20, 30, 50, 100],
        searching: true,
        autoWidth: true,
        scrollCollapse: true,
        orderCellsTop: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(tlu.curriculumManager.outlines.outline.getList, () => {
            var res = devmoba.datatables.searchHelper.getSearchConditions();
            res.schoolYearId = viewModel.selectedSchoolYear();
            return res;
        }),
        columnDefs: [
            { targets: [0] },
            {
                targets: [1],
                render: function (data, type, row, meta) {
                    return `<a href="javascript:void(0)" onClick="showDetailModal(${row.id})" data-id="${row.id}">${data}</a>`;
                } 
            },
            {
                targets: [2],
                render: function (data, type, row, meta) {
                    if (data == ApproveStatus.Reject)
                        return `<span style="color: red;">${l("Reject")}</span>`;
                    return `<span style="color: green;">${l("Approved")}</span>`;
                }
            },
            {
                rowAction: {
                    items: [
                        {
                            text: "Thêm tài liệu",
                            action: function (data) {
                                self.selectedId(data.record.id);
                                selectDocumentModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Edit'),
                            action: function (data) {
                                window.location.href = `/Outlines/Edit?id=${data.record.id}`;
                            }
                        },
                        {
                            text: l('Delete'),
                            confirmMessage: function (data) {
                                return l('RecordDeletionConfirmationMessage', data.record.name);
                            },
                            action: function (data) {
                                tlu.curriculumManager.outlines.outline.delete(data.record.id)
                                    .then(function () {
                                        abp.notify.info(l('SuccessfullyDeleted'));
                                        dataTable.ajax.reload();
                                    });
                            }
                        }
                    ]
                }
            }
        ],
        columns: [
            { data: "id", width: "30px", className: "content-cell" },
            { data: "subject.name", width: "1000px", className: "content-cell" },
            { data: "approveStatus", width: "80px", className: "content-cell" }
        ]
    });

    var dataTable = $('#OutlinesTable').DataTable(devmoba.datatables.fixDomConfiguration(datatableConfig));

    selectDocumentModal.onOpen(() => {
        ko.applyBindings(new SelectDocumentViewModel(allDocuments, self.selectedId()), document.getElementById("select-document"));
        $("#document").select2();
    });

    $("#selectSchoolYear").change(function () {
        dataTable.ajax.reload();
    });

    $('#NewOutlineButton').click(function (e) {
        e.preventDefault();
        window.location.href = "/Outlines/Create";
    }); 
});

function showDetailModal(id) {
    detailModal.open({ id: id });
}
