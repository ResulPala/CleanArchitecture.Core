using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Paging;

public class Paginate<T>
{
    public Paginate()
    {
        Items = Array.Empty<T>();
    }

    public int Size { get; set; } //sayfada kaç data var
    public int Index { get; set; } //hangi sayfadayız
    public int Count { get; set; } //toplam kayıt sayısı
    public int Pages { get; set; } //toplam kaç sayfa var 
    public IList<T> Items { get; set; } //datamız nedir
    public bool HasPrevious => Index > 0;
    public bool HasNext => Index + 1 < Pages;


}
