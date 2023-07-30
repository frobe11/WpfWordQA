using System.Collections.Generic;
using System.Windows;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace WpfWordQA
{
    public partial class RequestAnswerWindow : Window
    {
        
        private List<QA> _qas;

        public RequestAnswerWindow()
        {
            InitializeComponent();
        }
        
        private void readQAsFromJSON()
        {
            string JsonPath = @"C:\QA\qas.json";
            string Json;
            
            FileStream jsonFileStream = new FileStream(JsonPath, FileMode.OpenOrCreate);
            StreamReader jsonStreamReader = new StreamReader(jsonFileStream);
            Json = jsonStreamReader.ReadToEnd().ToString();
            jsonStreamReader.Close();
            jsonFileStream.Close();
            _qas = JsonConvert.DeserializeObject<List<QA>>(Json);
        }


        private void FindButton_OnClick(object sender, RoutedEventArgs e)
        {
            bool correct = false;
            readQAsFromJSON();
            foreach (var i in _qas)
            {
                if (i.Q == RequestTb.Text)
                {
                    correct = true;
                    answerTbl.Text = i.A;
                }   
            }

            if (!correct)
            {
                answerTbl.Text = "не найдено";
            }
        }

        private void ChangeWindow_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow s = new MainWindow();
            s.Show();
        }
    }
}