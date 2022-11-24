using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SportsCoachingTimeManagement1
{

    public partial class clientWindow : Window
    {
        public clientWindow()
        {
            InitializeComponent();
            foreach (var item in timeSheet.Courses)
            {
                listChoiceThing.Items.Add(item.courseId + ", " + item.sportType + ", Coach's name: " + item.coachName + " " + item.coachSurname + ", on " + item.courseDay +
                    " " + item.courseTime);
            }
        }

        private void buttonBuy_Click(object sender, RoutedEventArgs e)
        {
            var bleh = checkBox.IsChecked;
            if (bleh.Value)
            {
                if (textName.Text == "" || textCode1.Text == "" || textEmail1.Text == "" || listChoiceThing.SelectedItem == null)
                {
                    labelMistake.Content = "Text fields can't be empty and course must be choisen";
                } else
                {
                    if (textEmail1.Text.Contains("@")) {
                        double number;
                        bool success = double.TryParse(textCode1.Text, out number);
                        if (success) {
                            try
                            {
                                int n = (int)(number/100000);
                                int f = (int)(number%100000);
                                string code1 = n + "-" + f;
                                var holySmokes = listChoiceThing.Text + "; enrolled: " + textName.Text + ", " + code1 + ", " + textEmail1.Text;
                                string path = @"file.txt";
                                string createText = holySmokes + Environment.NewLine;
                                File.WriteAllText(path, createText);
                                string readText = File.ReadAllText(path);
                                labelMistake.Content = "Thank you!";
                            }
                            catch
                            {
                                labelMistake.Content = "CAN'T SAVE";
                            }
                        } else
                        {
                            labelMistake.Content = "Please, enter personal code only as numbers";
                        }
                        
                    } else
                    {
                        labelMistake.Content = "Email's format must be: text@text";
                    }
                }
                
            } else
            {
                labelMistake.Content = "You!! didn't!! agree!!";
            }
        }
    }
}
