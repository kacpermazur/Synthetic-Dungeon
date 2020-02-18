using Unity.Entities;

namespace Entity_Core
{
    [GenerateAuthoringComponent]
    public struct StatsData : IComponentData
    {
        public int Health;
        public int Mana;
        public int Toughness;
        public int AttackPower;
        public int MagicPower;
    }
}
