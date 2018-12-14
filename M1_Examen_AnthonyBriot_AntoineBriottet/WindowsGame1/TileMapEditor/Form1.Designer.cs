namespace TileMapEditor
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            TileMapEditor.Map map1 = new TileMapEditor.Map();
            this.editor1 = new TileMapEditor.Editor();
            this.tileDisplay1 = new TileMapEditor.TileDisplay(this.editor1);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvirMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sauvegarderMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor1
            // 
            this.editor1.Location = new System.Drawing.Point(12, 73);
            this.editor1.Map = map1;
            this.editor1.Name = "editor1";
            this.editor1.Size = new System.Drawing.Size(535, 448);
            this.editor1.TabIndex = 0;
            this.editor1.Text = "editor1";
            // 
            // tileDisplay1
            // 
            this.tileDisplay1.Location = new System.Drawing.Point(553, 73);
            this.tileDisplay1.Name = "tileDisplay1";
            this.tileDisplay1.Size = new System.Drawing.Size(762, 665);
            this.tileDisplay1.TabIndex = 1;
            this.tileDisplay1.Text = "tileDisplay1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1327, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvirMapToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sauvegarderMapToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // ouvirMapToolStripMenuItem
            // 
            this.ouvirMapToolStripMenuItem.Name = "ouvirMapToolStripMenuItem";
            this.ouvirMapToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.ouvirMapToolStripMenuItem.Text = "Ouvrir Map";
            this.ouvirMapToolStripMenuItem.Click += new System.EventHandler(this.ouvirMapToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
            // 
            // sauvegarderMapToolStripMenuItem
            // 
            this.sauvegarderMapToolStripMenuItem.Name = "sauvegarderMapToolStripMenuItem";
            this.sauvegarderMapToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.sauvegarderMapToolStripMenuItem.Text = "Enregistrer";
            this.sauvegarderMapToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderMapToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 647);
            this.Controls.Add(this.tileDisplay1);
            this.Controls.Add(this.editor1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Editor editor1;
        private TileDisplay tileDisplay1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvirMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderMapToolStripMenuItem;
    }
}

