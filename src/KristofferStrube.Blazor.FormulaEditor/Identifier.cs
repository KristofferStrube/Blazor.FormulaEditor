namespace KristofferStrube.Blazor.FormulaEditor;

public record Identifier(string Name, Func<double> GetValue);
