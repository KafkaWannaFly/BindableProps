"use strict";(self.webpackChunkdocument_site=self.webpackChunkdocument_site||[]).push([[48],{6357:(e,t,n)=>{n.r(t),n.d(t,{default:()=>be});var a=n(7731),o=n(8148),i=n(7975),s=n(5829),l=n(8120),r=n(3454),c=n(5512),d=n(1598),u=n(5040);const m={backToTopButton:"backToTopButton_LWPR",backToTopButtonShow:"backToTopButtonShow_ieeo"};var b=n(5091);function h(){const{shown:e,scrollToTop:t}=function(e){let{threshold:t}=e;const[n,o]=(0,a.useState)(!1),i=(0,a.useRef)(!1),{startScroll:s,cancelScroll:l}=(0,d.gk)();return(0,d.Mq)(((e,n)=>{let{scrollY:a}=e;const s=n?.scrollY;s&&(i.current?i.current=!1:a>=s?(l(),o(!1)):a<t?o(!1):a+window.innerHeight<document.documentElement.scrollHeight&&o(!0))})),(0,u.$)((e=>{e.location.hash&&(i.current=!0,o(!1))})),{shown:n,scrollToTop:()=>s(0)}}({threshold:300});return(0,b.jsx)("button",{"aria-label":(0,c.T)({id:"theme.BackToTopButton.buttonAriaLabel",message:"Scroll back to top",description:"The ARIA label for the back to top button"}),className:(0,o.A)("clean-btn",s.G.common.backToTopButton,m.backToTopButton,e&&m.backToTopButtonShow),type:"button",onClick:t})}var p=n(7251),x=n(5030),f=n(2732),j=n(3940),_=n(7970);function g(e){return(0,b.jsx)("svg",{width:"20",height:"20","aria-hidden":"true",...e,children:(0,b.jsxs)("g",{fill:"#7a7a7a",children:[(0,b.jsx)("path",{d:"M9.992 10.023c0 .2-.062.399-.172.547l-4.996 7.492a.982.982 0 01-.828.454H1c-.55 0-1-.453-1-1 0-.2.059-.403.168-.551l4.629-6.942L.168 3.078A.939.939 0 010 2.528c0-.548.45-.997 1-.997h2.996c.352 0 .649.18.828.45L9.82 9.472c.11.148.172.347.172.55zm0 0"}),(0,b.jsx)("path",{d:"M19.98 10.023c0 .2-.058.399-.168.547l-4.996 7.492a.987.987 0 01-.828.454h-3c-.547 0-.996-.453-.996-1 0-.2.059-.403.168-.551l4.625-6.942-4.625-6.945a.939.939 0 01-.168-.55 1 1 0 01.996-.997h3c.348 0 .649.18.828.45l4.996 7.492c.11.148.168.347.168.55zm0 0"})]})})}const v={collapseSidebarButton:"collapseSidebarButton_h_KT",collapseSidebarButtonIcon:"collapseSidebarButtonIcon_Csa5"};function C(e){let{onClick:t}=e;return(0,b.jsx)("button",{type:"button",title:(0,c.T)({id:"theme.docs.sidebar.collapseButtonTitle",message:"Collapse sidebar",description:"The title attribute for collapse button of doc sidebar"}),"aria-label":(0,c.T)({id:"theme.docs.sidebar.collapseButtonAriaLabel",message:"Collapse sidebar",description:"The title attribute for collapse button of doc sidebar"}),className:(0,o.A)("button button--secondary button--outline",v.collapseSidebarButton),onClick:t,children:(0,b.jsx)(g,{className:v.collapseSidebarButtonIcon})})}var A=n(6771),k=n(8974);const S=Symbol("EmptyContext"),T=a.createContext(S);function N(e){let{children:t}=e;const[n,o]=(0,a.useState)(null),i=(0,a.useMemo)((()=>({expandedItem:n,setExpandedItem:o})),[n]);return(0,b.jsx)(T.Provider,{value:i,children:t})}var I=n(5664),B=n(2459),y=n(7742),w=n(4711);function L(e){let{collapsed:t,categoryLabel:n,onClick:a}=e;return(0,b.jsx)("button",{"aria-label":t?(0,c.T)({id:"theme.DocSidebarItem.expandCategoryAriaLabel",message:"Expand sidebar category '{label}'",description:"The ARIA label to expand the sidebar category"},{label:n}):(0,c.T)({id:"theme.DocSidebarItem.collapseCategoryAriaLabel",message:"Collapse sidebar category '{label}'",description:"The ARIA label to collapse the sidebar category"},{label:n}),type:"button",className:"clean-btn menu__caret",onClick:a})}function E(e){let{item:t,onItemClick:n,activePath:i,level:r,index:c,...d}=e;const{items:u,label:m,collapsible:h,className:p,href:x}=t,{docs:{sidebar:{autoCollapseCategories:f}}}=(0,j.p)(),_=function(e){const t=(0,w.A)();return(0,a.useMemo)((()=>e.href&&!e.linkUnlisted?e.href:!t&&e.collapsible?(0,l.Nr)(e):void 0),[e,t])}(t),g=(0,l.w8)(t,i),v=(0,B.ys)(x,i),{collapsed:C,setCollapsed:A}=(0,I.u)({initialState:()=>!!h&&(!g&&t.collapsed)}),{expandedItem:N,setExpandedItem:E}=function(){const e=(0,a.useContext)(T);if(e===S)throw new k.dV("DocSidebarItemsExpandedStateProvider");return e}(),H=function(e){void 0===e&&(e=!C),E(e?null:c),A(e)};return function(e){let{isActive:t,collapsed:n,updateCollapsed:o}=e;const i=(0,k.ZC)(t);(0,a.useEffect)((()=>{t&&!i&&n&&o(!1)}),[t,i,n,o])}({isActive:g,collapsed:C,updateCollapsed:H}),(0,a.useEffect)((()=>{h&&null!=N&&N!==c&&f&&A(!0)}),[h,N,c,A,f]),(0,b.jsxs)("li",{className:(0,o.A)(s.G.docs.docSidebarItemCategory,s.G.docs.docSidebarItemCategoryLevel(r),"menu__list-item",{"menu__list-item--collapsed":C},p),children:[(0,b.jsxs)("div",{className:(0,o.A)("menu__list-item-collapsible",{"menu__list-item-collapsible--active":v}),children:[(0,b.jsx)(y.A,{className:(0,o.A)("menu__link",{"menu__link--sublist":h,"menu__link--sublist-caret":!x&&h,"menu__link--active":g}),onClick:h?e=>{n?.(t),x?H(!1):(e.preventDefault(),H())}:()=>{n?.(t)},"aria-current":v?"page":void 0,"aria-expanded":h?!C:void 0,href:h?_??"#":_,...d,children:m}),x&&h&&(0,b.jsx)(L,{collapsed:C,categoryLabel:m,onClick:e=>{e.preventDefault(),H()}})]}),(0,b.jsx)(I.N,{lazy:!0,as:"ul",className:"menu__list",collapsed:C,children:(0,b.jsx)(F,{items:u,tabIndex:C?-1:0,onItemClick:n,activePath:i,level:r+1})})]})}var H=n(6630),M=n(1959);const P={menuExternalLink:"menuExternalLink_oPfo"};function G(e){let{item:t,onItemClick:n,activePath:a,level:i,index:r,...c}=e;const{href:d,label:u,className:m,autoAddBaseUrl:h}=t,p=(0,l.w8)(t,a),x=(0,H.A)(d);return(0,b.jsx)("li",{className:(0,o.A)(s.G.docs.docSidebarItemLink,s.G.docs.docSidebarItemLinkLevel(i),"menu__list-item",m),children:(0,b.jsxs)(y.A,{className:(0,o.A)("menu__link",!x&&P.menuExternalLink,{"menu__link--active":p}),autoAddBaseUrl:h,"aria-current":p?"page":void 0,to:d,...x&&{onClick:n?()=>n(t):void 0},...c,children:[u,!x&&(0,b.jsx)(M.A,{})]})},u)}const W={menuHtmlItem:"menuHtmlItem_mwjZ"};function R(e){let{item:t,level:n,index:a}=e;const{value:i,defaultStyle:l,className:r}=t;return(0,b.jsx)("li",{className:(0,o.A)(s.G.docs.docSidebarItemLink,s.G.docs.docSidebarItemLinkLevel(n),l&&[W.menuHtmlItem,"menu__list-item"],r),dangerouslySetInnerHTML:{__html:i}},a)}function D(e){let{item:t,...n}=e;switch(t.type){case"category":return(0,b.jsx)(E,{item:t,...n});case"html":return(0,b.jsx)(R,{item:t,...n});default:return(0,b.jsx)(G,{item:t,...n})}}function V(e){let{items:t,...n}=e;const a=(0,l.Y)(t,n.activePath);return(0,b.jsx)(N,{children:a.map(((e,t)=>(0,b.jsx)(D,{item:e,index:t,...n},t)))})}const F=(0,a.memo)(V),U={menu:"menu_CkVC",menuWithAnnouncementBar:"menuWithAnnouncementBar_GJiB"};function z(e){let{path:t,sidebar:n,className:i}=e;const l=function(){const{isActive:e}=(0,A.Mj)(),[t,n]=(0,a.useState)(e);return(0,d.Mq)((t=>{let{scrollY:a}=t;e&&n(0===a)}),[e]),e&&t}();return(0,b.jsx)("nav",{"aria-label":(0,c.T)({id:"theme.docs.sidebar.navAriaLabel",message:"Docs sidebar",description:"The ARIA label for the sidebar navigation"}),className:(0,o.A)("menu thin-scrollbar",U.menu,l&&U.menuWithAnnouncementBar,i),children:(0,b.jsx)("ul",{className:(0,o.A)(s.G.docs.docSidebarMenu,"menu__list"),children:(0,b.jsx)(F,{items:n,activePath:t,level:1})})})}const Y="sidebar_oBgw",O="sidebarWithHideableNavbar_EVog",q="sidebarHidden_yDhP",K="sidebarLogo_ico3";function X(e){let{path:t,sidebar:n,onCollapse:a,isHidden:i}=e;const{navbar:{hideOnScroll:s},docs:{sidebar:{hideable:l}}}=(0,j.p)();return(0,b.jsxs)("div",{className:(0,o.A)(Y,s&&O,i&&q),children:[s&&(0,b.jsx)(_.A,{tabIndex:-1,className:K}),(0,b.jsx)(z,{path:t,sidebar:n}),l&&(0,b.jsx)(C,{onClick:a})]})}const Z=a.memo(X);var J=n(5166),$=n(7187);const Q=e=>{let{sidebar:t,path:n}=e;const a=(0,$.M)();return(0,b.jsx)("ul",{className:(0,o.A)(s.G.docs.docSidebarMenu,"menu__list"),children:(0,b.jsx)(F,{items:t,activePath:n,onItemClick:e=>{"category"===e.type&&e.href&&a.toggle(),"link"===e.type&&a.toggle()},level:1})})};function ee(e){return(0,b.jsx)(J.GX,{component:Q,props:e})}const te=a.memo(ee);function ne(e){const t=(0,f.l)(),n="desktop"===t||"ssr"===t,a="mobile"===t;return(0,b.jsxs)(b.Fragment,{children:[n&&(0,b.jsx)(Z,{...e}),a&&(0,b.jsx)(te,{...e})]})}const ae={expandButton:"expandButton_rGhg",expandButtonIcon:"expandButtonIcon_OlvS"};function oe(e){let{toggleSidebar:t}=e;return(0,b.jsx)("div",{className:ae.expandButton,title:(0,c.T)({id:"theme.docs.sidebar.expandButtonTitle",message:"Expand sidebar",description:"The ARIA label and title attribute for expand button of doc sidebar"}),"aria-label":(0,c.T)({id:"theme.docs.sidebar.expandButtonAriaLabel",message:"Expand sidebar",description:"The ARIA label and title attribute for expand button of doc sidebar"}),tabIndex:0,role:"button",onKeyDown:t,onClick:t,children:(0,b.jsx)(g,{className:ae.expandButtonIcon})})}const ie={docSidebarContainer:"docSidebarContainer_P3vk",docSidebarContainerHidden:"docSidebarContainerHidden_Yfw_",sidebarViewport:"sidebarViewport_MH3n"};function se(e){let{children:t}=e;const n=(0,r.t)();return(0,b.jsx)(a.Fragment,{children:t},n?.name??"noSidebar")}function le(e){let{sidebar:t,hiddenSidebarContainer:n,setHiddenSidebarContainer:i}=e;const{pathname:l}=(0,x.zy)(),[r,c]=(0,a.useState)(!1),d=(0,a.useCallback)((()=>{r&&c(!1),!r&&(0,p.O)()&&c(!0),i((e=>!e))}),[i,r]);return(0,b.jsx)("aside",{className:(0,o.A)(s.G.docs.docSidebarContainer,ie.docSidebarContainer,n&&ie.docSidebarContainerHidden),onTransitionEnd:e=>{e.currentTarget.classList.contains(ie.docSidebarContainer)&&n&&c(!0)},children:(0,b.jsx)(se,{children:(0,b.jsxs)("div",{className:(0,o.A)(ie.sidebarViewport,r&&ie.sidebarViewportHidden),children:[(0,b.jsx)(ne,{sidebar:t,path:l,onCollapse:d,isHidden:r}),r&&(0,b.jsx)(oe,{toggleSidebar:d})]})})})}const re={docMainContainer:"docMainContainer_XEtU",docMainContainerEnhanced:"docMainContainerEnhanced_xE9U",docItemWrapperEnhanced:"docItemWrapperEnhanced_zeLO"};function ce(e){let{hiddenSidebarContainer:t,children:n}=e;const a=(0,r.t)();return(0,b.jsx)("main",{className:(0,o.A)(re.docMainContainer,(t||!a)&&re.docMainContainerEnhanced),children:(0,b.jsx)("div",{className:(0,o.A)("container padding-top--md padding-bottom--lg",re.docItemWrapper,t&&re.docItemWrapperEnhanced),children:n})})}const de={docRoot:"docRoot_a3VL",docsWrapper:"docsWrapper_EN2u"};function ue(e){let{children:t}=e;const n=(0,r.t)(),[o,i]=(0,a.useState)(!1);return(0,b.jsxs)("div",{className:de.docsWrapper,children:[(0,b.jsx)(h,{}),(0,b.jsxs)("div",{className:de.docRoot,children:[n&&(0,b.jsx)(le,{sidebar:n.items,hiddenSidebarContainer:o,setHiddenSidebarContainer:i}),(0,b.jsx)(ce,{hiddenSidebarContainer:o,children:t})]})]})}var me=n(1032);function be(e){const t=(0,l.B5)(e);if(!t)return(0,b.jsx)(me.A,{});const{docElement:n,sidebarName:a,sidebarItems:c}=t;return(0,b.jsx)(i.e3,{className:(0,o.A)(s.G.page.docsDocPage),children:(0,b.jsx)(r.V,{name:a,items:c,children:(0,b.jsx)(ue,{children:n})})})}},1032:(e,t,n)=>{n.d(t,{A:()=>l});n(7731);var a=n(8148),o=n(5512),i=n(3534),s=n(5091);function l(e){let{className:t}=e;return(0,s.jsx)("main",{className:(0,a.A)("container margin-vert--xl",t),children:(0,s.jsx)("div",{className:"row",children:(0,s.jsxs)("div",{className:"col col--6 col--offset-3",children:[(0,s.jsx)(i.A,{as:"h1",className:"hero__title",children:(0,s.jsx)(o.A,{id:"theme.NotFound.title",description:"The title of the 404 page",children:"Page Not Found"})}),(0,s.jsx)("p",{children:(0,s.jsx)(o.A,{id:"theme.NotFound.p1",description:"The first paragraph of the 404 page",children:"We could not find what you were looking for."})}),(0,s.jsx)("p",{children:(0,s.jsx)(o.A,{id:"theme.NotFound.p2",description:"The 2nd paragraph of the 404 page",children:"Please contact the owner of the site that linked you to the original URL and let them know their link is broken."})})]})})})}}}]);