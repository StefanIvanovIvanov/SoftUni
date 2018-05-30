using System;
using System.Collections.Generic;
using System.Text;

namespace SkeletonTests
{
    public class FakeTarget:ITarget
    {
        public int Health => 0;
        private int health;
        private int experience;
        public int GiveExperience()
        {
            return 20;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
           // if (this.IsDead())
           // {
           //     throw new InvalidOperationException("Dummy is dead.");
           // }

            this.health -= attackPoints;
        }
    }
}
