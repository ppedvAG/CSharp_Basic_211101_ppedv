using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dateien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.FileName = "datei.txt";

            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveDialog.InitialDirectory = "::{20d04fe0-3aea-1069-a2d8-08002b30309d}";

            saveDialog.Filter = "Textdatei|*.txt|Stringdatei|*.string|Alle Dateien|*.*";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {

                StreamWriter writer = null;

                try
                {
                    writer = new StreamWriter(saveDialog.FileName);

                    writer.WriteLine(Tbx_Input.Text);

                    writer.WriteLine("Ende des Texts");

                    MessageBox.Show("Speichern erfolgreich");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Speichern fehlgeschlagen " + ex.Message);
                }
                finally
                {
                    //if (writer != null)

                    writer?.Close();
                }

            }
        }

        private void Btn_Load_Click(object sender, EventArgs e)
        {

            try
            {
                using (StreamReader reader = new StreamReader(@"datei.txt"))
                {
                    Tbx_Input.Clear();

                    while (!reader.EndOfStream)
                    {
                        Tbx_Input.Text += reader.ReadLine() + Environment.NewLine;
                    }
                }

                MessageBox.Show("Laden erfolgreich");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Laden fehlgeschlagen " + ex.Message);
            }
        }

        private void Btn_SaveP_Click(object sender, EventArgs e)
        {
            List<Person> liste = new List<Person>();
            liste.Add(new Person() { Name = "Anna", Alter = 45 });
            liste.Add(new Arbeitnehmer() { Name = "Hugo", Alter = 23, Abteilung = "Marketing" });

            StreamWriter writer = null;

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;

            try
            {
                writer = new StreamWriter("personen.txt");

                for (int i = 0; i < liste.Count; i++)
                {
                    string jsonString = JsonConvert.SerializeObject(liste[i], settings);
                    writer.WriteLine(jsonString);
                }

                MessageBox.Show("Speichern erfolgreich");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Speichern fehlgeschlagen " + ex.Message);
            }
            finally
            {
                //if (writer != null)

                writer?.Close();
            }

        }

        private void Btn_LoadP_Click(object sender, EventArgs e)
        {
            StreamReader reader = null;

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;

            try
            {
                reader = new StreamReader("personen.txt");

                while (!reader.EndOfStream)
                {
                    Person person = JsonConvert.DeserializeObject<Person>(reader.ReadLine(), settings);
                    MessageBox.Show(person.ToString());
                }

                MessageBox.Show("Speichern erfolgreich");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Speichern fehlgeschlagen " + ex.Message);
            }
            finally
            {
                //if (writer != null)

                reader?.Close();
            }
        }
    }
}
