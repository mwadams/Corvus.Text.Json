// Registers a Roslyn-backed completion provider for the C# Monaco editor.
// The dotNetHelper calls back into IntelliSenseService via [JSInvokable].
window.registerCSharpCompletionProvider = function (dotNetHelper) {
    monaco.languages.registerCompletionItemProvider('csharp', {
        triggerCharacters: ['.'],
        provideCompletionItems: async function (model, position) {
            const code = model.getValue();
            const line = position.lineNumber;
            const column = position.column;

            try {
                const completions = await dotNetHelper.invokeMethodAsync(
                    'GetCompletionsForJs',
                    code,
                    line,
                    column
                );

                if (!completions || completions.length === 0) {
                    return { suggestions: [] };
                }

                // Compute the word at the cursor for the replacement range
                const word = model.getWordUntilPosition(position);
                const range = {
                    startLineNumber: position.lineNumber,
                    startColumn: word.startColumn,
                    endLineNumber: position.lineNumber,
                    endColumn: word.endColumn
                };

                return {
                    suggestions: completions.map(function (item) {
                        return {
                            label: item.label,
                            kind: item.kind,
                            detail: item.detail,
                            insertText: item.insertText,
                            sortText: item.sortText,
                            filterText: item.filterText,
                            range: range
                        };
                    })
                };
            } catch (e) {
                console.error('Completion provider error:', e);
                return { suggestions: [] };
            }
        }
    });
};
