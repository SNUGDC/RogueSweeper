namespace RogueSweeper.Tile
{
    public struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Coordinate operator +(Coordinate thiz, Coordinate other){
            return new Coordinate(thiz.x + other.x, thiz.y + other.y);
        }

        public static Coordinate operator -(Coordinate thiz, Coordinate other){
            return new Coordinate(thiz.x - other.x, thiz.y - other.y);
        }

        public static Coordinate operator -(Coordinate thiz){
            return new Coordinate(-thiz.x, -thiz.y);
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Coordinate other = (Coordinate)obj;

            return x == other.x && y == other.y;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return x ^ y;
        }
    }
}