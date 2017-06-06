using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FancyText.Repo
{
    public class FancyTextRepo:IRepo<FancyText>
    {
        private readonly FancyContext _context;

        public FancyTextRepo(FancyContext context)
        {
            _context = context;
        }

        public ICollection<FancyText> GetAll()
        {
            return _context.FancyTexts.ToList();
        }

        public FancyText GetById(int id)
        {
            return _context.FancyTexts.FirstOrDefault(ft => ft.Id == id);
        }

        public void Add(FancyText fancyText)
        {
            _context.Add(fancyText);
            _context.SaveChanges();
        }

        public void Update(FancyText fancyText)
        {
            _context.Update(fancyText);
            _context.SaveChanges();
        }

        public void Delete(FancyText fancyText)
        {
            _context.Remove(fancyText);
            _context.SaveChanges();
        }
    }
}
