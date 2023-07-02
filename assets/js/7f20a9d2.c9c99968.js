"use strict";(self.webpackChunkdocument_site=self.webpackChunkdocument_site||[]).push([[119],{3905:(e,t,n)=>{n.d(t,{Zo:()=>c,kt:()=>f});var r=n(7294);function a(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function o(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function l(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?o(Object(n),!0).forEach((function(t){a(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):o(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function u(e,t){if(null==e)return{};var n,r,a=function(e,t){if(null==e)return{};var n,r,a={},o=Object.keys(e);for(r=0;r<o.length;r++)n=o[r],t.indexOf(n)>=0||(a[n]=e[n]);return a}(e,t);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);for(r=0;r<o.length;r++)n=o[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}var i=r.createContext({}),s=function(e){var t=r.useContext(i),n=t;return e&&(n="function"==typeof e?e(t):l(l({},t),e)),n},c=function(e){var t=s(e.components);return r.createElement(i.Provider,{value:t},e.children)},p="mdxType",d={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},b=r.forwardRef((function(e,t){var n=e.components,a=e.mdxType,o=e.originalType,i=e.parentName,c=u(e,["components","mdxType","originalType","parentName"]),p=s(n),b=a,f=p["".concat(i,".").concat(b)]||p[b]||d[b]||o;return n?r.createElement(f,l(l({ref:t},c),{},{components:n})):r.createElement(f,l({ref:t},c))}));function f(e,t){var n=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var o=n.length,l=new Array(o);l[0]=b;var u={};for(var i in t)hasOwnProperty.call(t,i)&&(u[i]=t[i]);u.originalType=e,u[p]="string"==typeof e?e:a,l[1]=u;for(var s=2;s<o;s++)l[s]=n[s];return r.createElement.apply(null,l)}return r.createElement.apply(null,n)}b.displayName="MDXCreateElement"},5162:(e,t,n)=>{n.d(t,{Z:()=>l});var r=n(7294),a=n(6010);const o={tabItem:"tabItem_Ymn6"};function l(e){let{children:t,hidden:n,className:l}=e;return r.createElement("div",{role:"tabpanel",className:(0,a.Z)(o.tabItem,l),hidden:n},t)}},4866:(e,t,n)=>{n.d(t,{Z:()=>T});var r=n(7462),a=n(7294),o=n(6010),l=n(2466),u=n(6550),i=n(1980),s=n(7392),c=n(12);function p(e){return function(e){return a.Children.map(e,(e=>{if(!e||(0,a.isValidElement)(e)&&function(e){const{props:t}=e;return!!t&&"object"==typeof t&&"value"in t}(e))return e;throw new Error(`Docusaurus error: Bad <Tabs> child <${"string"==typeof e.type?e.type:e.type.name}>: all children of the <Tabs> component should be <TabItem>, and every <TabItem> should have a unique "value" prop.`)}))?.filter(Boolean)??[]}(e).map((e=>{let{props:{value:t,label:n,attributes:r,default:a}}=e;return{value:t,label:n,attributes:r,default:a}}))}function d(e){const{values:t,children:n}=e;return(0,a.useMemo)((()=>{const e=t??p(n);return function(e){const t=(0,s.l)(e,((e,t)=>e.value===t.value));if(t.length>0)throw new Error(`Docusaurus error: Duplicate values "${t.map((e=>e.value)).join(", ")}" found in <Tabs>. Every value needs to be unique.`)}(e),e}),[t,n])}function b(e){let{value:t,tabValues:n}=e;return n.some((e=>e.value===t))}function f(e){let{queryString:t=!1,groupId:n}=e;const r=(0,u.k6)(),o=function(e){let{queryString:t=!1,groupId:n}=e;if("string"==typeof t)return t;if(!1===t)return null;if(!0===t&&!n)throw new Error('Docusaurus error: The <Tabs> component groupId prop is required if queryString=true, because this value is used as the search param name. You can also provide an explicit value such as queryString="my-search-param".');return n??null}({queryString:t,groupId:n});return[(0,i._X)(o),(0,a.useCallback)((e=>{if(!o)return;const t=new URLSearchParams(r.location.search);t.set(o,e),r.replace({...r.location,search:t.toString()})}),[o,r])]}function m(e){const{defaultValue:t,queryString:n=!1,groupId:r}=e,o=d(e),[l,u]=(0,a.useState)((()=>function(e){let{defaultValue:t,tabValues:n}=e;if(0===n.length)throw new Error("Docusaurus error: the <Tabs> component requires at least one <TabItem> children component");if(t){if(!b({value:t,tabValues:n}))throw new Error(`Docusaurus error: The <Tabs> has a defaultValue "${t}" but none of its children has the corresponding value. Available values are: ${n.map((e=>e.value)).join(", ")}. If you intend to show no default tab, use defaultValue={null} instead.`);return t}const r=n.find((e=>e.default))??n[0];if(!r)throw new Error("Unexpected error: 0 tabValues");return r.value}({defaultValue:t,tabValues:o}))),[i,s]=f({queryString:n,groupId:r}),[p,m]=function(e){let{groupId:t}=e;const n=function(e){return e?`docusaurus.tab.${e}`:null}(t),[r,o]=(0,c.Nk)(n);return[r,(0,a.useCallback)((e=>{n&&o.set(e)}),[n,o])]}({groupId:r}),y=(()=>{const e=i??p;return b({value:e,tabValues:o})?e:null})();(0,a.useLayoutEffect)((()=>{y&&u(y)}),[y]);return{selectedValue:l,selectValue:(0,a.useCallback)((e=>{if(!b({value:e,tabValues:o}))throw new Error(`Can't select invalid tab value=${e}`);u(e),s(e),m(e)}),[s,m,o]),tabValues:o}}var y=n(2389);const g={tabList:"tabList__CuJ",tabItem:"tabItem_LNqP"};function h(e){let{className:t,block:n,selectedValue:u,selectValue:i,tabValues:s}=e;const c=[],{blockElementScrollPositionUntilNextRender:p}=(0,l.o5)(),d=e=>{const t=e.currentTarget,n=c.indexOf(t),r=s[n].value;r!==u&&(p(t),i(r))},b=e=>{let t=null;switch(e.key){case"Enter":d(e);break;case"ArrowRight":{const n=c.indexOf(e.currentTarget)+1;t=c[n]??c[0];break}case"ArrowLeft":{const n=c.indexOf(e.currentTarget)-1;t=c[n]??c[c.length-1];break}}t?.focus()};return a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,o.Z)("tabs",{"tabs--block":n},t)},s.map((e=>{let{value:t,label:n,attributes:l}=e;return a.createElement("li",(0,r.Z)({role:"tab",tabIndex:u===t?0:-1,"aria-selected":u===t,key:t,ref:e=>c.push(e),onKeyDown:b,onClick:d},l,{className:(0,o.Z)("tabs__item",g.tabItem,l?.className,{"tabs__item--active":u===t})}),n??t)})))}function v(e){let{lazy:t,children:n,selectedValue:r}=e;const o=(Array.isArray(n)?n:[n]).filter(Boolean);if(t){const e=o.find((e=>e.props.value===r));return e?(0,a.cloneElement)(e,{className:"margin-top--md"}):null}return a.createElement("div",{className:"margin-top--md"},o.map(((e,t)=>(0,a.cloneElement)(e,{key:t,hidden:e.props.value!==r}))))}function P(e){const t=m(e);return a.createElement("div",{className:(0,o.Z)("tabs-container",g.tabList)},a.createElement(h,(0,r.Z)({},e,t)),a.createElement(v,(0,r.Z)({},e,t)))}function T(e){const t=(0,y.Z)();return a.createElement(P,(0,r.Z)({key:String(t)},e))}},992:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>c,contentTitle:()=>i,default:()=>f,frontMatter:()=>u,metadata:()=>s,toc:()=>p});var r=n(7462),a=(n(7294),n(3905)),o=n(4866),l=n(5162);const u={},i="AllBindableProps and IgnoredProp",s={unversionedId:"How To Use/AllBindableProps and IgnoredProp",id:"How To Use/AllBindableProps and IgnoredProp",title:"AllBindableProps and IgnoredProp",description:"If you just need the default setting for many of your props, try this:",source:"@site/docs/02-How To Use/02-AllBindableProps and IgnoredProp.mdx",sourceDirName:"02-How To Use",slug:"/How To Use/AllBindableProps and IgnoredProp",permalink:"/BindableProps/docs/How To Use/AllBindableProps and IgnoredProp",draft:!1,tags:[],version:"current",sidebarPosition:2,frontMatter:{},sidebar:"tutorialSidebar",previous:{title:"BindableProp",permalink:"/BindableProps/docs/How To Use/BindableProp"},next:{title:"AttachedProp",permalink:"/BindableProps/docs/How To Use/AttachedProp"}},c={},p=[],d={toc:p},b="wrapper";function f(e){let{components:t,...n}=e;return(0,a.kt)(b,(0,r.Z)({},d,n,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("h1",{id:"allbindableprops-and-ignoredprop"},"AllBindableProps and IgnoredProp"),(0,a.kt)("p",null,"If you just need the default setting for many of your props, try this:"),(0,a.kt)(o.Z,{mdxType:"Tabs"},(0,a.kt)(l.Z,{value:"TextInput.cs",mdxType:"TabItem"},(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},'[AllBindableProps]\npublic partial class TextInput : ContentView\n{\n    // Default field\n    string text;\n\n    // Support field with a default value\n    string placeHolder = "Do you trust me?";\n\n    // This field will be handled by BindableProp\n    [BindableProp(\n        DefaultBindingMode = (int)BindingMode.TwoWay,\n        ValidateValueDelegate = nameof(ValidateValue)\n        )]\n    string message = "With every cell in my body!";\n\n    [IgnoredProp]\n    bool isBusy; // Don\'t touch!\n\n    // If you have existing props, we don\'t touch them\n    public static readonly BindableProperty ErrorProperty = BindableProperty.Create(\n            nameof(Error),\n            typeof(string),\n            typeof(TextInput),\n            "Things just get out of hand",\n            (BindingMode)(int)BindingMode.OneWayToSource\n        );\n\n    // Also not touch this prop\n    public string Error\n    {\n        get => (string)GetValue(TextInput.ErrorProperty);\n        set\n        {\n            SetValue(TextInput.ErrorProperty, value);\n        }\n    }\n\n    static bool ValidateValue(BindableObject bindable, object value)\n    {\n        return true;\n    }\n\n    public TextInput()\n    {\n        InitializeComponent();\n    }\n}\n'))),(0,a.kt)(l.Z,{value:"TextInput.g.cs",mdxType:"TabItem"},(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},'// <auto-generated/>\nnamespace MyApp.Controls\n{\n    public partial class TextInput\n    {\n        public static readonly BindableProperty TextProperty = BindableProperty.Create(\n                    nameof(Text),\n                    typeof(string),\n                    typeof(TextInput),\n                    default,\n                    propertyChanged: (bindable, oldValue, newValue) =>\n                                    ((TextInput)bindable).Text = (string)newValue\n                );\n\n        public string Text\n        {\n            get => text;\n            set\n            {\n                OnPropertyChanging(nameof(Text));\n\n                text = value;\n                SetValue(TextInput.TextProperty, text);\n\n                OnPropertyChanged(nameof(Text));\n            }\n        }\n\n        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(\n                    nameof(PlaceHolder),\n                    typeof(string),\n                    typeof(TextInput),\n                    "Do you trust me?",\n                    propertyChanged: (bindable, oldValue, newValue) =>\n                                    ((TextInput)bindable).PlaceHolder = (string)newValue\n                );\n\n        public string PlaceHolder\n        {\n            get => placeHolder;\n            set\n            {\n                OnPropertyChanging(nameof(PlaceHolder));\n\n                placeHolder = value;\n                SetValue(TextInput.PlaceHolderProperty, placeHolder);\n\n                OnPropertyChanged(nameof(PlaceHolder));\n            }\n        }\n\n    }\n}\n')))))}f.isMDXComponent=!0}}]);