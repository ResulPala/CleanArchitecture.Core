using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Paging;

public abstract class BasePageableModel
{
    public int Size { get; set; } //sayfada kaç data var
    public int Index { get; set; } //hangi sayfadayız
    public int Count { get; set; } //toplam kayıt sayısı
    public int Pages { get; set; } //toplam kaç sayfa var 
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
    
}
