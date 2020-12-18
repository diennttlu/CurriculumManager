function SchoolYear(id, name, course) {
    this.id = id;
    this.name = name;
    this.course = course;
}

function Subject(id, name) {
    this.id = id;
    this.name = name;
}

function CreateOutlineViewModel(schoolYears) {
    var self = this;
    self.schoolYears = ko.observableArray(schoolYears);
    self.selectedSchoolYear = ko.observable();
    self.subjects = ko.observableArray();
    self.selectedSubject = ko.observable();
    self.getListSubject = ko.computed(function () {
        if (self.selectedSchoolYear() >= 1) {
            tlu.curriculumManager.curriculums.curriculum.getSubjectsBySchoolYearId(self.selectedSchoolYear()).done(function (result) {
                self.subjects.removeAll();
                self.subjects.push(new Subject(
                    null,
                    "--"
                ));
                $.each(result, function (index, value) {
                    self.subjects.push(new Subject(
                        value.id,
                        `${value.code} - ${value.name}`
                    ));
                });
            });
        }
    });
}

$(function () {
    var createOutlineViewModel = new CreateOutlineViewModel(allSchoolYears);
    ko.applyBindings(createOutlineViewModel);

    $("#cancel").click((e) => {
        e.preventDefault();
        window.location.href = "/Outlines/Index";
    });

    $("#submit").click((e) => {
        e.preventDefault();
        var schoolYearId = $("#schoolYear").val();
        var subjectId = $("#subject").val();
        var description = $("#description").val();
        var goal = $("#goal").val();
        var assessment = $("#assessment").val();
        var content = $("#content").val();
        tlu.curriculumManager
            .outlines
            .outline
            .create({ description: description, goal: goal, assessment: assessment, content: content, approveStatus: 0, subjectId: subjectId, schoolYearId: schoolYearId })
            .done(function (result) {
                if (result) {
                    window.location.href = "/Outlines/Index";
                }
            });
    });
});