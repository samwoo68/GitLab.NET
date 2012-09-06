using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GitLab.NET.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
          
            var conn = new GitLabConnection(new Uri("http://securityvision.ch:8010"), new Token(txtToken.Text));
            //conn.TestJsonProjects();
            AsyncQuery();
        } 

        private async void AsyncQuery()
        {
            var conn = new GitLabConnection(new Uri("http://securityvision.ch:8010"), new Token(txtToken.Text));

            var sb = new StringBuilder();

            foreach (var project in await conn.FetchAllProjects())
            {
                sb.AppendLine(project.ToString());
            }

            txtResponse.Text = sb.ToString();
        }
    }
}
