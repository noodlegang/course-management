using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SportsCoachingTimeManagement1
{
    /// <summary>
    /// Interaction logic for loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public loginWindow()
        {
            InitializeComponent();
            try
            {
                if (!(new FileInfo("info.json").Length == 0))
                {
                    loadFromFile();
                }
            }
            catch
            {
                labelMistake.Content = "Please help me";
            }
        }

        private void loadFromFile()
        {
            var col = JsonConvert.DeserializeObject<List<Course>>(File.ReadAllText(@"info.json"));
            foreach (var item in col)
            {
                timeSheet.Courses.Add(item);
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = "admin";
            var password = "1111";
            if (textUser.Text == "" || textpassword.Password == "")
            {
                labelMistake.Content = "Fields can't be empty";
            } else
            {
                
                if (textUser.Text == username && textpassword.Password == password)
                {
                    var w = new MainWindow();
                    w.Show();
                    Close();
                }
                else
                {

                    
                    labelMistake.Content = "Username or password incorrect";
                }
            }
            
        }

        private void buttonClickBleh_Click(object sender, RoutedEventArgs e)
        {
            var w = new clientWindow();
            w.Show();
            Close();
        }
    }
}
