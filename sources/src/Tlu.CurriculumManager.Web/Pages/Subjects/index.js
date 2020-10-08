$(function () {
    var l = abp.localization.getResource('CurriculumManager');
    var createModal = new abp.ModalManager(abp.appPath + 'Subjects/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Subjects/EditModal');

    moment.locale(abp.localization.currentCulture.twoLetterIsoLanguageName);

    devmoba.datatables.enableIndividualColumnSearch('#SubjectsTable', [
        { name: "id" },
        { name: "code" },
        { name: "name" },
        { name: "unit", enableRangeFilter: true },
        { name: "condition" },
        { name: "hoursStudy" },
        { name: "coefficient", enableRangeFilter: true },
        { searchDisabled: true }
    ]);

    var datatableConfig = abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        lengthMenu: [20, 30, 50, 100],
        searching: true,
        autoWidth: true,
        scrollCollapse: true,
        orderCellsTop: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(tlu.curriculumManager.subjects.subject.getList, () => {
            return devmoba.datatables.searchHelper.getSearchConditions();
        }),
        columnDefs: [
            { targets: [0] },
            { targets: [1] },
            { targets: [2] },
            { targets: [3] },
            { targets: [4] },
            { targets: [5] },
            { targets: [6] },
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
                                tlu.curriculumManager.subjects.subject.delete(data.record.id)
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
            { data: "code", width: "60px", className: "content-cell" },
            { data: "name", width: "350px", className: "content-cell" },
            { data: "unit", width: "80px", className: "content-cell" },
            { data: "condition", width: "120px", className: "content-cell" },
            { data: "hoursStudy", width: "100px", className: "content-cell" },
            { data: "coefficient", width: "80px", className: "content-cell" }
        ]
    });

    var dataTable = $('#SubjectsTable').DataTable(devmoba.datatables.fixDomConfiguration(datatableConfig));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewSubjectButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});