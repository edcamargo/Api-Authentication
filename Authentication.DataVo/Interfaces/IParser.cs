using System.Collections.Generic;

namespace Authentication.DataVo.Interfaces
{
    /// <summary>
    /// Performs the Origin Object Parse with the Target Object
    /// </summary>
    /// <typeparam name="O"></typeparam>
    /// <typeparam name="D"></typeparam>
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}
