using KristofferStrube.Blazor.FormulaEditor.Expressions;
using Microsoft.AspNetCore.Components;

namespace KristofferStrube.Blazor.FormulaEditor;

public record SupportedExpression(string Name, RenderFragment Icon, Type Expression, Func<Expression> Create, Func<MathEditorContext, bool> AvailableInContext);
