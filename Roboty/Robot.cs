namespace Roboty
{
    public class Robot
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Type}";
        }
    }
}
