//过滤<script><\/script>标签
function clearScript(s) {  
    return s.replace(/<script.*?>.*?<\/script>/ig, '');  
}

var showMsg = function(content,fn){
	var newlayer=layer.open({
		content: content,
		btn: '确定',
		shadeClose: false,
		yes: function(){
			if(typeof(fn) == "function"){
				fn();
			}
			layer.close(newlayer);
		}
	});
}

var validselector = function(obj,type) {
	switch(type){
		case "mobile":
		regex = /^0?((1[3|5|8|4][0-9]\d{8})|(17\d{9}))$/;
		msg = "请正确输入手机号码";
		break;
		
		case "username":
		regex = /^[a-zA-Z0-9_.@]{5,16}$/;
		msg = "5-16位[字符、数字、_.@]";
		break;
		
		case "password":
		regex=/(?=^[0-9a-zA-Z]{6,16}$)((?=.*[0-9])(?=.*[^0-9])|(?=.*[a-zA-Z])(?=.*[^a-zA-Z]))/;
		msg = "6-16位字母和数字的组合";
		break;
		
		case "email":
		regex = /^(\w)+(\.\w+)*@(\w)+((\.\w+)+)$/;
		msg = "邮箱格式不正确";
		break;

		case "idcard":
		regex = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/;
		msg = "身份证号码不正确";
		break;
		
		case "validcode":
		regex = /^\d{6}$/;
		msg = "请输入手机验证码";
		break;
		
		case "openid":
		regex = /^[a-zA-Z0-9_.@]{5,16}$/;
		msg = "请输入推荐人";
		break;

		case "notnull":
		regex = /^.+$/;
		msg = "不能为空";
		break;

		case "num":
		regex = /^[0-9.]+$/;
		msg = "请输入数字";
		break;
	}
	
	if(!regex.test($(obj).val())){
		var selector = $(obj).attr("id");
		addFocus(selector,msg);
		return false;
	}
	return true;
}

function addFocus(selector,msg) {
	$("#block-"+selector).addClass('has-error').delegate("input","focus",function(){
		clearFocus($(this).attr("id"));
	});
	errshow(selector,msg);
}

function clearFocus(selector) {
	$("#block-"+selector).removeClass('has-error');
	errshow(selector,'&nbsp;');
}

var errshow = function(selector,msg){
	$("#error-"+selector).html(msg);
}

var overlayclick = function(){
	$("#sidenav-toggle").click();
}