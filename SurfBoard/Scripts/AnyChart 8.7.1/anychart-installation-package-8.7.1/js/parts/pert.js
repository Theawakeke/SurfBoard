if(!_.pert){_.pert=1;(function($){var Kga=function(a){return $.pk(Jga,a,"circle")},HY=function(){$.Mq.call(this);this.Vb=this.$=this.UL=this.cb=null;$.T(this.ua,[["color",0,8192]]);var a={};$.T(a,[["fill",0,8192],["stroke",0,8192],["labels",0,0]]);this.ba=new $.zx(this,a,$.Vl);this.ba.pa("labelsFactoryConstructor",$.Bx);this.ba.pa("labelsAfterInitCallback",this.VC);this.wa=new $.zx(this,a,$.fo);this.wa.pa("labelsFactoryConstructor",$.Bx);this.wa.pa("labelsAfterInitCallback",this.VC);this.Ca=new $.zx(this,a,$.go);this.Ca.pa("labelsFactoryConstructor",
$.Bx);this.Ca.pa("labelsAfterInitCallback",this.VC)},IY=function(a){var b=a.Va().F(),c=a.Va().i("titleFormat");a=a.Va().i("format");c&&c!=$.Po&&(b.titleFormat=c);a&&a!=$.Po&&(b.format=a);return b},JY=function(){HY.call(this);this.Fa("milestones");$.T(this.ua,[["size",0,1],["shape",0,1]])},KY=function(){HY.call(this);this.Fa("tasks");$.Hx(this.ba,[["dummyFill",0,8192],["dummyStroke",0,8192],["lowerLabels",0,0],["upperLabels",0,0]]);this.ba.pa("lowerLabelsAfterInitCallback",this.VC);this.wa.pa("lowerLabelsAfterInitCallback",
this.VC);this.Ca.pa("lowerLabelsAfterInitCallback",this.VC)},LY=function(){$.Mq.call(this);this.Fa("criticalPath");this.fk=this.Fj=null},MY=function(){$.Rw.call(this);this.Fa("pert");this.na=null;this.b={};this.g={};this.f=[];this.Rb=[];this.Na=[];this.Ga=this.ca=this.D=null;this.ga=[];this.j={};this.Ja=this.fk=this.Fj=this.ka=this.Ch=this.$a=this.fb=this.U=this.ta=null;this.O=[];this.N=[];this.G={};this.za=[];this.Yc=this.sb=0;this.jc=[];this.cb=this.Cc=null;$.Ft(this,this,this.ng,this.Cg,this.rba,
this.ng,null,this.oj);$.T(this.ua,[["expectedTimeCalculator",8192,1],["verticalSpacing",4,1],["horizontalSpacing",4,1]])},NY=function(a,b,c){var d=a.Va(),e=!0;$.da(a.Cc.enabled)&&(e=a.Cc.enabled);d.K(a.Cc);b&&$.da(b.enabled)&&(e=b.enabled);d.K(b);c&&$.da(c.enabled)&&(e=c.enabled);d.K(c);d.enabled(e)},Lga=function(a){var b={type:"pointsselect",selectedTasks:[],selectedMilestones:[]},c;for(c=0;c<a.O.length;c++){var d=a.O[c],e=a.g[d.id];d={item:d.item,name:d.item.get("name"),successors:d.Li,predecessors:d.ck,
earliestStart:e.kR,earliestFinish:e.Cz,latestStart:e.YL,latestFinish:e.PT,duration:e.duration,slack:e.tN,variance:e.yW};b.selectedTasks.push(d)}for(c=0;c<a.N.length;c++)d=a.N[c],e={successors:d.Li,predecessors:d.ck,isCritical:d.Ue,isStart:d.$x},d.mF&&(e.creator=d.mF.item),b.selectedMilestones.push(e);return b},PY=function(a){a.g={};if(a.Rb.length&&a.Na.length)for(var b=0;b<a.Rb.length;b++)OY(a,String(a.Rb[b].get("id")));b=0;for(var c in a.g){var d=a.g[c];d.tN||(b+=d.yW)}a.Ia("pertChartCriticalPathStandardDeviation",
Math.sqrt(b));a.I(8192)},OY=function(a,b){var c=a.b[b];if(!(b in a.g)){a.g[b]={};var d=Number(c.item.get("optimistic")),e=Number(c.item.get("pessimistic"));a.g[b].yW=$.Gm(Math.pow((e-d)/6,2),3)}d=a.g[b];$.n(d.duration)||(e=a.Gc(!1,c,d),d.duration=$.Gm(a.i("expectedTimeCalculator").call(e,e),3));e=d.duration;var f;if(!$.n(d.kR)){var h=0;for(f=0;f<c.ck.length;f++){var k=String(c.ck[f].get("id")),l=a.g[k];$.n(l)&&$.n(l.Cz)||OY(a,k);h=Math.max(h,a.g[k].Cz)}d.kR=$.Gm(h,3);d.Cz=$.Gm(h+e,3)}if(!$.n(d.PT)){if(c.Li.length)for(h=
window.Infinity,f=0;f<c.Li.length;f++)k=String(c.Li[f].get("id")),l=a.g[k],$.n(l)&&$.n(l.YL)||OY(a,k),h=Math.min(h,a.g[k].YL);else{h=-window.Infinity;for(f=0;f<a.Na.length;f++)c=String(a.Na[f].get("id")),k=a.g[c],$.n(k)&&$.n(k.Cz)||OY(a,c),h=Math.max(h,a.g[c].Cz);a.Ia("pertChartProjectDuration",h)}d.PT=$.Gm(h,3);d.YL=$.Gm(h-e,3);d.tN=$.Gm(h-d.Cz,3)}},QY=function(a,b){a!=b&&($.Ba(a.$q,b),$.Ba(b.jm,a))},RY=function(a,b,c,d){b={label:d||"",id:"",Li:[],ck:[],jm:[],$q:[],level:-1,Ue:!1,left:0,top:0,$x:c,
mF:b,en:!1,Am:!1,Yi:[],index:-1};c="m"+$.oa(b);a.j[c]=b;b.id=c;return b},SY=function(a,b,c){var d={from:b,yf:c,en:!1,Am:!1,Jy:null,id:"",Ue:!1},e="e"+$.oa(d);d.id=e;a.G[e]=d;$.Ba(b.Yi,d);$.Ba(c.Yi,d);return d},TY=function(a,b){var c,d,e=[];for(c in a.G){var f=a.G[c];if(!f.Am&&f.en==b){f.en=!b;var h={qI:{},Yi:{}};h.qI[f.from.id]=f.from;h.qI[f.yf.id]=f.yf;h.Yi[f.id]=f;var k=[];f.from.Am||f.from.en!=b||(f.from.en=!b,k.push(f.from));f.yf.Am||f.yf.en!=b||(f.yf.en=!b,k.push(f.yf));for(;k.length;){var l=
k.pop();for(d=0;d<l.Yi.length;d++)if(f=l.Yi[d],!f.Am&&f.en==b){f.en=!b;h.Yi[f.id]=f;var m=f.from==l?f.yf:f.from;m.Am||m.en!=b||(m.en=!b,k.push(m));h.qI[m.id]=m}}e.push(h)}f.en=!b}for(c in a.j)a.j[c].en=!b;return e},Mga=function(a,b){var c,d,e,f=null,h=window.Infinity;for(c=0;c<a.length;c++){var k=a[c],l=0,m=-1;for(d=0;d<b.length;d++){var p=b[d],q=!0;for(e in k.qI){var r=k.qI[e];if(r.Am&&0>p.indexOf(r)){q=!1;break}}if(q&&(l++,0>m&&(m=d),l>=h))break}if(!l)throw"non planar!";l<h&&(f=[c,m],h=l)}return f},
UY=function(a,b,c,d){var e=Math.atan((d-b)/(c-a)),f=Math.atan(.3);a=$.Um(0,0,3,10);b=e-f;e+=f;return[c-a*Math.cos(b),d-a*Math.sin(b),c-a*Math.cos(e),d-a*Math.sin(e)]},VY=function(a,b){return $.da(a.enabled())?a.enabled():b},WY=function(){var a=new MY;a.ia(!0,$.dm("pert"));return a},Jga={tO:"circle",bna:"rhombus",B6:"rectangle"};$.H(HY,$.Mq);$.kq(HY,["fill","stroke","labels"],"normal");HY.prototype.qa=$.Mq.prototype.qa|28672;HY.prototype.ra=$.Mq.prototype.ra;var XY={};$.Xp(XY,1,"color",$.rq);
$.U(HY,XY);$.g=HY.prototype;$.g.i=$.Lq;$.g.aG=function(a){var b=this.parent();return b?b[a&$.go?"selected":a&$.fo?"hovered":"normal"]():null};$.g.Xf=function(a){$.n(a)&&(this.Vb=a);return this.Vb};$.g.Yg=$.Kq;$.g.Sd=function(){var a=[this.ma];this.$&&(a=$.Ga(a,this.$.Sd()));return a};$.g.Rd=function(){var a=[this.La];this.$&&(a=$.Ga(a,this.$.Rd()));return a};
$.g.parent=function(a){return $.n(a)?(this.$!=a&&(null===a?($.Nq(this.$,this.Sc,this),this.$=null):(this.$&&$.Nq(this.$,this.Sc,this),this.$=a,this.Va().Re().parent(this.$.Va()),$.L(this.$,this.Sc,this))),this):this.$};$.g.Sc=function(a){var b=0,c=0;$.X(a,1)&&(b|=16,c|=1);$.X(a,8)&&(b|=4,c|=8);$.X(a,32768)&&(b|=1,c|=1);this.Vb=null;this.u(b,c)};$.g.Ra=function(a){return $.n(a)?(this.ba.K(a),this):this.ba};$.g.kb=function(a){return $.n(a)?(this.wa.K(a),this):this.wa};
$.g.selected=function(a){return $.n(a)?(this.Ca.K(a),this):this.Ca};$.g.rv=function(a,b){return this.ty("fill",a,b)};$.g.Nq=function(a,b){return this.ty("stroke",a,b)};$.g.ty=function(a,b,c){a=(0==b?this.ba:1==b?this.wa:this.Ca).i(a);$.E(a)&&(c.sourceColor=this.i("color"),a=a.call(c));return a};$.g.VC=function(a){$.L(a,this.Yq,this)};$.g.Yq=function(){this.xa(4096)};
$.g.Va=function(a){this.cb||(this.cb=new $.Iv(0),$.W(this,"tooltip",this.cb),$.L(this.cb,this.cp,this));return $.n(a)?(this.cb.K(a),this):this.cb};$.g.cp=function(){this.xa(16384)};$.g.dA=function(a){return $.n(a)?(this.UL!=a&&(this.UL=a,this.ba.labels().P(this.UL)),this):this.UL};$.g.Vi=function(){this.ba.labels().Y();return this};$.g.CJ=function(){this.ba.labels().clear();return this};
$.g.F=function(){var a=HY.B.F.call(this);$.uq(this,XY,a,"Pert visual element");a.normal=this.ba.F();a.hovered=this.wa.F();a.selected=this.Ca.F();a.tooltip=this.Va().F();return a};$.g.X=function(a,b){HY.B.X.call(this,a,b);$.mq(this,XY,a);this.ba.ia(!!b,a);this.ba.ia(!!b,a.normal);this.wa.ia(!!b,a.hovered);this.Ca.ia(!!b,a.selected);"tooltip"in a&&this.Va().ia(!!b,a.tooltip)};$.g.R=function(){$.od(this.cb);HY.B.R.call(this)};var YY=HY.prototype;YY.tooltip=YY.Va;YY.normal=YY.Ra;YY.hovered=YY.kb;
YY.selected=YY.selected;$.H(JY,HY);JY.prototype.qa=HY.prototype.qa|1;var ZY=function(){var a={};$.Yp(a,[[0,"size",function(a){return $.io(a,80)||0}],[0,"shape",Kga]]);return a}();$.U(JY,ZY);JY.prototype.F=function(){var a=JY.B.F.call(this);$.uq(this,ZY,a);return a};JY.prototype.X=function(a,b){JY.B.X.call(this,a,b);$.mq(this,ZY,a)};$.H(KY,HY);$.kq(KY,["dummyFill","dummyStroke","lowerLabels","upperLabels"],"normal");KY.prototype.qa=HY.prototype.qa;KY.prototype.dA=function(a){KY.B.dA.call(this,a);(a=KY.B.dA.call(this))&&this.ba.$j().P(a);return a};KY.prototype.Vi=function(){this.ba.$j().Y();return KY.B.Vi.call(this)};KY.prototype.CJ=function(){this.ba.$j().clear();return KY.B.CJ.call(this)};$.H(LY,$.Mq);$.g=LY.prototype;$.g.qa=$.Mq.prototype.qa|12289;$.g.vc=function(a){this.Fj||(this.Fj=new JY,$.W(this,"milestones",this.Fj));return $.n(a)?(this.Fj.K(a),this):this.Fj};$.g.dc=function(a){this.fk||(this.fk=new KY,$.W(this,"tasks",this.fk));return $.n(a)?(this.fk.K(a),this):this.fk};$.g.F=function(){var a=LY.B.F.call(this);a.tasks=this.dc().F();a.milestones=this.vc().F();return a};
$.g.X=function(a,b){LY.B.X.call(this,a,b);"milestones"in a&&this.vc().X(a.milestones,b);"tasks"in a&&this.dc().X(a.tasks,b)};var $Y=LY.prototype;$Y.tasks=$Y.dc;$Y.milestones=$Y.vc;$.H(MY,$.Rw);$.g=MY.prototype;$.g.qa=$.Rw.prototype.qa;$.g.ra=$.Rw.prototype.ra|61440;$.g.Oa=function(){return"pert"};
$.g.Gc=function(a,b,c,d){if(!this.D||a)this.D=new $.Rv;a={};var e=null;if(b){a.item={value:b.item,type:""};e=b.item;a.name={value:b.item.get("name"),type:"string"};var f=b.item.get("pessimistic");$.n(f)&&(a.pessimistic={value:+f,type:"number"});f=b.item.get("optimistic");$.n(f)&&(a.optimistic={value:+f,type:"number"});f=b.item.get("mostLikely");$.n(f)&&(a.mostLikely={value:+f,type:"number"});f=b.item.get("duration");$.n(f)&&(a.duration={value:+f,type:"number"});a.successors={value:b.Li,type:""};a.predecessors=
{value:b.ck,type:""};a.isCritical={value:b.Ue,type:"string"}}c&&(a.earliestStart={value:c.kR,type:"number"},a.earliestFinish={value:c.Cz,type:"number"},a.latestStart={value:c.YL,type:"number"},a.latestFinish={value:c.PT,type:"number"},$.n(a.duration)||(a.duration={value:c.duration,type:"number"}),a.slack={value:c.tN,type:"number"},a.variance={value:c.yW,type:"number"});d&&(a.successors={value:d.Li,type:""},a.predecessors={value:d.ck,type:""},a.isCritical={value:d.Ue,type:"string"},d.mF&&(a.creator=
{value:d.mF.item,type:""}),a.isStart={value:d.$x,type:"string"},a.index={value:d.index,type:"number"});this.D.ej([this]).xg(e);return $.Bu(this.D,a)};$.g.MJ=function(){var a=new $.Iv(0);a.Aa(this);$.L(a,this.cp,this);return a};$.g.cp=function(){this.Va().Y()};$.g.data=function(a,b,c){return $.n(a)?($.K(a,$.nt)||$.K(a,$.kt)?this.na!=a&&(this.na&&$.Nq(this.na,this.Fd,this),this.na=a):(this.na&&$.Nq(this.na,this.Fd,this),this.na=new $.nt(a,b,c)),$.L(this.na,this.Fd,this),this.u(4352,1),this):this.na};
$.g.sy=function(){this.ab().Gq()&&this.u(-6145,9)};$.g.Fd=function(){this.u(4356,1)};$.g.Yl=function(){return[]};$.g.Se=function(){return[]};
$.g.ng=function(a){var b=a.domTarget,c=this.Va();var d=b.tag;var e=!0;if(d)if(null!=d.m){var f=d.m;d=this.Gc(!0,void 0,void 0,f);var h=f.Ue?this.Ee().vc():this.vc();var k=f.Ke?$.go:$.fo;e=h.rv(k,d);h=h.Nq(k,d);b.fill(e).stroke(h);e=!1;b=f.Ue?IY(this.Ee().vc()):void 0;$.V(c);NY(this,IY(this.vc()),b);$.$v(c,a.clientX,a.clientY,d);c.da(!0);if(a=f.gV)b=!0,c=this.vc().Ra().labels(),a.md(c.Nd()),b=VY(c,b),f.Ke?(c=this.vc().selected().labels(),a.md(c.Nd()),b=VY(c,b)):(c=this.vc().kb().labels(),a.md(c.Nd()),
b=VY(c,b)),f.Ue&&(c=this.Ee().vc().Ra().labels(),a.md(c.Nd()),b=VY(c,b),f.Ke?(c=this.Ee().vc().selected().labels(),a.md(c.Nd()),b=VY(c,b)):(c=this.Ee().vc().kb().labels(),a.md(c.Nd()),b=VY(c,b))),a.enabled(b),a.Y()}else null!=d.w&&(f=d.w,b=this.g[f.id],d=this.Gc(!0,f,b,void 0),k=f.Ke?$.go:$.fo,h=f.Ue?this.Ee().dc():this.dc(),e=h.rv(k,d),h=h.Nq(k,d),f.hV.stroke(h),f.KY.fill(e).stroke(h),h=f.uW,e=f.VT,h&&(b=!0,k=this.dc().Ra().pm(),h.md(k.Nd()),b=VY(k,b),f.Ke?(k=this.dc().selected().pm(),h.md(k.Nd()),
b=VY(k,b)):(k=this.dc().kb().pm(),h.md(k.Nd()),b=VY(k,b)),f.Ue&&(k=this.Ee().dc().Ra().pm(),h.md(k.Nd()),b=VY(k,b),f.Ke?(k=this.Ee().dc().selected().pm(),h.md(k.Nd()),b=VY(k,b)):(k=this.Ee().dc().kb().pm(),h.md(k.Nd()),b=VY(k,b))),h.enabled(b),h.Y()),e&&(b=!0,h=this.dc().Ra().$j(),e.md(h.Nd()),b=VY(h,b),f.Ke?(h=this.dc().selected().$j(),e.md(h.Nd()),b=VY(h,b)):(h=this.dc().kb().$j(),e.md(h.Nd()),b=VY(h,b)),f.Ue&&(h=this.Ee().dc().Ra().$j(),e.md(h.Nd()),b=VY(h,b),f.Ke?(h=this.Ee().dc().selected().$j(),
e.md(h.Nd()),b=VY(h,b)):(h=this.Ee().dc().kb().$j(),e.md(h.Nd()),b=VY(h,b))),e.enabled(b),e.Y()),e=!1,b=f.Ue?IY(this.Ee().dc()):void 0,$.V(c),NY(this,IY(this.dc()),b),$.$v(c,a.clientX,a.clientY,d),c.da(!0));e&&this.Va().Oc()};
$.g.Cg=function(a){var b=a.domTarget;if(a=b.tag)if(null!=a.m){var c=a.m;a=c.Ue?this.Ee().vc():this.vc();var d=this.Gc(!0,void 0,void 0,c);var e=c.Ke?$.go:$.Vl;var f=a.rv(e,d);d=a.Nq(e,d);if(e=c.gV){a=!0;var h=this.vc().Ra().labels();e.md(h.Nd());a=VY(h,a);c.Ke&&(h=this.vc().selected().labels(),e.md(h.Nd()),a=VY(h,a));c.Ue&&(h=this.Ee().vc().Ra().labels(),e.md(h.Nd()),a=VY(h,a),c.Ke&&(c=this.Ee().vc().selected().labels(),e.md(c.Nd()),a=VY(c,a)));e.enabled(a);e.Y()}b.fill(f).stroke(d)}else null!=a.w&&
(b=a.w,d=this.Gc(!0,b,this.g[b.id],void 0),e=b.Ke?$.go:$.Vl,a=b.Ue?this.Ee().dc():this.dc(),f=a.rv(e,d),d=a.Nq(e,d),b.hV.stroke(d),b.KY.fill(f).stroke(d),c=b.uW,f=b.VT,c&&(a=!0,d=this.dc().Ra().pm(),c.md(d.Nd()),a=VY(d,a),b.Ke&&(d=this.dc().selected().pm(),c.md(d.Nd()),a=VY(d,a)),b.Ue&&(d=this.Ee().dc().Ra().pm(),c.md(d.Nd()),a=VY(d,a),b.Ke&&(d=this.Ee().dc().selected().pm(),c.md(d.Nd()),a=VY(d,a))),c.enabled(a),c.Y()),f&&(a=!0,c=this.dc().Ra().$j(),f.md(c.Nd()),a=VY(c,a),b.Ke&&(c=this.dc().selected().$j(),
f.md(c.Nd()),a=VY(c,a)),b.Ue&&(c=this.Ee().dc().Ra().$j(),f.md(c.Nd()),a=VY(c,a),b.Ke&&(b=this.Ee().dc().selected().$j(),f.md(b.Nd()),a=VY(b,a))),f.enabled(a),f.Y()))};
$.g.rba=function(a){var b=a.metaKey||a.ctrlKey,c,d,e=a.domTarget,f=e.tag;$.K(a.target,$.$t)&&(f=a.target.de(a.labelIndex).tag);if($.K(e,$.fg)){f&&(null!=f.m?c=f.m:null!=f.w&&(d=f.w));if(c||d)if(b)c&&(c.Ke=!c.Ke,c.Ke?$.Ba(this.N,c):$.Fa(this.N,c)),d&&(d.Ke=!d.Ke,d.Ke?$.Ba(this.O,d):$.Fa(this.O,d));else{for(a=0;a<this.N.length;a++)this.N[a].Ke=!1;for(a=0;a<this.O.length;a++)this.O[a].Ke=!1;this.N.length=0;this.O.length=0;c&&(c.Ke=!0,this.N.push(c));d&&(d.Ke=!0,this.O.push(d))}else{for(a=0;a<this.N.length;a++)this.N[a].Ke=
!1;for(a=0;a<this.O.length;a++)this.O[a].Ke=!1;this.N.length=0;this.O.length=0}this.dispatchEvent(Lga(this));this.u(32768,1)}};var aZ=function(){var a={};$.Xp(a,0,"expectedTimeCalculator",$.gq);$.Xp(a,0,"verticalSpacing",function(a){return $.io(a,20)});$.Xp(a,0,"horizontalSpacing",function(a){return $.io(a,20)});return a}();$.U(MY,aZ);$.g=MY.prototype;
$.g.nb=function(){if(this.J(4096)){this.b={};this.Rb.length=0;this.Na.length=0;if(this.na&&!this.na.od){for(var a=this.na.Jz(),b=0;b<a.length;b++){var c=a[b],d=String(c.get("id"));d in this.b||(this.b[d]={id:d,item:c,Li:[],ck:[],level:-1,Ue:!1,TQ:[],UQ:[]},this.Na.push(c));var e=c.get("dependsOn");if($.n(e)&&"array"==$.ka(e))for(var f=0;f<e.length;f++){var h=String(e[f]);if(h in this.b)h!=d&&(this.b[h].Li.push(c),this.b[d].ck.push(this.b[h].item),$.Fa(this.Na,this.b[h].item),$.Ua(this.b[h].UQ,d),
$.Ua(this.b[d].TQ,h));else{var k=this.na.jp("id",h)[0];if(k){var l=String(k.get("id"));this.b[l]={id:l,item:k,Li:[c],ck:[],level:-1,Ue:!1,TQ:[],UQ:[]};$.Fa(this.Na,k);this.b[d].ck.push(k);$.Ua(this.b[l].UQ,d);$.Ua(this.b[d].TQ,h)}}}else this.Rb.push(c)}PY(this);this.ga.length=0;this.j={};this.Ga=RY(this,null,!0,"Start");this.Ga.Ue=!0;this.ca=RY(this,null,!1,"Finish");this.ca.Ue=!0;var m,p;for(p in this.b){var q=this.b[p],r=this.g[p];q.kp||(q.kp=RY(this,q,!0,"S"+q.item.get("name")));q.zm||(q.zm=RY(this,
q,!1,"F"+q.item.get("name")),q.zm.mF=q);$.Ba(q.kp.Li,q.item);$.Ba(q.zm.ck,q.item);r.tN||(q.Ue=!0,q.kp.Ue=!0,q.zm.Ue=!0);if(q.Li.length)for(m=0;m<q.Li.length;m++){var t=String(q.Li[m].get("id")),u=this.b[t];u.kp||(u.kp=RY(this,u,!0,"S"+u.item.get("name")));u.zm||(u.zm=RY(this,u,!1,"F"+u.item.get("name")));QY(u.kp,q.zm)}else QY(this.ca,q.zm);if(q.ck.length)for(m=0;m<q.ck.length;m++){var v=String(q.ck[m].get("id")),w=this.b[v];w.kp||(w.kp=RY(this,w,!0,"Start: "+w.item.get("name")));w.zm||(w.zm=RY(this,
w,!1,"Finish: "+w.item.get("name")));QY(q.kp,w.zm)}else QY(q.kp,this.Ga)}var x,y,B,G=[];for(x in this.j){var C=this.j[x];var I={};for(y=0;y<C.jm.length;y++){var P=C.jm[y];if(1==P.Li.length&&2>P.$q.length&&!P.ck.length){var Q=String(P.Li[0].get("id"));var S=this.b[Q];var va=S.zm;for(B=0;B<C.jm.length;B++)if(y!=B){var xa=C.jm[B];if(1==xa.Li.length){var Qa=String(xa.Li[0].get("id"));this.b[Qa].zm==va&&(I[va.id]=va)}}}else I[P.id]=P}for(y=G.length=0;y<C.jm.length;y++)if(P=C.jm[y],!(P.id in I)){Q=String(P.Li[0].get("id"));
S=this.b[Q];var ub=S.kp;S.kp=C;$.Ba(C.Li,S.item);G.push(ub)}for(y=0;y<G.length;y++){var nc=G[y];$.Fa(C.jm,nc);delete this.j[nc.id]}}for(x in this.j){C=this.j[x];I={};for(y=0;y<C.$q.length;y++){var bb=C.$q[y];if(1==bb.ck.length&&2>bb.jm.length&&!bb.Li.length){var Wb=String(bb.ck[0].get("id"));var wb=this.b[Wb];var Fc=wb.kp;for(B=0;B<C.$q.length;B++)if(y!=B){var fe=C.$q[B];if(1==fe.ck.length){var xb=String(fe.ck[0].get("id"));this.b[xb].kp==Fc&&(I[bb.id]=bb)}}}else I[bb.id]=bb}for(y=G.length=0;y<C.$q.length;y++)bb=
C.$q[y],bb.id in I||(Wb=String(bb.ck[0].get("id")),wb=this.b[Wb],ub=wb.zm,wb.zm=C,$.Ba(C.ck,wb.item),G.push(ub));for(y=0;y<G.length;y++)nc=G[y],$.Fa(C.$q,nc),delete this.j[nc.id]}this.G={};var dd;for(dd in this.j){var jc=this.j[dd],Yc;for(Yc=0;Yc<jc.Li.length;Yc++){var Dd=String(jc.Li[Yc].get("id")),Ub=this.b[Dd];var qb=SY(this,jc,Ub.zm);qb.Jy=Ub;qb.Ue=Ub.Ue}for(Yc=0;Yc<jc.jm.length;Yc++){var rg=jc.jm[Yc];qb=SY(this,jc,rg);qb.Ue=jc.Ue&&rg.Ue}}this.za.length=0;this.Ga.level=0;for(var Ae=[this.Ga],
ff=[];Ae.length;){var Lg=Ae.pop(),sg=Lg.level;ff.length>sg&&(ff.length=sg);ff.push(Lg);Lg==this.ca&&this.za.push(ff.slice(0));var Be;for(Be=Lg.Li.length;Be--;){var ge=String(Lg.Li[Be].get("id")),Ce=this.b[ge].zm;var Ue=sg+1;Ce.level=Math.max(Ue,Ce.level);this.sb=Math.max(Ce.level,this.sb);Ae.push(Ce)}for(Be=Lg.jm.length;Be--;){var Vd=Lg.jm[Be];Ue=sg+1;Vd.level=Math.max(Ue,Vd.level);this.sb=Math.max(Vd.level,this.sb);Ae.push(Vd)}}for(var si in this.G){var id=this.G[si];if(!id.Nv){var dh=id.from,Bf=
id.yf,yj=Bf.level-dh.level;if(1<yj){for(var Kd=null,Wd,De,xg,mk=0;mk<yj-1;mk++){var nk=!Kd;Kd=Kd||dh;Wd={Nv:!0,id:null,label:"Fake milestone "+mk,level:dh.level+1+mk,Ue:id.Ue,en:!1,Am:!1,Yi:[],Dha:null,IN:null,$q:[Kd],jm:[],B2:id,Li:[],ck:[],Xb:0};Wd.id="fm"+$.oa(Wd);this.j[Wd.id]=Wd;nk?(xg={Nv:!0,from:Kd,yf:Wd,en:!1,Am:!1,Jy:id.Jy,id:null,Ue:id.Ue,B2:id},xg.id="fe"+$.oa(xg),this.G[xg.id]=xg):(xg=Kd.IN,xg.yf=Wd);De={Nv:!0,from:Wd,yf:null,en:!1,Am:!1,Jy:id.Jy,id:null,Ue:id.Ue,B2:id};De.id="fe"+$.oa(De);
this.G[De.id]=De;Wd.IN=De;Wd.Dha=xg;Wd.Yi=[De,xg];Kd.Nv?(Kd.jm.push(Wd),Kd.IN.yf=Wd):(id.Jy||($.Fa(Kd.jm,Bf),$.Ba(Kd.jm,Wd)),$.Fa(Kd.Yi,id),$.Ba(Kd.Yi,xg));Kd=Wd}De.yf=Bf;$.Fa(Bf.$q,dh);$.Ba(Bf.$q,Wd);Wd.jm.push(Bf);var ad=(0,$.za)(Bf.Yi,id);0>ad&&(ad=0);$.Ca(Bf.Yi,ad,1,De);delete this.G[id.id]}}}this.jc.length=0;this.Ga.Am=this.ca.Am=!0;for(var Vi=!1,th=TY(this,Vi),uh=[[this.Ga,this.ca]],hl;hl=Mga(th,uh);){var he=void 0,Cf=uh,vh=hl[1],ok=th[hl[0]],wi=null;for(he in ok.Yi){var ie=ok.Yi[he].from;ie.Am&&
(!wi||wi.level>ie.level)&&(wi=ie)}var am=[wi];for(ie=wi;ie;){var il=ie.Yi,$f=null;for(he=0;he<il.length;he++){var wh=il[he];if(wh.from==ie&&!wh.Am){wh.Am=!0;var Yh=wh.yf;am.push(Yh);Yh.Am||(Yh.Am=!0,$f=Yh);break}}ie=$f}var Zh=void 0,$h=void 0,ai=void 0,Qg=void 0,eh=Cf[vh],je=am,ag=eh.indexOf(je[0]),yg=eh.indexOf(je[je.length-1]);ag<yg?(Qg=ag,ai=yg,$h=!1):(Qg=yg,ai=ag,$h=!0);var Df=eh.slice(0,Qg);if($h)for(Zh=je.length;Zh--;)Df.push(je[Zh]);else Df.push.apply(Df,je);Df.push.apply(Df,eh.slice(ai+1));
var Xd=eh.slice(Qg+1,ai);if($h)Xd.push.apply(Xd,je);else for(Zh=je.length;Zh--;)Xd.push(je[Zh]);var fh=[Df,Xd];$.Ca(Cf,vh,1,fh[0],fh[1]);th=TY(this,Vi=!Vi)}this.jc=uh;this.ga[0]=[this.Ga];this.ga[this.sb]=[this.ca];this.Yc=1;var ud,gh;if(2<this.jc.length)for(ud=0;ud<this.jc.length;ud++){var xi=this.jc[ud];a:{for(var hh=window.Infinity,jl=0,Wi=0;Wi<xi.length;Wi++){var Kb=xi[Wi];if(!Kb.level){var ke=Wi;break a}Kb.level<hh&&(hh=Kb.level,jl=Wi)}ke=jl}for(var yd=0,Ef,ih,bg;;){yd+=1;bg=[xi[$.$a(ke+yd,xi.length)],
xi[$.$a(ke-yd,xi.length)]];Ef=bg[0];ih=bg[1];if(Ef==ih||Ef!=ih&&(Ef==this.ca||ih==this.ca))break;Ef.WT=ih;ih.zja=Ef}}for(gh in this.j){var Xi=this.j[gh];if(Xi!=this.Ga&&Xi!=this.ca&&!Xi.zja){var cg=Xi.level;this.ga[cg]=[Xi];for(var zg=Xi;zg.WT;)this.ga[cg].push(zg.WT),zg=zg.WT,this.Yc=Math.max(this.Yc,this.ga[cg].length)}}var kl=0;for(ud=0;ud<this.ga.length;ud++){var Ag=this.ga[ud];for(gh=0;gh<Ag.length;gh++){var Co=Ag[gh];Co&&!Co.Nv&&(Co.index=kl++)}}}this.I(4096)}};
$.g.T1=function(a){var b=0;$.X(a,4096)&&(b|=16384);$.X(a,8192)&&(b|=32768);$.X(a,1)&&(b|=4);this.u(b,1)};$.g.X1=function(a){var b=0;$.X(a,4096)&&(b|=16384);$.X(a,8192)&&(b|=32768);this.u(b,1)};$.g.vc=function(a){this.Fj||(this.Fj=new JY,$.W(this,"milestones",this.Fj),$.L(this.Fj,this.T1,this));return $.n(a)?(this.Fj.K(a),this):this.Fj};$.g.dc=function(a){this.fk||(this.fk=new KY,$.W(this,"tasks",this.fk),$.L(this.fk,this.X1,this));return $.n(a)?(this.fk.K(a),this):this.fk};
$.g.Ee=function(a){this.Ja||(this.Ja=new LY,$.L(this.Ja.vc(),this.T1,this),this.Ja.vc().parent(this.vc()),$.L(this.Ja.dc(),this.X1,this),this.Ja.dc().parent(this.dc()));return $.n(a)?(this.Ja.K(a),this):this.Ja};$.g.Mfa=function(a){var b=a.tag;if(b&&null!=b.m){var c=b.m;b=c.Ue?this.Ee().vc():this.vc();var d=this.Gc(!0,void 0,void 0,c),e=c.Ke?$.go:$.Vl;c=b.rv(e,d);b=b.Nq(e,d);a.fill(c).stroke(b)}};
$.g.Nfa=function(a){if((a=a.tag)&&null!=a.m){var b=a.m;a=b.gV;var c=!0;if(a){var d=this.vc().Ra().labels();a.md(d.Nd());c=VY(d,c);b.Ke&&(d=this.vc().selected().labels(),a.md(d.Nd()),c=VY(d,c));b.Ue&&(d=this.Ee().vc().Ra().labels(),a.md(d.Nd()),c=VY(d,c),b.Ke&&(b=this.Ee().vc().selected().labels(),a.md(b.Nd()),c=VY(b,c)));a.enabled(c);a.Y()}}};
$.g.Hja=function(a){if((a=a.tag)&&null!=a.w){a=a.w;var b=a.Z0;b.clear();b.ic(1,0,0,1,0,0);var c={width:null,height:null,rotation:0,padding:[0,0,0,0]},d=a.uW,e=a.VT;if(d){var f=!0,h=this.dc().Ra().pm();f=VY(h,f);d.md(h.Nd());if(a.Ke){var k=this.dc().selected().pm();d.md(k.Nd());f=VY(k,f)}a.Ue&&(k=this.Ee().dc().Ra().pm(),d.md(k.Nd()),f=VY(k,f),a.Ke&&(k=this.Ee().dc().selected().pm(),d.md(k.Nd()),f=VY(k,f)));d.enabled(f);d.Y();f=$.lu(h,d,void 0,c);b.moveTo(f.left,f.top).lineTo(f.left+f.width,f.top).lineTo(f.left+
f.width,f.top+f.height).lineTo(f.left,f.top+f.height).close()}e&&(f=!0,d=this.dc().Ra().$j(),e.md(d.Nd()),f=VY(d,f),a.Ke&&(h=this.dc().selected().$j(),e.md(h.Nd()),f=VY(h,f)),a.Ue&&(h=this.Ee().dc().Ra().$j(),e.md(h.Nd()),f=VY(h,f),a.Ke&&(h=this.Ee().dc().selected().$j(),e.md(h.Nd()),f=VY(h,f))),e.enabled(f),e.Y(),c=$.lu(d,e,void 0,c),b.moveTo(c.left,c.top).lineTo(c.left+c.width,c.top).lineTo(c.left+c.width,c.top+c.height).lineTo(c.left,c.top+c.height).close());b.du(a.rotation,"center")}};
$.g.Gja=function(a){var b=a.tag;if(b)if(null!=b.w){var c=b.w;var d=this.g[c.id];var e=c.Ue?this.Ee().dc():this.dc();d=this.Gc(!0,c,d,void 0);var f=c.Ke?$.go:$.Vl;c=e.rv(f,d);e=e.Nq(f,d);b.a&&($.D(e)&&(e=$.Mc(e),delete e.dash),a.fill(c));a.stroke(e)}else null!=b.d&&(e=b.d?this.Ee().dc():this.dc(),d=this.Gc(!1,void 0,void 0,void 0),c=e.ty("dummyFill",0,d),e=e.ty("dummyStroke",0,d),b.a&&($.D(e)&&(e=$.Mc(e),delete e.dash),a.fill(c)),a.stroke(e))};
$.g.Ui=function(a){this.nb();this.J(8192)&&(PY(this),this.I(8192));this.ka||(this.ka=this.Ma.Md(),this.U=new $.jB(function(){return $.ek()},function(a){a.clear();a.tag=void 0}),this.U.zIndex(1),this.U.parent(this.ka),this.fb=new $.jB(function(){var a=$.ek();a.fill("none").stroke({color:"#fff",opacity:1E-4,thickness:6});return a},function(a){a.clear();a.tag=void 0}),this.fb.zIndex(3),this.fb.parent(this.ka),this.ta=new $.jB(function(){return $.ek()},function(a){a.clear()}),this.ta.zIndex(3),this.ta.parent(this.ka),
this.Ch=this.ka.Md(),this.Ch.zIndex(4),this.$a=new $.jB(function(){var a=$.ek();a.fill({color:"#fff",opacity:1E-4}).stroke({color:"#fff",opacity:1E-4,thickness:2});return a},function(a){a.clear();a.tag=void 0;a.ic(1,0,0,1,0,0)}),this.$a.zIndex(5),this.$a.parent(this.ka),this.vc().dA(this.Ch),this.Ee().vc().dA(this.Ch),this.dc().dA(this.Ch),this.Ee().dc().dA(this.Ch),this.vc().Vi(),this.dc().Vi(),this.Ee().vc().Vi(),this.Ee().dc().Vi());$.Mv(this.Va(),this);$.Mv(this.vc().Va(),this);$.Mv(this.dc().Va(),
this);$.Mv(this.Ee().vc().Va(),this);$.Mv(this.Ee().dc().Va(),this);if(this.J(4)){this.U.clear();this.fb.clear();this.ta.clear();this.$a.clear();this.vc().CJ();this.dc().CJ();var b=$.M(this.i("verticalSpacing"),a.height),c=$.M(this.i("horizontalSpacing"),a.width),d,e=this.sb>=this.Yc?a.width:a.height;var f=$.M(this.Ee().vc().i("size"),e);var h=$.M(this.vc().i("size"),e);var k=Math.max(h,f);h=a.left+k/2;for(f=0;f<this.ga.length;f++){var l=this.ga[f];if(l){var m=a.top+k/2;for(d=0;d<l.length;d++){var p=
l[d];if(p){if(!p.Nv){var q=$.kB(this.ta);var r=p.Ue?this.Ee().vc():this.vc();r=p.Ke?r.selected().i("stroke"):r.Ra().i("stroke");r=0==$.Oo(r)%2?0:.5;var t=p.Ue?this.Ee().vc():this.vc();var u=$.M(t.i("size"),e);var v=Math.round(u/2);p.Xb=v;switch(t.i("shape")){case "rhombus":q.moveTo(h+r-v,m+r).lineTo(h+r,m+r-v).lineTo(h+r+v,m+r).lineTo(h+r,m+r+v).close();break;case "rectangle":q.moveTo(h+r-v,m+r-v).lineTo(h+r+v,m+r-v).lineTo(h+r+v,m+r+v).lineTo(h+r-v,m+r+v).close();break;default:q.moveTo(h+r+v,m+r).arcTo(v,
v,0,360)}q.tag={m:p};p.hV=q;t=this.Gc(!0,void 0,void 0,p);r=p.Ue?this.Ee().vc():this.vc();q=this.vc().Ra().labels().add(t,{value:{x:h-v,y:m-v}});q.md(r.Ra().labels().Nd());q.width(u);q.height(u);p.gV=q}p.left=h;p.top=m}m+=b}}h+=c}for(f in this.G)if(t=this.G[f],e=t.from,d=t.yf,c=(b=t.Jy?t.Jy:void 0)?this.g[b.id]:void 0,r=t.Ue,!e.Nv){k=$.kB(this.U);p=$.kB(this.U);l=$.kB(this.fb);k.tag=b?{w:b}:{d:r};p.tag=b?{w:b}:{d:r};p.tag.a=!0;l.tag=b?{w:b}:{d:r};r=t.Ue?this.Ee().dc():this.dc();u=this.Gc(!0,b,c,void 0);
b?(r=r.Nq(b.Ke?$.go:$.Vl,u),b.hV=k,b.Z0=$.kB(this.$a),b.Z0.tag={w:b},b.KY=p):r=r.ty("dummyStroke",0,u);r=0==$.Oo(r)%2?0:.5;v=e.left+r+(e.Xb||0);var w=e.top+r;k.moveTo(v,w);l.moveTo(v,w);u=(v+d.left-d.Xb)/2;q=(d.top+w)/2;var x=Math.atan((d.top-e.top)/(d.left-d.Xb-e.left-e.Xb));b&&(b.rotation=180*x/Math.PI);if(t.Nv){for(x=t.yf;x.Nv;)h=x.left+r,m=x.top+r,k.lineTo(h,m),l.lineTo(h,m),t=x.IN,x=t.yf;v=h;w=m;t=x.left+r-(x.Xb||0);x=x.top+r;var y=Math.atan((x-w)/(t-v)),B=UY(v,w,t,x),G=t-10*Math.cos(y);y=x-
10*Math.sin(y);var C=B[0],I=B[1],P=B[2];B=B[3];k.moveTo(v,w).lineTo(G,y)}else t=d.left+r-(d.Xb||0),x=d.top+r,y=Math.atan((x-w)/(t-v)),B=UY(v,w,t,x),G=t-10*Math.cos(y),y=x-10*Math.sin(y),C=B[0],I=B[1],P=B[2],B=B[3],k.moveTo(v,w).lineTo(G,y);p.moveTo(G,y).lineTo(C,I).lineTo(t,x).lineTo(P,B).close();l.lineTo(t,x);b&&(e=$.Um(0,0,d.left-d.Xb-e.left-e.Xb,d.top-e.top),t=this.Gc(!0,b,c,void 0),c=this.dc().Ra().pm().add(t,{value:{x:u+r,y:q+r}}),b.uW=c,c.width(e),c.height(a.height),c.rotation(b.rotation),c.tag=
{w:b},r=this.dc().Ra().$j().add(t,{value:{x:u+r,y:q+r}}),r.width(e),r.height(a.height),b.VT=r,r.rotation(b.rotation),r.tag={w:b})}this.u(49152)}this.J(32768)&&(this.ta.$i(this.Mfa,this),this.U.$i(this.Gja,this),this.u(16384),this.I(32768));this.J(16384)&&(this.vc().Vi(),this.dc().Vi(),this.Ee().vc().Vi(),this.Ee().dc().Vi(),this.ta.$i(this.Nfa,this),this.U.$i(this.Hja,this),this.I(16384))};$.g.pj=function(){return this.na?!this.na.$b():!0};$.g.gk=function(a,b){return $.Dt(this.data(),b)};
$.g.R=function(){this.Rb.length=0;this.Na.length=0;delete this.b;delete this.g;delete this.na;$.od(this.vc(),this.dc(),this.Ee());$.od(this.fb,this.$a,this.ta,this.U,this.Ch,this.ka);this.ka=this.Ch=this.U=this.ta=this.$a=this.fb=null;MY.B.R.call(this)};$.g.F=function(){var a=MY.B.F.call(this);this.na&&(a.treeData=this.na.EA());a.milestones=this.vc().F();a.tasks=this.dc().F();a.criticalPath=this.Ee().F();$.uq(this,aZ,a);return{chart:a}};
$.g.X=function(a,b){MY.B.X.call(this,a,b);this.Cc=$.dm("defaultTooltip");"treeData"in a&&this.data($.pt(a.treeData));"milestones"in a&&this.vc().X(a.milestones,b);"tasks"in a&&this.dc().X(a.tasks,b);"criticalPath"in a&&this.Ee().X(a.criticalPath,b);$.mq(this,aZ,a)};var bZ=MY.prototype;bZ.getType=bZ.Oa;bZ.tasks=bZ.dc;bZ.milestones=bZ.vc;bZ.criticalPath=bZ.Ee;bZ.data=bZ.data;bZ.toCsv=bZ.gk;$.zp.pert=WY;$.F("anychart.pert",WY);}).call(this,$)}