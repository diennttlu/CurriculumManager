const ApproveStatus = {
    Reject: 0,
    Approve: 1
}
var detailModal = new abp.ModalManager(abp.appPath + 'Curriculums/DetailModal');

$(function () {
    var l = abp.localization.getResource('CurriculumManager');
    var createModal = new abp.ModalManager(abp.appPath + 'Curriculums/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Curriculums/EditModal');
    var createModalSubjectGroup = new abp.ModalManager(abp.appPath + 'SubjectGroups/CreateModal');

    devmoba.datatables.enableIndividualColumnSearch('#CurriculumsTable', [
        { name: "id" },
        { name: "name" },
        { name: "majorId", options: allMajors },
        { name: "schoolYearId", options: allSchoolYears },
        { name: "approveStatus" },
        { searchDisabled: true }
    ]);

    var datatableConfig = abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        lengthMenu: [10, 20, 30],
        searching: true,
        autoWidth: true,
        scrollCollapse: true,
        orderCellsTop: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(tlu.curriculumManager.curriculums.curriculum.getList, () => {
            return devmoba.datatables.searchHelper.getSearchConditions();
        }),
        columnDefs: [
            {
                targets: [0],
            },
            {
                targets: [1],
                render: function (data, type, row, meta) {
                    return `<a href="javascript:void(0)" onClick="showDetailModal(${row.id})" data-id="${row.id}">${data}</a>`;
                }   
            },
            { targets: [2] },
            { targets: [3] },
            {
                targets: [4],
                render: function (data, type, row, meta) {
                    if (data == ApproveStatus.Reject)
                        return `<span style="color: red;">${ l("Reject") }</span>`;
                    return `<span style="color: green;">${ l("Approved") }</span>`;
                }   
            },
            {
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            action: function (data) {
                                editModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            confirmMessage: function (data) {
                                return l('RecordDeletionConfirmationMessage', data.record.name);
                            },
                            action: function (data) {
                                tlu.curriculumManager.curriculums.curriculum.delete(data.record.id)
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
            { data: "id", width: "100px", className: "content-cell" },
            { data: "name", width: "300px", className: "content-cell" },
            { data: "major.name", width: "auto", className: "content-cell" },
            { data: "schoolYear.name", width: "auto", className: "content-cell" },
            { data: "approveStatus", width: "auto", className: "content-cell" },
        ]
    });

    var dataTable = $('#CurriculumsTable').DataTable(devmoba.datatables.fixDomConfiguration(datatableConfig));

    createModal.onOpen(function () {
        $('select[name ="Curriculum.ApproveStatus"]').parent().hide();
    });

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCurriculumButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    $('#NewSubjectGroupButton').click(function (e) {
        e.preventDefault();
        createModalSubjectGroup.open();
    });

    $(".search_c_2").select2();
    $(".search_c_3").select2();
});
function showDetailModal(id) {
    detailModal.open({ id: id });
}
