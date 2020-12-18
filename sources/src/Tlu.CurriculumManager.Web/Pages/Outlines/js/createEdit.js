const toolbarConfig = ['heading', '|', 'bold', 'italic', 'link', 'bulletedList', 'numberedList', 'blockQuote', '|', 'undo', 'redo'];

ClassicEditor
	.create(document.querySelector('#description'), {
		toolbar: toolbarConfig
	})
	.then(editor => {
		window.editor = editor;
	})
	.catch(err => {
		console.error(err.stack);
	});


ClassicEditor
	.create(document.querySelector('#goal'), {
		toolbar: toolbarConfig 
	})
	.then(editor => {
		window.editor = editor;
	})
	.catch(err => {
		console.error(err.stack);
	});

ClassicEditor
	.create(document.querySelector('#assessment'), {
		toolbar: toolbarConfig
	})
	.then(editor => {
		window.editor = editor;
	})
	.catch(err => {
		console.error(err.stack);
	});

ClassicEditor
	.create(document.querySelector('#content'), {
		toolbar: toolbarConfig
	})
	.then(editor => {
		window.editor = editor;
	})
	.catch(err => {
		console.error(err.stack);
	});

$("#schoolYear").select2();
$("#subject").select2();
$("#document").select2();
$(".col-md-3 .row .select2-container").removeAttr("style");
$(".col-md-6 .row .select2-container").removeAttr("style");
$(".col-md-4 .select2-container").removeAttr("style");