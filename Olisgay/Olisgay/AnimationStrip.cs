using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olisgay
{
    public class AnimationStrip
    {

        #region Fields

        public Texture2D Texture;

        public int FrameWidth;

        public int FrameHeight;

        private float frameTimer = 0f;

        public float FrameDelay = 0.05f;

        private int currentFrame;

        public bool LoopAnimation = true;

        public bool FinishedPlaying = false;

        public string Name;

        public string NextAnimation;

        #endregion

        #region Properties

        public int FrameCount
        {

            get { return Texture.Width / FrameWidth; }

        }

        public Rectangle FrameRectangle
        {

            get
            {

                return new Rectangle(

                    currentFrame * FrameWidth,

                    0,

                    FrameWidth,

                    FrameHeight);

            }

        }

        #endregion

        #region Constructor

        public AnimationStrip(Texture2D texture, int frameWidth, string name)
        {

            this.Texture = texture;

            this.FrameWidth = frameWidth;

            this.FrameHeight = texture.Height;

            this.Name = name;

        }

        #endregion

        #region Update

        public void Update(GameTime gameTime)
        {

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            frameTimer += elapsed;

            if (frameTimer >= FrameDelay)
            {

                currentFrame++;

                if (currentFrame >= FrameCount)
                {

                    if (LoopAnimation)
                    {

                        currentFrame = 0;

                    }

                    else
                    {

                        currentFrame = FrameCount - 1;

                        FinishedPlaying = true;

                    }

                }

                frameTimer = 0f;

            }

        }

        #endregion

        #region Public Methods

        public void Play()
        {

            currentFrame = 0;

            FinishedPlaying = false;

        }

        #endregion




    }
}
