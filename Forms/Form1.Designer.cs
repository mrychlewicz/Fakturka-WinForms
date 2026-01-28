namespace Fakturka
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvFaktury = new System.Windows.Forms.DataGridView();
            this.dgvPozycje = new System.Windows.Forms.DataGridView();
            this.tbNumerFaktury = new System.Windows.Forms.TextBox();
            this.dtpDataFaktury = new System.Windows.Forms.DateTimePicker();
            this.cmbRodzajFaktury = new System.Windows.Forms.ComboBox();
            this.btnDodajFakture = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUsluga = new System.Windows.Forms.TextBox();
            this.numIlosc = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCenaNetto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbVat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCenaBrutto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEdytujFakture = new System.Windows.Forms.Button();
            this.btnEdytujPozycje = new System.Windows.Forms.Button();
            this.btnUsunFakture = new System.Windows.Forms.Button();
            this.btnUsunPozycje = new System.Windows.Forms.Button();
            this.tbSzukanaFaktura = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.chbAktywne = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaktury)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPozycje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIlosc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFaktury
            // 
            this.dgvFaktury.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaktury.Location = new System.Drawing.Point(8, 38);
            this.dgvFaktury.Name = "dgvFaktury";
            this.dgvFaktury.RowHeadersWidth = 51;
            this.dgvFaktury.RowTemplate.Height = 24;
            this.dgvFaktury.Size = new System.Drawing.Size(776, 96);
            this.dgvFaktury.TabIndex = 0;
            this.dgvFaktury.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFaktury_CellFormatting);
            this.dgvFaktury.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaktury_RowEnter);
            // 
            // dgvPozycje
            // 
            this.dgvPozycje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPozycje.Location = new System.Drawing.Point(8, 140);
            this.dgvPozycje.Name = "dgvPozycje";
            this.dgvPozycje.RowHeadersWidth = 51;
            this.dgvPozycje.RowTemplate.Height = 24;
            this.dgvPozycje.Size = new System.Drawing.Size(776, 149);
            this.dgvPozycje.TabIndex = 1;
            // 
            // tbNumerFaktury
            // 
            this.tbNumerFaktury.Location = new System.Drawing.Point(8, 319);
            this.tbNumerFaktury.Name = "tbNumerFaktury";
            this.tbNumerFaktury.Size = new System.Drawing.Size(200, 22);
            this.tbNumerFaktury.TabIndex = 2;
            // 
            // dtpDataFaktury
            // 
            this.dtpDataFaktury.Location = new System.Drawing.Point(8, 373);
            this.dtpDataFaktury.Name = "dtpDataFaktury";
            this.dtpDataFaktury.Size = new System.Drawing.Size(200, 22);
            this.dtpDataFaktury.TabIndex = 3;
            // 
            // cmbRodzajFaktury
            // 
            this.cmbRodzajFaktury.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRodzajFaktury.FormattingEnabled = true;
            this.cmbRodzajFaktury.Items.AddRange(new object[] {
            "Sprzedazowa",
            "Zakupowa"});
            this.cmbRodzajFaktury.Location = new System.Drawing.Point(8, 426);
            this.cmbRodzajFaktury.Name = "cmbRodzajFaktury";
            this.cmbRodzajFaktury.Size = new System.Drawing.Size(200, 24);
            this.cmbRodzajFaktury.TabIndex = 4;
            // 
            // btnDodajFakture
            // 
            this.btnDodajFakture.Location = new System.Drawing.Point(8, 465);
            this.btnDodajFakture.Name = "btnDodajFakture";
            this.btnDodajFakture.Size = new System.Drawing.Size(100, 23);
            this.btnDodajFakture.TabIndex = 5;
            this.btnDodajFakture.Text = "Dodaj Fakture";
            this.btnDodajFakture.UseVisualStyleBackColor = true;
            this.btnDodajFakture.Click += new System.EventHandler(this.btnDodajFakture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Numer Faktury";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Data Wystawienia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rodzaj Faktury";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(488, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Usługa";
            // 
            // tbUsluga
            // 
            this.tbUsluga.Location = new System.Drawing.Point(487, 318);
            this.tbUsluga.Name = "tbUsluga";
            this.tbUsluga.Size = new System.Drawing.Size(191, 22);
            this.tbUsluga.TabIndex = 9;
            // 
            // numIlosc
            // 
            this.numIlosc.Location = new System.Drawing.Point(702, 319);
            this.numIlosc.Name = "numIlosc";
            this.numIlosc.Size = new System.Drawing.Size(82, 22);
            this.numIlosc.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(703, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ilość";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(488, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Cena Netto";
            // 
            // tbCenaNetto
            // 
            this.tbCenaNetto.Location = new System.Drawing.Point(487, 375);
            this.tbCenaNetto.Name = "tbCenaNetto";
            this.tbCenaNetto.Size = new System.Drawing.Size(191, 22);
            this.tbCenaNetto.TabIndex = 13;
            this.tbCenaNetto.TextChanged += new System.EventHandler(this.tbCenaNetto_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(693, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Stawka VAT";
            // 
            // tbVat
            // 
            this.tbVat.Location = new System.Drawing.Point(697, 373);
            this.tbVat.Name = "tbVat";
            this.tbVat.Size = new System.Drawing.Size(87, 22);
            this.tbVat.TabIndex = 15;
            this.tbVat.TextChanged += new System.EventHandler(this.tbVat_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(488, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Cena Brutto";
            // 
            // tbCenaBrutto
            // 
            this.tbCenaBrutto.Enabled = false;
            this.tbCenaBrutto.Location = new System.Drawing.Point(487, 426);
            this.tbCenaBrutto.Name = "tbCenaBrutto";
            this.tbCenaBrutto.ReadOnly = true;
            this.tbCenaBrutto.Size = new System.Drawing.Size(191, 22);
            this.tbCenaBrutto.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(487, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Dodaj Pozycje";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEdytujFakture
            // 
            this.btnEdytujFakture.Location = new System.Drawing.Point(114, 465);
            this.btnEdytujFakture.Name = "btnEdytujFakture";
            this.btnEdytujFakture.Size = new System.Drawing.Size(100, 23);
            this.btnEdytujFakture.TabIndex = 20;
            this.btnEdytujFakture.Text = "Edytuj Fakture";
            this.btnEdytujFakture.UseVisualStyleBackColor = true;
            this.btnEdytujFakture.Click += new System.EventHandler(this.btnEdytujFakture_Click);
            // 
            // btnEdytujPozycje
            // 
            this.btnEdytujPozycje.Location = new System.Drawing.Point(664, 465);
            this.btnEdytujPozycje.Name = "btnEdytujPozycje";
            this.btnEdytujPozycje.Size = new System.Drawing.Size(120, 23);
            this.btnEdytujPozycje.TabIndex = 21;
            this.btnEdytujPozycje.Text = "Edytuj Pozycje";
            this.btnEdytujPozycje.UseVisualStyleBackColor = true;
            this.btnEdytujPozycje.Click += new System.EventHandler(this.btnEdytujPozycje_Click);
            // 
            // btnUsunFakture
            // 
            this.btnUsunFakture.Location = new System.Drawing.Point(220, 465);
            this.btnUsunFakture.Name = "btnUsunFakture";
            this.btnUsunFakture.Size = new System.Drawing.Size(94, 23);
            this.btnUsunFakture.TabIndex = 22;
            this.btnUsunFakture.Text = "Usuń Fakture";
            this.btnUsunFakture.UseVisualStyleBackColor = true;
            this.btnUsunFakture.Click += new System.EventHandler(this.btnUsunFakture_Click);
            // 
            // btnUsunPozycje
            // 
            this.btnUsunPozycje.Location = new System.Drawing.Point(585, 494);
            this.btnUsunPozycje.Name = "btnUsunPozycje";
            this.btnUsunPozycje.Size = new System.Drawing.Size(112, 23);
            this.btnUsunPozycje.TabIndex = 23;
            this.btnUsunPozycje.Text = "Usuń Pozycje";
            this.btnUsunPozycje.UseVisualStyleBackColor = true;
            this.btnUsunPozycje.Click += new System.EventHandler(this.btnUsunPozycje_Click);
            // 
            // tbSzukanaFaktura
            // 
            this.tbSzukanaFaktura.Location = new System.Drawing.Point(220, 12);
            this.tbSzukanaFaktura.Name = "tbSzukanaFaktura";
            this.tbSzukanaFaktura.Size = new System.Drawing.Size(141, 22);
            this.tbSzukanaFaktura.TabIndex = 24;
            this.tbSzukanaFaktura.TextChanged += new System.EventHandler(this.tbSzukanaFaktura_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Filtrowanie faktur";
            // 
            // dtpOd
            // 
            this.dtpOd.Checked = false;
            this.dtpOd.Location = new System.Drawing.Point(378, 12);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.ShowCheckBox = true;
            this.dtpOd.Size = new System.Drawing.Size(200, 22);
            this.dtpOd.TabIndex = 26;
            this.dtpOd.ValueChanged += new System.EventHandler(this.dtpOd_ValueChanged);
            // 
            // dtpDo
            // 
            this.dtpDo.Checked = false;
            this.dtpDo.Location = new System.Drawing.Point(584, 13);
            this.dtpDo.Name = "dtpDo";
            this.dtpDo.ShowCheckBox = true;
            this.dtpDo.Size = new System.Drawing.Size(200, 22);
            this.dtpDo.TabIndex = 27;
            this.dtpDo.ValueChanged += new System.EventHandler(this.dtpDo_ValueChanged);
            // 
            // chbAktywne
            // 
            this.chbAktywne.AutoSize = true;
            this.chbAktywne.Checked = true;
            this.chbAktywne.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAktywne.Location = new System.Drawing.Point(121, 12);
            this.chbAktywne.Name = "chbAktywne";
            this.chbAktywne.Size = new System.Drawing.Size(79, 20);
            this.chbAktywne.TabIndex = 28;
            this.chbAktywne.Text = "Aktywne";
            this.chbAktywne.UseVisualStyleBackColor = true;
            this.chbAktywne.CheckedChanged += new System.EventHandler(this.chbAktywne_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.chbAktywne);
            this.Controls.Add(this.dtpDo);
            this.Controls.Add(this.dtpOd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbSzukanaFaktura);
            this.Controls.Add(this.btnUsunPozycje);
            this.Controls.Add(this.btnUsunFakture);
            this.Controls.Add(this.btnEdytujPozycje);
            this.Controls.Add(this.btnEdytujFakture);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbCenaBrutto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbVat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbCenaNetto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numIlosc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUsluga);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDodajFakture);
            this.Controls.Add(this.cmbRodzajFaktury);
            this.Controls.Add(this.dtpDataFaktury);
            this.Controls.Add(this.tbNumerFaktury);
            this.Controls.Add(this.dgvPozycje);
            this.Controls.Add(this.dgvFaktury);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaktury)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPozycje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIlosc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFaktury;
        private System.Windows.Forms.DataGridView dgvPozycje;
        private System.Windows.Forms.TextBox tbNumerFaktury;
        private System.Windows.Forms.DateTimePicker dtpDataFaktury;
        private System.Windows.Forms.ComboBox cmbRodzajFaktury;
        private System.Windows.Forms.Button btnDodajFakture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUsluga;
        private System.Windows.Forms.NumericUpDown numIlosc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCenaNetto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbVat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCenaBrutto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEdytujFakture;
        private System.Windows.Forms.Button btnEdytujPozycje;
        private System.Windows.Forms.Button btnUsunFakture;
        private System.Windows.Forms.Button btnUsunPozycje;
        private System.Windows.Forms.TextBox tbSzukanaFaktura;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpOd;
        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.CheckBox chbAktywne;
    }
}

