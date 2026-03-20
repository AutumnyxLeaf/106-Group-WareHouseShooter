using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Right_to_Return_Arms
{
    internal class BulletManager
    {
        // <--------------------------------------- Fields --------------------------------------->
        private List<Bullet> bulletList;


        // <------------------------------------- Properties --------------------------------------->




        // <--------------------------------------- Constructor --------------------------------------->

        public BulletManager()
        {
            bulletList = new List<Bullet>();
        }


        // <--------------------------------------- Methods --------------------------------------->

        public void AddBullet(Bullet bullet)
        {
            bulletList.Add(bullet);
        }

        public void RemoveBullet(Bullet bullet)
        {
            bulletList.Remove(bullet);
        }

        public void UpdateBullets()
        {
            foreach (Bullet b in bulletList)
            {
                b.Update();
            }
        }

        public void DrawBullets(SpriteBatch sb)
        {
            foreach (Bullet b in bulletList)
            {
                b.Draw(sb);
            }
        }

        public void CheckBulletCollisons(GameObject gameObject, CollisionTags tag = CollisionTags.Default)
        {
            for(int i = 0; i < bulletList.Count; i++)
            {
                if (bulletList[i].CheckCollision(gameObject, tag))
                {
                    RemoveBullet(bulletList[i]);
                }
                
            }
        }

        public Bullet GetBullet(int i)
        {
            return bulletList[i];
        }

        public Bullet GetLastBullet()
        {
            return bulletList[bulletList.Count - 1];
        }
    }
}
