$(document).ready(function(){
	var tabIndex = 0;

	$(".tabitem li").click(function(){
		tabIndex = $(this).index();
		$(this).addClass("active").siblings().removeClass("active");
		$("[data-item]").css("display","none");
		$("[data-item='type-"+tabIndex+"']").css("display","block");
	});
	
	//开放给全局
	switchTab = function(index){
		$('.tabitem li').eq(index).click();
	}

	var CheckUserName = function(userName,fn1,fn2){
		$.ajax({
            url: "/Ajax.aspx?Action=CheckUserName&UserName="+userName,
            type: "POST",
            data: {},
            async: false,
            success: function(data) {
                data = JSON.parse(clearScript(data));
                if(data.result == "true"){
					fn1(data);
				}
				else if(data.result == "false"){
					fn2();
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
			$.post('/Ajax.aspx?Action=Login', {UserName: userName, Password:password}, function(data, textStatus, xhr) {
				data = JSON.parse(clearScript(data));
				if(data.result == "true"){
					if(data.state=="0"){
						showMsg("冻结用户不能登陆，请联系管理员！");
					}
					else if (data.state=="2") {
						window.location.href = "Default.aspx";
					}
					else {
						window.location.href = "UserAdd.aspx?Action=UpdateLoad";
					}					
				}
				else{
					showMsg("用户名或密码错误！");
				}
			});
		}
	});

	$("#userbutton").click(function(){
		var validResult = true,
		action=$("#Action").val();

		if (action == "Add") {
			validResult = validselector($("#introducer"),"openid") && validResult;
			if (validResult) {
				CheckUserName($("#introducer").val(),function(data){
					clearFocus("introducer");
					if (data.state != "2") {
						addFocus("introducer","推荐人的状态不符合要求！");
						validResult = false;
					}
					// if (validResult && data.canIntroduce == "false") {
					// 	addFocus("introducer","报单人的积分不够！");
					// 	validResult = false;
					// }
				},function(){
					addFocus("introducer","推荐人帐号不存在！");
					validResult = false;
				})
			}
			validResult = validselector($("#username"),"username") && validResult;
			if (validResult) {
				CheckUserName($("#username").val(),function(){
					addFocus("username","用户名已存在！");
					validResult = false;
				},function(){
					clearFocus("username");
				})
			}
			validResult = validselector($("#password"),"password") && validResult;
		}
		
		if (action == "Update") {
			validResult = validselector($("#realname"),"notnull") && validResult;
			validResult = validselector($("#sex"),"sex") && validResult;
			validResult = validselector($("#idcard"),"idcard") && validResult;
			if(validResult){
				$.ajax({
					url: "/Ajax.aspx?Action=CheckIDCard",
					type: "POST",
					data: {
						IDCard: $("#idcard").val()
					},
					async: false,
					success: function(data){
						data = JSON.parse(clearScript(data));
						if(data.result == "false"){
							addFocus("idcard","此身份证帐户数超限！");
							validResult = false;
						}
						else{
							clearFocus("idcard");
						}
					}
				});
			}			
			validResult = validselector($("#address"),"notnull") && validResult;
		}
		if(validResult){			
			$(".userinfo").submit();
		}
	});

	$("#changepasswordbutton").click(function(){
		var validResult = true;
		var userName = $("#username").val(),
		password = $("#oldpassword").val(),
		password1 = $("#password1").val(),
		password2 = $("#password2").val();

		validResult = validselector($("#oldpassword"),"password") && validResult;
		validResult = validselector($("#password1"),"password") && validResult;
		validResult = validselector($("#password2"),"password") && validResult;
		if (password1 != password2) {
			addFocus("password2","两次密码不一样！");
			validResult = false;
		}
		if(validResult){
			$.post('/Ajax.aspx?Action=Login', {UserName: userName, Password:password}, function(data) {
				data = JSON.parse(clearScript(data));
				if(data.result == "false"){
					addFocus("oldpassword","密码不正确！");
					validResult = false;
				}
				else{
					clearFocus("oldpassword");
					$(".changepassword").submit();
				}
			});
		}
	});

	$("#transferbutton").click(function(event) {
		var validResult = true;
		validResult = validselector($("#username"),"username") && validResult;
		if(validResult && $("#username").val() == $("#MyselfName").val()) {
			addFocus("username","不能转帐给自己！");
			validResult = false;
		}
		if(validResult) {			
			CheckUserName($("#username").val(),function(){
				clearFocus("username");
			},function(){
				addFocus("username","帐号不存在！");
				validResult = false;
			})
		}
		validResult = validselector($("#money"),"num") && validResult;
		if(validResult){
			$.ajax({
				url: "/Ajax.aspx?Action=CheckTransferMoney",
				type: "POST",
				data: {
					Money: $("#money").val()
				},
				async: false,
				success: function(data){
					data = JSON.parse(clearScript(data));
					if(data.result.toLowerCase() == "false"){
						addFocus("money",data.error);
						validResult = false;
					}
					else{
						clearFocus("money");
					}
				}
			});
		}
		if(validResult){
			$("#transferform").submit();
		}
	});

	var canReport = $("#CanReport");
	if (canReport.length>0) {
		if (canReport.val().toLowerCase() == "false") {
			showMsg("报单所需积分不够！",function(){
				window.location.href="/";
			});
		}
	}

	// 组织架构图开始
	var strtBlocks=$("div.strt-block");
	strtBlocks.each(function(n){
		var childs=$(this).children();
		var w=(childs.last().width() - childs.first().width())/4;
		if(w>0){
			$(this).css("margin-left",w)
		}else{
			$(this).css("padding-right",-w*2);
		}
	});
	// var aw=0;
	// $("#aa").children().each(function(index, el) {
	// 	aw +=$(this).width();
	// });

	// $("#aa").width(aw).css("margin-left",-aw/2);
	
	var strtWrap=$("#strtWrap");
	strtWrap.width(strtWrap.children().width());
	// strtWrap.draggable({
	// 	cursor:"move",
	// 	opacity:0.5
	// });
	// 组织架构图结束
});