"use strict";(self.webpackChunkdocument_site=self.webpackChunkdocument_site||[]).push([[676],{1794:(e,n,a)=>{a.r(n),a.d(n,{assets:()=>c,contentTitle:()=>s,default:()=>h,frontMatter:()=>o,metadata:()=>u,toc:()=>d});var t=a(5091),r=a(943),l=a(1530),i=a(2580);const o={},s=void 0,u={id:"How To Use/BindableReadOnlyProp",title:"BindableReadOnlyProp",description:"Simple Usage",source:"@site/docs/02-How To Use/02-BindableReadOnlyProp.mdx",sourceDirName:"02-How To Use",slug:"/How To Use/BindableReadOnlyProp",permalink:"/BindableProps/docs/How To Use/BindableReadOnlyProp",draft:!1,unlisted:!1,tags:[],version:"current",sidebarPosition:2,frontMatter:{},sidebar:"tutorialSidebar",previous:{title:"BindableProp",permalink:"/BindableProps/docs/How To Use/BindableProp"},next:{title:"AllBindableProps and IgnoredProp",permalink:"/BindableProps/docs/How To Use/AllBindableProps and IgnoredProp"}},c={},d=[{value:"Simple Usage",id:"simple-usage",level:2}];function p(e){const n={admonition:"admonition",code:"code",h2:"h2",p:"p",pre:"pre",strong:"strong",...(0,r.R)(),...e.components};return(0,t.jsxs)(t.Fragment,{children:[(0,t.jsx)(n.h2,{id:"simple-usage",children:"Simple Usage"}),"\n",(0,t.jsxs)(n.p,{children:["Similar to ",(0,t.jsx)(n.code,{children:"BindableProp"}),", ",(0,t.jsx)(n.code,{children:"BindableReadOnlyProp"})," is used to create a bindable property with a read-only property. Here's how you can use it:"]}),"\n",(0,t.jsxs)(l.A,{children:[(0,t.jsx)(i.A,{value:"MainPage.xaml.cs",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-csharp",metastring:"showLineNumbers",children:'\nnamespace MauiApp1;\n\npublic partial class MainPage : ContentPage\n{\n    // highlight-start\n    [BindableReadOnlyProp]\n    private string _pageType = "Portrait";\n    // highlight-end\n    \n    public MainPage()\n    {\n        InitializeComponent();\n    }\n\n    protected override void OnSizeAllocated(double width, double height)\n    {\n        PageType = height > width ? "Portrait" : "Landscape";\n        base.OnSizeAllocated(width, height);\n    }\n}\n'})})}),(0,t.jsx)(i.A,{value:"MauiApp1.MainPage.g.cs",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-csharp",metastring:"showLineNumbers",children:'#pragma warning disable\n\n// <auto-generated/>\nusing BindableProps;\n\nnamespace MauiApp1\n{\n    public partial class MainPage\n    {\n\n        public  static readonly BindablePropertyKey PageTypePropertyKey = BindableProperty.CreateReadOnly(\n            nameof(PageType),\n            typeof(string),\n            typeof(MainPage),\n            "Portrait",\n            (BindingMode)0,\n            null,\n            (bindable, oldValue, newValue) => \n                        ((MainPage)bindable).PageType = (string)newValue,\n            null,\n            null,\n            null\n        );\n\n        public  static readonly BindableProperty PageTypeProperty = PageTypePropertyKey.BindableProperty;\n\n        public  string PageType\n        {\n            get => _pageType;\n            // highlight-start\n            private set \n            // highlight-end\n            { \n                OnPropertyChanging(nameof(PageType));\n\n                _pageType = value;\n                SetValue(MainPage.PageTypePropertyKey, _pageType);\n\n                OnPropertyChanged(nameof(PageType));\n            }\n        }\n\n    }\n}\n'})})})]}),"\n",(0,t.jsx)(n.admonition,{type:"warning",children:(0,t.jsxs)(n.p,{children:["Notice the ",(0,t.jsx)(n.code,{children:"private set"})," in ",(0,t.jsx)(n.code,{children:"MauiApp1.MainPage.g.cs"}),". This is the ",(0,t.jsx)(n.strong,{children:"read-only"})," property that you can set only within the class."]})}),"\n",(0,t.jsxs)(n.p,{children:["In this example, the ",(0,t.jsx)(n.code,{children:"PageType"})," property is set based on the screen width and height."]}),"\n",(0,t.jsx)(l.A,{children:(0,t.jsx)(i.A,{value:"MainPage.xaml",children:(0,t.jsx)(n.pre,{children:(0,t.jsx)(n.code,{className:"language-xml",metastring:"showLineNumbers",children:'<?xml version="1.0" encoding="utf-8"?>\n\n<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"\n             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"\n             x:Name="Self"\n             x:Class="MauiApp1.MainPage">\n\n    <ScrollView>\n        <VerticalStackLayout\n            Padding="30,0"\n            Spacing="25">\n            <Label\n                Text="{x:Binding PageType, Source={x:Reference Self}}"\n                FontSize="30"\n                HorizontalOptions="Center" />\n        </VerticalStackLayout>\n    </ScrollView>\n\n</ContentPage>\n'})})})})]})}function h(e={}){const{wrapper:n}={...(0,r.R)(),...e.components};return n?(0,t.jsx)(n,{...e,children:(0,t.jsx)(p,{...e})}):p(e)}},2580:(e,n,a)=>{a.d(n,{A:()=>i});a(7731);var t=a(8148);const r={tabItem:"tabItem_Y9a4"};var l=a(5091);function i(e){let{children:n,hidden:a,className:i}=e;return(0,l.jsx)("div",{role:"tabpanel",className:(0,t.A)(r.tabItem,i),hidden:a,children:n})}},1530:(e,n,a)=>{a.d(n,{A:()=>w});var t=a(7731),r=a(8148),l=a(1598),i=a(5030),o=a(5845),s=a(5603),u=a(6944),c=a(2132);function d(e){return t.Children.toArray(e).filter((e=>"\n"!==e)).map((e=>{if(!e||(0,t.isValidElement)(e)&&function(e){const{props:n}=e;return!!n&&"object"==typeof n&&"value"in n}(e))return e;throw new Error(`Docusaurus error: Bad <Tabs> child <${"string"==typeof e.type?e.type:e.type.name}>: all children of the <Tabs> component should be <TabItem>, and every <TabItem> should have a unique "value" prop.`)}))?.filter(Boolean)??[]}function p(e){const{values:n,children:a}=e;return(0,t.useMemo)((()=>{const e=n??function(e){return d(e).map((e=>{let{props:{value:n,label:a,attributes:t,default:r}}=e;return{value:n,label:a,attributes:t,default:r}}))}(a);return function(e){const n=(0,u.X)(e,((e,n)=>e.value===n.value));if(n.length>0)throw new Error(`Docusaurus error: Duplicate values "${n.map((e=>e.value)).join(", ")}" found in <Tabs>. Every value needs to be unique.`)}(e),e}),[n,a])}function h(e){let{value:n,tabValues:a}=e;return a.some((e=>e.value===n))}function g(e){let{queryString:n=!1,groupId:a}=e;const r=(0,i.W6)(),l=function(e){let{queryString:n=!1,groupId:a}=e;if("string"==typeof n)return n;if(!1===n)return null;if(!0===n&&!a)throw new Error('Docusaurus error: The <Tabs> component groupId prop is required if queryString=true, because this value is used as the search param name. You can also provide an explicit value such as queryString="my-search-param".');return a??null}({queryString:n,groupId:a});return[(0,s.aZ)(l),(0,t.useCallback)((e=>{if(!l)return;const n=new URLSearchParams(r.location.search);n.set(l,e),r.replace({...r.location,search:n.toString()})}),[l,r])]}function b(e){const{defaultValue:n,queryString:a=!1,groupId:r}=e,l=p(e),[i,s]=(0,t.useState)((()=>function(e){let{defaultValue:n,tabValues:a}=e;if(0===a.length)throw new Error("Docusaurus error: the <Tabs> component requires at least one <TabItem> children component");if(n){if(!h({value:n,tabValues:a}))throw new Error(`Docusaurus error: The <Tabs> has a defaultValue "${n}" but none of its children has the corresponding value. Available values are: ${a.map((e=>e.value)).join(", ")}. If you intend to show no default tab, use defaultValue={null} instead.`);return n}const t=a.find((e=>e.default))??a[0];if(!t)throw new Error("Unexpected error: 0 tabValues");return t.value}({defaultValue:n,tabValues:l}))),[u,d]=g({queryString:a,groupId:r}),[b,m]=function(e){let{groupId:n}=e;const a=function(e){return e?`docusaurus.tab.${e}`:null}(n),[r,l]=(0,c.Dv)(a);return[r,(0,t.useCallback)((e=>{a&&l.set(e)}),[a,l])]}({groupId:r}),f=(()=>{const e=u??b;return h({value:e,tabValues:l})?e:null})();(0,o.A)((()=>{f&&s(f)}),[f]);return{selectedValue:i,selectValue:(0,t.useCallback)((e=>{if(!h({value:e,tabValues:l}))throw new Error(`Can't select invalid tab value=${e}`);s(e),d(e),m(e)}),[d,m,l]),tabValues:l}}var m=a(4711);const f={tabList:"tabList_WUbM",tabItem:"tabItem_sbBo"};var y=a(5091);function P(e){let{className:n,block:a,selectedValue:t,selectValue:i,tabValues:o}=e;const s=[],{blockElementScrollPositionUntilNextRender:u}=(0,l.a_)(),c=e=>{const n=e.currentTarget,a=s.indexOf(n),r=o[a].value;r!==t&&(u(n),i(r))},d=e=>{let n=null;switch(e.key){case"Enter":c(e);break;case"ArrowRight":{const a=s.indexOf(e.currentTarget)+1;n=s[a]??s[0];break}case"ArrowLeft":{const a=s.indexOf(e.currentTarget)-1;n=s[a]??s[s.length-1];break}}n?.focus()};return(0,y.jsx)("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,r.A)("tabs",{"tabs--block":a},n),children:o.map((e=>{let{value:n,label:a,attributes:l}=e;return(0,y.jsx)("li",{role:"tab",tabIndex:t===n?0:-1,"aria-selected":t===n,ref:e=>s.push(e),onKeyDown:d,onClick:c,...l,className:(0,r.A)("tabs__item",f.tabItem,l?.className,{"tabs__item--active":t===n}),children:a??n},n)}))})}function v(e){let{lazy:n,children:a,selectedValue:r}=e;const l=(Array.isArray(a)?a:[a]).filter(Boolean);if(n){const e=l.find((e=>e.props.value===r));return e?(0,t.cloneElement)(e,{className:"margin-top--md"}):null}return(0,y.jsx)("div",{className:"margin-top--md",children:l.map(((e,n)=>(0,t.cloneElement)(e,{key:n,hidden:e.props.value!==r})))})}function x(e){const n=b(e);return(0,y.jsxs)("div",{className:(0,r.A)("tabs-container",f.tabList),children:[(0,y.jsx)(P,{...e,...n}),(0,y.jsx)(v,{...e,...n})]})}function w(e){const n=(0,m.A)();return(0,y.jsx)(x,{...e,children:d(e.children)},String(n))}},943:(e,n,a)=>{a.d(n,{R:()=>i,x:()=>o});var t=a(7731);const r={},l=t.createContext(r);function i(e){const n=t.useContext(l);return t.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function o(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(r):e.components||r:i(e.components),t.createElement(l.Provider,{value:n},e.children)}}}]);