using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Globalization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TileMapEditor
{
    public class Layer// Class Layer
    {
        public class TileMap // Class TileMap définie par les balise <Row> du Xml
        {
            [XmlElement("Row")]
            public List<string> Row;
        }

        Vector2 tileDimensions;
        List<List<Vector2>> tileMap;
        [XmlElement("TileMap")]//L'élément TileMap est définie par la balise <TileMap>
        public TileMap TileLayout;
        [XmlElement("Image")]//L'élément Image est définie par la balise <Image>
        public Image Image;

        public Vector2 TileDimensions//retourne la dimensions de la tile 
        {
            get { return tileDimensions; }
        }

        public Layer() // Layer définie en fonction de la tileDimensions et de la tileMap
        {
            tileDimensions = new Vector2();
            tileMap = new List<List<Vector2>>();
        }

        public void ReplaceTiles(Vector2 position, Rectangle selectedRegion) // fonction permettant de changer les cases du tileeditor en fonction de la tile selectionné dans le tileset
        {
            Vector2 startIndex = new Vector2(position.X / tileDimensions.X, position.Y / tileDimensions.Y);
            Vector2 tileIndex = new Vector2(selectedRegion.X, selectedRegion.Y - 1);
            Vector2 mapIndex = Vector2.Zero;

            for (int i = (int)startIndex.Y; i <= startIndex.Y + selectedRegion.Height; i++)
            {
                tileIndex.X = selectedRegion.X;
                tileIndex.Y++;
                for( int j = (int)startIndex.X; j <= startIndex.X + selectedRegion.Width; j++)
                {
                    if (tileIndex.X * tileDimensions.X > Image.Texture.Width || tileIndex.Y * tileDimensions.Y > Image.Texture.Height)
                        mapIndex = -Vector2.One;
                    else
                        mapIndex = tileIndex;

                    try
                    {
                        tileMap[i][j] = mapIndex;
                    }
                    catch (Exception e)
                    {
                        while (tileMap.Count <= i)
                        {
                            List<Vector2> tempTileMap = new List<Vector2>();
                            for (int k = 0; k < tileMap[0].Count; k++)
                                tempTileMap.Add(-Vector2.One);
                            tileMap.Add(tempTileMap);
                        }

                        while (tileMap[i].Count <= j)
                            tileMap[i].Add(-Vector2.One);

                        tileMap[i][j] = mapIndex;
                    }

                    tileIndex.X++;
                }
            }
        }

        public void Initialize(ContentManager content, Vector2 tileDimensions)// Fonction d'initialisation du layer
        {
            foreach (string row in TileLayout.Row)
            {
                string[] split = row.Split(']');
                List<Vector2> tempTileMap = new List<Vector2>();
                foreach (string s in split)
                {
                    int value1, value2;
                    string str;
                    if (!s.Contains('x') && s != String.Empty)//Prend les information du fichier Xml et enlève les "[]" et les ":"
                    {
                        str = s.Replace("[", string.Empty);
                        Int32.TryParse(str.Substring(0, str.IndexOf(':')) ,out value1);                        
                        Int32.TryParse(str.Substring(str.IndexOf(':') + 1), out value2);
                    }

                    else
                        value1 = value2 = -1;

                    tempTileMap.Add(new Vector2(value1, value2));
                }
                tileMap.Add(tempTileMap);//ajoute les information dans tileMap Temporaire 
            }

            Image.Initialize(content);
            this.tileDimensions = tileDimensions;

        }

        public void Draw(SpriteBatch spriteBatch)//Fonction permettant de dessiner le layer
        {
            for (int i = 0; i < tileMap.Count; i++)
            {
                for(int j = 0; j< tileMap[i].Count; j++)
                {
                    if (tileMap[i][j] != -Vector2.One)
                    {
                        Image.position = new Vector2(j * tileDimensions.X, i * tileDimensions.Y);
                        Image.SourceRect = new Rectangle((int)(tileMap[i][j].X * tileDimensions.X),
                            (int)(tileMap[i][j].Y * tileDimensions.Y), (int)tileDimensions.X,
                            (int)tileDimensions.Y);
                        Image.Draw(spriteBatch);
                    }
                }
            }
            Image.position = Vector2.Zero;
            Image.SourceRect = Image.Texture.Bounds;
        }

        public void Save() // fonction de sauvegarde du layer 
        {
            TileLayout.Row = new List<string>();

            for (int i = 0; i < tileMap.Count; i++)
            {
                string row = String.Empty;
                for(int j = 0; j < tileMap[i].Count; j++)
                {
                    if (tileMap[i][j] == -Vector2.One) //ecris dans le xml le tileMap[i][j].X et le tileMap[i][j].Y sous la forme [x:x]
                        row += "[x:x]";
                    else
                        row += "[" + tileMap[i][j].X.ToString() + ":" + tileMap[i][j].Y.ToString() + "]";
                }
                TileLayout.Row.Add(row);
            }
        }
    }
}
