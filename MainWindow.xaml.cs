using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFtaskList.SRC;


namespace WPFtaskList
{
    
    public partial class MainWindow : Window
    {
        public List<ToDo> toDoList = new List<ToDo>();
        public MainWindow()
        {
            InitializeComponent(); //прорисовка хмл
            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = DateTime.Today.AddDays(1);

            toDoList.Add(new ToDo("Родиться", new DateTime(2024, 01, 10), "Важно!")); //добавили в список дела
            toDoList.Add(new ToDo("Посадить сына", new DateTime(2024, 01, 11), "Важно!"));
            toDoList.Add(new ToDo("Построить дерево", new DateTime(2024, 01, 12), "Важно!"));
            toDoList.Add(new ToDo("Вырастить дом", new DateTime(2024, 01, 13), "Важно!"));
            toDoList.Add(new ToDo("Умереть", new DateTime(2024, 01, 14), "Важно!"));
            RefreshToDoList(); //обновили, чтобы список отобразился
            CheckBoxEnableToDo_UnChecked(Owner, new RoutedEventArgs()); //скрываем правую панель
        }

        private void RefreshToDoList() //обновляем список
        {
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = toDoList; 
        }

        private void CheckBoxEnableToDo_Checked(object sender, RoutedEventArgs e) //открывает правую панель при запуске
        {
            if (groupBoxToDo == null || buttonAdd == null) return; // WHY
            groupBoxToDo.Visibility = Visibility.Visible;
            buttonAdd.Visibility = Visibility.Visible;
        }

        private void CheckBoxEnableToDo_UnChecked(object sender, RoutedEventArgs e) //скрывает кнопку и скрывает GroupBox (правую панель)
        {
            if (groupBoxToDo != null || buttonAdd != null) return; //WHY
            groupBoxToDo.Visibility = Visibility.Hidden;
            buttonAdd.Visibility = Visibility.Hidden;
        }

        private void ButtonRemoveToDo_Click(object sender, RoutedEventArgs e) //удалили
        {
            toDoList.Remove(listToDo.SelectedItem as ToDo);
            RefreshToDoList();
        }

        private void ButtonAddToDo_Click(Object sender, RoutedEventArgs e) //добавили
        {
            if(!dateToDo.SelectedDate.HasValue)
            {
                MessageBox.Show("Дата повесилась", Name = "ошибка");
                return;
            }
            toDoList.Add(
                new ToDo(
                    titleToDo.Text,
                    (DateTime)dateToDo.SelectedDate,
                    descriptionToDo.Text ) );
            titleToDo.Text = null;
            descriptionToDo.Text = "Описания нет";
            RefreshToDoList();
        }

    }

    
}