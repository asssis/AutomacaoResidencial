namespace Monitoramento
{
    partial class frmMonitorar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxComando = new System.Windows.Forms.ListBox();
            this.btnMonitorar = new System.Windows.Forms.Button();
            this.picMonitora = new System.Windows.Forms.PictureBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.ckbPortas = new System.Windows.Forms.CheckedListBox();
            this.cbTensao = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMonitora)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxComando
            // 
            this.lbxComando.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbxComando.FormattingEnabled = true;
            this.lbxComando.Location = new System.Drawing.Point(343, 0);
            this.lbxComando.Name = "lbxComando";
            this.lbxComando.Size = new System.Drawing.Size(600, 457);
            this.lbxComando.TabIndex = 0;
            // 
            // btnMonitorar
            // 
            this.btnMonitorar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonitorar.Location = new System.Drawing.Point(1, 418);
            this.btnMonitorar.Name = "btnMonitorar";
            this.btnMonitorar.Size = new System.Drawing.Size(336, 39);
            this.btnMonitorar.TabIndex = 2;
            this.btnMonitorar.Text = "Iniciar";
            this.btnMonitorar.UseVisualStyleBackColor = true;
            this.btnMonitorar.Click += new System.EventHandler(this.btnMonitorar_Click);
            // 
            // picMonitora
            // 
            this.picMonitora.Image = global::Monitoramento.Properties.Resources.Monitorando_desligado;
            this.picMonitora.Location = new System.Drawing.Point(1, 0);
            this.picMonitora.Name = "picMonitora";
            this.picMonitora.Size = new System.Drawing.Size(50, 46);
            this.picMonitora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMonitora.TabIndex = 3;
            this.picMonitora.TabStop = false;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Enabled = false;
            this.txtEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(1, 130);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(335, 26);
            this.txtEndereco.TabIndex = 6;
            // 
            // txtBairro
            // 
            this.txtBairro.Enabled = false;
            this.txtBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.Location = new System.Drawing.Point(1, 185);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(237, 26);
            this.txtBairro.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-3, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Endereço";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-3, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bairro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(240, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Numero";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(244, 185);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(92, 26);
            this.txtNumero.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nome";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(1, 74);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(335, 26);
            this.txtUsuario.TabIndex = 12;
            // 
            // ckbPortas
            // 
            this.ckbPortas.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ckbPortas.FormattingEnabled = true;
            this.ckbPortas.Location = new System.Drawing.Point(2, 275);
            this.ckbPortas.Name = "ckbPortas";
            this.ckbPortas.Size = new System.Drawing.Size(335, 139);
            this.ckbPortas.TabIndex = 15;
            // 
            // cbTensao
            // 
            this.cbTensao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbTensao.FormattingEnabled = true;
            this.cbTensao.Items.AddRange(new object[] {
            "110 V",
            "220 V"});
            this.cbTensao.Location = new System.Drawing.Point(1, 241);
            this.cbTensao.Name = "cbTensao";
            this.cbTensao.Size = new System.Drawing.Size(237, 28);
            this.cbTensao.TabIndex = 16;
            this.cbTensao.Text = "110 V";
            this.cbTensao.SelectedIndexChanged += new System.EventHandler(this.cbTensao_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-3, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Corrente";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.lblHora.Location = new System.Drawing.Point(163, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(174, 46);
            this.lblHora.TabIndex = 18;
            this.lblHora.Text = "00:00:00";
            // 
            // frmMonitorar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(943, 457);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTensao);
            this.Controls.Add(this.ckbPortas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.picMonitora);
            this.Controls.Add(this.btnMonitorar);
            this.Controls.Add(this.lbxComando);
            this.MaximizeBox = false;
            this.Name = "frmMonitorar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitorar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMonitorar_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picMonitora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxComando;
        private System.Windows.Forms.Button btnMonitorar;
        private System.Windows.Forms.PictureBox picMonitora;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.CheckedListBox ckbPortas;
        private System.Windows.Forms.ComboBox cbTensao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHora;
    }
}