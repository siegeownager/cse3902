﻿using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
   public class Koopa : IEnemy
    {
        public bool movingLeft { get; set; }
        public bool isFalling { get; set; }
        public bool canAttack { get; set; }
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
       
        public Koopa(Game1 game, Vector2 location)
        {
            movingLeft = true;
            isFalling = true;
            MyGame = game;
            Sprite = SpriteFactory.CreateKoopa();
            MyGame.sprite = Sprite;
            canAttack = true;
            this.Location = location;
        }

        public void Update(GameTime GameTime)
        {
            //flip direction if at edge of screen
            if (Location.X == 0 || Location.X == MyGame.GraphicsDevice.Viewport.Width - Sprite.Area(Location).Width)
                movingLeft = !movingLeft;

            if (movingLeft)
                Location = new Vector2(Location.X - 1, Location.Y);
            else
                Location = new Vector2(Location.X + 1, Location.Y);

            if (isFalling)
                Location = new Vector2(Location.X, Location.Y + 5);

            Sprite.Update(GameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //location = new Vector2(this.Area.X, this.Area.Y);
            Sprite.Draw(spriteBatch, this.Location);
        }
    }
}
