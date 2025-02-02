namespace KristofferStrube.Blazor.FormulaEditor.BooleanExpressions;

public class EqualsOperator : BinaryBooleanOperator
{
    public override string Operator => "=";

    public override bool Evaluate()
    {
        return First?.Evaluate() == Second?.Evaluate();
    }
}
