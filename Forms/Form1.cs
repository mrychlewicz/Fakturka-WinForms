using Fakturka.Models;
using Fakturka.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fakturka
{
    public partial class Form1 : Form
    {
        private static bool czyAktualizacjaFaktury = false;
        private static bool czyAktualizacjaPozycji = false;
        private static int idFakturyAktualizacja;
        private static int idPozycjiAktualizacja;
        Font pogrubionaCzcionka, zwyklaCzcionka;
        private static int czyAktywne = 1;
        public Form1()
        {
            InitializeComponent();
            var bazowaCzcionka = dgvFaktury.DefaultCellStyle.Font;
            zwyklaCzcionka = bazowaCzcionka;
            pogrubionaCzcionka = new Font(bazowaCzcionka, FontStyle.Bold);
        }


        private void WyczyscFormularzFaktura()
        {
            tbNumerFaktury.Text = "";
            dtpDataFaktury.Value = DateTime.Today;
            cmbRodzajFaktury.SelectedIndex = -1;
        }

        private void WyczyscFormularzPozycjeFaktura()
        {
            tbUsluga.Text = "";
            numIlosc.Value = 0;
            tbCenaBrutto.Text = "";
            tbCenaNetto.Text = "";
            tbVat.Text = "0,23";
        }

        private void ZaladujPozycjeFaktury(int idFaktury)
        {
         FakturaPozycjeRepository fpr = new FakturaPozycjeRepository();
         var pozycje = fpr.PobierzPozycjeFaktury(idFaktury);

         if (pozycje != null)
         {
                dgvPozycje.DataSource = pozycje;
                dgvPozycje.Columns["IdPozycji"].Visible = false;
                dgvPozycje.Columns["IdFaktury"].Visible = false;
                dgvPozycje.Columns["Usluga"].HeaderText = "Usługa";
                dgvPozycje.Columns["Ilosc"].HeaderText = "Ilość";
                dgvPozycje.Columns["KwotaNetto"].HeaderText = "Kwota Netto";
                dgvPozycje.Columns["StawkaVat"].HeaderText = "Stawka VAT";
                dgvPozycje.Columns["KwotaBrutto"].HeaderText = "Kwota Brutto";
         }
            
        }
        private void ZaladujFaktury()
        {
            var fraza = tbSzukanaFaktura.Text;
            FakturaRepository fr = new FakturaRepository();
            DateTime dataOd, dataDo;
            if(dtpOd.Value.Date > dtpDo.Value.Date)
            {
                MessageBox.Show("Próbujesz filtrować poza zakresem dat");
                return;
            }
            if (dtpOd.Checked)
            {
                dataOd = dtpOd.Value.Date;
            }
            else
            {
                dataOd = dtpOd.MinDate;
            }
            if(dtpDo.Checked)
            {
                dataDo = dtpDo.Value.Date.AddDays(1).AddSeconds(-1);
            }
            else
            {
                dataDo = dtpDo.MaxDate;
            }
            var faktury = fr.PobierzFaktury(fraza, dataOd, dataDo, czyAktywne);

            if (faktury != null)
            {
                dgvFaktury.DataSource = faktury;
                dgvFaktury.Columns["IdFaktury"].Visible = false;
                dgvFaktury.Columns["NumerFaktury"].HeaderText = "Numer Faktury";
                dgvFaktury.Columns["DataWystawienia"].HeaderText = "Data Wystawienia";
                dgvFaktury.Columns["DataWystawienia"].DefaultCellStyle.Format = "D";
                dgvFaktury.Columns["RodzajFaktury"].HeaderText = "Rodzaj Faktury";
                dgvFaktury.Columns["KwotaNetto"].HeaderText = "Kwota Netto";
                dgvFaktury.Columns["KwotaNetto"].DefaultCellStyle.Format = "c2";
                dgvFaktury.Columns["CzyAktywna"].Visible = false;
            }
        }

        private void CalculateBrutto()
        {
            if (!String.IsNullOrWhiteSpace(tbCenaNetto.Text) && !String.IsNullOrWhiteSpace(tbVat.Text))
            {
                if (decimal.TryParse(tbCenaNetto.Text, out decimal netto) && decimal.TryParse(tbVat.Text, out decimal vat))
                {

                    var brutto = netto + (netto * vat);
                    tbCenaBrutto.Text = brutto.ToString("N2");

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ZaladujFaktury();
            tbVat.Text = "0,23";
        }

        private void tbCenaNetto_TextChanged(object sender, EventArgs e)
        {
            CalculateBrutto();
        }

        private void tbVat_TextChanged(object sender, EventArgs e)
        {
            CalculateBrutto();
        }

        private void btnDodajFakture_Click(object sender, EventArgs e)
        {
            var numer = tbNumerFaktury.Text;
            var data = dtpDataFaktury.Value;
            var rodzaj = cmbRodzajFaktury.SelectedItem.ToString();

            try
            {
                if (czyAktualizacjaFaktury == false)
                {
                    Faktura faktura = new Faktura()
                    {
                        NumerFaktury = numer,
                        DataWystawienia = data,
                        RodzajFaktury = rodzaj
                    };

                    FakturaRepository fr = new FakturaRepository();
                    fr.DodajFakture(faktura);
                    ZaladujFaktury();
                    MessageBox.Show($"Pomyślnie dodano fakturę: {numer}");
                    WyczyscFormularzFaktura();
                }
                else if (czyAktualizacjaFaktury == true)
                {

                    Faktura faktura = new Faktura()
                    {
                        IdFaktury = idFakturyAktualizacja,
                        NumerFaktury = numer,
                        DataWystawienia = data,
                        RodzajFaktury = rodzaj
                    };

                    FakturaRepository fr = new FakturaRepository();
                    fr.EdytujFakture(faktura);
                    ZaladujFaktury();
                    MessageBox.Show($"Pomyślnie edytowano fakturę: {numer}");
                    WyczyscFormularzFaktura();
                    btnDodajFakture.Text = "Dodaj Fakture";
                    czyAktualizacjaFaktury = false;
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Błąd formatu, popraw dane!");
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException oe)
            {
                MessageBox.Show($"Błąd połączenia z bazą danych! \n{oe.Number} \n{oe.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyjątek w programie: {ex.Message}");
            }
        }

        private void dgvFaktury_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var wiersz = dgvFaktury.Rows[e.RowIndex];
            var idFaktury = Convert.ToInt32(wiersz.Cells["IdFaktury"].Value);

            ZaladujPozycjeFaktury(idFaktury);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvFaktury.SelectedRows.Count > 0)
            {
                var wiersz = dgvFaktury.SelectedRows[0];
                var idFaktury = Convert.ToInt32(wiersz.Cells["IdFaktury"].Value);
                var usluga = tbUsluga.Text;
                var netto = Convert.ToDecimal(tbCenaNetto.Text);
                var ilosc = Convert.ToInt32(numIlosc.Value);
                var brutto = Convert.ToDecimal(tbCenaBrutto.Text);
                var vat = Convert.ToDecimal(tbVat.Text);

                try
                {
                    if (czyAktualizacjaPozycji == false)
                    {
                        FakturaPozycje fp = new FakturaPozycje()
                        {
                            IdFaktury = idFaktury,
                            Usluga = usluga,
                            Ilosc = ilosc,
                            KwotaNetto = netto,
                            KwotaBrutto = brutto,
                            StawkaVat = vat,
                        };

                        FakturaPozycjeRepository fpr = new FakturaPozycjeRepository();
                        fpr.DodajPozycjeFaktury(fp);
                        ZaladujPozycjeFaktury(idFaktury);
                        MessageBox.Show("Pomyślnie dodane pozycję dla faktury!");
                        WyczyscFormularzPozycjeFaktura();
                        ZaladujFaktury();
                    }
                    else if(czyAktualizacjaPozycji == true)
                    {
                        FakturaPozycje fp = new FakturaPozycje()
                        {
                            IdPozycji = idPozycjiAktualizacja,
                            IdFaktury = idFakturyAktualizacja,
                            Usluga = usluga,
                            Ilosc = ilosc,
                            KwotaNetto = netto,
                            KwotaBrutto = brutto,
                            StawkaVat = vat,
                        };

                        FakturaPozycjeRepository fpr = new FakturaPozycjeRepository();
                        fpr.EdytujPozycjeFaktury(fp);
                        ZaladujPozycjeFaktury(idFakturyAktualizacja);
                        MessageBox.Show("Pomyślnie zaktualizowana pozycję dla faktury!");
                        WyczyscFormularzPozycjeFaktura();
                        button1.Text = "Dodaj Pozycje";
                        czyAktualizacjaPozycji = false;
                        ZaladujFaktury();
                    }
                }
                catch (FormatException fex)
                {
                    MessageBox.Show("Błąd formatu, popraw dane!");
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException oe)
                {
                    MessageBox.Show($"Błąd połączenia z bazą danych! \n{oe.Number} \n{oe.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wychwycono wyjątek {ex.Message}");
                }
            }
        }

        private void btnEdytujFakture_Click(object sender, EventArgs e)
        {
            if(dgvFaktury.SelectedRows.Count > 0)
            {
                var wiersz = dgvFaktury.SelectedRows[0];
                idFakturyAktualizacja = Convert.ToInt32(wiersz.Cells["IdFaktury"].Value);
                var numerFaktury = wiersz.Cells["NumerFaktury"].Value.ToString();
                var dataWystawienia = Convert.ToDateTime(wiersz.Cells["DataWystawienia"].Value);
                var rodzajFaktury = wiersz.Cells["RodzajFaktury"].Value.ToString();

                tbNumerFaktury.Text = numerFaktury;
                dtpDataFaktury.Value = dataWystawienia;
                cmbRodzajFaktury.SelectedItem = rodzajFaktury;
                btnDodajFakture.Text = "Zaktualizuj dane";
                czyAktualizacjaFaktury = true;
            }
        }

        private void btnEdytujPozycje_Click(object sender, EventArgs e)
        {
            if(dgvPozycje.SelectedRows.Count > 0)
            {
                var wiersz = dgvPozycje.SelectedRows[0];
                idFakturyAktualizacja = Convert.ToInt32(wiersz.Cells["IdFaktury"].Value);
                idPozycjiAktualizacja = Convert.ToInt32(wiersz.Cells["IdPozycji"].Value);
                var usluga = wiersz.Cells["Usluga"].Value.ToString();
                var ilosc = Convert.ToInt32(wiersz.Cells["Ilosc"].Value);
                var netto = wiersz.Cells["KwotaNetto"].Value.ToString();
                var brutto = wiersz.Cells["KwotaBrutto"].Value.ToString();
                var vat = wiersz.Cells["StawkaVat"].Value.ToString();

                tbUsluga.Text = usluga;
                numIlosc.Value = ilosc;
                tbCenaBrutto.Text = brutto;
                tbCenaNetto.Text = netto;
                tbVat.Text = vat;
                czyAktualizacjaPozycji = true;
                button1.Text = "Aktualizuj Pozycje";
            }
        }

        private void btnUsunFakture_Click(object sender, EventArgs e)
        {
            if(dgvFaktury.SelectedRows.Count > 0)
            {
                var wiersz = dgvFaktury.SelectedRows[0];
                DialogResult result =  MessageBox.Show(
                    $"Czy na pewno chcesz usunąć fakturę {wiersz.Cells["NumerFaktury"].Value}?",
                    "Usuwanie faktury",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var idFaktury = Convert.ToInt32(wiersz.Cells["IdFaktury"].Value);
                    FakturaRepository fr = new FakturaRepository();
                    fr.UsunFakture(idFaktury);
                    ZaladujFaktury();
                }
            }
        }

        private void btnUsunPozycje_Click(object sender, EventArgs e)
        {
            if(dgvPozycje.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Czy na pewno chcesz usunąć pozycję",
                    "Usuwanie pozycji",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var wiersz = dgvPozycje.SelectedRows[0];
                    var idPozycji = Convert.ToInt32(wiersz.Cells["IdPozycji"].Value);
                    var idFaktury = Convert.ToInt32(wiersz.Cells["IdFaktury"].Value);

                    FakturaPozycjeRepository fpr = new FakturaPozycjeRepository();
                    fpr.UsunPozycjeFaktury(idPozycji);
                    ZaladujPozycjeFaktury(idFaktury);
                }
            }
        }

        private void tbSzukanaFaktura_TextChanged(object sender, EventArgs e)
        {
            ZaladujFaktury();
        }

        private void dtpOd_ValueChanged(object sender, EventArgs e)
        {
            ZaladujFaktury();
        }

        private void dtpDo_ValueChanged(object sender, EventArgs e)
        {
            ZaladujFaktury();
        }

        private void chbAktywne_CheckedChanged(object sender, EventArgs e)
        {
            if(chbAktywne.Checked == true)
            {
                czyAktywne = 1;
            }
            else if(chbAktywne.Checked == false)
            {
                czyAktywne = 0;
            }
            ZaladujFaktury();
        }

        private void dgvFaktury_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var wiersz = dgvFaktury.Rows[e.RowIndex];
            if(wiersz.IsNewRow)
            {
                return;
            }
            decimal netto;
            int aktywna;
            decimal.TryParse(Convert.ToString(wiersz.Cells["KwotaNetto"].Value),out netto);
            int.TryParse(Convert.ToString(wiersz.Cells["CzyAktywna"].Value), out aktywna);

            if (netto > 1000)
            {
                e.CellStyle.Font = pogrubionaCzcionka;
            }
            else if(netto <= 1000)
            {
                e.CellStyle.Font = zwyklaCzcionka;
            }
            if(aktywna == 0)
            {
                e.CellStyle.BackColor = Color.Gray;
            }
        }
    }
}
