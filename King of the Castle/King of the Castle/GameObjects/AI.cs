using King_of_the_Castle.AITypes;
using King_of_the_Castle.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_the_Castle.GameObjects
{
    public class AI : IAI
    {
        private IAIType AIType;

        public AI(IEnemy enemy, string type)
        {
            if (type == "Enemy")
            {
                AIType = new EnemyAI(enemy);
            }
        }

        public void Update(GameTime gameTime)
        {
            AIType.Update(gameTime);
        }
    }
}
