using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace FileRouge
{
    class EnrLireScores
    {
        public EnrLireScores()
        {
            //Création du fichier s'il n'existe pas
            if (!File.Exists("scores.xml"))
            {
                CreerFichierScores();
            }
        }

        private void CreerFichierScores()
        {
            FileStream myFileStream = new FileStream("scores.xml", FileMode.OpenOrCreate);

            XmlTextWriter myXmlTextWriter = new XmlTextWriter(myFileStream, System.Text.Encoding.UTF8);

            myXmlTextWriter.Formatting = Formatting.Indented;

            myXmlTextWriter.WriteStartDocument();

            myXmlTextWriter.WriteStartElement("Scores");
            myXmlTextWriter.WriteEndElement();

            myXmlTextWriter.Flush();
            myXmlTextWriter.Close();
        }

        public void AjouterScore(String nom, String score)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("scores.xml");
            XmlNode root = doc.DocumentElement;

            //Ajout d'un joueur
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "Joueur", null);
            //Ajout Nom
            XmlNode nodeNom = doc.CreateElement("Nom");
            nodeNom.InnerText = nom;
            node.AppendChild(nodeNom);
            //Ajout Score
            XmlNode nodeScore = doc.CreateElement("Score");
            nodeScore.InnerText = score;
            node.AppendChild(nodeScore);
            //Ajout Date
            XmlNode nodeDate = doc.CreateElement("Date");
            nodeDate.InnerText = DateTime.Now.ToString();
            node.AppendChild(nodeDate);
            
            doc.DocumentElement.AppendChild(node);

            doc.Save("scores.xml");
        }

        public List<Scores> RecupScores()
        {
            List<Scores> listDesScores = new List<Scores>();
            
            XmlDocument doc = new XmlDocument();
            doc.Load("scores.xml");

            XmlNodeList listNoms = doc.GetElementsByTagName("Nom");
            XmlNodeList listScores = doc.GetElementsByTagName("Score");
            XmlNodeList listDates = doc.GetElementsByTagName("Date");

            for (int i = 0; i < listNoms.Count; i++)
            {
                Scores score = new Scores();
                score.Nom = listNoms[i].InnerText;
                score.Score = int.Parse(listScores[i].InnerText);
                score.Date = listDates[i].InnerText;
                listDesScores.Add(score);
            }
            return listDesScores;
        }
    }
}
