using System;
using System.Collections.Generic; ///kövi felevben fog kelleni
using System.Linq; //nem szabad filekezelesnel hazsnalni
using System.Text;
using System.Threading.Tasks;
using System.IO; //filekezeleshez kell

namespace FaljKezeles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Mappakezelés
            Directory.CreateDirectory(@"C:\MyFolder\MyFirstFolder");
            Directory.CreateDirectory(@"C:\\MyFolder\\MySecondFolder"); //ugyan az csak
            string[] allFolders = Directory.GetDirectories(@"C:\MyFolder"); //kis c vel is mukodik
            foreach (string folder in allFolders)
            {
                Console.WriteLine(folder);
            }
            string folderDelete = "C:\\MyFolder";
            //mivel nem üres bennelévőket is törli
            if (Directory.Exists(folderDelete))
            {
                //létezik vagy sem 
                Directory.Delete(folderDelete, true);
                //ha igen törlje
            }
            #endregion
            #region fáljok
            // Directory.CreateDirectory(@"C:\SourceFolder");
            // Directory.CreateDirectory(@"C:\\TargetFolder");
            // string original = @"C:\SourceFolder\mySource.txt";
            // string copy = @"C:\TargetFolder\myTarget.txt";
            // File.Copy(original, copy);  --csak egyszr szabad futtatni
            // if (File.Exists(original)) { File.Delete(original); }
            // File.Move(copy, original);
            #endregion
            #region fálj irása
            string fileName = (@"C:\Users\Asus\Dokumentumok\bevprog.txt");
            StreamWriter fileWriting = new StreamWriter(fileName, false, Encoding.Unicode);
            fileWriting.WriteLine("Mócza Szilvia");
            fileWriting.Close(); //fontos bezárni
            #endregion
            #region fálj olvasás
            StreamReader fileReading = new StreamReader(fileName, Encoding.Unicode);
            string text;
            while (!fileReading.EndOfStream) {
                text = fileReading.ReadLine();
                Console.WriteLine("Beolvasott szöveg: " + text);
                    }
            fileReading.Close();
            //nem lehet hozzáírni
            #endregion
            #region hozzáírás
            
            StreamWriter appendTetx = new StreamWriter(fileName, true, Encoding.Unicode);
            appendTetx.WriteLine("hozzáírás");
            appendTetx.Close();
            #endregion
            #region Fálj olvasás, írás röviden
            string path = "Mytext.txt";
            if (!File.Exists(path)) {

                string createText = "Első szöveg" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }
            string appendTXT = " EZ EGY HOZZÁÍRT SZÖVEG \n";
            File.AppendAllText(path, appendTXT);
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
            #endregion
            #region tömbök és fáljlok
            fileName = "tömb.txt";
            string[] lines = { "alma", "körte", "barack" };
            File.AppendAllLines(fileName, lines);
            string[] readedArray = File.ReadAllLines(fileName);
            for (int i = 0; i < readedArray.Length; i++)
            {
                Console.WriteLine(readedArray[i]);
            }

            #endregion
            // a binbe a debugban vannak azek a txt fileok aminek nem adunk utvonalat
            //FUTTATÁSOKRA FIGYELNI KELL +++

        }
    }
}