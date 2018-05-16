$(document).ready(function(){
	
	var CheckUserName = function(userName,fn1,fn2){
		$.ajax({
            url: "/Ajax.aspx?Action=CheckUserName&UserName="+userName,
            type: "POST",
            data: {},
            async: false,
            success: function(data) {
                data = JSON.parse(clearScript(data));
                if(data.result == "0"){
					fn2();
				}
				else{
					fn1();
				}
            }
        });
	}

	$("#loginbutton").click(function(){
		var validResult = true;
		validResult = validselector($("#username"),"username") && validResult;
		validResult = validselector($("#password"),"password") && validResult;
		if(validResult){			
			var userName = $("#username").val(),
			password = $("#password").val();
			$.post('/admin/Ajax.aspx?Action=Login', {UserName: userName, Password:password}, function(data, textStatus, xhr) {
				data = JSON.parse(clearScript(data));
				if(data.result == "true"){
					window.location.href = "Default.aspx";
				}
				else{
					showMsg("用户名或密码错误！");
				}
			});
		}
	});
	
});