using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMS.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // មុខងារទាញយកទិន្នន័យទាំងអស់
        IEnumerable<T> GetAll();

        // មុខងារទាញយកទិន្នន័យតាម ID
        T GetById(int id);

        // មុខងារបន្ថែមទិន្នន័យថ្មី
        bool Add(T entity);

        // មុខងារកែប្រែទិន្នន័យ
        bool Update(T entity);

        // មុខងារលុបទិន្នន័យ
        bool Delete(int id);
    }
}
