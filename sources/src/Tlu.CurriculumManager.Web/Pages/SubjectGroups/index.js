$(function () {
    var l = abp.localization.getResource('CurriculumManager');
    var createModal = new abp.ModalManager(abp.appPath + 'SubjectGroups/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'SubjectGroups/EditModal');

    devmoba.datatables.enableIndividualColumnSearch('#SubjectGroupsTable', [
        { name: "id" },
        { name: "name" },
        { name: "parentId", options: allSubjectGroups },
        { searchDisabled: true },
        { name: "curriculumId", options: allCurriculums },
        { searchDisabled: true },
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
        ajax: abp.libs.datatables.createAjax(tlu.curriculumManager.subjectGroups.subjectGroup.getList, () => {
            return devmoba.datatables.searchHelper.getSearchConditions();
        }),
        columnDefs: [
            { targets: [0] },
            { targets: [1] },
            {
                targets: [2],
                render: function (data, row, type, meta) {
                    if (data)
                        return data;
                    return "";
                }
            },
            { targets: [3] },
            { targets: [4] },
            {
                targets: [5],
                render: function (data, row, type, meta) {
                    return `${data.name} - ${data.course}`;
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
                                tlu.curriculumManager.subjectGroups.subjectGroup.delete(data.record.id)
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
            { data: "id", width: "60px", className: "content-cell" },
            { data: "name", width: "300px", className: "content-cell" },
            { data: "parent.name", width: "150px", className: "content-cell" },
            { data: "note", width: "400px", className: "content-cell" },
            { data: "curriculum.name", width: "300px", className: "content-cell" },
            { data: "curriculum.schoolYear", width: "150px", className: "content-cell" },
        ]
    });

    var dataTable = $('#SubjectGroupsTable').DataTable(devmoba.datatables.fixDomConfiguration(datatableConfig));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewSubjectGroupButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    $(".search_c_2").select2();
    $(".search_c_3").select2();
});