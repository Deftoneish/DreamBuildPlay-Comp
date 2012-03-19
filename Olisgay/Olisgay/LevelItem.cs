using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework;

namespace Olisgay

{

    public class LevelItem : Sprite

    {

        public LevelItem(Texture2D texture, Vector2 position, float rotation)

        {

            this.texture = texture;

            this.position = position;

            this.rotation = MathHelper.ToRadians(rotation);

            frameHeight = texture.Height;

            frameWidth = texture.Width;

            this.origin = Center;

            animations.Add(“idle”, new AnimationStrip(texture, frameWidth, “idle”));
                          

            PlayAnimation(“idle”);

        }

    }

}