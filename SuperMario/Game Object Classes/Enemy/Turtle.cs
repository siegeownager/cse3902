﻿using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class Turtle
    {
        private Game1 myGame;

        public Turtle(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateTurtle();
            myGame.sprite = mySprite;
        }
    }
}
