using Geometry.Model;

namespace Geometry.Function
{

    public delegate bool FormPredicate(Form f);

    public static class Forms { 
    
        public static IEnumerable<Form> Filter(IEnumerable<Form> source, FormPredicate predicate)
        {
            return source.Where(f => predicate(f));
        }

        // TODO: IEnumerable<U> filterByType<T,U>(IEnumerable<T> source)

    }

}

