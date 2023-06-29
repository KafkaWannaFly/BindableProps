import useDocusaurusContext from "@docusaurus/useDocusaurusContext";
import Layout from "@theme/Layout";
import { Space } from "antd";
import React from "react";

export default function Home(): JSX.Element {
    const { siteConfig } = useDocusaurusContext();

    const backgroundColor = "#25c2a0";
    const textColor = "#181920";
    return (
        <Layout title={`Hello from ${siteConfig.title}`} description="MAUI App source generator">
            <div
                style={{
                    height: "100vh",
                    display: "flex",
                    justifyContent: "center",
                    alignItems: "center",
                    textAlign: "center",
                }}
            >
                <Space direction="horizontal" align="center"></Space>
            </div>
        </Layout>
    );
}
