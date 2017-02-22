﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    class BreakableCurlyBrickSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 Location { get; set; }
        public int currentFrame;

        private Boolean isNotDestroyed = true;

        public BreakableCurlyBrickSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if(isNotDestroyed)
            {
                int width = 36;
                int height = 34;
                int row = (int)((float)currentFrame / (float)Columns);
                int column = currentFrame % Columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle(600, 250, width, height);
                spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }
        public Rectangle Area()
        {
            if (isNotDestroyed)
            {
                int width = 34;//Texture.Width / Columns;
                int height = 32;//Texture.Height;// / Rows;
                return new Rectangle(600, 250, width, height);
            }
            else
                return Rectangle.Empty;

        }
        public void CollisionSprite()
        {
            isNotDestroyed = false;
        }
    }
}
