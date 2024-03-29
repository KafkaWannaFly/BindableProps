// @ts-check
// Note: type annotations allow type checking and IDEs autocompletion
import { themes as prismThemes } from 'prism-react-renderer';

/** @type {import('@docusaurus/types').Config} */
const config = {
    title: "BindableProps",
    tagline: "BindableProps",
    favicon: "img/favicon.ico",

    // Set the production url of your site here
    url: "https://kafkawannafly.github.io",
    // Set the /<baseUrl>/ pathname under which your site is served
    // For GitHub pages deployment, it is often '/<projectName>/'
    baseUrl: "/BindableProps/",

    // GitHub pages deployment config.
    // If you aren't using GitHub pages, you don't need these.
    organizationName: "KafkaWannaFly", // Usually your GitHub org/user name.
    projectName: "BindableProps", // Usually your repo name.
    deploymentBranch: "master",

    onBrokenLinks: "throw",
    onBrokenMarkdownLinks: "warn",
    trailingSlash: false,

    // Even if you don't use internalization, you can use this field to set useful
    // metadata like html lang. For example, if your site is Chinese, you may want
    // to replace "en" with "zh-Hans".
    i18n: {
        defaultLocale: "en",
        locales: ["en"],
    },

    presets: [
        [
            "classic",
            /** @type {import('@docusaurus/preset-classic').Options} */
            {
                docs: {
                    sidebarPath: require.resolve("./sidebars.js"),
                },
                blog: false,
                theme: {
                    customCss: require.resolve("./src/css/custom.css"),
                },
                gtag: {
                    trackingID: 'G-FTPEY00WQV',
                    anonymizeIP: true,
                },
            },

        ],
    ],

    themeConfig:
        /** @type {import('@docusaurus/preset-classic').ThemeConfig} */
        ({
            // Replace with your project's social card
            image: "img/docusaurus-social-card.jpg",
            metadata: [
                {
                    name: "dotnet maui",
                    content: "Library, helper, utility, open source"
                },
                {
                    name: "source generator",
                    content: "Source generator for BindableProperty"
                },
                {
                    name: "author",
                    content: "KafkaWannaFly"
                }
            ],
            navbar: {
                title: "BindableProps",
                logo: {
                    alt: "Logo",
                    src: "img/favicon.ico",
                },
                items: [
                    {
                        type: "docSidebar",
                        sidebarId: "tutorialSidebar",
                        position: "left",
                        label: "Documentation",
                    },
                    {
                        href: "https://github.com/KafkaWannaFly/BindableProps",
                        label: "GitHub",
                        position: "right",
                    },
                ],
            },
            footer: {
                style: "dark",
                copyright: `Copyright © ${new Date().getFullYear()} BindableProps, Inc. Built with Docusaurus.`,
            },
            prism: {
                theme: prismThemes.nightOwl,
                additionalLanguages: ["csharp"],
            },
        }),
    plugins: []
};

module.exports = config;
