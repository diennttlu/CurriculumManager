function Curriculum(Id, Name) {
    this.id = Id;
    this.name = Name;
}

function SchoolYear(Id, Name, Course) {
    this.id = Id;
    this.name = Name;
    this.course = Course;
}

function Subject({ id, code, name, unit, condition, hoursStudy, coefficient }) {
    this.id = id;
    this.code = code;
    this.name = name;
    this.unit = unit;
    this.condition = condition;
    this.hoursStudy = hoursStudy;
    this.coefficient = coefficient;
}


function DetailViewModel(schoolYears) {
    var self = this;
    self.schoolYears = schoolYears;
    self.curriculums = ko.observableArray([]);
    self.selectedCurriculum = ko.observable();
    self.selectedSchoolYear = ko.observable(1);
    self.subjects = ko.observableArray([]);

    self.getCurriculums = ko.computed(function () {
        if (self.selectedSchoolYear() >= 1) {
            tlu.curriculumManager.curriculums.curriculum.getAllBySchoolYearId(self.selectedSchoolYear()).done(function (result) {
                self.curriculums.removeAll();
                $.each(result, function (index, value) {
                    self.curriculums.push(new Curriculum(
                        value.id,
                        value.name
                    ));
                });
            });
        }
    });

    self.getSubjects = ko.computed(function () {
        if (self.selectedCurriculum() >= 1) {
            tlu.curriculumManager.curriculums.curriculum.getSubjectByCurriculumId(self.selectedCurriculum()).done(function (result) {
                self.subjects.removeAll();
                $.each(result, function (index, value) {
                    self.subjects.push(new Subject(value));
                });
            });
        }
    });


}


