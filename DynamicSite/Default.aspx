<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="DynamicSite.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JQuery</title>
    <link rel="Stylesheet" href="Content/bootstrap.css" />
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="Scripts/jqGrid/jquery.jqGrid.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/redmond/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <style type="text/css">
        flash
        {
            font-size: 16;
            opacity: 0.3;
        }
        
        div.center
        {
            position: relative;
            margin-left: auto;
            margin-right: auto;
            margin-bottom: auto;
            margin-top: auto;
            height: 50%;
            width: 50%;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

            $('.flash').mouseleave(function () {
                $(this).animate({ opacity: 0.3 }, "slow");
                $(this).css("font-size", 14);
            });
            $('.flash').mouseenter(function () {
                $(this).animate({ opacity: 1 }, "fast");
                $(this).css("font-size", 16);
            });

            $('#refresh').click(function () {
                var msg = new String();
                var name = $('#name').val();
                msg = "Hello, " + name + "! I am JQuery!";
                $('#messageLocal').text(msg);
            });
            $("#submit").click(function () {
                var name = "name=" + $('#name').val();
                $.ajax({
                    type: "GET",
                    url: "API.svc/Msg",
                    data: name,
                    cache: false,
                    success: function (r) {
                        $('#messageSvc').text(r.d);
                    }

                });

            });           
            
            
            $("#filltable").click(function () {
                var name = "name=" + $('#name').val();
                $.ajax({
                    type: "GET",
                    url: "API.svc/Fill",
                    cache: false,
                    success: function (r) {
                        //$('#messageSvc').text(r.d);
                        var data = r.d;

                        $("#grid").jqGrid({
                            datatype: "local",
                            height: 250,
                            colNames: ['№', 'Название', 'Цена', 'Количество', 'Стоимость'],
                            colModel: [{
                                name: 'num',
                                index: 'num',
                                width: 60,
                                sorttype: "int"},
                                {
                                    name: 'name',
                                    index: 'name',
                                    width: 190,
                                    sorttype: "string"},
                                {
                                    name: 'price',
                                    index: 'price',
                                    width: 130,
                                    sorttype: "float"},
                                {
                                    name: 'count',
                                    index: 'count',
                                    width: 180,
                                    sorttype: "int"},
                                {
                                    name: 'cost',
                                    index: 'cost',
                                    width: 180,
                                    sorttype: "float"}
                            ]
                        });

                        var names = ["num", "name", "price", "count", "cost"];
                        var mydata = [];

                        for (var i = 0; i < data.length; i++) {
                            mydata[i] = {};
                            for (var j = 0; j < data[i].length; j++) {
                                mydata[i][names[j]] = data[i][j];
                            }
                        }

                        for (var i = 0; i <= mydata.length; i++) {
                            $("#grid").jqGrid('addRowData', i + 1, mydata[i]);
                        }
                    }
                });
            });   
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="well center" id="contenet">
        <span id="Welcome" class="text-info flash">Привет, введите своё имя:</span>
        <br />
        <input type="text" id="name" value="Серёга" />
        <br />
        <input type="button" value="обновить" class="btn btn-mini btn-success" id="refresh" />
        <span id="messageLocal" class="text-info flash">Текст</span>
        <br />
        <input type="button" value="получить" class="btn btn-mini btn-success" id="submit" />
        <span id="messageSvc" class="text-info flash">Текст</span>
    </div>
    <div class="well center" style="width: 80%;">
        <table id="grid">
        </table>
    </div>
    <div class="well center" style="width: 80%;">
        <input type="button" value="заполнить" class="btn btn-mini btn-success" id="filltable" />
    </div>
    </form>
</body>
</html>
