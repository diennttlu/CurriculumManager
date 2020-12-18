function OutlineDocument(id, documentName, documentType) {
    this.id = id;
    this.documentName = documentName;
    this.documentType = documentType;
}

function SelectDocumentViewModel(documents, outlineId) {
    var self = this;
    self.outlineId = ko.observable(outlineId);
    self.documents = ko.observableArray(documents);
    self.outlineDocuments = ko.observableArray();
    self.selectedDocument = ko.observable();
    self.getOutlineDocuments = ko.computed(function () {
        if (self.outlineId() >= 1 || self.selectedDocument() >= 1) {
            tlu.curriculumManager.outlineDocuments.outlineDocument.getListByOutlineId(outlineId).done(function (result) {
                self.outlineDocuments.removeAll();
                $.each(result, function (index, value) {
                    self.outlineDocuments.push(new OutlineDocument(
                        value.id,
                        `${value.document.name}`,
                        value.documentType
                    ));
                });
            });
        }
    });
}
