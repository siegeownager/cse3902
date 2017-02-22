﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace SuperMario.Sprites
{
    public class MovingDownRightDiagonalSmallMario : IMarioState
    {
        private Mario mario;
        private int currentFrame;
        private int flashStatus;
        private int nextFlashTime;
        private int millisecondsPerFlash;
        private int startFrame;
        private int totalFrames;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;

        public MovingDownRightDiagonalSmallMario(Mario mario)
        {
            this.mario = mario;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 150;
            currentFrame = 7;
            startFrame = currentFrame;
            totalFrames = 3;
            flashStatus = 0;
            nextFlashTime = 0;
            millisecondsPerFlash = 400;

        }

        public void Update(GameTime gameTime)
        {
            KeyboardState newKeyboardState = Keyboard.GetState();
            GamePadState newGamepadState = GamePad.GetState(PlayerIndex.One);

            if (Mario.starStatus == true)
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
            if ((newKeyboardState.IsKeyDown(Keys.Down) && newKeyboardState.IsKeyDown(Keys.Right))
                || (newGamepadState.IsButtonDown(Buttons.LeftThumbstickDown) &&
                newGamepadState.IsButtonDown(Buttons.LeftThumbstickRight)))
            {
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame -= millisecondsPerFrame;
                    currentFrame++;
                }
                if (currentFrame == startFrame + totalFrames)
                    currentFrame = startFrame;
                if (Mario.locationY == 400)
                {
                    Mario.locationY = 0;
                }
                else if(Mario.locationX == 800)
                {
                    Mario.locationX = 0;
                }
                else
                {
                    Mario.locationY++;
                    Mario.locationX++;
                }
            }
            else
            {
                Mario.marioMode = (int)Mario.MarioModes.Small;
                Mario.orientation = (int)Mario.Orientations.StandingRight;
                currentFrame = 6;
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