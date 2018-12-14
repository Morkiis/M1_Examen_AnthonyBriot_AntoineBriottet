using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TileMapEditor
{
    public class Image //class Image
    {
        private Texture2D texture;
        private ContentManager content;
        public Rectangle SourceRect;
        public float Alpha;
        public string Path;
        public Vector2 position;

        [XmlIgnore]
        public Texture2D Texture
        {
            get { return texture; }
        }

        public Image()
        {
            Alpha = 1.0f;
            SourceRect = Rectangle.Empty;
        }

        public void Initialize(ContentManager content)// initialise l'image dans le contenue
        {
            this.content = new ContentManager(content.ServiceProvider, "Content");
            //charge la texture si la balise <path> n'est pas vide
            if (!string.IsNullOrEmpty(Path))
                texture = this.content.Load<Texture2D>(Path);

            if (SourceRect == Rectangle.Empty)
                SourceRect = texture.Bounds;

        
        }

        public void Draw(SpriteBatch spriteBatch) // Dessine l'image 
        {
            spriteBatch.Draw(texture, position, SourceRect, Color.White * Alpha);
        }

    }
}
