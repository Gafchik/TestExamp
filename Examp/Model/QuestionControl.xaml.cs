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
using DapperLib;

namespace Examp
{
    /// <summary>
    /// Логика взаимодействия для QuestionControl.xaml
    /// </summary>
    public partial class QuestionControl : UserControl
    {
     
        public List<Answer> _answers;
        public List<CheckBox> checks;
        public QuestionControl()
        {
            checks = new List<CheckBox>();
            InitializeComponent();
        }            
        public void SetAnswer(Question value)
        {
            _question.Text = value.Question_Text;

            _answers = Answer_Repository.Select().ToList().FindAll(i => i.Answer_Question_ID == value.Question_ID);
            for (int i = 0; i < _answers.Count; i++)
            {
                if (i != 0)
                    _grid.RowDefinitions.Add(new RowDefinition { Height= GridLength.Auto});
                CheckBox lb = new CheckBox { Content = _answers[i].Answer_Text };
                Grid.SetRow(lb, i+1);
                Grid.SetColumn(lb, 0);
                Grid.SetColumnSpan(lb, 3);
                // _grid.Children.Add(lb);
                checks.Add(lb);




            }
            checks.ForEach(i=> _grid.Children.Add(i));
        }
        public void Clear()
        {
            checks.Clear();
           /* for (int i = 0; i < _grid.Children.Count; i++)
            {
                if (_grid.Children[i] == _question)
                    continue;
                if (_grid.Children[i] is CheckBox)
                    _grid.Children.Remove(_grid.Children[i]);


            }*/

               _grid.RowDefinitions.Clear();
            _grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            _grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

           
        }

       

    }
}
