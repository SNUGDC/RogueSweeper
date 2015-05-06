using System;

namespace RogueSweeper.Tile
{
    public enum TileCategory
    {
        FLAG,
        MINE,
        HIDDEN,
        NUMBER
    }

    public struct TileType
    {
        public TileCategory Category { get; internal set; }
        public int Number { get; internal set; }

        public TileType(TileCategory category)
        {
            if (category == TileCategory.NUMBER)
            {
                throw new ArgumentException("Use TileType(int) to set Number tile");
            }
            this.Category = category;
            this.Number = -1;
        }

        public TileType(int number)
        {
            this.Category = TileCategory.NUMBER;
            this.Number = number;
        }
    }
}