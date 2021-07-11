using JustWork.Models;
using JustWork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustWork.Repositories
{
    class SpecialtiesRepository : ISpecialtiesRepository<Specialties>
    {
        private Model db = new Model();
        
        /// <summary>
        /// Return all specialties 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Specialties> GetList()
        {
            return db.Specialties;
        }
        
        /// <summary>
        /// Return specitialty by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Specialties GetOne(int id)
        {
            return db.Specialties.FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// Adds 1 to the number of statements by specialty id
        /// </summary>
        /// <param name="id"></param>
        public void PlusOneSpecialty(int id)
        {
            Specialties Specialty = GetOne(id);
            int StAmount = Specialty.AmountStatements;
            Specialty.AmountStatements = StAmount + 1;
            Save();
        }

        /// <summary>
        /// Adds 1 to the number of priority applications
        /// </summary>
        /// <param name="id"></param>
        public void PlusOneSpecialtyWithPriority(int id)
        {
            Specialties Specialty = GetOne(id);
            int StAmount = Specialty.AmountStatements;
            int PrAmount = Specialty.AmountPriority;
            Specialty.AmountStatements = StAmount + 1;
            Specialty.AmountPriority = PrAmount + 1;
            Save();
        }

        /// <summary>
        /// Subtracts 1 from the number of statements by specialty id
        /// </summary>
        /// <param name="id"></param>
        public void MinusOneSpecialty(int id)
        {
            Specialties Specialty = GetOne(id);
            int StAmount = Specialty.AmountStatements;
            Specialty.AmountStatements = StAmount - 1;
            Save();
        }

        /// <summary>
        /// Subtracts 1 from the number of priority statements by specialty id
        /// </summary>
        /// <param name="id"></param>
        public void MinusOneSpecialtyWithPriority(int id)
        {
            Specialties Specialty = GetOne(id);
            int StAmount = Specialty.AmountStatements;
            int PrAmount = Specialty.AmountPriority;
            Specialty.AmountStatements = StAmount - 1;
            Specialty.AmountPriority = PrAmount - 1;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
