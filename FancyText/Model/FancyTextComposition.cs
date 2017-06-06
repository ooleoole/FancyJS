using System.Collections.Generic;

namespace FancyText
{
    public class FancyTextComposition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FancyText> FancyTexts { get; set; }
    }
}
