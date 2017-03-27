﻿using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class Goomba : IEnemy
    {
        public bool movingLeft { get; set; }
        public bool canAttack { get; set; }
        public bool isFalling { get; set; }
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
        public int cameraPositionX { get; set; }

        private bool dead;
        private int deadCounter = 10;
        public Goomba(Game1 game, Vector2 location)
        {
            movingLeft = true;
            isFalling = true;
            MyGame = game;
            Sprite = SpriteFactory.CreateGoomba();
            canAttack = true;
            Location = location;
            dead = false;
        }
        public void GetKilled()
        {
            if (!dead)
            {
                this.Sprite = new GoombaBeingKilledSprite(SpriteFactory.goombaTexture,4,8);
                dead = true;
            }
        }
        public void ChangeDirection()
        {
            

        }
        public void Update(GameTime GameTime)
        {
            //flip direction if at edge of screen
            if (Location.X - Camera.cameraPositionX < 0)
            {
                movingLeft = false;
                Location = new Vector2(Location.X + 2, Location.Y);
            }
            // if (Location.X - Camera.cameraPositionX > MyGame.GraphicsDevice.Viewport.Width - Sprite.Area(Location).Width)
            //{
            //    movingLeft = true;
            //    Location = new Vector2(Location.X - 2, Location.Y);
            //}

            if (movingLeft)
                Location = new Vector2(Location.X - 4, Location.Y);
            else
                Location = new Vector2(Location.X + 4, Location.Y);

            if (isFalling)
                Location = new Vector2(Location.X, Location.Y + 3);

            if (dead)
            {
                deadCounter--;
            }
            if (deadCounter == 0)
            {
                Sprite = new CleanSprite(SpriteFactory.goombaTexture);
            }

            Sprite.Update(GameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //location = new Vector2(location.X, location.Y);
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.cameraPositionX, Location.Y));
        }
    }

}
