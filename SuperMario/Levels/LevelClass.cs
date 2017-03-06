﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Levels
{
    public class LevelClass
    {
        public Game1 MyGame;
        public static List<IItem> ItemList = new List<IItem>();
        public static List<IEnemy> EnemyList = new List<IEnemy>();
        public static List<IBlock> BlockList = new List<IBlock>();
        public static List<IBackground> BackgroundList = new List<IBackground>();

        public LevelReader loader;
        private int count = 0;

        public LevelClass(Game1 game)
        {
            MyGame = game;
            loader = new LevelReader(this, game);

        }
        public void Load()
        {
            loader.Load();
        }

        public void Update(GameTime gameTime)
        {
            foreach (IEnemy enemy in EnemyList)
            {
                enemy.Update(gameTime);
            }
            foreach (IBlock block in BlockList)
            {
                block.Update(gameTime);
            }
            foreach (IItem item in ItemList)
            {
                item.Update(gameTime);

            }
            foreach (IBackground background in BackgroundList)
            {
                background.Update(gameTime);
            }
        }
        public void Draw(Vector2 location)
        {
            foreach (IBackground background in BackgroundList)
            {
                background.Draw(MyGame.spriteBatch, location);
            }
            foreach (IItem item in ItemList)
            {
                item.Draw(MyGame.spriteBatch, location);
            }
            foreach (IBlock block in BlockList)
            {
                block.Draw(MyGame.spriteBatch, location);
            }
            foreach (IEnemy enemy in EnemyList)
            {
                enemy.Draw(MyGame.spriteBatch, location);
            }
        }
    }
}