var cachedCategoryOptions = null;

$(document).ready(() => {
    $('#CategoryTableContainer').jtable({
        title: 'Categories',
        actions: {
            listAction: (postData, jtParams) => getRecords('/api/Categories', postData, jtParams),
            createAction: (postData) => createRecord('/api/Categories', postData),
            updateAction: (postData) => updateRecord('/api/Categories', postData),
            deleteAction: (postData) => deleteRecord('/api/Categories', postData),
        },
        fields: {
            id: {
                key: true,
                list: false
            },
            name: {
                title: 'Name',
                width: '45%'
            },
            parentCategoryId: {
                title: 'Parent Category',
                width: '45%',
                options: (data) => {
                    if (!cachedCategoryOptions) { //Check for cache
                        var cachedCategoryOptions = [];

                        $.ajax({
                            url: '/api/Categories',
                            type: 'GET',
                            async: false,
                            success: (result) => {
                                cachedCategoryOptions = result.map((category) => ({ DisplayText: category.name, Value: category.id }));
                                cachedCategoryOptions.push({ DisplayText: '', Value: null });
                            }
                        });
                    }

                    if (data.source === 'edit')
                        return cachedCategoryOptions
                            .filter(category => category.Value !== data.record?.id);

                    return cachedCategoryOptions;
                }
            },
            position: {
                title: 'Position',
                width: '10%'
            }
        }
    });
    $('#CategoryTableContainer').jtable('load');


    $('#ReleaseTableContainer').jtable({
        title: 'Releases',
        actions: {
            listAction: (postData, jtParams) => getRecords('/api/Releases', postData, jtParams),
            createAction: (postData) => createRecord('/api/Releases', postData),
            updateAction: (postData) => updateRecord('/api/Releases', postData),
            deleteAction: (postData) => deleteRecord('/api/Releases', postData),
        },
        fields: {
            id: {
                key: true,
                list: false
            },
            name: {
                title: 'Name',
                width: '40%'
            }
        }
    });
    $('#ReleaseTableContainer').jtable('load');


    $('#GenreTableContainer').jtable({
        title: 'Genres',
        actions: {
            listAction: (postData, jtParams) => getRecords('/api/Genres', postData, jtParams),
            createAction: (postData) => createRecord('/api/Genres', postData),
            updateAction: (postData) => updateRecord('/api/Genres', postData),
            deleteAction: (postData) => deleteRecord('/api/Genres', postData),
        },
        fields: {
            id: {
                key: true,
                list: false
            },
            name: {
                title: 'Name',
                width: '40%'
            }
        }
    });
    $('#GenreTableContainer').jtable('load');


    $('#StyleTableContainer').jtable({
        title: 'Styles',
        actions: {
            listAction: (postData, jtParams) => getRecords('/api/Styles', postData, jtParams),
            createAction: (postData) => createRecord('/api/Styles', postData),
            updateAction: (postData) => updateRecord('/api/Styles', postData),
            deleteAction: (postData) => deleteRecord('/api/Styles', postData),
        },
        fields: {
            id: {
                key: true,
                list: false
            },
            name: {
                title: 'Name',
                width: '40%'
            }
        }
    });
    $('#StyleTableContainer').jtable('load');


    $('#FormatTableContainer').jtable({
        title: 'Formats',
        actions: {
            listAction: (postData, jtParams) => getRecords('/api/Formats', postData, jtParams),
            createAction: (postData) => createRecord('/api/Formats', postData),
            updateAction: (postData) => updateRecord('/api/Formats', postData),
            deleteAction: (postData) => deleteRecord('/api/Formats', postData),
        },
        fields: {
            id: {
                key: true,
                list: false
            },
            name: {
                title: 'Name',
                width: '40%'
            }
        }
    });
    $('#FormatTableContainer').jtable('load');


    $('#ConditionTableContainer').jtable({
        title: 'Conditions',
        actions: {
            listAction: (postData, jtParams) => getRecords('/api/Conditions', postData, jtParams),
            createAction: (postData) => createRecord('/api/Conditions', postData),
            updateAction: (postData) => updateRecord('/api/Conditions', postData),
            deleteAction: (postData) => deleteRecord('/api/Conditions', postData),
        },
        fields: {
            id: {
                key: true,
                list: false
            },
            name: {
                title: 'Name',
                width: '40%'
            }
        }
    });
    $('#ConditionTableContainer').jtable('load');
});



function getRecords(url, postData, jtParams) {
    return $.Deferred(($dfd) => {
        $.ajax({
            url: url,
            type: 'GET',
            success: (data) => {
                const result = {
                    "Result": "OK",
                    "Records": [...data],
                    "TotalRecordCount": data.length
                };

                $dfd.resolve(result);
            },
            error: () => {
                $dfd.reject();
            }
        });
    });
}

function createRecord(url, postData, jtParams) {
    return $.Deferred(function ($dfd) {
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'json',
            data: postData,
            success: function (data) {
                const result = {
                    "Result": "OK",
                    "Record": data,
                };
                $dfd.resolve(result);
            },
            error: function () {
                $dfd.reject();
            }
        });
    });
}

function updateRecord(url, postData) {
    let { id, ...rest } = Object.fromEntries(new URLSearchParams(postData));
    return $.Deferred(function ($dfd) {
        $.ajax({
            url: `${url}/${id}`,
            type: 'PUT',
            //contentType: 'application/json',
            data: postData,//JSON.stringify(rest),
            success: function (data) {
                const result = {
                    "Result": "OK"
                };
                $dfd.resolve(result);
            },
            error: function (data) {
                $dfd.reject();
            }
        });
    });
}

function deleteRecord(url, postData) {
    return $.Deferred(function ($dfd) {
        $.ajax({
            url: `${url}/${postData.id}`,
            type: 'DELETE',
            success: function (data) {
                debugger;
                const result = {
                    "Result": "OK",
                };
                $dfd.resolve(result);
            },
            error: function () {
                $dfd.reject();
            }
        });
    });
}