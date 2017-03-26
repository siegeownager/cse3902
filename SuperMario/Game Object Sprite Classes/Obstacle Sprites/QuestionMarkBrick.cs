﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework.Content;
using SuperMario.Levels;

namespace SuperMario
{
    class QuestionMarkBrickSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 Location { get; set; }

        private int currentFrame;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;
        private bool hasBeenUsed;
        private int width;
        private int height;
        public QuestionMarkBrickSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 350;
            width = 51;
            height = 29;
            hasBeenUsed = false;
        }

        public void Update(GameTime GameTime)
        {
            if(!hasBeenUsed)
            {
                timeSinceLastFrame += GameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame -= millisecondsPerFrame;
                    currentFrame++;
                }

                if (currentFrame == 3)
                { currentFrame = 0; }
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
          
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X - 7 , (int)location.Y - 2, width + 4, height +4);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public Rectangle Area(Vector2 location)
        {
            int width  = 32; //Texture.Width / Columns;
            int height =32;// Texture.Height / Rows;
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
        public void CollisionSprite()
        {
            Texture = SpriteFactory.solidBrickWithCrewsTexture;
            width = 28;
            height = 29;
            hasBeenUsed = true;
            currentFrame = 0;
        }
    }
}
