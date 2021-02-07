namespace US_Geography_
{
    public class State
    {
        public int[] population { get; set; }
        public double[] growth { get; set; }
        public string name { get; set; }

        public State(int elements)
        {
            population = new int[elements];
            growth = new double[elements];
        }
    }
}