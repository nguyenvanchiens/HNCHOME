////$(document).ready(function () {
////    $("#select2").change(function () {
////        var id = $("#select2").val();
////        var data = JSON.stringify({ id: id })
////        $.ajax({
////            type: 'POST',
////            url: '/Branches/GetBranchById',
////            dataType: 'json',
////            contentType: 'application/json',
////            data: data,
////            async: false,
////            success: function (data) {
////                console.log(data);
////            },
////            error: function (data) {
////                console.log(data);
////            }
////        })
////        //console.log($("#select2").val())
////    });
////})