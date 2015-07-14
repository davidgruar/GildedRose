namespace GildedRose.Console
{
    public class SulfurasItemUpdater : ItemUpdater
    {
        public SulfurasItemUpdater(Program.Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        }
    }
}