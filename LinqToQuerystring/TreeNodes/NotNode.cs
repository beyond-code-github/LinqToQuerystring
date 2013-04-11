namespace LinqToQuerystring.TreeNodes
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Antlr.Runtime;

    using LinqToQuerystring.TreeNodes.Base;

    using MongoDB.Bson;

    public class NotNode : SingleChildNode
    {
        public NotNode(Type inputType, IToken payload)
            : base(inputType, payload)
        {
        }

        public override Expression BuildLinqExpression(IQueryable query, Expression expression, Expression item = null)
        {
            var childExpression = this.ChildNode.BuildLinqExpression(query, expression, item);
            if (!typeof(bool).IsAssignableFrom(childExpression.Type))
            {
                //if (query.Provider.GetType().Name.Contains("MongoQueryProvider"))
                //{
                //    //childExpression = Expression.TypeAs(childExpression, typeof(BsonBoolean));
                //}
                //else
                //{
                childExpression = Expression.Convert(childExpression, typeof(bool));
                //}


            }

            return Expression.Not(childExpression);
        }
    }
}