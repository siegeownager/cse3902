﻿using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class Star : IItem
    {
        private Game1 myGame;
        public ISprite Sprite;
        public Rectangle Rectangle { get; set; }

        public Star(Game1 game)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateStar();
            myGame.sprite = Sprite;
            Rectangle = new Rectangle(500, 160, 0, 0);

        }

        public void Update()
        {
            Sprite.Update(myGame.gameTime);
        }
        public Rectangle Area()
        {
            return Rectangle;
        }
        public void UpdateCollision()
        {
            this.Sprite = new CleanSprite(SpriteFactory.starTexture);
            myGame.store.arrayOfSprites[6] = Sprite;
            this.Rectangle = new Rectangle();
        }

        public void Draw(SpriteBatch sb, Vector2 v)
        {
            throw new NotImplementedException();
        }
    }
}
