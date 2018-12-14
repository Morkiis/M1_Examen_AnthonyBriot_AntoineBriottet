using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TileMapEditor
{
    class Editor : GraphicsDeviceControl
    {
        ContentManager content;
        SpriteBatch spriteBatch;
        Map map;
        int layerNumber;
        bool isMouseDown = false;
        public Rectangle SelectedTileRegion;
        public List<Vector2> SelectedTiles;
        Vector2 mousePosition;
        bool  mouseOnScreen = false;
        string[] selectorPath = { "Editor/SelectorT1", "Editor/SelectorT2", "Editor/SelectorB1", "Editor/SelectorB2" };
        public List<Image>Selector;
        public Vector2 SelectorDimensions;

        public event EventHandler OnInitialize;

        public Map Map
        {
            get { return map; }
            set { map = value; }
        }

        public ContentManager Content
        {
            get { return content; }
        }

        protected override void Draw()//permet de dessiner l'editeur , dessine le selecteur si la souris est sur le tileset
        {
            GraphicsDevice.Clear(Color.GreenYellow);
            spriteBatch.Begin();
            map.Draw(spriteBatch);
            if (mouseOnScreen)
            {
                foreach (Image img in Selector)
                    img.Draw(spriteBatch);
            }
            spriteBatch.End();

        }

        public Editor() // permet de selectionner les cases du tileset/map
        {
            map = new Map();
            layerNumber = 0;
            Selector = new List<Image>();


            for (int i = 0; i < 4; i++)
                Selector.Add(new Image());

            SelectorDimensions = Vector2.Zero;
            SelectedTileRegion = new Rectangle(0, 0, 0, 0);

            SelectedTiles = new List<Vector2>();
            SelectedTiles.Add(Vector2.Zero);
            MouseMove += Editor_MouseMove;
            MouseDown += Editor_MouseDown;
            MouseUp += delegate { isMouseDown = false; };
            MouseEnter += delegate { mouseOnScreen = true; };
            MouseLeave += delegate { mouseOnScreen = false; Draw(); Invalidate(); };
            
        }

        private void Editor_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)//récupère la tile selectionée en fonction de la position et le click de la souris
        {
            CurrentLayer.ReplaceTiles(mousePosition, SelectedTileRegion);
            isMouseDown = true;
        }

        private void Editor_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)//récupère la position de la souris et si la souris est Down permet d'agrandir la séléction 
        {
            mousePosition = new Vector2((int)(e.X / CurrentLayer.TileDimensions.X), (int)(e.Y / CurrentLayer.TileDimensions.Y));
            mousePosition *= 32;

            int width = (int)(SelectedTileRegion.Width * CurrentLayer.TileDimensions.X);
            int height = (int)(SelectedTileRegion.Height * CurrentLayer.TileDimensions.Y);

            Selector[0].position = mousePosition;
            Selector[1].position = new Vector2(mousePosition.X + width, mousePosition.Y);
            Selector[2].position = new Vector2(mousePosition.X , mousePosition.Y + height);
            Selector[3].position = new Vector2(mousePosition.X + width, mousePosition.Y + height);

            if (isMouseDown)
                Editor_MouseDown(this, null);

            Invalidate();//Invalide la surface totale du contrôle et le contrôle est redessiné.


        }

        public Layer CurrentLayer //retourne le layer sur lequel se trouve l'editeur (pour l'instant un seul est disponible)
        {
            get { return map.Layer[layerNumber]; }
        }

        protected override void Initialize()//Initialise l'editeur au lancement de l'appli et à l'ouverture d'un fichier
        {
            content = new ContentManager(Services, "Content");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            for (int i = 0; i < 4; i++)
            {
                Selector[i].Path = selectorPath[i];
                Selector[i].Initialize(content);
            }
            XmlSerializer xml = new XmlSerializer(map.GetType());
            Stream stream = File.Open("Load/Map.xml", FileMode.Open);
            map = (Map)xml.Deserialize(stream);
            map.Initialize(content);

            if (OnInitialize != null)
                OnInitialize(this, null);
        }
    }
}
