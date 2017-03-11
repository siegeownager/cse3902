﻿using Microsoft.Xna.Framework;
using SuperMario.Collision_Detection_and_Responses;
using SuperMario.Interfaces;
using SuperMario.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Collision_Detection_and_Responses
{
    class CollisionHandling
    {

        private CollisionHandling()
        {

        }
        public static void Update(LevelClass level, Game1 game)
        {
            Rectangle marioRect = game.Mario.Area();

            foreach (IItem item in LevelClass.ItemList)
            {

                Rectangle itemRect = item.Area();

                if (marioRect.Intersects(itemRect))
                {
                    MarioAndItemCollisionResponser.Response(game.Mario, item);
                }

            }

            foreach (IBlock item in LevelClass.BlockList)
            {

                Rectangle blockRect = item.Sprite.Area(item.Location);

                if (marioRect.Intersects(blockRect))
                {
                    MarioAndBlockCollisionHandling.HandleCollision(game.Mario, item);
                }
                

                for (int i = 0; i < LevelClass.EnemyList.Count; i++)
                {
                    IEnemy enemyInList = LevelClass.EnemyList.ElementAt<IEnemy>(i);

                    if (blockRect.Intersects(enemyInList.Sprite.Area(enemyInList.Location)))
                        EnemyAndBlockCollisionHandling.HandleCollision(enemyInList, item);
                    else
                        enemyInList.isFalling = true;
                }
            }

            foreach (IEnemy item in LevelClass.EnemyList)
            {

                Rectangle enemyRect = item.Sprite.Area(item.Location);

                if (marioRect.Intersects(enemyRect) && !game.Mario.isDead())
                {
                    MarioAndEnemyCollisionHandling.HandleCollision(game.Mario, item);
                }
                               
            }


            //enemy and enemy collision
            for (int i = 0; i < LevelClass.EnemyList.Count - 1; i++)
            {
                for (int j = i + 1; j < LevelClass.EnemyList.Count; j++)
                {
                    IEnemy enemy1 = LevelClass.EnemyList.ElementAt<IEnemy>(i);
                    IEnemy enemy2 = LevelClass.EnemyList.ElementAt<IEnemy>(j);
                    if (enemy1.Sprite.Area(enemy1.Location).Intersects(enemy2.Sprite.Area(enemy2.Location)))
                    {
                        EnemyAndEnemyCollisionHandling.HandleCollision(enemy1, enemy2);
                    }
                }
            }
        }
    }
}
