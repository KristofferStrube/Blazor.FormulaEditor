namespace KristofferStrube.Blazor.FormulaEditor;

public record Function(string Name, Func<double, double> Expression);
