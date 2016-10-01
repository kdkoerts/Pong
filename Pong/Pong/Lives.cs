using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class LivesHandeler : GameObject
    {
        public void DrawLives(int lives, string side, SpriteBatch spritebatch)
        {
            for (int i = 0; i < lives; i++)
            {
                if (side == "Right")
                    spritebatch.Draw(sprite, new Vector2(Game.SchreenWith -  i * sprite.Width, 0));
                else
                    spritebatch.Draw(sprite, new Vector2(i * sprite.Width, 0));
            }
        }
    }
}