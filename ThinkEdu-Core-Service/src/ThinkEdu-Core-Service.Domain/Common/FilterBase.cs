using System.Linq.Expressions;
using System.Reflection;
using ThinkEdu_Core_Service.Domain.Enums;

namespace ThinkEdu_Core_Service.Domain.Common
{
    public class FilterBase<T>
    {
        private readonly PropertyInfo[] _props;
        public int Page { get; init; } = 1;
        public int Rows { get; set; } = 10;
        public string? KeySort { get; set; }
        public List<string>? MemberNames { get; set; }
        public List<string> Includes { get; set; } = new();
        public ESort Sort { get; set; } = ESort.DESC;
        public Dictionary<string, string>? Properties { get; set; }
        public bool? All { get; set; }
        public string? Keyword { get; set; }

        public FilterBase()
        {
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var props =
                from p in propertyInfos
                group p by p.Name into g
                select g.OrderByDescending(t => t.DeclaringType == typeof(T)).First();
            _props = props.ToArray();
            if (Properties == null || Properties.Values.Count == 0)
            {
                Properties = new Dictionary<string, string>();
            }

            All ??= false;
            MemberNames ??= null;
            Keyword ??= null;
        }

        public List<Expression<Func<T, bool>>> GetFilterWhere()
        {
            var filterExpressions = new List<Expression<Func<T, bool>>>();

            if (Properties != null)
            {
                foreach (var item in Properties)
                {
                    var check = _props.FirstOrDefault(x => x.Name.ToString().ToUpper() == item.Key.ToUpper());
                    if (check != null && !string.IsNullOrEmpty(item.Value))
                    {
                        var parameter = Expression.Parameter(typeof(T), "p");
                        // parameter.GetType()
                        ConstantExpression right;
                        object value;
                        if (check.PropertyType.IsEnum)
                        {
                            value = Enum.Parse(check.PropertyType, item.Value);
                            right = Expression.Constant(value);
                        }
                        else
                        {
                            value = item.Value;
                            right = Expression.Constant(item.Value);
                        }

                        Expression left;
                        if (check.MemberType == MemberTypes.Property)
                        {
                            PropertyInfo? propInfo = null;
                            foreach (var p in check.DeclaringType!.GetProperties())
                            {
                                if (p.Name == check.Name)
                                {
                                    //Just pick the first one. 
                                    propInfo = p;
                                    break;
                                }
                            }

                            left = Expression.Property(Expression.Convert(parameter, typeof(T)), propInfo!);
                        }
                        else
                        {
                            left = Expression.Field(Expression.Convert(parameter, typeof(T)), check.Name);
                        }
                        // Expression left = Expression.PropertyOrField(parameter, check.Name);

                        if (check.PropertyType == typeof(string))
                        {
                            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
                            var predicate = Expression.Lambda<Func<T, bool>>(
                                Expression.Call(left, method, right),
                                parameter);
                            filterExpressions.Add(predicate);
                        }
                        else if (check.PropertyType == typeof(DateTime) && item.Value.Split(" ~ ").Length == 2)
                        {
                            var times = item.Value.Split(" ~ ");
                            var valueToSet = Convert.ToDateTime(times[0]);
                            right = Expression.Constant(valueToSet);
                            var predicate = Expression.Lambda<Func<T, bool>>(
                                Expression.GreaterThanOrEqual(left, right),
                                parameter);
                            filterExpressions.Add(predicate);
                            valueToSet = Convert.ToDateTime(times[1] + " 23:59:59.999");
                            right = Expression.Constant(valueToSet);
                            predicate = Expression.Lambda<Func<T, bool>>(
                                Expression.LessThanOrEqual(left, right),
                                parameter);
                            filterExpressions.Add(predicate);
                        }
                        else
                        {
                            try
                            {
                                var t = check.PropertyType;
                                t = Nullable.GetUnderlyingType(t) ?? t;
                                var valueToSet = Convert.ChangeType(value, t);
                                right = Expression.Constant(valueToSet, check.PropertyType);
                                var predicate = Expression.Lambda<Func<T, bool>>(
                                    Expression.Equal(left, right),
                                    parameter);
                                filterExpressions.Add(predicate);
                            }
                            catch
                            {
                                // ignored
                            }
                        }
                    }
                }
            }


            return filterExpressions;
        }

        public string? UnqualifiedFieldName
        {
            get
            {
                var check = _props
                    .FirstOrDefault(x => KeySort != null && string.Equals(x.Name.ToString(), KeySort, StringComparison.CurrentCultureIgnoreCase));
                KeySort = check == null ? null : check.Name;

                return KeySort;
            }
        }

        public int CheckRows
        {
            get
            {
                if (Rows < 0)
                {
                    Rows = -1;
                }
                return Rows;
            }
        }


        public Expression<Func<T, bool>>? BuildOrSearchExpression()
        {
            if (string.IsNullOrEmpty(Keyword))
                return null;
            var parameter = Expression.Parameter(typeof(T), "p");
            Expression? whereExpression = null;
            var props = _props.Where(x => x.PropertyType == typeof(string)).ToList();
            foreach (var prop in props)
            {
                var method = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
                var right = Expression.Constant(Keyword);
                var left = Expression.PropertyOrField(parameter, prop.Name);
                Expression? local = Expression.Call(left, method, right);
                if (local != null)
                {
                    whereExpression = whereExpression == null
                        ? local
                        : Expression.OrElse(whereExpression, local);
                }
            }

            whereExpression = whereExpression ?? Expression.Constant(true, typeof(bool));
            var filedOrs = Expression.Lambda<Func<T, bool>>(
                whereExpression,
                parameter);
            return filedOrs;

        }
    }
}