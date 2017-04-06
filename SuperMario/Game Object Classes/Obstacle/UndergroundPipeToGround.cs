﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Command;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class UndergroundPipeToGround : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 Location { get; set; }
        public UndergroundPipeToGround(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateUndergroundPipeToGround();
            MyGame.Sprite = Sprite;
            this.Location = location;
        }
        public void BrickToDisappear()
        {
        }
        public void HiddenToUsed()
        {
        }
        public void BecomeUsed()
        {
            ICommand gotoUnderground = new MarioBackToGroundCommand(MyGame);
            gotoUnderground.Execute();
        }
        public void Update(GameTime GameTime)
        {
            Sprite.Update(GameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.CameraPositionX, Location.Y));
        }
    }
}
