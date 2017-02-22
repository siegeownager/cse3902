﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    class KoopaDieSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;
        public KoopaDieSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 2;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 400;
        }

        public void Update(GameTime gameTime)
        {

            //Temporary comment just for this sprint

            //timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            //if (timeSinceLastFrame > millisecondsPerFrame)
            //{
            //    timeSinceLastFrame -= millisecondsPerFrame;
            //    currentFrame++;
            //}

            //if (currentFrame == 4)
            //{ currentFrame = 1; }

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 17;
            int height = 24;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(700, 160, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public Rectangle Area()
        {

            return new Rectangle();
        }
        public void CollisionSprite()
        {

        }
    }
}
