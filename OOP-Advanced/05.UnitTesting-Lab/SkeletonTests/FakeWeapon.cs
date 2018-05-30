using System;
using System.Collections.Generic;
using System.Text;

namespace SkeletonTests
{
    class FakeWeapon:IWeapon
    {
        private int attackPoints;
        private int durabilityPoints=2;
        public int AttackPoints { get; }
        public int DurabilityPoints { get; }
        public void Attack(ITarget target)
        {
            if (this.durabilityPoints <= 0)
            {
                throw new InvalidOperationException("Axe is broken.");
            }

            target.TakeAttack(this.attackPoints);
            this.durabilityPoints -= 1;
        }
    }
}
