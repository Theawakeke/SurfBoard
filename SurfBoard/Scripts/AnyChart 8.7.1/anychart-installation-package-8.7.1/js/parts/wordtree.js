if(!_.wordtree){_.wordtree=1;(function($){var e5=function(){$.Mq.call(this);$.T(this.ua,xla)},f5=function(a,b){$.Gw.call(this);$.Ft(this,this,this.ng,this.Cg,this.Bv,this.ng,null,null);this.jr=null;this.ju=[];this.eh=[];this.eN=this.tK=null;this.dg=[];this.Ns=[];$.T(this.ua,[["minFontSize",4,1],["maxFontSize",4,1],["postfix",4,1],["fontFamily",4,1],["fontStyle",16,1],["fontWeight",4,1],["fontColor",16,1],["fontOpacity",16,1],["fontDecoration",16,1]]);this.data(a,b)},yla=function(a,b){var c=b.getParent();if(c){for(var d=0;d<c.$b();d++){var e=
c.Ld(d);e!=b&&e.o("hidden",!0)}yla(a,c)}},zla=function(a){for(var b=0;b<a.eh.length;b++)a.eh[b].o("hidden",!1)},Ala=function(a,b,c){if(c.length){for(var d=b.xl(),e=!1,f=0;f<b.$b();f++)if(d[f].get("value")==c[0]){e=!0;break}e?(c.shift(),b=d[f]):(b=b.hc({value:c[0]}),c.shift());return Ala(a,b,c)}return b},Bla=function(a){a=a.split(/\s*(.+?(?:[?!]+|$|\.(?=\s+[A-Z]|$)))\s*/);return a=(0,$.Se)(a,function(a){return!!a.length})},g5=function(a){a=a.split(/([!?,;:.&"-]+|\S*[A-Z]\.|\S*(?:[^!?,;:.\s&-]))/);
return a=(0,$.Se)(a,function(a){return a.length&&" "!=a})},Cla=function(a,b){null!=a.na&&($.Nq(a.na,a.Fd,a),a.na.dd());a.na=b;$.L(a.na,a.Fd,a);a.u(4100,1)},Dla=function(a,b,c){if(b){var d=b.get("fontSize");if(null==d){if((d=b.getParent())&&(1==d.$b()||c))return d=Dla(a,d,c),b.o("fontSize",d),d;c=a.i("maxFontSize");a=a.i("minFontSize");d=b.o("height")/1.5;d=$.Za(d,a,c);b.o("fontSize",d)}return d}return 0},Ela=function(a,b){if(b){var c=b.$b(),d=0;if(c)for(var e=0;e<c;e++)d+=Ela(a,b.Ld(e));else d=b.get("weight")||
1;b.o("leafCount",d).o("weight",d);return d}return 0},Fla=function(a,b,c,d,e,f){if(b){b.o("connectorInXPosition",c[0]).o("connectorInYPosition",c[1]).o("connectorOutXPosition",c[0]+a.zU(b)).o("connectorOutYPosition",c[1]);var h=a.Sf.Za();if(d<h){c=a.sl();var k=b.$b(),l=c.i("length"),m=c.i("offset");c=c.i("curveFactor");var p=a.i("minFontSize");if(k){if(1<k){var q=p/10;e+=q;f-=q}q=e;for(var r=!1,t,u=0;u<k;u++)if(t=b.Ld(u),t.o("hidden")){r=!0;break}if((f-e)/k<1.5*p&&1<k){k="+"+b.o("leafCount")+" "+
a.i("postfix");var v=(f+e)/2;m=d;d=a.px(m,v,k,b.o("fontSize")||p,a.i("fontFamily"),a.i("fontWeight"));v-=d.gG()/2;d.y(v);d.tag.node=b;d.tag.R0=!0;k=d.oS();m+k>=h&&d.visible(!1);a.cC(b.o("connectorOutXPosition"),b.o("connectorOutYPosition"),b.o("connectorOutXPosition")+20,(f+e)/2,c)}else for(r&&(d-=l+m),u=0;u<k;u++)if(t=b.Ld(u),!t.o("hidden")){m=t.o("leafCount");h=b.o("leafCount");h=r?f-e:(f-e)*Math.max(1,m)/Math.max(1,h);p=q;var w=0;q=p+h;m=d;v=p+h/2;var x=[m,v];t.o("height",h).o("nodePositionX",
m).o("nodePositionY",v);a.oK(t,r);v=b.o("textHeight")/2;x[1]-=v;1!=t.$b()&&(w+=l);m=a.zU(t);v=[x[0],x[1]+v];w+=x[0]+m;Fla(a,t,v,w,p,p+h);1<b.$b()&&!r&&a.cC(b.o("connectorOutXPosition"),b.o("connectorOutYPosition"),t.o("connectorInXPosition"),t.o("connectorInYPosition"),c)}}}}},Gla=function(a,b){var c=new f5(a,b);c.Fa("wordtree");return c};$.H(e5,$.Mq);var h5={};$.Yp(h5,[[0,"curveFactor",$.Hq],[0,"offset",$.Eq],[0,"length",$.Eq],[1,"stroke",$.qq]]);$.U(e5,h5);e5.prototype.qa=8201;
var xla=[["curveFactor",0,8],["offset",0,8],["length",0,8],["stroke",0,8192]];e5.prototype.F=function(){var a=e5.B.F.call(this);$.uq(this,h5,a);return a};e5.prototype.X=function(a,b){e5.B.X.call(this,a,b);$.mq(this,h5,a,b)};$.H(f5,$.Gw);f5.prototype.qa=$.Gw.prototype.qa;f5.prototype.ra=$.Gw.prototype.ra|4112;var i5=function(){var a={};$.Yp(a,[[0,"minFontSize",$.Eq],[0,"maxFontSize",$.Eq],[0,"fontFamily",$.dq],[0,"fontStyle",$.Pk],[0,"fontWeight",$.bq],[0,"fontColor",$.eq],[0,"fontOpacity",$.fq],[0,"fontDecoration",$.Ok],[0,"postfix",function(a){if($.n(a))return null===a&&(a=this.kf("postfix")),String(a)}]]);return a}();$.U(f5,i5);$.g=f5.prototype;$.g.Oa=function(){return"wordtree"};
$.g.pj=function(){return!(this.na&&(!this.na||this.na.$b()))};$.g.Se=function(){return[]};$.g.wt=function(){return[this]};$.g.lT=function(a,b){return function(c){return a*(1-c)+b*c}};$.g.gk=function(a,b){return $.Dt(this.data(),b)};$.g.sl=function(a){this.tm||(this.tm=new e5,$.W(this,"connectors",this.tm),$.L(this.tm,this.Cga,this));return a?(this.tm.K(a),this):this.tm};
$.g.TB=function(a){this.tl||(this.tl=new $.Rv);var b={};a&&(b.value={value:a.get("value"),type:"string"},b.weight={value:a.o("weight"),type:"number"});this.tl.xg(a);return $.Bu(this.tl,b)};$.g.Iq=function(a){if(a){"array"==$.ka(a)&&(a=a[0]);if(!$.K(a,$.qt)&&(a=this.data().jp("value",a)[0],!a))return;this.tK=a;yla(this,a);this.u(20,1)}};$.g.qx=function(){zla(this);this.tK&&this.tK.getParent()&&this.Iq(this.tK.getParent());return this};
$.g.Cga=function(a){var b=0;$.X(a,8192)&&(b|=16);$.X(a,8)&&(b|=4);this.u(b,1)};$.g.Fd=function(a){$.X(a,16)&&this.u(4100,9)};$.g.Bv=function(a){a.button==$.Li&&(a=a.domTarget.tag)&&a.node&&(zla(this),this.Iq(a.node))};$.g.ng=function(a){var b=a.domTarget.tag;if(b&&b.node&&!b.R0){var c=b.node;b=this.Va();$.$v(b,a.clientX,a.clientY,this.TB(c))}else this.Va().Oc()};$.g.Cg=function(){this.Va().Oc()};
$.g.DW=function(a){if("implicit"==this.ie){if($.n(a)){if(this.eN!=a||this.n_){this.n_=!1;if(null===a||/^[\s\xa0]*$/.test(a))a=this.Kv[0][0];this.eN=a;for(var b=[],c=0;c<this.Kv.length;c++){var d=(0,$.za)(this.Kv[c],a);-1!=d&&b.push($.Ja(this.Kv[c],d))}b.length||(b[0]=[a]);a=b[0][0];$.V(this.data());this.data().$b()&&this.data().cj(0);c={value:a};c=this.data().ig(c,0);for(d=0;d<b.length;d++){var e=b[d];e[0]==a&&(e.shift(),Ala(this,c,e))}this.data().da(!0)}return this}return this.eN}return this};
$.g.data=function(a,b){if($.n(a)){if($.K(a,$.nt)||$.K(a,$.kt))this.na!=a&&(this.na&&$.Nq(this.na,this.Fd,this),this.na=a,$.L(this.na,this.Fd,this),this.ie="explicit",this.u(4100,1));else if("array"==$.ka(a)&&"object"==$.ka(a[0]))this.data($.Bt(a,b));else if(null===a)this.na&&($.Nq(this.na,this.Fd),this.na.dd()),this.na=null,this.u(4100,1);else{this.ie="implicit";this.dg=a;if("array"==$.ka(a)&&a.length)if(this.Kv=[],"array"==$.ka(a[0]))for(var c=0;c<a.length;c++)this.Kv.push(g5(a[c][0]));else{if("string"==
$.ka(a[0]))for(c=0;c<a.length;c++)this.Kv.push(g5(a[c]))}else if("string"==$.ka(a)){c=Bla(a);for(var d=[],e=0;e<c.length;e++)d.push(g5(c[e]));this.Kv=d}else this.Kv=[[a.toString()]];this.na||Cla(this,$.Bt());this.n_=!0;this.DW(this.Kv[0][0])}return this}return this.na};$.g.Ai=function(){var a;0<this.Ns.length?a=this.Ns.pop():a=new $.Nh;return a};$.g.zU=function(a){if(a){var b=a.o("textWidth"),c=this.sl().i("offset"),d=a.getParent();d&&1<d.$b()&&(b+=c);1<a.$b()&&(b+=c);return b}return 0};
$.g.depth=function(a){if(a){var b=a.$b(),c=0,d=a.getParent();d&&(c=d.o("depth")+1);a.o("depth",c);for(c=0;c<b;c++)this.depth(a.Ld(c))}};$.g.px=function(a,b,c,d,e,f){var h=this.Ai();h.tag||(h.tag={});h.text(c);h.y(b);h.x(a);h.fontSize(d);h.fontFamily(e);h.fontWeight(f);h.width(null);h.visible(!0);this.ju.push(h);return h};$.g.cC=function(a,b,c,d,e){var f=this.QB,h=this.lT(a,c),k=h(e);e=h(1-e);f.moveTo(a,b).pk(k,b,e,d,c,d)};
$.g.oK=function(a,b){var c=0,d=a.getParent();d&&1<d.$b()&&(c+=this.sl().i("offset"));var e=a.get("value");1==a.$b()&&(e+=" ");c=a.o("nodePositionX")+c;d=a.o("nodePositionY");var f=a.get("fontFamily")||this.i("fontFamily");var h=a.get("fontWeight")||this.i("fontWeight");var k=Dla(this,a,b);f=this.px(c,d,e,k,f,h);f.tag={node:a,type:"node",R0:!1};h=f.gG();e=f.oS();a.o("textHeight",h).o("textWidth",e);d-=h/2;h=c+e;k=this.Sf.Za();h>k&&f.width(e-(h-k)-.05*e);f.x(c).y(d)};
$.g.Ui=function(a){if(!this.nf())if(this.va||(this.va=this.Ma.Md(),this.QB=new $.Bg,this.va.zIndex(30)),this.pj())this.va.Ei();else{var b=this.jr=this.na.Ld(0);this.J(4096)&&(Ela(this,this.jr),this.depth(this.jr),this.eh.length=0,this.eh=this.data().wv().yB(),this.I(4096));if(this.J(4)){this.va.Ei();var c=a.left;var d=a.top;a=a.height;for(var e=this.sl(),f=e.i("offset"),h=0;h<this.ju.length;h++){var k=this.ju[h];this.Ns.push(k)}this.ju.length=0;this.QB.clear();this.va.suspend();k=[c+f,d+a/2];b.o("nodePositionX",
k[0]).o("nodePositionY",k[1]).o("height",a);this.oK(b,!1);c=c+f+this.zU(b)+(1<b.$b()?e.i("length"):0);Fla(this,b,k,c,d,d+a);this.QB.parent(this.va);this.I(4);for(h=0;h<this.ju.length;h++)this.ju[h].parent(this.va);this.va.resume();this.u(16)}if(this.J(16)){this.va.suspend();this.QB.stroke(this.sl().i("stroke"));d=this.i("fontColor");c=this.i("fontDecoration");a=this.i("fontStyle");e=this.i("fontOpacity");for(f=0;f<this.ju.length;f++){b=this.ju[f];if(b.tag&&b.tag.node){var l=b.tag.node;var m=l.get("fontColor")||
d;var p=l.get("fontDecoration")||c;var q=l.get("fontStyle")||a;l=l.get("fontOpacity")||e}b.color(m);b.Eq(p);b.fontStyle(q);b.opacity(l);b.mm(!1)}this.va.resume();this.I(16)}}};$.g.F=function(){var a=f5.B.F.call(this);$.uq(this,i5,a);"implicit"==this.ie&&(a.wordTreeRawData=JSON.stringify(this.dg),a.word=this.eN);a.treeData=this.data().EA(["hidden"]);a.connectors=this.sl().F();return{chart:a}};
$.g.X=function(a,b){f5.B.X.call(this,a,b);$.mq(this,i5,a,b);"wordTreeRawData"in a?(this.data(JSON.parse(a.wordTreeRawData)),"word"in a&&this.DW(a.word),"treeData"in a&&Cla(this,$.pt(a.treeData))):"treeData"in a&&this.data($.pt(a.treeData));"connectors"in a&&this.sl().ia(!!b,a.connectors)};$.g.R=function(){f5.B.R.call(this);$.od(this.tm,this.QB,this.ju,this.Ns,this.na,this.va);this.na=this.QB=this.tm=null;this.ju.length=0;this.Ns.length=0;this.va=null};var j5=f5.prototype;j5.connectors=j5.sl;
j5.word=j5.DW;j5.getType=j5.Oa;j5.drillTo=j5.Iq;j5.drillUp=j5.qx;j5.toCsv=j5.gk;j5.noData=j5.Km;$.zp.wordtree=Gla;$.F("anychart.wordtree",Gla);}).call(this,$)}