
var viewModel = new SubjectGroupViewModel(allCurriculums);

ko.applyBindings(viewModel);
var delayInMilliseconds = 300; //1 second

setTimeout(function () {
    var l = abp.localization.getResource('CurriculumManager');

    moment.locale(abp.localization.currentCulture.twoLetterIsoLanguageName);

    devmoba.datatables.enableIndividualColumnSearch('#SubjectGroupDetailsTable', [
        { name: "id" },
        { name: "code" },
        { name: "name" },
        { name: "unit", enableRangeFilter: true },
        { name: "condition" },
        { name: "hoursStudy" },
        { name: "coefficient", enableRangeFilter: true },
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
        ajax: abp.libs.datatables.createAjax(tlu.curriculumManager.subjectGroupDetails.subjectGroupDetail.getSubjectBySubjectGroupId, () => {
            var res = devmoba.datatables.searchHelper.getSearchConditions();
            res.subjectGroupId = viewModel.selectedSubjectGroup();
            return res;
        }),
        columnDefs: [
            { targets: [0] },
            { targets: [1] },
            { targets: [2] },
            { targets: [3] },
            { targets: [4] },
            { targets: [5] },
            { targets: [6] },
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

    var dataTable = $('#SubjectGroupDetailsTable').DataTable(devmoba.datatables.fixDomConfiguration(datatableConfig));

    $("#selectSubjectGroup").change(function () {
        dataTable.ajax.reload();
    });
}, delayInMilliseconds);

    

