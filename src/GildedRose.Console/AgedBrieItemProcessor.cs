namespace GildedRose.Console
{
    public class AgedBrieItemProcessor : ItemProcessor
    {
        public override void ProcessItem(Item item)
        {
            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
                item.Quality = item.Quality + 2;
            else
                item.Quality = item.Quality + 1;

            item.Quality = item.Quality > 50 ? 50 : item.Quality;
        }
    }
}