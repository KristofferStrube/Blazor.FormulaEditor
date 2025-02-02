namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public class SubtractionOperator : BinaryOperator
{
    public override string Operator => "-";

    public override double Evaluate()
    {
        return First!.Evaluate() - Second!.Evaluate();
    }
}
