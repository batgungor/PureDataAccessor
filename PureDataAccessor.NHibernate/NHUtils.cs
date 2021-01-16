using NHibernate;
using NHibernate.Hql.Ast.ANTLR;
using NHibernate.Linq;
using System.Linq;

namespace PureDataAccessor.NHibernate
{
    public class NHUtils
    {
        public static string GetGeneratedSql(IQueryable query, ISession session)
        {
            var sessionImpl = session.GetSessionImplementation();
            var factory = sessionImpl.Factory;
            var nhLinqExpression = new NhLinqExpression(query.Expression, factory);
            var translatorFactory = new ASTQueryTranslatorFactory();
            var translator = translatorFactory.CreateQueryTranslators(nhLinqExpression, null, false, sessionImpl.EnabledFilters, factory).FirstOrDefault();
            return translator.SQLString;
        }
    }
}
