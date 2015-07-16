namespace GildedRose.Console
{
    public class SulfurasItemUpdater : ItemUpdater
    {
        public SulfurasItemUpdater(Program.Item item)
            : base(item)
        {
        }

        protected override void UpdateSellIn()
        {
            // "Sulfuras", being a legendary item, never has to be sold...
        }

        protected override void UpdateQuality()
        {
            // ...or decreases in Quality
        }
    }
}