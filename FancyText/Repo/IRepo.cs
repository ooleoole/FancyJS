using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FancyText.Repo
{
    public interface IRepo<TEntity>
    {
        ICollection<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity fancyText);
        void Update(TEntity fancyText);
        void Delete(TEntity fancyText);
        


    }
}
