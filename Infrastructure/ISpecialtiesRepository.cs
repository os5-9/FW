using System;
using System.Collections.Generic;

namespace JustWork.Infrastructure
{

    interface ISpecialtiesRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetList();
        T GetOne(int id);
        void PlusOneSpecialty(int id);
        void PlusOneSpecialtyWithPriority(int id);
        void MinusOneSpecialty(int id);
        void MinusOneSpecialtyWithPriority(int id);
        void Save();
    }
}
