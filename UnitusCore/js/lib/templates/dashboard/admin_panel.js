define(["jade"],function(jade){

return function template(locals) {
var buf = [];
var jade_mixins = {};
var jade_interp;

buf.push("<div id=\"adminSidebar\" class=\"sidebar\"><ul role=\"tablist\" class=\"nav nav-tabs\"><li role=\"presentation\" class=\"active\"><a href=\"#adminNewCircle\" aria-controls=\"adminNewCircle\" role=\"tab\" data-toggle=\"tab\"><i class=\"glyphicon glyphicon-plus\"></i><span class=\"title\">新規団体追加</span></a></li><li role=\"presentation\"><a href=\"#adminUserList\" aria-controls=\"adminUserList\" role=\"tab\" data-toggle=\"tab\"><i class=\"glyphicon glyphicon-th-list\"></i><span class=\"title\">ユーザー一覧</span></a></li></ul></div><div id=\"adminContent\" class=\"content\"><div class=\"tab-content\"><div id=\"adminNewCircle\" role=\"tabpanel\" class=\"tab-pane fade in active\"><h1>新規団体追加<div data-js=\"markdown\" class=\"label label-default\">プレビュー</div></h1><form><div class=\"form-group\"><label for=\"circle_name\">団体名</label><input id=\"circle_name\" type=\"text\" placeholder=\"応用数学研究部\" class=\"form-control\"/><label for=\"circle_description\">団体説明を記入</label><textarea id=\"circle_description\" placeholder=\"団体説明を記入\" rows=\"10\" class=\"form-control\"></textarea><label for=\"circle_num\">人数</label><input id=\"circle_num\" type=\"text\" placeholder=\"18\" class=\"form-control\"/><label for=\"site_name\">ウェブサイト</label><input id=\"site_name\" type=\"text\" placeholder=\"http://unitus-ac.com\" class=\"form-control\"/><label for=\"university\">所属大学</label><input id=\"university\" type=\"text\" placeholder=\"東京理科大学\" class=\"form-control\"/><label for=\"remarks\">備考</label><textarea id=\"remarks\" placeholder=\"インカレサークルです。\" class=\"form-control\"></textarea><label for=\"contact\">連絡先</label><input id=\"contact\" type=\"text\" placeholder=\"Tel: 090123456\" class=\"form-control\"/><label for=\"leader\">代表者</label><input id=\"leader\" type=\"text\" placeholder=\"@hogehoge\" class=\"form-control\"/><div class=\"checkbox\"><label><input id=\"isAcceptOutside\" type=\"checkbox\"/> 外部生のサークル加入可否</label></div><div class=\"pull-right\"><button type=\"submit\" class=\"btn btn-primary\">保存する</button></div><div class=\"clear\"></div></div></form></div><div id=\"adminUserList\" role=\"tabpanel\" class=\"tab-pane fade\"><h1>ユーザー一覧</h1><table><thead><tr><th class=\"name_w\">名前</th><th class=\"author_w\">権限</th><th class=\"number_w\">学年</th><th class=\"university_w\">所属大学</th><th class=\"mail_w\">メールアドレス</th></tr></thead><tbody data-js=\"userList\"></tbody></table></div></div></div><div id=\"adminOptionbar\"><div data-js=\"close_admin\" class=\"close_btn\"><div class=\"glyphicon glyphicon-remove\"></div></div></div>");;return buf.join("");
};

});
