import useDocusaurusContext from "@docusaurus/useDocusaurusContext";
import Layout from "@theme/Layout";
import { Space, Tabs } from "antd";
import React, { useEffect, useState } from "react";
import { TypeAnimation } from "react-type-animation";
import { CodeBlock } from "../components/code-block";

export default function Home(): JSX.Element {
    const { siteConfig } = useDocusaurusContext();
    const [latestVersion, setLatestVersion] = useState("1.3.9");
    const [csProjSettingString, setCsProjSettingString] = useState("");

    useEffect(() => {
        fetch("https://api.nuget.org/v3-flatcontainer/BindableProps/index.json")
            .then((res) => res.json())
            .then((data) => {
                console.log(data);
                const versions = data.versions as string[];
                setLatestVersion(versions[versions.length - 1]);
            });
    }, []);

    useEffect(() => {
        setCsProjSettingString(getCsProjSettingString(latestVersion));
    }, [latestVersion]);

    const codeBlockHeight = "450px";
    return (
        <Layout title={`${siteConfig.title}`} description="MAUI App source generator">
            <div>
                <Space
                    direction="vertical"
                    style={{
                        display: "flex",
                        justifyContent: "center",
                        alignItems: "center",
                        textAlign: "center",
                    }}
                    className="margin-vert--lg container"
                    size={48}
                >
                    <TypeAnimation
                        sequence={[`"I spent hours to save your moments." - Kafka Wanna Fly`, 1000, "", 1000]}
                        repeat={Infinity}
                        style={{
                            fontFamily: "monospace",
                            fontSize: "2rem",
                            textDecoration: "underline",
                            textUnderlineOffset: "1rem",
                        }}
                    />

                    <p>
                        This library is a source generator. <code>BindableProps</code> helps you to create MAUI
                        components much faster than the standard way. It saves your time and is an essential part of
                        every MAUI project.
                    </p>
                </Space>

                <div className="margin-vert--lg container">
                    <p>
                        <h4>Install with dotnet CLI</h4>
                        <CodeBlock
                            language="git"
                            codeBlockHeight="auto"
                            lineNumber={false}
                            code={`dotnet add package BindableProps --version ${latestVersion}`}
                        />
                    </p>

                    <p>
                        <h4>
                            Your <code>csproj</code> file should has this
                        </h4>
                        <CodeBlock
                            language="xml"
                            codeBlockHeight="auto"
                            lineNumber={true}
                            code={csProjSettingString}
                            highlightLinePredicate={(line) => line.match("PackageReference") !== null}
                            highlightLineColor="rgba(255, 255, 255, 0.1)"
                        />
                    </p>
                </div>

                <div
                    style={{
                        backgroundImage: "url('img/lion.png')",
                    }}
                >
                    <Tabs
                        defaultActiveKey="1"
                        centered
                        className="container"
                        type="line"
                        tabBarStyle={{
                            backgroundColor: "var(--ifm-background-color)",
                            marginBottom: 0,
                            borderRadius: 8,
                            color: "var(--ifm-font-color-base)",
                        }}
                        items={[
                            {
                                label: "My Code",
                                key: "1",
                                children: (
                                    <CodeBlock
                                        key={1}
                                        language="csharp"
                                        code={appCode}
                                        codeBlockHeight={codeBlockHeight}
                                        highlightLinePredicate={(line) => line.match(/\[(BindableProp.*?)\]/g) !== null}
                                        highlightLineColor="rgba(255, 255, 255, 0.1)"
                                    />
                                ),
                            },
                            {
                                label: "Generated Code",
                                key: "2",
                                children: (
                                    <CodeBlock
                                        key={2}
                                        language="csharp"
                                        code={generatedCode}
                                        codeBlockHeight={codeBlockHeight}
                                    />
                                ),
                            },
                        ]}
                    />
                    s
                </div>
            </div>
        </Layout>
    );
}

const appCode = `
    using BindableProps;

    namespace MyMauiApp.Controls;

    public partial class NovelReview : ContentView
    {
        [BindableProp(DefaultBindingMode = (int)BindingMode.OneTime)]
        private string _name = "Kafka On The Shore";
        
        [BindableProp]
        private string _author = "Haruki Murakami";

        public NovelReview()
        {
            
        }
    }
`;

const generatedCode = `
    // <auto-generated/>
    using BindableProps;

    namespace MyMauiApp.Controls
    {
        public partial class NovelReview
        {

            public  static readonly BindableProperty NameProperty = BindableProperty.Create(
                nameof(Name),
                typeof(string),
                typeof(NovelReview),
                "Kafka On The Shore",
                (BindingMode)(int)BindingMode.OneTime,
                null,
                (bindable, oldValue, newValue) => 
                            ((NovelReview)bindable).Name = (string)newValue,
                null,
                null,
                null
            );

            public  string Name
            {
                get => _name;
                set 
                { 
                    OnPropertyChanging(nameof(Name));

                    _name = value;
                    SetValue(NovelReview.NameProperty, _name);

                    OnPropertyChanged(nameof(Name));
                }
            }

            public  static readonly BindableProperty AuthorProperty = BindableProperty.Create(
                nameof(Author),
                typeof(string),
                typeof(NovelReview),
                "Haruki Murakami",
                (BindingMode)0,
                null,
                (bindable, oldValue, newValue) => 
                            ((NovelReview)bindable).Author = (string)newValue,
                null,
                null,
                null
            );

            public  string Author
            {
                get => _author;
                set 
                { 
                    OnPropertyChanging(nameof(Author));

                    _author = value;
                    SetValue(NovelReview.AuthorProperty, _author);

                    OnPropertyChanged(nameof(Author));
                }
            }

        }
    }
`;

function getCsProjSettingString(version: string) {
    return `
    <Project Sdk="Microsoft.NET.Sdk">
        <ItemGroup>
            <PackageReference Include="BindableProps" Version="${version}" />
        </ItemGroup>
    </Project>
    `;
}
