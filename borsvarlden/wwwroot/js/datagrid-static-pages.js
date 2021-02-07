
$(function () {

    $("#articles-grid").dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: "id",
            loadUrl: "../api/StaticPages",
            updateUrl: "../api/StaticPages/Update"
        }),
        columns: [
            {
                dataField: "pageName",
                caption: "Page Name"
            },
            {
                dataField: "text",
                caption: "Text",
                editCellTemplate: (itemElement, cellInfo) => {

                    ($("<textarea>", { "id": "ckpeditor", "val": cellInfo.value })).appendTo(itemElement);

                    $("<script>").append(CKEDITOR.replace("ckpeditor", {
                        extraPlugins: 'embed',
                        embed_provider: '//ckeditor.iframe.ly/api/oembed?url={url}&callback={callback}&api_key=90d4029ed5529f8b49bbdc',
                        filebrowserBrowseUrl: '/lib/fileman/index.html',
                        filebrowserImageBrowseUrl: '/lib/fileman/index.html' + '?type=image',
                        removeDialogTabs: 'link:upload;image:upload'
                    })).appendTo(itemElement);

                    $("<script>").append(CKEDITOR.instances.ckpeditor.on("change", function () { cellInfo.setValue(CKEDITOR.instances.ckpeditor.getData()) })).appendTo(itemElement);

                }

            }
        ],
        editing: {
            mode: "popup",
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                my: "top",
                at: "top",
                of: window
            },
            form: {
                colCount: 2,
                items: [
                   
                    {
                        colSpan: 2,
                        dataField: "text"
                    },
                ]
            }
        },
        remoteOperations: true,
        searchPanel: {
            visible: true
        },
        grouping: {
            autoExpandAll: false
        },
        filterRow: {
            visible: true,
            applyFilter: "onClick"
        }
    });
});