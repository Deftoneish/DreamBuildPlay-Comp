using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using Microsoft.Xna.Framework;

namespace Olisgay
{

    public class Level
    {

        public int levelNumber;

        public string name;

        public int Width;

        public int Height;

        public Vector2 startPosition;

        public Rectangle endPosition;

        private List<LevelItem> items;

        private Texture2D endTex;

        private Texture2D backgroundTex;

    }

    public Level(ContentManager content)

        {

            //load the two textures we need

            endTex = content.Load<Texture2D>(“endTile”);

            backgroundTex = content.Load<Texture2D>(“background”);

            items = new List<LevelItem>();

        }

    public void Update()

        {

        }

public void Draw(SpriteBatch spriteBatch)

        {

            //draw the background first, then the end texture rectangle

            spriteBatch.Draw(backgroundTex, new Rectangle(0, 0, Width, Height), Color.White);

            spriteBatch.Draw(endTex, endPosition, Color.White);

            foreach (LevelItem item in items)

            {

                //Remember that the LevelItem class inherits from Sprite, so it does have a draw method

                item.Draw(spriteBatch);

            }

        }

public void AddLevelItem(LevelItem item)

        {

            items.Add(item);

        }

}