﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class Pipe : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 location { get; set; }

        public Pipe(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreatePipe();
            MyGame.sprite = Sprite;
            this.location = location;
        }
        public void BrickToDisappear()
        {
        }
        public void HiddenToUsed()
        {
        }
        public void BecomeUsed()
        {
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(this.location.X, this.location.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
