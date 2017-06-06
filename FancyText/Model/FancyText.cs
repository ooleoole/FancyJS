namespace FancyText
{
    public class FancyText
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }

        public FancyTextComposition FancyTextComposition { get; set; }
        public int FancyTextCompositionId { get; set; }

    }

    public enum Color
    {
        Transparent,
        Yellow,
        Pink,
        Green,
        Blue
    }
}
