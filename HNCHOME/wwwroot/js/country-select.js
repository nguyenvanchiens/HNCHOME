$(document).ready(function () {
    $("#select2").change(function () {
        var id = $("#select2").val();
        $.ajax({
            type: 'GET',
            url: '/Branch/GetBranchById',
            contentType: 'application/json; charset=utf-8',
            data: { id },
            success: function (data) {
                console.log(data);
                let option = '<option value = ""> ----Chọn tỉnh thành-----</option>';
                if (data != null && data.length != 0) {
                    for (var i = 0; i < data.length; i++) {
                        option += '<option value="' + data[i].brandId + '">' + data[i].brandName + '</option>';
                    }
                    document.getElementById("password").innerHTML = option;
                }
                else if (data == null || data.length == 0){
                    document.getElementById("password").innerHTML = '<option value = ""> ----Chọn tỉnh thành-----</option>';
                }

            },
            error: function (response) {
                console.log(response);
            }
        })
    });
})