﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMario.Levels;
using SuperMario.Interfaces;

namespace SuperMario
{
    public class WorldManager
    {
        public Game1 MyGame;
        public LevelClass Level;

        public WorldManager(Game1 game)
        {
            MyGame = game;
            Level = new LevelClass(MyGame);
        }
        public void Load()
        {
            Level.Load();
        }

        public void Update(GameTime gameTime)
        {
            Level.Update(gameTime);

        }

        public void Draw(Vector2 location)
        {
            Level.Draw(location);
        }
    }
}