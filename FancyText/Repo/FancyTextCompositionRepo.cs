using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FancyText.Repo
{
    public class FancyTextCompositionRepo : IRepo<FancyTextComposition>
    {
        private readonly FancyContext _dbContext;

        public FancyTextCompositionRepo(FancyContext context)
        {
            _dbContext = context;
        }

        public ICollection<FancyTextComposition> GetAll()
        {
            return _dbContext.FancyTextCompositions.Include(p => p.FancyTexts).ToList();

        }

        public FancyTextComposition GetById(int id)
        {
            return _dbContext.FancyTextCompositions.Include(p => p.FancyTexts).ThenInclude(p => p.Color).FirstOrDefault(ft=>ft.Id==id);
        }

        public void Add(FancyTextComposition fancyText)
        {
            _dbContext.FancyTextCompositions.Add(fancyText);
            _dbContext.SaveChanges();
        }

        public void Update(FancyTextComposition fancyText)
        {
            _dbContext.FancyTextCompositions.Update(fancyText);
            _dbContext.SaveChanges();
        }

        public void Delete(FancyTextComposition fancyText)
        {
            _dbContext.FancyTextCompositions.Remove(fancyText);
            _dbContext.SaveChanges();
        }
    }
}
