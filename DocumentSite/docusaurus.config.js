// @ts-check
// Note: type annotations allow type checking and IDEs autocompletion

/** @type {import('@docusaurus/types').Config} */
const config = {
    title: "BindableProps",
    tagline: "BindableProps",
    favicon: "./static/img/favicon.ico",

    // Set the production url of your site here
    url: "https://kafkawannafly.github.io",
    // Set the /<baseUrl>/ pathname under which your site is served
    // For GitHub pages deployment, it is often '/<projectName>/'
    baseUrl: "/BindableProps/",

    // GitHub pages deployment config.
    // If you aren't using GitHub pages, you don't need these.
    organizationName: "Kafka Wanna Fly", // Usually your GitHub org/user name.
    projectName: "BindableProps", // Usually your repo name.

    onBrokenLinks: "throw",
    onBrokenMarkdownLinks: "warn",

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
            },
        ],
    ],

    themeConfig:
        /** @type {import('@docusaurus/preset-classic').ThemeConfig} */
        ({
            // Replace with your project's social card
            image: "img/docusaurus-social-card.jpg",
            navbar: {
                title: "BindableProps",
                logo: {
                    alt: "My Site Logo",
                    src: "./static/img/favicon.ico",
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
                links: [
                    {
                        title: "Docs",
                        items: [
                            {
                                label: "Documentation",
                                to: "/docs/intro",
                            },
                        ],
                    },
                    {
                        title: "More",
                        items: [
                            {
                                label: "GitHub",
                                href: "https://github.com/KafkaWannaFly/BindableProps",
                            },
                        ],
                    },
                ],
                copyright: `Copyright © ${new Date().getFullYear()} BindableProps, Inc. Built with Docusaurus.`,
            },
            prism: {
                theme: require("prism-react-renderer/themes/nightOwl"),
                additionalLanguages: ["csharp"],
            },
        }),
    plugins: []
};

module.exports = config;
