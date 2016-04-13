﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iichanTouhou.Attack;
using iichanTouhou.Helpers;
using SFML.Graphics;
using SFML.System;

namespace iichanTouhou.Objects.NPC
{
    class NPC1 :GameObject
    {
        public NPC1(Danmaku danmaku, Vector2f startPosition, Vector2f size, float hitboxRadius, double lifeTime) : base(danmaku, startPosition, size, hitboxRadius, lifeTime)
        {
        }

        public override void LoadContent()
        {
            
        }

        public override void Initialize()
        {
            Texture = TextureGenerator.Generate(Properties.Resources.npc, ImageFormat.Png);
           
            Speed=new Vector2f(0,2f);
        }


        public override void Tick()
        {
            base.Tick();
            if (Position.Y > 300)
            {
                base.rectangleShape.Texture=TextureGenerator.Generate(Properties.Resources.bullet2, ImageFormat.Png);

                Speed = new Vector2f(0, 0);
                if (attack2 == null)
                    Attack();
            }
            Position += Speed;

            attack2?.Tick();

            
        }

        private Attack2 attack2;

        public void Attack()
        {
            attack2 = new Attack2(danmaku,this.CenterCoordinates,60*60*3);
            attack2.Initialize();
        }


        public override void Render()
        {
            base.Render();
            attack2?.Render();
        }


        
    }
}
