using System.Windows.Input;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace WpfWordQA
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Collection<IQA> _qas = new Collection<IQA>();
        
        public MainWindow()
        {
            InitializeComponent();
        }
            private void writeQAsToJSON(Collection<IQA> qas)
            {
                string JsonPath = @"C:\QA\qas.json";
                string Json = JsonConvert.SerializeObject(qas);
                FileStream jsonFileStream = new FileStream(JsonPath, FileMode.Create);

                StreamWriter jsonStreamWriter = new StreamWriter(jsonFileStream);
                jsonStreamWriter.Write(Json);
                jsonStreamWriter.Close();
                jsonFileStream.Close();
            }
            
        private void AddQAButton_OnClick(object sender, RoutedEventArgs e)
        {
            QA qa = new QA(Question.Text, Answer.Text);
            _qas.Add(qa);
            writeQAsToJSON(_qas);
            Question.Text = Answer.Text ="";
        }
    }
}