var selectedNewCompany;

$(function () {

    $("#articles-grid").dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            key: "id",
            loadUrl: "api/Articles",
            insertUrl: "api/Articles/Insert",
            updateUrl: "api/Articles/Update",
            deleteUrl: "api/Articles/Delete"
        }),
        columns: [
            {
                dataField: "date",
                caption: "Date created",
                dataType: "datetime",
                format: "MM/dd/yyyy hh:mm"
            },
            {
                dataField: "title",
                caption: "Title"
            },
            {
                dataField: "subtitle",
                visible: false
            },
            {
                dataField: "imageRelativeUrl",
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
                        uploadUrl: "api/Image/UploadImage",
                        onUploaded: (e) => {
                            cellInfo.setValue(e.request.response);
                            tb.dxTextBox('option', 'value', e.request.response);
                        }
                    }).appendTo(itemElement);

                }
            },
            {
                dataField: "newsText",
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
                dataField: "isAdvertising",
                dataType: "boolean",
                visible: false
            },
            {
                dataField: "dateModified",
                dataType: "datetime",
                format: "MM/dd/yyyy hh:mm",
                visible: false
            },
            {
                dataField: "slug",
                dataType: "string",
                visible: false
            },
            {
                dataField: "order",
                dataType: "number",
                visible: false
            },
            {
                dataField: "companyName",
                dataType: "string",
                visible: true
            },
            {
                dataField: "prioDeadLine",
                caption: "Prio deadline",
                dataType: "datetime",
                format: "MM/dd/yyyy hh:mm",
                visible: true
            },
            {
                dataField: "label",
                dataType: "string",
                visible: true
            },
            {
                dataField: "isPublished",
                dataType: "boolean",
                visible: true
            },
            {
                dataField: "actualDeadLine",
                caption: "Actual deadline",
                dataType: "datetime",
                format: "MM/dd/yyyy hh:mm",
                visible: true
            },
            {
                dataField: "isBorsvarldenArticle",
                dataType: "boolean",
                visible: true
            },
            {
                dataField: "is15MinutesVideo",
                dataType: "boolean",
                visible: true
            },
            {
                dataField: "isHotStocks",
                dataType: "boolean",
                visible: true
            },
            {
                dataField: "FinwireNew2FinwireCompanies",
                caption: "Companies related",
                visible: true,
                editCellTemplate: (itemElement, cellInfo) => {

                    var rootElement = $("<div style='display:flex'>");

                    var ds =
                        new DevExpress.data.DataSource({
                            store:
                                DevExpress.data.AspNet.createStore({
                                    loadUrl: "api/Companies/GetCompaniesByNews/" + cellInfo.key 
                                })
                        });

                    var elementList = $("<div height=200 width=300 />").dxList({
                        dataSource: ds,
                        height: 200,
                        width: 300,
                        showSelectionControls: true,
                        selectionMode: "multiple"
                    });

                    elementList.appendTo(rootElement);
                    var listInstance = elementList.dxList("instance");

                    var elementButtonDelete = $("<div style='margin-left:10px' />").dxButton({
                        stylingMode: "contained",
                        text: "Delete",
                        type: "normal",
                        width: 120,
                        height: 40,
                        onClick: function () {
                            var arrSelectedItems = listInstance.option("selectedItems");
                            if (arrSelectedItems.length > 0) {
                                const Http = new XMLHttpRequest();
                                const url = 'api/Companies/DeleteCompanyForNews/' + cellInfo.key + '/' + arrSelectedItems;
                                Http.open("GET", url);
                                Http.send();

                                Http.onreadystatechange = (e) => {
                                    ds.reload();
                                    DevExpress.ui.notify("Companies deleted from article: " + arrSelectedItems);
                                    console.log(Http.responseText);
                                }
                            }
                        }
                    });

                    elementButtonDelete.appendTo(rootElement);

                    var elementSelectBox = $("<div style='height:40px; width:300px;margin-left:200px' />").dxSelectBox({
                        dataSource: DevExpress.data.AspNet.createStore({
                            key: "Id",
                            loadUrl: "api/Companies"
                        }),
                        onValueChanged: function (data) {
                            selectedNewCompany = data.value;
                        }
                    });
                    elementSelectBox.appendTo(rootElement);

                    var elementButtonAdd = $("<div style='margin-left: 10px' />").dxButton({
                        stylingMode: "contained",
                        text: "Add",
                        type: "normal",
                        width: 120,
                        height: 40,
                        onClick: function () {
                            if (selectedNewCompany) {
                                const Http = new XMLHttpRequest();
                                const url = 'api/Companies/AddCompanyToNews/' + cellInfo.key + '/' + selectedNewCompany;
                                Http.open("GET", url);
                                Http.send();

                                Http.onreadystatechange = (e) => {
                                    ds.reload();
                                    DevExpress.ui.notify("New company \"" + selectedNewCompany + " \" added to article.");
                                    console.log(Http.responseText);
                                }
                            }
                        }
                    });
                    elementButtonAdd.appendTo(rootElement);
                    rootElement.appendTo(itemElement);
                }
            },
            {
                dataField: "dateStartVisible",
                caption: "Start visible from",
                dataType: "datetime",
                format: "MM/dd/yyyy hh:mm",
                visible: true
            }
        ],
        editing: {
            mode: "popup",
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            popup: {
                title: "Article",
                showTitle: true,
                my: "top",
                at: "top",
                of: window
            },
            form: {
                colCount: 2,
                items: ["date",
                    {
                        dataField: "isAdvertising",
                        dataType: "boolean"
                    },
                    "title", "subtitle",
                    {
                        colSpan: 2,
                        dataField: "newsText",
                        //editorOptions: {
                        //    height: 550,
                        //    activeStateEnabled: true,
                        //    //toolbar: {
                        //    //    items: [
                        //    //        "undo", "redo", "separator",
                        //    //        {
                        //    //            formatName: "size",
                        //    //            formatValues: ["8pt", "10pt", "12pt", "14pt", "18pt", "24pt", "36pt"]
                        //    //        },
                        //    //        {
                        //    //            formatName: "font",
                        //    //            formatValues: ["Arial", "Courier New", "Georgia", "Impact", "Lucida Console", "Tahoma", "Times New Roman", "Verdana"]
                        //    //        },
                        //    //        "separator", "bold", "italic", "strike", "underline", "separator",
                        //    //        "alignLeft", "alignCenter", "alignRight", "alignJustify", "separator",
                        //    //        "orderedList", "bulletList", "separator",
                        //    //        {
                        //    //            formatName: "header",
                        //    //            formatValues: [false, 1, 2, 3, 4, 5]
                        //    //        }, "separator",
                        //    //        "color", "background", "separator",
                        //    //        "link", "image", "separator",
                        //    //        "clear", "codeBlock", "blockquote"
                        //    //    ]
                        //    //}
                        //}
                    },
                    {
                        colSpan: 2,
                        dataField: "imageRelativeUrl",
                    },
                    {
                        dataField: "dateModified",
                        dataType: "datetime",
                    },
                    "slug",
                    "order",
                    "companyName",
                    {
                        dataField: "prioDeadLine",
                        dataType: "datetime"
                    },
                    "label",
                    {
                        dataField: "isPublished",
                        dataType: "boolean"
                    },
                    {
                        dataField: "actualDeadLine",
                        dataType: "datetime"
                    },
                    {
                        dataField: "isBorsvarldenArticle",
                        dataType: "boolean",
                        visible: true
                    },
                    {
                        width: 50,
                        dataField: "dateStartVisible",
                        dataType: "datetime",
                        visible: true
                    },
                    {
                        dataField: "isHotStocks",
                        dataType: "boolean",
                        visible: true
                    },
                    {
                        dataField: "is15MinutesVideo",
                        dataType: "boolean",
                        visible: true
                    },
                    {
                        colSpan: 2,
                        dataField: "FinwireNew2FinwireCompanies",
                        visible: true
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