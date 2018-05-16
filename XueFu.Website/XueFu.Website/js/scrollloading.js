// JavaScript Document
var currentpage=1;
$(document).ready(function() {
	$("#loadMore").show();
	setTimeout("loadData()", 100);
});
var window_scroll = function() {//判断是否显示数据
	if ($(window).scrollTop() + $(window).height() >= $(document).height()*4/5) {
		$("#loadMore").show();
		$(window).unbind("scroll",window_scroll);
		setTimeout("loadData()", 500);
	}
};
var loadData = function() {//Ajax获取服务器数据
	var action = $("#datalist").data("action");
	$.ajax({//初始化
		url: "Ajax.aspx",
		type: 'GET',
		data: { Page: currentpage, Action: action },
		dateType: 'html',
		timeout: 10000,
		success: function(msg) {
			if (msg == "") {
				$("#loadMore").css("background-image","none").html("加载完成了");
				return false;
			} else {
				$("#datalist").append(msg);
				currentpage+=1;
				$(window).bind("scroll",window_scroll);
				$("#loadMore").hide();
			}
		}
	});
};