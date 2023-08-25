import React from "react";
import Highlight, { Language, Prism } from "prism-react-renderer";
import theme from "prism-react-renderer/themes/nightOwl";

interface CodeBlockProps {
    codeBlockHeight: string;
    language: string;
    code: string;
    lineNumber?: boolean;
    highlightLinePredicate?: (line: string) => boolean;
    highlightLineColor?: string;
}

export const CodeBlock = ({
    codeBlockHeight,
    code,
    language,
    highlightLinePredicate,
    highlightLineColor,
    lineNumber = true,
}: CodeBlockProps) => {
    return (
        <Highlight key={Math.random() * 100} Prism={Prism} language={language as Language} code={code} theme={theme}>
            {({ className, style, tokens, getLineProps, getTokenProps }) => (
                <pre key={tokens.toString()} style={{ ...style, height: codeBlockHeight, fontFamily: "monospace" }}>
                    {tokens.map((line, i) => {
                        const codeLindeStr = line
                            .map((i) => i.content)
                            .join()
                            .replace(/,/g, "");
                        return (
                            <div
                                key={i}
                                {...getLineProps({ line })}
                                style={{
                                    backgroundColor:
                                        highlightLinePredicate && highlightLinePredicate(codeLindeStr)
                                            ? highlightLineColor
                                            : "inherit",
                                }}
                            >
                                {lineNumber && <span key={i}>{i + 1}</span>}
                                {line.map((token, key) => (
                                    <span key={key} {...getTokenProps({ token })} />
                                ))}
                            </div>
                        );
                    })}
                </pre>
            )}
        </Highlight>
    );
};
