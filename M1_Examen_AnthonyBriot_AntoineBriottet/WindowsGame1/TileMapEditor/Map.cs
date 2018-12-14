using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TileMapEditor
{
    public class Map //Class Map
    {
        [XmlElement("Layer")] // Definie sur la balise <Layer> du xml
        public List<Layer> Layer; 
        public Vector2 TileDimensions;

        public void Initialize(ContentManager content) // Initialisation de la map 
        {
            foreach (Layer l in Layer)
                l.Initialize(content, TileDimensions);
        }

        public void Draw(SpriteBatch spriteBatch) // Cette fonction dessine la map
        {
            foreach (Layer l in Layer)
                l.Draw(spriteBatch);
        }

        public void Save(string filePath) // cette fonction permet la sauvegarde de la map 
        {
            foreach (Layer l in Layer)
                l.Save();

            XmlSerializer xml = new XmlSerializer(this.GetType());
            using (StreamWriter writer = new StreamWriter(filePath))
                xml.Serialize(writer, this);
        }
    }
}
