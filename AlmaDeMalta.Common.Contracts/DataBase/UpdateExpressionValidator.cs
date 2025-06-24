
using MongoDB.Driver;
using System.Linq.Expressions;

namespace AlmaDeMalta.Common.Contracts.DataBase;
public class UpdateExpressionVisitor<T> : ExpressionVisitor where T : class
{
    private readonly List<UpdateDefinition<T>> _updates = new();
    public IEnumerable<UpdateDefinition<T>> Visit(Expression<Func<T, T>> expression)
    {
        _updates.Clear();

        if (expression.Body is not MemberInitExpression memberInit)
            throw new ArgumentException("La expresión debe ser un MemberInit (inicialización de objeto).");

        foreach (var binding in memberInit.Bindings.OfType<MemberAssignment>())
        {
            var memberName = binding.Member.Name;
            var value = Evaluate(binding.Expression);
            _updates.Add(Builders<T>.Update.Set(memberName, value));
        }

        return _updates;
    }
    private object Evaluate(Expression e)
    {
        // Si es un parámetro o propiedad del objeto, no se evalúa ahora
        if (e is ParameterExpression || e is MemberExpression)
            return null;

        // Evaluar valores estáticos
        return Expression.Lambda(e).Compile().DynamicInvoke();
    }
}
