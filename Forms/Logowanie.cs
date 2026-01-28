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

namespace Fakturka.Forms
{
    public partial class Logowanie : Form
    {
        public Logowanie()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var username = tbUsername.Text;
            var password = tbPassword.Text;

            try
            {
                UsersRepository ur = new UsersRepository();
                button1.Enabled = false;
                Cursor = Cursors.WaitCursor;
                var wynik = await ur.czyIstnieje(username, password);

                if (wynik == true)
                {
                    DialogResult = DialogResult.OK;
                }
                else if (wynik == false)
                {
                    MessageBox.Show("Niepoprawne dane logowania! Spróbuj ponownie.");
                }
            }

            catch (FormatException fex)
            {
                MessageBox.Show("Błąd formatu! Popraw dane");
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException oe)
            {
                MessageBox.Show($"Błąd połączenia z bazą danych! \n{oe.Number} \n{oe.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bład programu {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
                button1.Enabled = true;
            }
        }
    }
}
