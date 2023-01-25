using Ecs.Core.Interfaces;

namespace Ecs.Buffs.Components
{
    public struct Health : IResetable
    {
        public int Current;

        public int Max;

        public void Reset()
        {
            Current = Max;
        }
    }
}