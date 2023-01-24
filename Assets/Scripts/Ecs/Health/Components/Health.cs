namespace Ecs.Health.Components
{
    public struct Health
    {
        public int Current;

        public int Max;

        public void Reset()
        {
            Current = Max;
        }
    }
}