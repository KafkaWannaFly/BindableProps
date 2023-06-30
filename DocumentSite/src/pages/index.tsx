import useDocusaurusContext from "@docusaurus/useDocusaurusContext";
import Layout from "@theme/Layout";
import { Col, Row, Space } from "antd";
import Highlight, { Prism } from "prism-react-renderer";
import React, { useRef } from "react";
import { TypeAnimation } from "react-type-animation";
import theme from "prism-react-renderer/themes/nightOwl";

export default function Home(): JSX.Element {
    const { siteConfig } = useDocusaurusContext();

    const codeBlockHeight = "500px";

    const ref = useRef<Highlight>();

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
                        backgroundColor: "var(--ifm-color-primary-darkest)",
                    }}
                    className="margin-top--xl margin-bottom--md padding--xl"
                >
                    <TypeAnimation
                        sequence={[`I spent hours to save your moments.`, 1000, "", 1000]}
                        repeat={Infinity}
                        style={{ fontFamily: "intel-one-mono", fontSize: "1.5rem", color: "white" }}
                    />
                </Space>

                <Row justify={"center"}>
                    <Col className="margin-horiz--md">
                        <Highlight language="csharp" code={appCode} Prism={Prism} theme={theme} ref={ref}>
                            {({ className, style, tokens, getLineProps, getTokenProps }) => (
                                <pre style={{ ...style, height: codeBlockHeight }}>
                                    {tokens.map((line, i) => (
                                        <div key={i} {...getLineProps({ line })}>
                                            <span>{i + 1}</span>
                                            {line.map((token, key) => (
                                                <span key={key} {...getTokenProps({ token })} />
                                            ))}
                                        </div>
                                    ))}
                                </pre>
                            )}
                        </Highlight>
                    </Col>

                    <Col className="margin-horiz--md" style={{ height: "500px" }}>
                        <Highlight language="csharp" code={generatedCode} Prism={Prism} theme={theme}>
                            {({ className, style, tokens, getLineProps, getTokenProps }) => (
                                <pre style={{ ...style, height: codeBlockHeight }}>
                                    {tokens.map((line, i) => (
                                        <div key={i} {...getLineProps({ line })}>
                                            <span>{i + 1}</span>
                                            {line.map((token, key) => (
                                                <span key={key} {...getTokenProps({ token })} />
                                            ))}
                                        </div>
                                    ))}
                                </pre>
                            )}
                        </Highlight>
                    </Col>
                </Row>
            </div>
        </Layout>
    );
}

const appCode = `
    using BindableProps;

    namespace MyMauiApp.Controls
    {
        // Notice: Your class must be partial class
        public partial class TextInput : ContentView
        {
            [BindableProp]
            string text;

            [BindableProp]
            string placeHolder;


            public TextInput()
            {
                // This piece is same as above
            }
        }
    }
`;

const generatedCode = `
    using BindableProps;

    namespace MyMauiApp.Controls
    {
        public partial class TextInput
        {

            public static readonly BindableProperty TextProperty = BindableProperty.Create(
                nameof(Text),
                typeof(string),
                typeof(TextInput),
                default,
                (BindingMode)0,
                null,
                (bindable, oldValue, newValue) =>
                            ((TextInput)bindable).Text = (string)newValue,
                null,
                null,
                null
            );

            public string Text
            {
                get => text;
                set
                {
                    OnPropertyChanging(nameof(Text));

                    text = value;
                    SetValue(TextInput.TextProperty, text);

                    OnPropertyChanged(nameof(Text));
                }
            }

            public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
                nameof(PlaceHolder),
                typeof(string),
                typeof(TextInput),
                default,
                (BindingMode)0,
                null,
                (bindable, oldValue, newValue) =>
                            ((TextInput)bindable).PlaceHolder = (string)newValue,
                null,
                null,
                null
            );

            public string PlaceHolder
            {
                get => placeHolder;
                set
                {
                    OnPropertyChanging(nameof(PlaceHolder));

                    placeHolder = value;
                    SetValue(TextInput.PlaceHolderProperty, placeHolder);

                    OnPropertyChanged(nameof(PlaceHolder));
                }
            }

        }
    }
`;
