$(document).ready(function () {
    var table = $('#myTable').DataTable({
        dom:
            //"<'row'<'col-sm-12'P>>" +
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
        //"dom": 'Bfrtip',
        //dom: "fBrtip",
        //"searchPanes": {
        //    "cascadePanes": true,
        //    "layout": 'columns-2',
        //    "initCollapsed": true
        //},
        "processing": true,
        //"serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/api/RecordsApi",
            "type": "POST",
            "datatype": "json"
        },
        "order": [[2, 'desc']],
        "columnDefs": [
            {
                "targets": [5, 6, 8, 9, 10],
                "searchPanes": {
                    "show": true
                },
            },
            {
                "targets": [0, 1, 2, 3, 4, 7, 14],
                "searchPanes": {
                    "show": false
                },
            },
            {
                "targets": [11, 12, 13],
                "searchPanes": {
                    "orthogonal": 'sp',
                    "show": true
                }
            },
            {
                "targets": [1, 2, 3, 7],
                "visible": false,
                "searchable": false
            }
        ],
        "columns": [
            {
                "className": 'dt-control',
                "sortable": false,
                "data": null,
                "defaultContent": '',
                "width": "20px",
            },
            { "data": "id", "name": "Id", "autoWidth": true, "visible": false, "searchable": false },
            { "data": "createDate", "name": "CreateDate", "autoWidth": true, "visible": false, "searchable": false },
            {
                "data": "photos", "name": "Photos",
                "render": CreateThumbnail,
                "width": "140px",
                "visible": true,
                "searchable": false,
                "orderable": false,
            },
            { "data": "title", "name": "Title", "autoWidth": true },
            { "data": "year", "name": "Year", "autoWidth": true },
            { "data": "price", "name": "Price", "autoWidth": true },
            { "data": "description", "name": "Description", "autoWidth": true, "visible": false, },
            { "data": "format", "render": (data, type, row) => (data?.name ?? ''), "name": "Format", "autoWidth": true, "visible": false },
            { "data": "release", "render": (data, type, row) => (data?.name ?? ''), "name": "Release", "autoWidth": true, "visible": false },
            { "data": "recordCondition", "render": (data, type, row) => (data?.name ?? ''), "name": "RecordCondition", "autoWidth": true, "visible": false },
            {
                "data": "categories",
                "render": {
                    _: '[, ].name',
                    sp: '[].name'
                },
                "orderable": false,
                "visible": false
            },
            {
                "data": "genres",
                "render": {
                    _: '[, ].name',
                    sp: '[].name'
                },
                "orderable": false,
                "visible": false
            },
            {
                "data": "styles",
                "render": {
                    _: '[, ].name',
                    sp: '[].name'
                },
                "orderable": false,
                "visible": false
            },
            {
                "render": (data, x, row) => {
                    return ('<a class="btn d-block btn-primary mb-1" href="/Admin/Records/Edit/' + row.id + '" title="Edit Record"><i class="bi bi-pencil"></i> Edit</a>' +
                        '<a class="btn d-block btn-info mb-1" href="/Admin/Records/Details/' + row.id + '" title="View Details"><i class="bi bi-file-richtext"></i> Details</a>' +
                        '<a class="btn d-block btn-danger" href="/Admin/Records/Delete/' + row.id + '" title="Delete Record"><i class="bi bi-trash"></i> Remove</a>');
                },
                "sortable": false,
                "width": "120px",
            },
        ],
        buttons: [//'searchPanes',
            {
                "extend": "searchPanes",
                "config": {
                    "layout": "columns-2",
                    "initCollapsed": true
                }
            },
            {
                text: 'Add New Record',
                className: "btn-primary",
                action: function (e, dt, node, config) {
                    location.href = '/Admin/Records/Create';
                }
            }
        ]
    });
    //table.buttons().container()
    //    .appendTo('#myTable .myTable_filter:eq(0)');
    //new $.fn.dataTable.SearchPanes(table, {});
    //table.searchPanes.container().prependTo(table.table().container());
    //table.searchPanes.resizePanes();

    // Add event listener for opening and closing details
    $('#myTable tbody').on('click', 'td.dt-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        } else {
            // Open this row
            row.child(format(row.data())).show();
            tr.addClass('shown');
        }
    });
});

const CreateThumbnail = (urls) => {
    const url = [...urls][0];
    const backgroundImage = url ? `background-image: url(/Images/Thumbs/${url});` : "";
    return `<div class="photo-tumbnail artwork-placeholder"><span style="width:100%; height:100%; ${backgroundImage}" /></div>`;
}

/* Formatting function for row details - modify as you need */
const format = (d) => {
    // `d` is the original data object for the row
    return (
        '<table cellpadding="5" cellspacing="0" border="0" class="d-block ps-5">' +
        '<tr>' +
        '<td><b>Description:</b></td>' +
        '<td>' + (d.description ?? '') + '</td>' +
        '</tr>' +
        '</table>' +
        '<table cellpadding="5" cellspacing="0" border="0" class="d-inline-block ps-5">' +
        '<tr>' +
        '<td><b>Title:</b></td>' +
        '<td>' + d.title + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td><b>Year:</b></td>' +
        '<td>' + d.year + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td><b>Price:</b></td>' +
        '<td>' + (d.price) + '</td>' +
        '</tr>' +
        '</table>' +
        '<table cellpadding="5" cellspacing="0" border="0" class="d-inline-block ps-5">' +
        '<tr>' +
        '<td><b>Format:</b></td>' +
        '<td>' + (d.format?.name ?? '') + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td><b>Release:</b></td>' +
        '<td>' + (d.release?.name ?? '') + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td><b>Record Condition:</b></td>' +
        '<td>' + (d.recordCondition?.name ?? '') + '</td>' +
        '</tr>' +
        '</table>' +
        '<table cellpadding="5" cellspacing="0" border="0" class="d-inline-block ps-5">' +
        '<tr>' +
        '<td><b>Categories:</b></td>' +
        '<td>' + d.categories.map(c => c.name).join(', ') + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td><b>Genres:</b></td>' +
        '<td>' + d.genres.map(c => c.name).join(', ') + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td><b>Styles:</b></td>' +
        '<td>' + d.styles.map(c => c.name).join(', ') + '</td>' +
        '</tr>' +
        '</table>'
    );
}