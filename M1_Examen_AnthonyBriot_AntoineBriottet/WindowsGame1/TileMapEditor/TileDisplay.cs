using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileMapEditor
{
    class TileDisplay : GraphicsDeviceControl
    {
        Editor editor;
        Image image;
        SpriteBatch spriteBatch;
        List<Image> selector;
        bool isMouseDown;
        Vector2 mousePosition, clickPosition;


        public TileDisplay()
        {

        }

        public TileDisplay(Editor editor)
        {
            this.editor = editor;
            editor.OnInitialize += LoadContent;
            isMouseDown = false;
        }

        void LoadContent(object sender, EventArgs e)
        {
            image = editor.CurrentLayer.Image;
            selector = editor.Selector;


        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.GreenYellow);

            spriteBatch.Begin();
            image.Draw(spriteBatch);
            foreach (Image img in selector)
                img.Draw(spriteBatch);
            spriteBatch.End();
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MouseDown += TileDisplay_MouseDown;
            MouseUp += delegate {
                isMouseDown = false;

                List<Image> seletor = editor.Selector;

                //Rectangle selectedTileRegion = editor.SelectedTileRegion;
                editor.SelectedTileRegion = new Rectangle((int)selector[0].position.X, (int)selector[0].position.Y, (int)(selector[1].position.X - selector[0].position.X), (int)(selector[2].position.Y - selector[0].position.Y));

                editor.SelectedTileRegion.X /= 32;
                editor.SelectedTileRegion.Y /= 32;
                editor.SelectedTileRegion.Width /= 32;
                editor.SelectedTileRegion.Height /= 32;


            };



            MouseMove += TileDisplay_MouseMove;
        }

        private void TileDisplay_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mousePosition = new Vector2((int)(e.X / editor.CurrentLayer.TileDimensions.X),(int)(e.Y/editor.CurrentLayer.TileDimensions.Y));
            mousePosition *= 32;

            if(mousePosition != clickPosition && isMouseDown)//sert a augmenter la taille de la séléction 
            {
                for (int i = 0; i< 4; i++)
                {
                    if (i % 2 == 0 && mousePosition.X < clickPosition.X)
                        selector[i].position.X = mousePosition.X;
                    else if (i % 2 != 0 && mousePosition.X > clickPosition.X)
                        selector[i].position.X = mousePosition.X;
                    if (i < 2  && mousePosition.Y < clickPosition.Y)
                        selector[i].position.Y = mousePosition.Y;
                    else if (i >= 2 && mousePosition.Y > clickPosition.Y)
                        selector[i].position.Y = mousePosition.Y;
                    
                }
                Invalidate();
            }
            else
            {
                foreach (Image img in selector)
                    img.position = mousePosition;
            }
            Invalidate();
        }

        private void TileDisplay_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(!isMouseDown)
            {
                clickPosition = mousePosition;
                foreach (Image img in selector)
                    img.position = mousePosition;
            }
            isMouseDown = true;
            Invalidate();
        }
    }
}
