using gruppovyxa.frames;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace gruppovyxa
{
    /// <summary>
    /// Логика взаимодействия для CrosswordWindow.xaml
    /// </summary>
    public partial class CrosswordWindow : Window
    {
        IResultCheck page;
        double stagepoint;
        public CrosswordWindow(IResultCheck page, double stagepoint)
        {
            InitializeComponent();
            this.page = page;
            crossFrame.NavigationService.Navigate(page);
            this.stagepoint = stagepoint;
        }
       


        IEnumerable<TextBox> list = new List<TextBox>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (page is programmerCrossword)
            {
                string Vvod = vvod.Text;
                switch (Vvod.ToLower())
                {
                    case "интерфейс":
                        GetAllTextBoxesWithTag("1");
                        break;
                    case "процессор":
                        GetAllTextBoxesWithTag("2");
                        break;
                    case "принтер":
                        GetAllTextBoxesWithTag("3");
                        break;
                    case "объект":
                        GetAllTextBoxesWithTag("4");
                        break;
                    case "интернет":
                        GetAllTextBoxesWithTag("5");
                        break;
                }
            }
            if (page is doctorCrossword)
            {
                string Vvod = vvod.Text;
                switch (Vvod.ToLower())
                {
                    case "популяция":
                        GetAllTextBoxesWithTag("1");
                        break;
                    case "дерево":
                        GetAllTextBoxesWithTag("2");
                        break;
                    case "царство":
                        GetAllTextBoxesWithTag("3");
                        break;
                    case "деление":
                        GetAllTextBoxesWithTag("4");
                        break;
                    case "спора":
                        GetAllTextBoxesWithTag("5");
                        break;
                }
            }
            if (page is lawyerCrossword)
            {
                string Vvod = vvod.Text;
                switch (Vvod.ToLower())
                {
                    case "территория":
                        GetAllTextBoxesWithTag("1");
                        break;
                    case "экономика":
                        GetAllTextBoxesWithTag("2");
                        break;
                    case "министерство":
                        GetAllTextBoxesWithTag("3");
                        break;
                    case "обмен":
                        GetAllTextBoxesWithTag("4");
                        break;
                    case "политика":
                        GetAllTextBoxesWithTag("5");
                        break;
                }
            }


            if (page is programmerCrosswordHard)
            {
                string Vvod = vvod.Text;
                switch (Vvod.ToLower())
                {
                    case "алгоритм":
                        GetAllTextBoxesWithTag("1");
                        break;
                    case "вирус":
                        GetAllTextBoxesWithTag("2");
                        break;
                    case "интерфейс":
                        GetAllTextBoxesWithTag("3");
                        break;
                    case "приложение":
                        GetAllTextBoxesWithTag("4");
                        break;
                    case "байт":
                        GetAllTextBoxesWithTag("5");
                        break;
                    case "робот":
                        GetAllTextBoxesWithTag("6");
                        break;
                    case "макромир":
                        GetAllTextBoxesWithTag("7");
                        break;
                    case "алфавит":
                        GetAllTextBoxesWithTag("8");
                        break;
                    case "модель":
                        GetAllTextBoxesWithTag("9");
                        break;
                    case "кластер":
                        GetAllTextBoxesWithTag("10");
                        break;
                }
            }
            if (page is lawyerCrosswordHard)
            {
                string Vvod = vvod.Text;

                switch (Vvod.ToLower())
                {
                    case "лицензия":
                        GetAllTextBoxesWithTag("1");
                        break;
                    case "презумпция":
                        GetAllTextBoxesWithTag("2");
                        break;
                    case "параграф":
                        GetAllTextBoxesWithTag("3");
                        break;
                    case "суд":
                        GetAllTextBoxesWithTag("4");
                        break;
                    case "закон":
                        GetAllTextBoxesWithTag("5");
                        break;
                    case "адвокат":
                        GetAllTextBoxesWithTag("6");
                        break;
                    case "подсудимый":
                        GetAllTextBoxesWithTag("7");
                        break;
                    case "жалоба":
                        GetAllTextBoxesWithTag("8");
                        break;
                    case "имущество":
                        GetAllTextBoxesWithTag("9");
                        break;
                    case "право":
                        GetAllTextBoxesWithTag("10");
                        break;
                }
            }
            if (page is doctorCrosswordHard)
            {
                string Vvod = vvod.Text;

                switch (Vvod.ToLower())
                {
                    case "бедренная":
                        GetAllTextBoxesWithTag("1");
                        break;
                    case "сердце":
                        GetAllTextBoxesWithTag("2");
                        break;
                    case "плоские":
                        GetAllTextBoxesWithTag("3");
                        break;
                    case "тело":
                        GetAllTextBoxesWithTag("4");
                        break;
                    case "плюсны":
                        GetAllTextBoxesWithTag("5");
                        break;
                    case "плечевая":
                        GetAllTextBoxesWithTag("6");
                        break;
                    case "смешанные":
                        GetAllTextBoxesWithTag("7");
                        break;
                    case "эпифиз":
                        GetAllTextBoxesWithTag("8");
                        break;
                    case "череп":
                        GetAllTextBoxesWithTag("9");
                        break;
                    case "опорная":
                        GetAllTextBoxesWithTag("10");
                        break;
                }
            }
            vvod.Clear();

            var allTextBoxes = FindVisualChildren<TextBox>(page as Page);

            if (allTextBoxes.Where(p => p.Tag != null).All(p => p.Foreground != Brushes.Transparent))
            {
                Controllers.Controller.currentBall += 10;
                if (page is programmerCrossword || page is lawyerCrossword || page is doctorCrossword)
                {
                    try
                    {
                        if(Controllers.Controller.currentBall - stagepoint <= 0) throw new Exception("Этап не пройден");

                        if (page is programmerCrossword)
                            page = new programmerCrosswordHard();

                        if (page is lawyerCrossword)
                            page = new lawyerCrosswordHard();

                        if (page is doctorCrossword)
                            page = new doctorCrosswordHard();

                        crossFrame.Navigate(page);

                        hint.Visibility = Visibility.Visible;

                        stagepoint = Controllers.Controller.currentBall;
                        UpdateList();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        this.Close();
                        Controllers.Controller.currentBall = 0;
                    }

                }
                else
                {
                    try
                    {
                        string job = "";
                        if (page is programmerCrosswordHard)
                            job = "программист";

                        if (page is lawyerCrosswordHard)
                            job = "юрист";

                        if (page is doctorCrosswordHard)
                            job = "доктор";

                        if (Controllers.Controller.currentBall - stagepoint <= 0) throw new Exception("Этап не пройден");
                        MessageBox.Show("Ура, победа!");
                        Controllers.Controller.GameEnd(job);
                        this.Close();
                        Controllers.Controller.currentBall = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        this.Close();
                        Controllers.Controller.currentBall = 0;
                    }
                }

            }
        }

        private void GetAllTextBoxesWithTag(string tag)
        {
            var textBoxes = new List<TextBox>();
            if (page != null)
            {

                foreach (var textBox in FindVisualChildren<TextBox>(page as Page))
                {
                    if (textBox.Tag != null && textBox.Tag.ToString() == tag)
                    {
                        textBox.Foreground = Brushes.Black;
                        textBox.Opacity = 1;
                    }
                }
            }

        }
        private IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                    if (child != null && child is T tChild)
                    {
                        yield return tChild;
                    }

                    foreach (var childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            List<string> itemsToAdd = new List<string> { };

            if (page is programmerCrossword)
            {
                itemsToAdd = new List<string>
                {
                    "1. Набор правил и инструментов, с помощью которого человек общается с компьютером или другим электронным устройством(интерфейс)",
                    "2. Часть компьютера, управляющая всеми процессами(процессор)",
                    "3. Устройство для печати данных(принтер)",
                    "4. Любая часть окружающей действительности, воспринимаемая человеком как единое целое(объект)",
                    "5. Всемирная информационная компьютерная сеть(интернет)"
                };
            }

            if (page is lawyerCrossword)
            {
                itemsToAdd = new List<string>
                {
                    "1. Один из признаков государства (территория)",
                    "2. Сфера общественной жизни, в которой происходит производство, распределение, обмен и потребление материальных благ (экономика)",
                    "3. Специальный орган государственного управления (министерство)",
                    "4. Одна из четырёх сфер экономики (обмен)",
                    "5. Искусство управления государством (политика)"
                };
            }

            if (page is doctorCrossword)
            {
                itemsToAdd = new List<string>
                {
                    "1.	Совокупность особей одного вида, обменивающихся генетическим материалом и занимающих определённую территорию (популяция)",
                    "2.	Самая крупная жизненная форма растения (дерево)",
                    "3.	Очень большая группа организмов, сходных по строению, питанию и жизни в природе (царство)",
                    "4.	Размножение клетки (деление)",
                    "5.	Очень мелкая особая клетка, служащая для размножения растений (спора)"
                };

            }

            if (page is programmerCrosswordHard)
            {
                itemsToAdd = new List<string>
                {
                    "1. Описание последовательности действий, строгое исполнение которых приводит к решению поставленной задачи за конечное число шагов.",
                    "2. Программа, которая может «размножаться» и скрытно внедрять свои копии в файлы, загрузочные секторы дисков и документы.",
                    "3. Совокупность средств, методов и правил взаимодействия между элементами системы.",
                    "4. Программа, позволяющая пользователю обрабатывать текстовую, графическую, числовую, аудио и видеоинформацию.",
                    "5. Наиболее крупная единица измерения объёма информации.",
                    "6. Автоматические устройства, предназначенные для осуществления научных, производственных и других работ.",
                    "7. Мир, который состоит из объектов, по своим размерам сравнимых с человеком.",
                    "8. Набор однозначно определенных знаков (символов), из которых формируется сообщение.",
                    "9. Искусственно созданный объект, дающий упрощённое представление о реальном объекте, процессе или явлении.",
                    "10. Минимальный адресуемый блок дисковой памяти для записи/чтения данных на дисковом накопителе (жёстком диске).",
                };
            }

            if (page is lawyerCrosswordHard)
            {
                itemsToAdd = new List<string>
                {

                    "1. Официальное разрешение на осуществление определенной деятельности или право использования чего-либо.",
                    "2. Предположение, которое делается на основе определенных фактов или доказательств в отсутствие прямых доказательств.",
                    "3. Структурная единица закона или текста, обычно содержащая одну или несколько законодательных норм.",
                    "4. Орган власти, рассматривающий и разрешающий споры и конфликты в соответствии с законом.",
                    "5. Нормативный акт, устанавливающий правила поведения, обязательные для исполнения в обществе.",
                    "6. Юридический профессионал, оказывающий юридическую помощь и защиту в суде.",
                    "7. Человек, привлеченный к уголовной или административной ответственности и находящийся под судебным разбирательством.",
                    "8. Официальное обращение к вышестоящему органу или суду с просьбой о защите прав или рассмотрении жалобы.",
                    "9. Все, что принадлежит кому-либо и имеет ценность.",
                    "10. Норма, признанная обществом обязательной и обеспечиваемая государством. "
                };
            }
            if (page is doctorCrosswordHard)
            {
                itemsToAdd = new List<string>
                {

                    "1. Самая большая и длинная кость в скелете человека.",
                    "2. Жизненно важный орган человека, расположенный позади грудины.",
                    "3. Кости, участвующие в образовании стенок полостей, содержащих внутренние органы.",
                    "4. Удлинённая, средняя часть трубчатой кости.",
                    "5. Короткие трубчатые кости средней части стопы.",
                    "6. Длинная трубчатая кость верхней конечности человека.",
                    "7. Кости, имеющие сложную форму и состоящие из нескольких частей, имеющих различное строение и очертания.",
                    "8. Утолщённые концы трубчатой кости.",
                    "9. Скелет головы.",
                    "10. Основная функция скелета."
                };
            }

            listOfQuestions.ItemsSource = itemsToAdd;
        }

        private int clickCount = 0;
        private int clickCount2 = 0;
        private void hint_Click(object sender, RoutedEventArgs e)
        {
            if (page is programmerCrossword || page is lawyerCrossword || page is doctorCrossword)
            {
                clickCount++;
                if (clickCount == 1)
                {
                    Controllers.Controller.currentBall -= 2;
                }
                else if (clickCount == 2)
                {
                    Controllers.Controller.currentBall -= 5;
                    hint.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                clickCount2++;
                if (clickCount2 == 1)
                {
                    Controllers.Controller.currentBall -= 2;
                }
                else if (clickCount2 == 2)
                {
                    Controllers.Controller.currentBall -= 5;
                    hint.Visibility = Visibility.Hidden;
                }
            }
            HintWindow HW = new HintWindow();



            var programmer_hints = new Dictionary<string, string>
            {
                {"1", "Это технический термин, который описывает способ взаимодействия человека с устройством."},
                {"2", "Он осуществляет арифметические, логические и управляющие операции."},
                {"3", "Это устройство, которое преобразует электронные данные в физические копии на бумаге или других материалах."},
                {"4", "Этот термин в программировании часто используется для обозначения экземпляров классов или структур, которые могут содержать данные и методы для их обработки."},
                {"5", "Он предоставляет доступ к огромному объему информации и возможности коммуникации между людьми и системами."},
            };
            var lawyer_hints = new Dictionary<string, string>
            {
                {"1", "Это один из основных элементов, определяющих границы и пространство государства."},
                {"2", "Включает в себя такие элементы, как производство, потребление, инвестиции, торговля и финансы."},
                {"3", "Обычно управляет и координирует деятельность в соответствующей области, разрабатывает и реализует законодательные и административные меры."},
                {"4", "Это процесс передачи товаров, услуг и ресурсов между различными субъектами и участниками экономики."},
                {"5", "Это процесс принятия решений и осуществления действий, направленных на управление обществом и государством."},
            };
            var doctor_hints = new Dictionary<string, string>
            {
                {"1", "Группа однородных организмов одного вида, проживающих в определенной области и взаимодействующих друг с другом, что делает ее основной единицей для изучения экологических процессов и эволюции."},
                {"2", "Это высокое и долгоживущее растение с жестким стеблем, обычно имеющее ветви и листья."},
                {"3", "Это высший таксон, который объединяет различные организмы по основным общим признакам."},
                {"4", "Это процесс, при котором клетка делится на две или более дочерних клетки."},
                {"5", "Это особая клетка, которая обычно обладает защитной оболочкой и способна к выживанию в неблагоприятных условиях."},
            };
            var programmerHard_hints = new Dictionary<string, string>
            {
      {"1", "Набор инструкций или шагов, применяемых для выполнения определенной задачи или решения проблемы." },
      {"2", "Программное обеспечение, способное копировать себя и распространяться между компьютерами, часто нанося вред системе."},
      {"3", "Точка встречи между человеком и машиной, облегчающая взаимодействие и передачу информации."},
      {"4", "Программа, разработанная для выполнения определенной функции или задачи на компьютере или мобильном устройстве."},
      {"5", "Единица измерения информации, обычно состоящая из 8 бит, используемая для хранения данных в компьютерах."},
      {"6", "Автоматизированное устройство, способное выполнять различные задачи без прямого участия человека."},
      {"7", "Виртуальная среда, представляющая собой мир или систему, созданные программными средствами."},
      {"8", "Упорядоченный набор символов, используемый для записи языка или представления информации."},
      {"9", "Упрощенное представление объекта или системы, позволяющее изучать его свойства или поведение."},
      {"10","Группа объектов или узлов, объединенных на основе определенных характеристик или критериев."}
            };

            var lawyerHard_hints = new Dictionary<string, string>
            {
                {"1", "Часто представляет интересы клиентов в суде и консультирует по правовым вопросам." },
                {"2", "Совокупность норм, регулирующих отношения между людьми и государством." },
                {"3", "Место, где принимаются решения на основе представленных доказательств и законов." },
                {"4", "Может быть федеральным, муниципальным или международным и обязателен для всех граждан." },
                {"5", "Может быть движимым или недвижимым и обладает стоимостью." },
                {"6", "Подвергается судебному разбирательству по обвинению в совершении преступления." },
                {"7", "Часто требуется для занятия определенной профессиональной или коммерческой деятельностью." },
                {"8", "Может быть подана в связи с нарушением прав или несправедливым решением суда." },
                {"9", "Обычно содержит конкретную норму или положение в тексте закона или договора." },
                {"10", "Считается истиной до тех пор, пока не будет опровергнута достаточными доказательствами." }
            };
            var doctorHard_hints = new Dictionary<string, string>
            {
                { "1", "Относящаяся к части тела между тазом и коленом, содержащая крупные костные элементы." },
                {"2", "Орган, отвечающий за циркуляцию крови в организме, обычно располагается в грудной полости."},
                {"3", "Относящиеся к поверхностям, не имеющим выраженного объема или формы."},
                {"4", "Физическая структура организма, включающая в себя все его части, органы и системы."},
                {"5", "Костные элементы, образующие основу пальцев ноги."},
                {"6", "Относящаяся к части тела, соединяющей торс с верхней конечностью."},
                {"7", "Категория костей, содержащая элементы как плоской, так и длинной кости."},
                {"8", "Конечная часть длинной кости, образующая суставную поверхность."},
                {"9", "Костная структура, защищающая мозг и образующая форму головы."},
                {"10", "Связанная с функцией поддержки тела или его частей, обеспечивающей устойчивость и движение."}
            };


            var allTextBoxes = FindVisualChildren<TextBox>(page as Page);
            if (page is programmerCrossword)
            {
                foreach (var hint in programmer_hints)
                {
                    if (allTextBoxes.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Foreground == Brushes.Transparent))
                    {
                        HW.WordNum.Text = "Слово №" + hint.Key;
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }

            if (page is lawyerCrossword)
            {
                foreach (var hint in lawyer_hints)
                {
                    if (allTextBoxes.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Foreground == Brushes.Transparent))
                    {
                        HW.WordNum.Text = "Слово №" + hint.Key;
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }
            if (page is doctorCrossword)
            {
                foreach (var hint in doctor_hints)
                {
                    if (allTextBoxes.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Foreground == Brushes.Transparent))
                    {
                        HW.WordNum.Text = "Слово №" + hint.Key;
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }

            if (page is programmerCrosswordHard)
            {
                foreach (var hint in programmerHard_hints)
                {
                    if (allTextBoxes.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Foreground == Brushes.Transparent))
                    {
                        HW.WordNum.Text = "Слово №" + hint.Key;
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }
            if (page is lawyerCrosswordHard)
            {
                foreach (var hint in lawyerHard_hints)
                {
                    if (allTextBoxes.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Foreground == Brushes.Transparent))
                    {
                        HW.WordNum.Text = "Слово №" + hint.Key;
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }
            if (page is doctorCrosswordHard)
            {
                foreach (var hint in doctorHard_hints)
                {
                    if (allTextBoxes.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Foreground == Brushes.Transparent))
                    {
                        HW.WordNum.Text = "Слово №" + hint.Key;
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }
            HW.Show();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Этап не пройден");
            this.Close();
            Controllers.Controller.currentBall = 0;
        }
    }
}
