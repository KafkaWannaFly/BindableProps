"use strict";(self.webpackChunkdocument_site=self.webpackChunkdocument_site||[]).push([[237],{1322:(e,n,t)=>{t.r(n),t.d(n,{default:()=>g});var a=t(2263),r=t(7961),l=t(5222),o=t(5009),i=t(7294),c=t(9844),s=t(7462),u=t(3746),d=t(7410),m=t(5424);const p=e=>{let{codeBlockHeight:n,code:t,language:a,highlightLinePredicate:r,highlightLineColor:l}=e;return i.createElement(u.ZP,{key:100*Math.random(),Prism:d.Z,language:a,code:t,theme:m.Z},(e=>{let{className:t,style:a,tokens:o,getLineProps:c,getTokenProps:u}=e;return i.createElement("pre",{key:o.toString(),style:{...a,height:n,fontFamily:"monospace"}},o.map(((e,n)=>{const t=e.map((e=>e.content)).join().replace(/,/g,"");return i.createElement("div",(0,s.Z)({key:n},c({line:e}),{style:{backgroundColor:r&&r(t)?l:"inherit"}}),i.createElement("span",{key:n},n+1),e.map(((e,n)=>i.createElement("span",(0,s.Z)({key:n},u({token:e}))))))})))}))};function g(){const{siteConfig:e}=(0,a.Z)(),n="450px";return i.createElement(r.Z,{title:`${e.title}`,description:"MAUI App source generator"},i.createElement("div",null,i.createElement(l.Z,{direction:"vertical",style:{display:"flex",justifyContent:"center",alignItems:"center",textAlign:"center"},className:"margin-vert--lg container",size:48},i.createElement(c.e,{sequence:['"I spent hours to save your moments." - Kafka Wanna Fly',1e3,"",1e3],repeat:1/0,style:{fontFamily:"monospace",fontSize:"2rem",textDecoration:"underline",textUnderlineOffset:"1rem"}}),i.createElement("p",null,"This library is a source generator. ",i.createElement("code",null,"BindableProps")," helps you to create MAUI components much faster than the standard way. It saves your time and is an essential part of every MAUI project.")),i.createElement("div",{style:{backgroundImage:"url('img/lion.png')"}},i.createElement(o.Z,{defaultActiveKey:"1",centered:!0,className:"container",type:"line",tabBarStyle:{backgroundColor:"var(--ifm-background-color)",marginBottom:0,borderRadius:8,color:"var(--ifm-font-color-base)"},items:[{label:"My Code",key:"1",children:i.createElement(p,{key:1,language:"csharp",code:h,codeBlockHeight:n,highlightLinePredicate:e=>null!==e.match(/\[(BindableProp.*?)\]/g),highlightLineColor:"rgba(255, 255, 255, 0.1)"})},{label:"Generated Code",key:"2",children:i.createElement(p,{key:2,language:"csharp",code:y,codeBlockHeight:n})}]}))))}const h='\n    using BindableProps;\n\n    namespace MyMauiApp.Controls;\n\n    public partial class NovelReview : ContentView\n    {\n        [BindableProp(DefaultBindingMode = (int)BindingMode.OneTime)]\n        private string _name = "Kafka On The Shore";\n        \n        [BindableProp]\n        private string _author = "Haruki Murakami";\n\n        public NovelReview()\n        {\n            \n        }\n    }\n',y='\n    // <auto-generated/>\n    using BindableProps;\n\n    namespace MyMauiApp.Controls\n    {\n        public partial class NovelReview\n        {\n\n            public  static readonly BindableProperty NameProperty = BindableProperty.Create(\n                nameof(Name),\n                typeof(string),\n                typeof(NovelReview),\n                "Kafka On The Shore",\n                (BindingMode)(int)BindingMode.OneTime,\n                null,\n                (bindable, oldValue, newValue) => \n                            ((NovelReview)bindable).Name = (string)newValue,\n                null,\n                null,\n                null\n            );\n\n            public  string Name\n            {\n                get => _name;\n                set \n                { \n                    OnPropertyChanging(nameof(Name));\n\n                    _name = value;\n                    SetValue(NovelReview.NameProperty, _name);\n\n                    OnPropertyChanged(nameof(Name));\n                }\n            }\n\n            public  static readonly BindableProperty AuthorProperty = BindableProperty.Create(\n                nameof(Author),\n                typeof(string),\n                typeof(NovelReview),\n                "Haruki Murakami",\n                (BindingMode)0,\n                null,\n                (bindable, oldValue, newValue) => \n                            ((NovelReview)bindable).Author = (string)newValue,\n                null,\n                null,\n                null\n            );\n\n            public  string Author\n            {\n                get => _author;\n                set \n                { \n                    OnPropertyChanging(nameof(Author));\n\n                    _author = value;\n                    SetValue(NovelReview.AuthorProperty, _author);\n\n                    OnPropertyChanged(nameof(Author));\n                }\n            }\n\n        }\n    }\n'}}]);