using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace SportsCoachingTimeManagement1
{
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent(); 
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var name = textName.Text;
            var surname = textSurname.Text;
            var id = textID.Text;
            var type = textType.Text;
            var day = textDay.Text;
            var time = textTime.Text;
            try
            {
                var bleh = int.Parse(id);
                var item = new Course(day, type, name, bleh,  surname, time);
                timeSheet.Courses.Add(item);
                foreach (var i in timeSheet.Courses)
                {
                    listBox.Items.Add(i.courseId + ", " + i.sportType + ", Coach's name: " + i.coachName + " " + i.coachSurname);
                }
                labelClose.IsEnabled = true;
                textDay.Text = "";
                textID.Text = "";
                textTime.Text = "";
                textName.Text = "";
                textSurname.Text = "";
                textType.Text = "";
                saveToFile();
            } catch
            {

                labelMistake.Content = "Mistake???";
            }
        }


        private void saveToFile()
        {
            string json = JsonConvert.SerializeObject(timeSheet.Courses);
            try
            {
                string path = @"info.json";
                File.WriteAllText(path, json);
                labelMistake.Content = "";
            }
            catch
            {
                labelMistake.Content = "CAN'T SAVE";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var w = new clientWindow();
            w.Show();   
            Close();
        }
    }
}
