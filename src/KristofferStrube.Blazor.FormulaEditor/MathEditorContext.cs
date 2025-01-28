namespace KristofferStrube.Blazor.FormulaEditor;

public class MathEditorContext
{
    public required List<Identifier> AvailableIdentifiers { get; set; }

    public required List<Constant> AvailableConstants { get; set; }

    public required List<Function> AvailableFunctions { get; set; }

    public required Action RerenderTree { get; set; }

    public required List<SupportedExpression> SupportedExpressions { get; set; }
}
