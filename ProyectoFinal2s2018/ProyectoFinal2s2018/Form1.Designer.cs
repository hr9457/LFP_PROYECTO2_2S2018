namespace ProyectoFinal2s2018
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPrincipal = new System.Windows.Forms.TextBox();
            this.btnGraphviz = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardarComo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.BtnAnalizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPrincipal
            // 
            this.txtPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPrincipal.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtPrincipal.Location = new System.Drawing.Point(23, 106);
            this.txtPrincipal.Multiline = true;
            this.txtPrincipal.Name = "txtPrincipal";
            this.txtPrincipal.Size = new System.Drawing.Size(1520, 717);
            this.txtPrincipal.TabIndex = 5;
            // 
            // btnGraphviz
            // 
            this.btnGraphviz.Image = global::ProyectoFinal2s2018.Properties.Resources.icons8_diagrama_de_flujo_64;
            this.btnGraphviz.Location = new System.Drawing.Point(517, 23);
            this.btnGraphviz.Name = "btnGraphviz";
            this.btnGraphviz.Size = new System.Drawing.Size(83, 66);
            this.btnGraphviz.TabIndex = 7;
            this.btnGraphviz.UseVisualStyleBackColor = true;
            this.btnGraphviz.Click += new System.EventHandler(this.btnGraphviz_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Image = global::ProyectoFinal2s2018.Properties.Resources.icons8_reporte_de_negocios_64;
            this.btnReporte.Location = new System.Drawing.Point(434, 23);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(76, 66);
            this.btnReporte.TabIndex = 6;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::ProyectoFinal2s2018.Properties.Resources.icons8_cancelar_96;
            this.btnSalir.Location = new System.Drawing.Point(352, 23);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 66);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardarComo
            // 
            this.btnGuardarComo.Image = global::ProyectoFinal2s2018.Properties.Resources.icons8_guardar_todo_64;
            this.btnGuardarComo.Location = new System.Drawing.Point(271, 23);
            this.btnGuardarComo.Name = "btnGuardarComo";
            this.btnGuardarComo.Size = new System.Drawing.Size(75, 66);
            this.btnGuardarComo.TabIndex = 3;
            this.btnGuardarComo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::ProyectoFinal2s2018.Properties.Resources.icons8_guardar_como_64;
            this.btnGuardar.Location = new System.Drawing.Point(190, 23);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 66);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Image = global::ProyectoFinal2s2018.Properties.Resources.icons8_abrir_carpeta_96;
            this.btnAbrir.Location = new System.Drawing.Point(109, 23);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 66);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // BtnAnalizar
            // 
            this.BtnAnalizar.Image = global::ProyectoFinal2s2018.Properties.Resources.icons8_siguiente_96;
            this.BtnAnalizar.Location = new System.Drawing.Point(23, 23);
            this.BtnAnalizar.Name = "BtnAnalizar";
            this.BtnAnalizar.Size = new System.Drawing.Size(80, 66);
            this.BtnAnalizar.TabIndex = 0;
            this.BtnAnalizar.UseVisualStyleBackColor = true;
            this.BtnAnalizar.Click += new System.EventHandler(this.BtnAnalizar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1567, 867);
            this.Controls.Add(this.btnGraphviz);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.txtPrincipal);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardarComo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.BtnAnalizar);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analisar Lexico - Sintatico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAnalizar;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnGuardarComo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtPrincipal;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnGraphviz;
    }
}

