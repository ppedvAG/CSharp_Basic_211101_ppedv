﻿using Fahrzeugpark;
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

namespace FahrzeugGUI
{
    public partial class Wnd_FahrzeugVerwaltung : Form
    {
        //Liste zum Speichern der erstellten Fahrzeuge
        public List<Fahrzeug> Fahrzeugliste { get; set; }

        //Konstruktor zur Initalisierung des Fensters
        public Wnd_FahrzeugVerwaltung()
        {
            //Erstellung der im Designer definierten Elemente
            InitializeComponent();
            //Initialisierung der Liste
            this.Fahrzeugliste = new List<Fahrzeug>();
        }

        #region EventHandler-Methoden

        //Event-Handler für das Click-Event des Menüeintrags 'Beenden'
        private void MeI_Beenden_Click(object sender, EventArgs e)
        {
            //Nachfrage per MessageBox
            string dialogText = "Möchtest du wirklich beenden?\nNicht gespeicherte Änderungen werden verworfen.";
            DialogResult result = MessageBox.Show(dialogText, "Programm schließen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //Testen des in MessageBox geklickten Buttons
            if (result == DialogResult.Yes)
                //Schließen des Fensters
                this.Close();
        }

        //Events-Handler des 'Neu'-Buttons
        private void Btn_Neu_Click(object sender, EventArgs e)
        {
            //Erstellen eines neuen Fahrzeuges und Einfügen in die Liste
            this.Fahrzeugliste.Add(this.GeneriereFahrzeug());
            //Aktualisierung der ListBox
            this.UpdateGui();
        }

        //Event-Handler des 'Löschen'-Buttons
        private void Btn_Löschen_Click(object sender, EventArgs e)
        {
            //Prüfung, ob ein Eintrag ausgewählt ist
            if (Lbx_Fahrzeuge.SelectedItem != null)
                //Löschen des in der ListBox markierten Items aus der Personenliste
                LöscheFz(Lbx_Fahrzeuge.SelectedItem as Fahrzeug);

            //Aktualisierung der ListBox
            UpdateGui();
        }

        //EventHandler der ListBox (bei Auswahl-Veränderung)
        private void Lbx_Fahrzeuge_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Prüfun, ob eine Auswahl in ListBox besteht
            if (Lbx_Fahrzeuge.SelectedItem != null)
                //Anzeige der Info()-Methode in Label
                Lbl_Info.Text = (Lbx_Fahrzeuge.SelectedItem as Fahrzeug).Info();
        }
        #endregion

        #region zusätzliche Methoden

        //Methode zum Löschen von Fahrzeugen
        private void LöscheFz(Fahrzeug fz)
        {
            Fahrzeugliste.Remove(fz);
        }

        //Methode zur Synchronisation von ListBox.Items und Fahrzeugliste
        private void UpdateGui()
        {
            //Löschend des ListBox-Inhalts
            this.Lbx_Fahrzeuge.Items.Clear();

            //Neubefüllung der ListBox anhand der Liste
            foreach (var item in this.Fahrzeugliste)
            {
                this.Lbx_Fahrzeuge.Items.Add(item);
            }
        }

        //Methode zur zufälligen Generierung von Fahrzeugen
        private Random random = new Random();
        private Fahrzeug GeneriereFahrzeug()
        {
            switch (this.random.Next(1, 4))
            {
                case 1:
                    return PKW.ErzeugeZufälligenPKW("");
                case 2:
                    return new Schiff("Titanic", 40, 25000000, Schiff.SchiffsTreibstoff.Dampf);
                default:
                    return new Flugzeug("Boing", 350, 90000000, 9800);
            }
        } 
        #endregion

        #region Lab 15: Speichern und Laden

        private void Btn_LadeFz_Click(object sender, EventArgs e)
        {
            Fahrzeugliste = LadeFz();

            UpdateGui();
        }

        private void Btn_SpeicherFz_Click(object sender, EventArgs e)
        {
            SpeicherFz(this.Fahrzeugliste);
        }

        private List<Fahrzeug> LadeFz()
        {
            List<Fahrzeug> fzList = new List<Fahrzeug>();

            //Erstellen eines JsonSerialiserSetting-Objekt zur Spezifizierung der Serialisierung
            JsonSerializerSettings settings = new JsonSerializerSettings();
            //TypeNameHandling markiert die Json-Zeilen mit dem entsprechenden Objekt-Typ (z.B. PKW, Flugzeug, Schiff)
            settings.TypeNameHandling = TypeNameHandling.Objects;

            //Aubruf des Dateipfads
            string pfad = GetPfadViaDialog();

            //Prüfun, ob Dateipfad vorhanden ist
            if (!String.IsNullOrEmpty(pfad))
            {
                try
                {
                    //Etablierung eines StreamReaders per using-Statement
                    using (StreamReader reader = new StreamReader(pfad))
                    {
                        while (!reader.EndOfStream)
                        {
                            //Lesen einer Textzeile aus der Datei
                            string fzAlsString = reader.ReadLine();
                            //Umwandlung der Textzeile in ein Fahrzeug (Beachte die Übergabe des Settings-Objekts)
                            Fahrzeug fz = JsonConvert.DeserializeObject<Fahrzeug>(fzAlsString, settings);
                            //Hinzufügen des Fahrzeugs zur Liste
                            fzList.Add(fz);
                        }
                        //Erfolgsmeldung
                        MessageBox.Show("Laden erfolgreich");
                        //Rückgabe der geladenen Liste
                        return fzList;
                    }
                }
                catch (Exception ex)
                {
                    //Misserfolgsmeldung
                    MessageBox.Show("Laden fehlgeschlagen. " + ex.Message);
                }
            }
            //Rückgabe der 'alten' Liste, im Fehlerfall oder wenn kein Pfad ausgewählt wurde
            return this.Fahrzeugliste;
        }

        private void SpeicherFz(List<Fahrzeug> fahrzeugliste)
        {
            //Erstellen der Json-Settings
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;

            //Erfragen des Dateipfads
            string pfad = GetPfadViaDialog(true);

            //Prüfung, ob Pfad vorhanden ist
            if (!String.IsNullOrEmpty(pfad))
            {
                try
                {
                    //Etablierung eines StreamWriters per using-Anweisung
                    using (StreamWriter writer = new StreamWriter(pfad))
                    {
                        //Schleife über die Fahrzeugliste
                        for (int i = 0; i < fahrzeugliste.Count; i++)
                        {
                            //Serialisierung der Fahrzeuge
                            string fzAlsString = JsonConvert.SerializeObject(fahrzeugliste[i], settings);
                            //Speichern des Strings
                            writer.WriteLine(fzAlsString);
                        }

                        //Erfolgsmeldung
                        MessageBox.Show("Speichern erfolgreich");
                    }
                }
                catch (Exception ex)
                {
                    //Misserfolgsmeldung
                    MessageBox.Show("Speichern fehlgeschlagen. " + ex.Message);
                }
            }
        }

        private string GetPfadViaDialog(bool speichern = false)
        {
            //vorgeschlagener Standartdateiname
            string fileName = "Fahrzeuge.txt";
            //Bsp-Übergabe des Windows-Arbeitsplatzes als GUID
            string initialDirectory = "::{20d04fe0-3aea-1069-a2d8-08002b30309d}";
            //Mögliche Dateiformate
            string filter = "Textdatei|*.txt|Fahrzeugdatei|*.fz|Alle Dateien|*.*";

            //Deklaration einer allgemeinen FileDialog-Variablen
            FileDialog dialog;

            //Initialisierung gemäß Situation
            if (speichern)
                dialog = new SaveFileDialog();
            else
                dialog = new OpenFileDialog();

            //Übertrag der Propertiy-Werte
            dialog.FileName = fileName;
            dialog.InitialDirectory = initialDirectory;
            dialog.Filter = filter;

            //Ausführung des Dialogs und Prüfung, ob auf 'Ok' geklickt wurde
            if (dialog.ShowDialog() == DialogResult.OK)
                //'Ok'-Klick gibt gewählten Dateinamen zurück
                return dialog.FileName;
            else
                //'Abbruch'-Klick gibt leeren String zurück
                return "";
        } 

        #endregion
    }
}
