using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Dynamic;

public class Sort // a-z veya artan şekilde sıralama yapmak için
{
    public string Field { get; set; } //hangi alana uygulanacak
    public string Dir { get; set; } //hangi yönde, artan azalan

    public Sort()
    {
        Field = string.Empty;
        Dir = string.Empty;
    }

    public Sort(string field, string dir)
    {
        Field=field;
        Dir=dir;    
    }
}
