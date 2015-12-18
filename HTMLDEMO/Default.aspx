<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HTMLDEMO._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.raty.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div_Stars">
    </div>
    <div id="div_info">
    </div>
    </form>
</body>
<script type="text/javascript">
    $(function () {
        $.fn.raty.defaults.path = 'img/';
        var data = "";
        $.ajax({
            type: "post",
            dataType: "html",
            data: data,
            url: "/TableInfo.ashx",
            success: function (msg) {
                $("#div_info").html("");
                $("#div_info").append(msg);
            },
            error: function (msg) {

            }
        })
    })

    function func(siam) {
        //初始化星星评价模块
        if ($('#div_Stars_' + siam + ' input[name="score"]').val()==null) {
            $('#div_Stars_' + siam).raty();
        }
        $("#div_" + siam).slideToggle("slow");
    }
    function func_hide(siam) {
        func_submit(siam);
        $("#div_" + siam).slideUp("slow");
    }

    function func_submit(siam) {
        //Ajax提交部分
        alert('提交给服务器的内容如下：评价星星数目：' + $('#div_Stars_' + siam + ' input[name="score"]').attr("value") + "编号：" + siam);
    }
</script>
</html>
