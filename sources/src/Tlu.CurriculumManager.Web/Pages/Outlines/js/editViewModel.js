function EditOutlineViewModel(outline) {
    var self = this;
    self.approveStatus = ko.observableArray([{ text: "Chưa duyệt", value: 0 }, { text: "Đã duyệt", value: 1 }]);
    self.selectedApproveStatus = ko.observable(outline.approveStatus);
    self.outline = ko.observable(outline);
}

$(function () {
    var editOutlineViewModel = new EditOutlineViewModel(outline);
    ko.applyBindings(editOutlineViewModel);

    $("#cancel").click((e) => {
        e.preventDefault();
        window.location.href = "/Outlines/Index";
    });
});