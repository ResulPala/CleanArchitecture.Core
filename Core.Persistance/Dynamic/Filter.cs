using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Dynamic;

public class Filter
{
    public string Field { get; set; } //filtre hangi alan üzerinde çalışacak, örn: yakıt tipi
    public string? Value { get; set; } //bunun değeri ne
    public string Operator { get; set; } //sayısal değerler için büyüktür küçüktür gibi
    public string? Logic { get; set; } //birden fazla alan için çalışacağımız için, şu şartı sağlayan ve şu şartı sağlayan gibi. and or
    public IEnumerable<Filter> Filters { get; set; } //birden fazla filtre koyabiliriz

    public Filter()
    {
        Field = string.Empty;
        Operator = string.Empty;
    }

    public Filter(string field, string @operator)
    {
        Field = field;
        Operator = @operator;
    }
}
