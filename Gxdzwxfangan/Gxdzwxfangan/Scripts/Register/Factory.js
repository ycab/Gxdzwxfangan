

$(function () {

    $('.js_file_chat_head').on('change', function (event) {
        var files = event.target.files;
        // 允许上传的图片类型  
        var allowTypes = ['image/jpg', 'image/jpeg', 'image/png', 'image/gif'];
        // 1024KB，也就是 1MB  
        var maxSize = 5 * 1024 * 1024;
        // 图片最大宽度  
        var maxWidth = 600;
        // 最大上传图片数量  
        var maxCount = 1;
        // 如果没有选中文件，直接返回  
        if (files.length === 0) {
            return;
        }

        for (var i = 0, len = files.length; i < len; i++) {
            var file = files[i];
            var reader = new FileReader();

            // 如果类型不在允许的类型范围内  
            if (allowTypes.indexOf(file.type) === -1) {
                alter("该类型不允许上传");
                continue;
            }

            if (file.size > maxSize) {
                alter("图片太大，不允许上传");
                continue;
            }

            if ($('.chat_head_flag').length >= maxCount) {
                alter("最多只能上传" + maxCount + "张图片");
                return;
            }

            reader.onload = function (e) {
                var img = new Image();
                img.onload = function () {
                    // 不要超出最大宽度  
                    var w = Math.min(maxWidth, img.width);
                    // 高度按比例计算  
                    var h = img.height * (w / img.width);
                    var canvas = document.createElement('canvas');
                    var ctx = canvas.getContext('2d');
                    // 设置 canvas 的宽度和高度  
                    canvas.width = w;
                    canvas.height = h;
                    ctx.drawImage(img, 0, 0, w, h);
                    var base64 = canvas.toDataURL('image/png');

                    // 插入到预览区  
                    var $preview = $('<li class="weui_uploader_file weui_uploader_status chat_head_flag" style="background-image:url(' + base64 + ')"><div class="weui_uploader_status_content">0%</div></li>');
                    $('.view_chat_head').append($preview);
                    var num = $('.chat_head_flag').length;
                    $('.js_counter_chat_head').text(num + '/' + maxCount);

                    // 然后假装在上传，可以post base64格式，也可以构造blob对象上传，也可以用微信JSSDK上传  

                    $chat_head_gallery = $("#chat_head_gallery"),
                    $chat_head_galleryImg = $("#chat_head_galleryImg"),
                    $chat_head_uploaderFiles = $("#chat_head_uploaderFiles");
                    var index; //第几张图片
                    $chat_head_uploaderFiles.on("click", "li", function () {
                        index = $(this).index();
                        $chat_head_galleryImg.attr("style", this.getAttribute("style"));
                        $chat_head_gallery.fadeIn(100);
                    });
                    $chat_head_gallery.on("click", function () {
                        $chat_head_gallery.fadeOut(100);
                    });
                    //删除图片 删除图片的代码也贴出来。
                    $(".chat_head_delete").click(function () { //这部分刚才放错地方了，放到$(function(){})外面去了
                        console.log('删除');
                        $chat_head_uploaderFiles.find("li").eq(index).remove();
                        $('.js_counter_chat_head').text(0 + '/' + 1);
                    });

                    var progress = 0;

                    function uploading() {
                        $preview.find('.weui_uploader_status_content').text(++progress + '%');
                        if (progress < 100) {
                            setTimeout(uploading, 10);
                        } else {
                            // 如果是失败，塞一个失败图标  
                            //$preview.find('.weui_uploader_status_content').html('<i class="weui_icon_warn"></i>');  
                            $preview.removeClass('weui_uploader_status').find('.weui_uploader_status_content').remove();
                        }
                    }
                    setTimeout(uploading, 10);
                };

                img.src = e.target.result;
            };
            reader.readAsDataURL(file);
        }
    });
});

$(function () {

    $('.js_file_business_license').on('change', function (event) {
        var files = event.target.files;
        // 允许上传的图片类型  
        var allowTypes = ['image/jpg', 'image/jpeg', 'image/png', 'image/gif'];
        // 1024KB，也就是 1MB  
        var maxSize = 5 * 1024 * 1024;
        // 图片最大宽度  
        var maxWidth = 600;
        // 最大上传图片数量  
        var maxCount = 1;
        // 如果没有选中文件，直接返回  
        if (files.length === 0) {
            return;
        }

        for (var i = 0, len = files.length; i < len; i++) {
            var file = files[i];
            var reader = new FileReader();

            // 如果类型不在允许的类型范围内  
            if (allowTypes.indexOf(file.type) === -1) {
                alter("该类型不允许上传");
                continue;
            }

            if (file.size > maxSize) {
                alter("最多只能上传" + maxCount + "张图片");
                continue;
            }

            if ($('.business_license_flag').length >= maxCount) {
                alter("最多只能上传" + maxCount + "张图片");
                return;
            }

            reader.onload = function (e) {
                var img = new Image();
                img.onload = function () {
                    // 不要超出最大宽度  
                    var w = Math.min(maxWidth, img.width);
                    // 高度按比例计算  
                    var h = img.height * (w / img.width);
                    var canvas = document.createElement('canvas');
                    var ctx = canvas.getContext('2d');
                    // 设置 canvas 的宽度和高度  
                    canvas.width = w;
                    canvas.height = h;
                    ctx.drawImage(img, 0, 0, w, h);
                    var base64 = canvas.toDataURL('image/png');

                    // 插入到预览区  
                    var $preview = $('<li class="weui_uploader_file weui_uploader_status business_license_flag" style="background-image:url(' + base64 + ')"><div class="weui_uploader_status_content">0%</div></li>');
                    $('.view_business_license').append($preview);
                    var num = $('.business_license_flag').length;
                    $('.js_counter_business_license').text(num + '/' + maxCount);

                    // 然后假装在上传，可以post base64格式，也可以构造blob对象上传，也可以用微信JSSDK上传  

                    $business_license_gallery = $("#business_license_gallery"),
                    $business_license_galleryImg = $("#business_license_galleryImg"),
                    $business_license_uploaderFiles = $("#business_license_uploaderFiles");
                    var index; //第几张图片
                    $business_license_uploaderFiles.on("click", "li", function () {
                        index = $(this).index();
                        $business_license_galleryImg.attr("style", this.getAttribute("style"));
                        $business_license_gallery.fadeIn(100);
                    });
                    $business_license_gallery.on("click", function () {
                        $business_license_gallery.fadeOut(100);
                    });
                    //删除图片 删除图片的代码也贴出来。
                    $(".business_license_delete").click(function () { //这部分刚才放错地方了，放到$(function(){})外面去了
                        console.log('删除');
                        $business_license_uploaderFiles.find("li").eq(index).remove();
                        $('.js_counter_business_license').text(0 + '/' + 1);
                    });

                    var progress = 0;

                    function uploading() {
                        $preview.find('.weui_uploader_status_content').text(++progress + '%');
                        if (progress < 100) {
                            setTimeout(uploading, 10);
                        } else {
                            // 如果是失败，塞一个失败图标  
                            //$preview.find('.weui_uploader_status_content').html('<i class="weui_icon_warn"></i>');  
                            $preview.removeClass('weui_uploader_status').find('.weui_uploader_status_content').remove();
                        }
                    }
                    setTimeout(uploading, 10);
                };

                img.src = e.target.result;
            };
            reader.readAsDataURL(file);
        }
    });
});

$(function () {

    $('.js_file_credential').on('change', function (event) {
        var files = event.target.files;
        // 允许上传的图片类型  
        var allowTypes = ['image/jpg', 'image/jpeg', 'image/png', 'image/gif'];
        // 1024KB，也就是 1MB  
        var maxSize = 5 * 1024 * 1024;
        // 图片最大宽度  
        var maxWidth = 600;
        // 最大上传图片数量  
        var maxCount = 1;
        // 如果没有选中文件，直接返回  
        if (files.length === 0) {
            return;
        }

        for (var i = 0, len = files.length; i < len; i++) {
            var file = files[i];
            var reader = new FileReader();

            // 如果类型不在允许的类型范围内  
            if (allowTypes.indexOf(file.type) === -1) {
                alter("该类型不允许上传");
                continue;
            }

            if (file.size > maxSize) {
                alter("图片太大，不允许上传");
                continue;
            }

            if ($('.credential_flag').length >= maxCount) {
                alter("最多只能上传" + maxCount + "张图片");
                return;
            }

            reader.onload = function (e) {
                var img = new Image();
                img.onload = function () {
                    // 不要超出最大宽度  
                    var w = Math.min(maxWidth, img.width);
                    // 高度按比例计算  
                    var h = img.height * (w / img.width);
                    var canvas = document.createElement('canvas');
                    var ctx = canvas.getContext('2d');
                    // 设置 canvas 的宽度和高度  
                    canvas.width = w;
                    canvas.height = h;
                    ctx.drawImage(img, 0, 0, w, h);
                    var base64 = canvas.toDataURL('image/png');

                    // 插入到预览区  
                    var $preview = $('<li class="weui_uploader_file weui_uploader_status credential_flag" style="background-image:url(' + base64 + ')"><div class="weui_uploader_status_content">0%</div></li>');
                    $('.view_credential').append($preview);
                    var num = $('.credential_flag').length;
                    $('.js_counter_credential').text(num + '/' + maxCount);

                    // 然后假装在上传，可以post base64格式，也可以构造blob对象上传，也可以用微信JSSDK上传  

                    $credential_gallery = $("#credential_gallery"),
                    $credential_galleryImg = $("#credential_galleryImg"),
                    $credential_uploaderFiles = $("#credential_uploaderFiles");
                    var index; //第几张图片
                    $credential_uploaderFiles.on("click", "li", function () {
                        index = $(this).index();
                        $credential_galleryImg.attr("style", this.getAttribute("style"));
                        $credential_gallery.fadeIn(100);
                    });
                    $credential_gallery.on("click", function () {
                        $credential_gallery.fadeOut(100);
                    });
                    //删除图片 删除图片的代码也贴出来。
                    $(".credential_delete").click(function () { //这部分刚才放错地方了，放到$(function(){})外面去了
                        console.log('删除');
                        $credential_uploaderFiles.find("li").eq(index).remove();
                        $('.js_counter_credential').text(0 + '/' + 1);
                    });

                    var progress = 0;

                    function uploading() {
                        $preview.find('.weui_uploader_status_content').text(++progress + '%');
                        if (progress < 100) {
                            setTimeout(uploading, 10);
                        } else {
                            // 如果是失败，塞一个失败图标  
                            //$preview.find('.weui_uploader_status_content').html('<i class="weui_icon_warn"></i>');  
                            $preview.removeClass('weui_uploader_status').find('.weui_uploader_status_content').remove();
                        }
                    }
                    setTimeout(uploading, 10);
                };

                img.src = e.target.result;
            };
            reader.readAsDataURL(file);
        }
    });
});

$(function () {

    $('.js_file_honor').on('change', function (event) {
        var files = event.target.files;
        // 允许上传的图片类型  
        var allowTypes = ['image/jpg', 'image/jpeg', 'image/png', 'image/gif'];
        // 1024KB，也就是 1MB  
        var maxSize = 5 * 1024 * 1024;
        // 图片最大宽度  
        var maxWidth = 600;
        // 最大上传图片数量  
        var maxCount = 1;
        // 如果没有选中文件，直接返回  
        if (files.length === 0) {
            return;
        }

        for (var i = 0, len = files.length; i < len; i++) {
            var file = files[i];
            var reader = new FileReader();

            // 如果类型不在允许的类型范围内  
            if (allowTypes.indexOf(file.type) === -1) {
                alter("该类型不允许上传");
                continue;
            }

            if (file.size > maxSize) {
                alter("图片太大，不允许上传");
                continue;
            }

            if ($('.honor_flag').length >= maxCount) {
                alter("最多只能上传" + maxCount + "张图片");
                return;
            }

            reader.onload = function (e) {
                var img = new Image();
                img.onload = function () {
                    // 不要超出最大宽度  
                    var w = Math.min(maxWidth, img.width);
                    // 高度按比例计算  
                    var h = img.height * (w / img.width);
                    var canvas = document.createElement('canvas');
                    var ctx = canvas.getContext('2d');
                    // 设置 canvas 的宽度和高度  
                    canvas.width = w;
                    canvas.height = h;
                    ctx.drawImage(img, 0, 0, w, h);
                    var base64 = canvas.toDataURL('image/png');

                    // 插入到预览区  
                    var $preview = $('<li class="weui_uploader_file weui_uploader_status honor_flag" style="background-image:url(' + base64 + ')"><div class="weui_uploader_status_content">0%</div></li>');
                    $('.view_honor').append($preview);
                    var num = $('.honor_flag').length;
                    $('.js_counter_honor').text(num + '/' + maxCount);

                    // 然后假装在上传，可以post base64格式，也可以构造blob对象上传，也可以用微信JSSDK上传  

                    $honor_gallery = $("#honor_gallery"),
                    $honor_galleryImg = $("#honor_galleryImg"),
                    $honor_uploaderFiles = $("#honor_uploaderFiles");
                    var index; //第几张图片
                    $honor_uploaderFiles.on("click", "li", function () {
                        index = $(this).index();
                        $honor_galleryImg.attr("style", this.getAttribute("style"));
                        $honor_gallery.fadeIn(100);
                    });
                    $honor_gallery.on("click", function () {
                        $honor_gallery.fadeOut(100);
                    });
                    //删除图片 删除图片的代码也贴出来。
                    $(".honor_delete").click(function () { //这部分刚才放错地方了，放到$(function(){})外面去了
                        console.log('删除');
                        $honor_uploaderFiles.find("li").eq(index).remove();
                        $('.js_counter_honor').text(0 + '/' + 1);
                    });

                    var progress = 0;

                    function uploading() {
                        $preview.find('.weui_uploader_status_content').text(++progress + '%');
                        if (progress < 100) {
                            setTimeout(uploading, 10);
                        } else {
                            // 如果是失败，塞一个失败图标  
                            //$preview.find('.weui_uploader_status_content').html('<i class="weui_icon_warn"></i>');  
                            $preview.removeClass('weui_uploader_status').find('.weui_uploader_status_content').remove();
                        }
                    }
                    setTimeout(uploading, 10);
                };

                img.src = e.target.result;
            };
            reader.readAsDataURL(file);
        }
    });
});

$(function () {

    $('.js_file_related_picture').on('change', function (event) {
        var files = event.target.files;
        // 允许上传的图片类型  
        var allowTypes = ['image/jpg', 'image/jpeg', 'image/png', 'image/gif'];
        // 1024KB，也就是 1MB  
        var maxSize = 5 * 1024 * 1024;
        // 图片最大宽度  
        var maxWidth = 600;
        // 最大上传图片数量  
        var maxCount = 1;
        // 如果没有选中文件，直接返回  
        if (files.length === 0) {
            return;
        }

        for (var i = 0, len = files.length; i < len; i++) {
            var file = files[i];
            var reader = new FileReader();

            // 如果类型不在允许的类型范围内  
            if (allowTypes.indexOf(file.type) === -1) {
                alter("该类型不允许上传");
                continue;
            }

            if (file.size > maxSize) {
                alter("图片太大，不允许上传");
                continue;
            }

            if ($('.related_picture_flag').length >= maxCount) {
                alter("最多只能上传" + maxCount + "张图片");
                return;
            }

            reader.onload = function (e) {
                var img = new Image();
                img.onload = function () {
                    // 不要超出最大宽度  
                    var w = Math.min(maxWidth, img.width);
                    // 高度按比例计算  
                    var h = img.height * (w / img.width);
                    var canvas = document.createElement('canvas');
                    var ctx = canvas.getContext('2d');
                    // 设置 canvas 的宽度和高度  
                    canvas.width = w;
                    canvas.height = h;
                    ctx.drawImage(img, 0, 0, w, h);
                    var base64 = canvas.toDataURL('image/png');

                    // 插入到预览区  
                    var $preview = $('<li class="weui_uploader_file weui_uploader_status related_picture_flag" style="background-image:url(' + base64 + ')"><div class="weui_uploader_status_content">0%</div></li>');
                    $('.view_related_picture').append($preview);
                    var num = $('.related_picture_flag').length;
                    $('.js_counter_related_picture').text(num + '/' + maxCount);

                    // 然后假装在上传，可以post base64格式，也可以构造blob对象上传，也可以用微信JSSDK上传  

                    $related_picture_gallery = $("#related_picture_gallery"),
                    $related_picture_galleryImg = $("#related_picture_galleryImg"),
                    $related_picture_uploaderFiles = $("#related_picture_uploaderFiles");
                    var index; //第几张图片
                    $related_picture_uploaderFiles.on("click", "li", function () {
                        index = $(this).index();
                        $related_picture_galleryImg.attr("style", this.getAttribute("style"));
                        $related_picture_gallery.fadeIn(100);
                    });
                    $related_picture_gallery.on("click", function () {
                        $related_picture_gallery.fadeOut(100);
                    });
                    //删除图片 删除图片的代码也贴出来。
                    $(".related_picture_delete").click(function () { //这部分刚才放错地方了，放到$(function(){})外面去了
                        console.log('删除');
                        $related_picture_uploaderFiles.find("li").eq(index).remove();
                        $('.js_counter_related_picture').text(0 + '/' + 1);
                    });

                    var progress = 0;

                    function uploading() {
                        $preview.find('.weui_uploader_status_content').text(++progress + '%');
                        if (progress < 100) {
                            setTimeout(uploading, 10);
                        } else {
                            // 如果是失败，塞一个失败图标  
                            //$preview.find('.weui_uploader_status_content').html('<i class="weui_icon_warn"></i>');  
                            $preview.removeClass('weui_uploader_status').find('.weui_uploader_status_content').remove();
                        }
                    }
                    setTimeout(uploading, 10);
                };

                img.src = e.target.result;
            };
            reader.readAsDataURL(file);
        }
    });
});

$(function () {

    $('.js_file_quality_guaratee').on('change', function (event) {
        var files = event.target.files;
        // 允许上传的图片类型  
        var allowTypes = ['image/jpg', 'image/jpeg', 'image/png', 'image/gif'];
        // 1024KB，也就是 1MB  
        var maxSize = 5 * 1024 * 1024;
        // 图片最大宽度  
        var maxWidth = 600;
        // 最大上传图片数量  
        var maxCount = 1;
        // 如果没有选中文件，直接返回  
        if (files.length === 0) {
            return;
        }

        for (var i = 0, len = files.length; i < len; i++) {
            var file = files[i];
            var reader = new FileReader();

            // 如果类型不在允许的类型范围内  
            if (allowTypes.indexOf(file.type) === -1) {
                alter("该类型不允许上传");
                continue;
            }

            if (file.size > maxSize) {
                alter("图片太大，不允许上传");
                continue;
            }

            if ($('.quality_guaratee_flag').length >= maxCount) {
                alter("最多只能上传" + maxCount + "张图片");
                return;
            }

            reader.onload = function (e) {
                var img = new Image();
                img.onload = function () {
                    // 不要超出最大宽度  
                    var w = Math.min(maxWidth, img.width);
                    // 高度按比例计算  
                    var h = img.height * (w / img.width);
                    var canvas = document.createElement('canvas');
                    var ctx = canvas.getContext('2d');
                    // 设置 canvas 的宽度和高度  
                    canvas.width = w;
                    canvas.height = h;
                    ctx.drawImage(img, 0, 0, w, h);
                    var base64 = canvas.toDataURL('image/png');

                    // 插入到预览区  
                    var $preview = $('<li class="weui_uploader_file weui_uploader_status quality_guaratee_flag" style="background-image:url(' + base64 + ')"><div class="weui_uploader_status_content">0%</div></li>');
                    $('.view_quality_guaratee').append($preview);
                    var num = $('.quality_guaratee_flag').length;
                    $('.js_counter_quality_guaratee').text(num + '/' + maxCount);

                    // 然后假装在上传，可以post base64格式，也可以构造blob对象上传，也可以用微信JSSDK上传  

                    $quality_guaratee_gallery = $("#quality_guaratee_gallery"),
                    $quality_guaratee_galleryImg = $("#quality_guaratee_galleryImg"),
                    $quality_guaratee_uploaderFiles = $("#quality_guaratee_uploaderFiles");
                    var index; //第几张图片
                    $quality_guaratee_uploaderFiles.on("click", "li", function () {
                        index = $(this).index();
                        $quality_guaratee_galleryImg.attr("style", this.getAttribute("style"));
                        $quality_guaratee_gallery.fadeIn(100);
                    });
                    $quality_guaratee_gallery.on("click", function () {
                        $quality_guaratee_gallery.fadeOut(100);
                    });
                    //删除图片 删除图片的代码也贴出来。
                    $(".quality_guaratee_delete").click(function () { //这部分刚才放错地方了，放到$(function(){})外面去了
                        console.log('删除');
                        $quality_guaratee_uploaderFiles.find("li").eq(index).remove();
                        $('.js_counter_quality_guaratee').text(0 + '/' + 1);
                    });

                    var progress = 0;

                    function uploading() {
                        $preview.find('.weui_uploader_status_content').text(++progress + '%');
                        if (progress < 100) {
                            setTimeout(uploading, 10);
                        } else {
                            // 如果是失败，塞一个失败图标  
                            //$preview.find('.weui_uploader_status_content').html('<i class="weui_icon_warn"></i>');  
                            $preview.removeClass('weui_uploader_status').find('.weui_uploader_status_content').remove();
                        }
                    }
                    setTimeout(uploading, 10);
                };

                img.src = e.target.result;
            };
            reader.readAsDataURL(file);
        }
    });
});


var handler = function (e) { //禁止浏览器默认行为
    e.preventDefault();
};
$(function () {
    $("input").on("focus", function () {
        this.scrollIntoView();
    })
    clickevent();
})
function clickevent() {
    $('a').unbind("click"); //移除click
    $(".submit").click(publish);
    current();
}
function getFileName(o) {
    var pos = o.lastIndexOf("\\");
    return o.substring(pos + 1);
}

var publish = function () {
    var chat_head_name = getFileName($("#chat_head").val());
    var business_license_name = getFileName($("#business_license").val());
    var credential_name = getFileName($("#credential").val());
    var honor_name = getFileName($("#honor").val());
    var related_picture_name = getFileName($("#related_picture").val());
    var quality_guaratee_name = getFileName($("#quality_guaratee").val());
    var options = {
        type: "POST",
        url: rootUrl + "Home/SetFactoryInfo?chat_head_name=" + chat_head_name + "&business_license_name=" + business_license_name + "&credential_name=" + credential_name + "&honor_name=" + honor_name + "&related_picture_name=" + related_picture_name + "&quality_guaratee_name=" + quality_guaratee_name + "&random=" + Math.floor(Math.random() * (100000 + 1)),
        data: $("#theForm").serialize(),
        dataType: "text",
        success: function (response) {
            if (response == "success") {
                alert("完善成功");
                window.location.href = rootUrl + "Home/GxfaWxIndex";
            }
           // window.location.href = rootUrl + "Register/GxLoginRegisterThree";
        }
    }
    $('#theForm').ajaxSubmit(options);
}
function current() {
    $.ajax({
        type: "post",
        url: rootUrl + "OrderDown/GetOrderDown?random=" + Math.floor(Math.random() * (100000 + 1)),
        data: $("#userform").serialize(),
        dataType: 'json',
        async: true,
        success: function (data) {
            if (data.SIZE_WIDTH != "")
                window.location.href = rootUrl + "Order/GxPcbWxOrderTwo";
        }
    });
}
//var chat_head_not_null = "头像不能为空！";
//var nick_name_not_null = "昵称不能为空！";
//var signature_not_null = "个性签名不能为空！";
//var name_not_null = "姓名不能为空！";
//var company_name_not_null = "企业名称不能为空！";
//var company_industry_involved_not_null = "企业所属行业不能为空！";
//var company_introduce_not_null = "企业介绍不能为空！";
//var business_license_not_null = "营业执照不能为空！";
//var company_capability_not_null = "企业加工能力及产品介绍不能为空！";
//var credential_not_null = "证书不能为空！";
//var honor_not_null = "荣誉不能为空！";
//var architecture_related_not_null = "相关体系介绍不能为空！";
//var related_picture_not_null = "相关图片不能为空！";
//var quality_guarantee_not_null = "质量保证不能为空！";
//var tel_not_null = "电话不能为空！";
//var fax_not_null = "传真不能为空！";
//var email_not_null = "邮箱不能为空！";
//var address_not_null = "地址不能为空！";
//function checkInfo(frm) {
//    var msg = new Array();
//    var err = false;

//    if (Utils.isEmpty(frm.elements['chat_head'].value)) {
//        err = true;
//        msg.push(chat_head_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['nick_name'].value)) {
//        err = true;
//        msg.push(nick_name_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['signature'].value)) {
//        err = true;
//        msg.push(signature_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['name'].value)) {
//        err = true;
//        msg.push(name_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['company_name'].value)) {
//        err = true;
//        msg.push(company_name_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['company_industry_involved'].value)) {
//        err = true;
//        msg.push(company_industry_involved_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['company_introduce'].value)) {
//        err = true;
//        msg.push(company_introduce_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['business_license'].value)) {
//        err = true;
//        msg.push(business_license_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['company_capability'].value)) {
//        err = true;
//        msg.push(company_capability_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['credential'].value)) {
//        err = true;
//        msg.push(credential_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['honor'].value)) {
//        err = true;
//        msg.push(honor_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['architecture_related'].value)) {
//        err = true;
//        msg.push(architecture_related_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['related_picture'].value)) {
//        err = true;
//        msg.push(related_picture_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['quality_guaratee'].value)) {
//        err = true;
//        msg.push(quality_guaratee_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['tel'].value)) {
//        err = true;
//        msg.push(tel_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['fax'].value)) {
//        err = true;
//        msg.push(fax_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['email'].value)) {
//        err = true;
//        msg.push(email_not_null);
//    }
//    if (Utils.isEmpty(frm.elements['address'].value)) {
//        err = true;
//        msg.push(address_not_null);
//    }
//    if (err) {
//        message = msg.join("\n");
//        alert(message);
//    }

//    return !err;
//}