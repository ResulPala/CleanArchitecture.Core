using Core.Persistance.Dynamic;
using Core.Persistance.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Repositories;

public interface IAsyncRepository<TEntity, TEntityId> : IQuery<TEntity>
    where TEntity : Entity<TEntityId>
{
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate, //lambda exp. ile veri çekmemizi sağlar
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, //join atarak sorgu yapabilmemizi sağlar
        bool withDeleted = false, //soft delete edilenleri getireyim mi?
        bool enableTracking = false, //ef nin tracking desteğinin enable edilip edilmeyeceğini gösterir
        CancellationToken cancellationToken = default);

    Task<Paginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, //sorguda order by yapılabilir
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<Paginate<TEntity>> GetListByDynamicAsync(         //filtreleme yaparken ekstra bir select sorgusu oluşturmadan bunu dynamic nesnesiyle yapacağız
        DynamicQuery dynamic,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<bool> AnyAsync(                                    //bizim aradığımız veri var mı yok mu, bu tc var mı yok mu
      Expression<Func<TEntity, bool>>? predicate = null,
      bool withDeleted = false,
      bool enableTracking = true,
      CancellationToken cancellationToken = default
      );

    Task<TEntity> AddAsync(TEntity entity);

    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities); //çoklu veri ekleme, yani 20 tane entity ver hepsini ekleyeceğim

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities);

    Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false); //permanent kalıcı silmek için

    Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false);
}
