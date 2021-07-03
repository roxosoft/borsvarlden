var selectedNewCompany;

$(function () {

    $("#articles-grid").dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: "id",
            
            loadUrl: "../api/Companies/List",
            insertUrl: "../api/Companies/Insert",
            updateUrl: "../api/Companies/UpdateCompanyInfo"
           // deleteUrl: "api/Articles/Delete"
        }),
        columns: [
            {
                dataField: "company",
                caption: "company",
                sortIndex: 0,
                allowSorting: true,
                sortOrder: "asc"
            },
            ,
            {
                dataField: "image",
                caption: "Image",
                width: 110,
                alignment: "center",
                cellTemplate: function (container, options) {
                    container.append("<img style='width: auto' src=\"" + options.text + "\" width=\"50\" height=\"50\" >");
                },
                editCellTemplate: (itemElement, cellInfo) => {

                    let tb = $("<div />").dxTextBox({
                        value: cellInfo.value,
                        onValueChanged: (e) => {
                            cellInfo.setValue(e.value);
                        }
                    })
                    tb.appendTo(itemElement);

                    $("<div />").dxFileUploader({
                        accept: "image/*",
                        uploadUrl: "../api/Image/UploadImage",
                        onUploaded: (e) => {
                            cellInfo.setValue(e.request.response);
                            tb.dxTextBox('option', 'value', e.request.response);
                        },
                        onUploadError: function (e) {
                            var xhttp = e.request;
                            if (xhttp.readyState == 4 && xhttp.status == 0) {
                                console.log("Connection refused.");
                            }
                        }
                    }).appendTo(itemElement);

                }
            },
            {
                dataField: "description",
                visible: false,
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
            },
            {
                dataField: "greenTag",
                caption: "Green Tag"
             
            },
            {
                dataField: "isVisibleFromCompanyList",
                caption: "In company list"
            }

        ],
        editing: {
            mode: "popup",
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                title: "Companies",
                showTitle: true,
                my: "top",
                at: "top",
                of: window
            },
            form: {
                colCount: 2,
                items: [
                    {
                        dataField: "company",
                        colSpan: 2
                    },
                    {
                        colSpan: 2,
                        dataField: "description"
                    },
                    {
                        colSpan: 2,
                        dataField: "image"
                    },
                    {
                        colSpan: 2,
                        dataField: "greenTag"
                    },
                    {
                        colSpan: 2,
                        dataField: "isVisibleFromCompanyList"
                    }

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