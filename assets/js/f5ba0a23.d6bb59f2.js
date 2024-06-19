"use strict";(self.webpackChunkdocument_site=self.webpackChunkdocument_site||[]).push([[879],{155:(e,n,t)=>{t.r(n),t.d(n,{assets:()=>c,contentTitle:()=>u,default:()=>b,frontMatter:()=>s,metadata:()=>i,toc:()=>d});var r=t(8040),a=t(943),o=t(1387),l=t(1971);const s={},u="AllBindableProps and IgnoredProp",i={id:"How To Use/AllBindableProps and IgnoredProp",title:"AllBindableProps and IgnoredProp",description:"If you just need the default setting for many of your props, try this:",source:"@site/docs/02-How To Use/03-AllBindableProps and IgnoredProp.mdx",sourceDirName:"02-How To Use",slug:"/How To Use/AllBindableProps and IgnoredProp",permalink:"/BindableProps/docs/How To Use/AllBindableProps and IgnoredProp",draft:!1,unlisted:!1,tags:[],version:"current",sidebarPosition:3,frontMatter:{},sidebar:"tutorialSidebar",previous:{title:"BindableReadOnlyProp",permalink:"/BindableProps/docs/How To Use/BindableReadOnlyProp"},next:{title:"AttachedProp",permalink:"/BindableProps/docs/How To Use/AttachedProp"}},c={},d=[];function p(e){const n={code:"code",h1:"h1",p:"p",pre:"pre",...(0,a.R)(),...e.components};return(0,r.jsxs)(r.Fragment,{children:[(0,r.jsx)(n.h1,{id:"allbindableprops-and-ignoredprop",children:"AllBindableProps and IgnoredProp"}),"\n",(0,r.jsx)(n.p,{children:"If you just need the default setting for many of your props, try this:"}),"\n",(0,r.jsxs)(o.A,{children:[(0,r.jsx)(l.A,{value:"TextInput.cs",children:(0,r.jsx)(n.pre,{children:(0,r.jsx)(n.code,{className:"language-csharp",metastring:"showLineNumbers",children:'[AllBindableProps]\npublic partial class TextInput : ContentView\n{\n    // Default field\n    string text;\n\n    // Support field with a default value\n    string placeHolder = "Do you trust me?";\n\n    // This field will be handled by BindableProp\n    [BindableProp(\n        DefaultBindingMode = (int)BindingMode.TwoWay,\n        ValidateValueDelegate = nameof(ValidateValue)\n        )]\n    string message = "With every cell in my body!";\n\n    // highlight-start\n    [IgnoredProp]\n    bool isBusy; // Don\'t touch!\n    // highlight-end\n\n    private readonly Frame controlFrame; // Not touch either\n    \n\n    // If you have existing props, we don\'t touch them\n    public static readonly BindableProperty ErrorProperty = BindableProperty.Create(\n            nameof(Error),\n            typeof(string),\n            typeof(TextInput),\n            "Things just get out of hand",\n            (BindingMode)(int)BindingMode.OneWayToSource\n        );\n\n    // Also not touch this prop\n    public string Error\n    {\n        get => (string)GetValue(TextInput.ErrorProperty);\n        set\n        {\n            SetValue(TextInput.ErrorProperty, value);\n        }\n    }\n\n    static bool ValidateValue(BindableObject bindable, object value)\n    {\n        return true;\n    }\n\n    public TextInput()\n    {\n        InitializeComponent();\n    }\n}\n'})})}),(0,r.jsx)(l.A,{value:"TextInput.g.cs",children:(0,r.jsx)(n.pre,{children:(0,r.jsx)(n.code,{className:"language-csharp",metastring:"showLineNumbers",children:'// <auto-generated/>\nnamespace MyApp.Controls\n{\n    public partial class TextInput\n    {\n        public static readonly BindableProperty TextProperty = BindableProperty.Create(\n                    nameof(Text),\n                    typeof(string),\n                    typeof(TextInput),\n                    default,\n                    propertyChanged: (bindable, oldValue, newValue) =>\n                                    ((TextInput)bindable).Text = (string)newValue\n                );\n\n        public string Text\n        {\n            get => text;\n            set\n            {\n                OnPropertyChanging(nameof(Text));\n\n                text = value;\n                SetValue(TextInput.TextProperty, text);\n\n                OnPropertyChanged(nameof(Text));\n            }\n        }\n\n        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(\n                    nameof(PlaceHolder),\n                    typeof(string),\n                    typeof(TextInput),\n                    "Do you trust me?",\n                    propertyChanged: (bindable, oldValue, newValue) =>\n                                    ((TextInput)bindable).PlaceHolder = (string)newValue\n                );\n\n        public string PlaceHolder\n        {\n            get => placeHolder;\n            set\n            {\n                OnPropertyChanging(nameof(PlaceHolder));\n\n                placeHolder = value;\n                SetValue(TextInput.PlaceHolderProperty, placeHolder);\n\n                OnPropertyChanged(nameof(PlaceHolder));\n            }\n        }\n\n    }\n}\n'})})})]})]})}function b(e={}){const{wrapper:n}={...(0,a.R)(),...e.components};return n?(0,r.jsx)(n,{...e,children:(0,r.jsx)(p,{...e})}):p(e)}},1971:(e,n,t)=>{t.d(n,{A:()=>l});t(2340);var r=t(5978);const a={tabItem:"tabItem_LTlv"};var o=t(8040);function l(e){let{children:n,hidden:t,className:l}=e;return(0,o.jsx)("div",{role:"tabpanel",className:(0,r.A)(a.tabItem,l),hidden:t,children:n})}},1387:(e,n,t)=>{t.d(n,{A:()=>T});var r=t(2340),a=t(5978),o=t(2590),l=t(6378),s=t(17),u=t(4515),i=t(304),c=t(1468);function d(e){return r.Children.toArray(e).filter((e=>"\n"!==e)).map((e=>{if(!e||(0,r.isValidElement)(e)&&function(e){const{props:n}=e;return!!n&&"object"==typeof n&&"value"in n}(e))return e;throw new Error(`Docusaurus error: Bad <Tabs> child <${"string"==typeof e.type?e.type:e.type.name}>: all children of the <Tabs> component should be <TabItem>, and every <TabItem> should have a unique "value" prop.`)}))?.filter(Boolean)??[]}function p(e){const{values:n,children:t}=e;return(0,r.useMemo)((()=>{const e=n??function(e){return d(e).map((e=>{let{props:{value:n,label:t,attributes:r,default:a}}=e;return{value:n,label:t,attributes:r,default:a}}))}(t);return function(e){const n=(0,i.X)(e,((e,n)=>e.value===n.value));if(n.length>0)throw new Error(`Docusaurus error: Duplicate values "${n.map((e=>e.value)).join(", ")}" found in <Tabs>. Every value needs to be unique.`)}(e),e}),[n,t])}function b(e){let{value:n,tabValues:t}=e;return t.some((e=>e.value===n))}function h(e){let{queryString:n=!1,groupId:t}=e;const a=(0,l.W6)(),o=function(e){let{queryString:n=!1,groupId:t}=e;if("string"==typeof n)return n;if(!1===n)return null;if(!0===n&&!t)throw new Error('Docusaurus error: The <Tabs> component groupId prop is required if queryString=true, because this value is used as the search param name. You can also provide an explicit value such as queryString="my-search-param".');return t??null}({queryString:n,groupId:t});return[(0,u.aZ)(o),(0,r.useCallback)((e=>{if(!o)return;const n=new URLSearchParams(a.location.search);n.set(o,e),a.replace({...a.location,search:n.toString()})}),[o,a])]}function f(e){const{defaultValue:n,queryString:t=!1,groupId:a}=e,o=p(e),[l,u]=(0,r.useState)((()=>function(e){let{defaultValue:n,tabValues:t}=e;if(0===t.length)throw new Error("Docusaurus error: the <Tabs> component requires at least one <TabItem> children component");if(n){if(!b({value:n,tabValues:t}))throw new Error(`Docusaurus error: The <Tabs> has a defaultValue "${n}" but none of its children has the corresponding value. Available values are: ${t.map((e=>e.value)).join(", ")}. If you intend to show no default tab, use defaultValue={null} instead.`);return n}const r=t.find((e=>e.default))??t[0];if(!r)throw new Error("Unexpected error: 0 tabValues");return r.value}({defaultValue:n,tabValues:o}))),[i,d]=h({queryString:t,groupId:a}),[f,m]=function(e){let{groupId:n}=e;const t=function(e){return e?`docusaurus.tab.${e}`:null}(n),[a,o]=(0,c.Dv)(t);return[a,(0,r.useCallback)((e=>{t&&o.set(e)}),[t,o])]}({groupId:a}),g=(()=>{const e=i??f;return b({value:e,tabValues:o})?e:null})();(0,s.A)((()=>{g&&u(g)}),[g]);return{selectedValue:l,selectValue:(0,r.useCallback)((e=>{if(!b({value:e,tabValues:o}))throw new Error(`Can't select invalid tab value=${e}`);u(e),d(e),m(e)}),[d,m,o]),tabValues:o}}var m=t(2979);const g={tabList:"tabList_seV7",tabItem:"tabItem_lluL"};var y=t(8040);function v(e){let{className:n,block:t,selectedValue:r,selectValue:l,tabValues:s}=e;const u=[],{blockElementScrollPositionUntilNextRender:i}=(0,o.a_)(),c=e=>{const n=e.currentTarget,t=u.indexOf(n),a=s[t].value;a!==r&&(i(n),l(a))},d=e=>{let n=null;switch(e.key){case"Enter":c(e);break;case"ArrowRight":{const t=u.indexOf(e.currentTarget)+1;n=u[t]??u[0];break}case"ArrowLeft":{const t=u.indexOf(e.currentTarget)-1;n=u[t]??u[u.length-1];break}}n?.focus()};return(0,y.jsx)("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,a.A)("tabs",{"tabs--block":t},n),children:s.map((e=>{let{value:n,label:t,attributes:o}=e;return(0,y.jsx)("li",{role:"tab",tabIndex:r===n?0:-1,"aria-selected":r===n,ref:e=>u.push(e),onKeyDown:d,onClick:c,...o,className:(0,a.A)("tabs__item",g.tabItem,o?.className,{"tabs__item--active":r===n}),children:t??n},n)}))})}function x(e){let{lazy:n,children:t,selectedValue:a}=e;const o=(Array.isArray(t)?t:[t]).filter(Boolean);if(n){const e=o.find((e=>e.props.value===a));return e?(0,r.cloneElement)(e,{className:"margin-top--md"}):null}return(0,y.jsx)("div",{className:"margin-top--md",children:o.map(((e,n)=>(0,r.cloneElement)(e,{key:n,hidden:e.props.value!==a})))})}function P(e){const n=f(e);return(0,y.jsxs)("div",{className:(0,a.A)("tabs-container",g.tabList),children:[(0,y.jsx)(v,{...n,...e}),(0,y.jsx)(x,{...n,...e})]})}function T(e){const n=(0,m.A)();return(0,y.jsx)(P,{...e,children:d(e.children)},String(n))}},943:(e,n,t)=>{t.d(n,{R:()=>l,x:()=>s});var r=t(2340);const a={},o=r.createContext(a);function l(e){const n=r.useContext(o);return r.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function s(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(a):e.components||a:l(e.components),r.createElement(o.Provider,{value:n},e.children)}}}]);