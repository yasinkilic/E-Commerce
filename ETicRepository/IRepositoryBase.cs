using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ETicRepository
{

    public interface IRepositoryBase<T>
    {
        List<T> Listele();
        T GetElementById(int id);
        void Guncelle(T item);
        void Sil(int id);
        void Ekle(T item);
        IEnumerable<T> Include(Expression<Func<T, bool>> filter, string children);
        IEnumerable<T> Query(Expression<Func<T, bool>> filter);
    }
}
