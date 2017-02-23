﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;


namespace SuperMario.Sprites
{
    public class StandingRightSmallMarioState : IMarioState
    {
        private int currentFrame;
        private Mario mario;
        private int flashStatus;
        private int nextFlashTime;
        private int millisecondsPerFlash;

        public StandingRightSmallMarioState(Mario mario)
        {
            this.mario = mario;
            currentFrame = 6;
            flashStatus = 0;
            nextFlashTime = 0;
            millisecondsPerFlash = 400;
        }

        public void Update(GameTime gameTime)
        {
            if (Mario.starStatus || Mario.invulnStatus)
            {
                nextFlashTime += gameTime.ElapsedGameTime.Milliseconds;
                if (nextFlashTime > millisecondsPerFlash)
                {
                    nextFlashTime -= millisecondsPerFlash;
                    if (flashStatus == 0)
                    {
                        flashStatus = 1;
                    }

                    else if (flashStatus == 1)
                    {
                        flashStatus = 0;
                    }

                }
            }
            else
            {
                flashStatus = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = mario.Texture.Width / mario.Columns;
            int height = mario.Texture.Height / mario.Rows;
            int row = (int)((float)currentFrame / (float)mario.Columns);
            int column = currentFrame % mario.Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            if (flashStatus == 1)
            {
                spriteBatch.Draw(mario.Texture, destinationRectangle, sourceRectangle, Color.White * 0.5f);
            }
            else
            {
                spriteBatch.Draw(mario.Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            spriteBatch.End();
        }


    }
}
