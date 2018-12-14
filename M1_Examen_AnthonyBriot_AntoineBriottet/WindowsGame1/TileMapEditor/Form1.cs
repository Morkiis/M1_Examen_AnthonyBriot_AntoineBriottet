using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace TileMapEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sauvegarderMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Xml File (.xml)|*.xml";
            sfd.Title = "Enregistrer";

            if(sfd.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                editor1.Map.Save(sfd.FileName);
            }
        }

        private void ouvirMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd =new  OpenFileDialog();
            ofd.Filter = "Xml File (.xml)|*.xml";
            ofd.Title = "Ouvrir";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XmlSerializer xml = new XmlSerializer(editor1.Map.GetType());
                using (StreamReader reader = new StreamReader(ofd.FileName))
                {
                    editor1.Map = (Map)xml.Deserialize(reader);
                    editor1.Map.Initialize(editor1.Content);
                }
            }
        }
    }
}
