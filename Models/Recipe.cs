namespace all_spice.Models
{
    public class Recipe
    {
        public string title { get; set; }
        public string description { get; set; }
        public string imgUrl { get; set; }
        public string steps { get; set; }
        public int id { get; set; }
        public Ingredient ingredients { get; set; }
    }
}