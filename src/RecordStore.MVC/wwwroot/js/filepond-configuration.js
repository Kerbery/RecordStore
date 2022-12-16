FilePond.registerPlugin(
    FilePondPluginImagePreview
);

FilePond.setOptions({
    server: {
        url: '/api/Photos',
        process: '',
        //revert: {
        //    url: '',
        //    method: 'DELETE',
        //    headers: {
        //        "data-type": "json",
        //        "content-type": 'application/json'
        //    },
        //},
        revert: (file, load, error) => {
            $.ajax({
                url: '/api/Photos',
                type: 'DELETE',
                contentType: 'application/json',
                data: JSON.stringify( file ),
            })
                .done(() => {
                    load();
                })
                .fail(() => {
                    error(`Failed to remove ${file}.`);
                });
        },
        restore: '/',
        load: '/',
        fetch: '/'
    },
    allowReorder: true,
    labelIdle: 'Drag & Drop your photos or <span class="filepond--label-action"> Browse </span>'
});

const inputElement = document.querySelector('#images-input');

var existingFiles = [];

if (typeof existingPhotos !== 'undefined') {
    existingFiles = existingPhotos.map(p => ({
        source: p,
        options: {
            type: 'limbo',
        }
    }));
}

const pond = FilePond.create(inputElement, {
    files: existingFiles,
});