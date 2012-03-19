using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Olisgay
{
    public class Sprite
    {

        #region Fields

        public Texture2D texture;

        public Vector2 position = Vector2.Zero;

        public Color color = Color.White;

        public float rotation = 0.0f;

        public Vector2 origin = Vector2.Zero;

        public float scale = 1.0f;

        public SpriteEffects effects = SpriteEffects.None;

        public float layerDepth = 1.0f;

        private bool alive = true;

        public Vector2 velocity;

        private string currentAnimation;

        public int frameWidth;

        public int frameHeight;

        public Dictionary<string, AnimationStrip> animations =

            new Dictionary<string, AnimationStrip>();

        #endregion

        #region Properties

        public bool Alive
        {

            get { return alive; }

            set { alive = value; }

        }

        public Vector2 Center
        {

            get { return new Vector2(frameWidth / 2, frameHeight / 2); }

        }

        #endregion

        #region Constructor

        public Sprite()
        {

            velocity = Vector2.Zero;

            origin = Center;

        }

        #endregion

        #region Update

        public virtual void Update(GameTime gameTime)
        {

            if (!alive)

                return;

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            updateAnimation(gameTime);

            position += velocity * elapsed;

        }

        #endregion

        #region Draw

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            if (!alive)

                return;

            if (animations.ContainsKey(currentAnimation))
            {

                spriteBatch.Draw(

                    animations[currentAnimation].Texture,

                    position,

                    animations[currentAnimation].FrameRectangle,

                    color, rotation, origin, scale, effects, layerDepth);

            }

        }

        #endregion

        #region Methods

        public void PlayAnimation(string name)
        {

            if (!(name == null) && animations.ContainsKey(name))
            {

                currentAnimation = name;

                animations[name].Play();

            }

        }

        private void updateAnimation(GameTime gameTime)
        {

            if (animations.ContainsKey(currentAnimation))
            {

                if (animations[currentAnimation].FinishedPlaying)
                {

                    PlayAnimation(animations[currentAnimation].NextAnimation);

                }

                else
                {

                    animations[currentAnimation].Update(gameTime);

                }

            }

        }

        #endregion



    }
}
