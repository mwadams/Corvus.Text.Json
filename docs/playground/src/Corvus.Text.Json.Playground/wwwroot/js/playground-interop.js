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

// Triggers a browser file download from a byte array.
window.downloadFileFromBytes = function (filename, contentType, bytes) {
    const blob = new Blob([bytes], { type: contentType });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = filename;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
};

// Opens a file picker and returns the selected file as a byte array.
window.pickFileAsBytes = function (accept) {
    return new Promise(function (resolve) {
        const input = document.createElement('input');
        input.type = 'file';
        input.accept = accept || '.zip';
        input.style.display = 'none';
        input.onchange = function () {
            if (input.files && input.files.length > 0) {
                const reader = new FileReader();
                reader.onload = function () {
                    resolve(new Uint8Array(reader.result));
                };
                reader.readAsArrayBuffer(input.files[0]);
            } else {
                resolve(null);
            }
            document.body.removeChild(input);
        };
        // Handle cancel — listen for focus returning without a file selection
        input.oncancel = function () {
            resolve(null);
            document.body.removeChild(input);
        };
        document.body.appendChild(input);
        input.click();
    });
};
