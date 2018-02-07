namespace Lab12
{
    abstract class Player
    {
        public string  Name { get; set; }
        public string Roshambo { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        abstract public void GenerateRoshambo();
    }
}