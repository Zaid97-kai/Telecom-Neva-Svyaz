using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ООО__Телеком_Нева_Связь_.Models;

namespace ООО__Телеком_Нева_Связь_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Employees Employee;
        public SubscriberAdress Adress;

        public MainWindow()
        {
            InitializeComponent();

           

            using (DemoDBEntities db=new DemoDBEntities())
            {
                ComboUsers.ItemsSource = db.Employees.ToList();
                LvSubscribers.ItemsSource = db.Subscribers.Where(p => p.ContractTerminationDate == null).ToList();

                var allTypes = db.SubscriberAdress.ToList();
                allTypes.Insert(0, new SubscriberAdress
                {
                    Prefix = "Все улицы"
                });
                ComboStreet.ItemsSource = allTypes;

            }

            
        }

        private void ComboUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee=ComboUsers.SelectedItem as Employees;
 
            using (DemoDBEntities db = new DemoDBEntities())
            {
                LvEvents.ItemsSource = db.EmploeeEvents.Where(p => p.EmploeeType == Employee.Type).ToList();
            }
           
            RestartVisibility();
            ChangeVisibility();
        }

        private void RestartVisibility()
        {
            BtnActives.Visibility = Visibility.Collapsed;
            BtnBilling.Visibility = Visibility.Collapsed;
            BtnCRM.Visibility = Visibility.Collapsed;
            BtnSupport.Visibility = Visibility.Collapsed;
            BtnEquipment.Visibility = Visibility.Collapsed;
        }

        private void ChangeVisibility()
        {
            switch (Employee.Type)
            {
                case "Руководитель отдела по работе с клиентами":
                    {
                        BtnCRM.Visibility = Visibility.Visible;
                        BtnBilling.Visibility = Visibility.Visible;
                        break;
                    }
                case "Менеджер по работе с клиентами":
                    {
                        BtnCRM.Visibility = Visibility.Visible;
                        break;
                    }
                case "Руководитель отдела технической поддержки":
                    {
                        BtnCRM.Visibility = Visibility.Visible;
                        BtnSupport.Visibility = Visibility.Visible;
                        BtnEquipment.Visibility = Visibility.Visible;
                        break;
                    }
                case "Специалист ТП (выездной инженер)":
                    {
                        BtnCRM.Visibility = Visibility.Visible;
                        BtnSupport.Visibility = Visibility.Visible;
                        BtnEquipment.Visibility = Visibility.Visible;
                        break;
                    }
                case "Бухгалтер":
                    {
                        BtnBilling.Visibility = Visibility.Visible;
                        BtnActives.Visibility = Visibility.Visible;
                        break;
                    }
                case "Директор по развитию":
                    {
                        BtnCRM.Visibility = Visibility.Visible;
                        BtnSupport.Visibility = Visibility.Visible;
                        BtnEquipment.Visibility = Visibility.Visible;
                        BtnBilling.Visibility = Visibility.Visible;
                        BtnActives.Visibility = Visibility.Visible;
                        break;
                    }
                case "Технический департамент":
                    {
                        BtnCRM.Visibility = Visibility.Visible;
                        BtnEquipment.Visibility = Visibility.Visible;
                        BtnActives.Visibility = Visibility.Visible;
                        break;
                    }
            }
        }

        private void BtnCRM_Click(object sender, RoutedEventArgs e)
        {
            TbMode.Text = "CRM";
        }

        private void BtnEquipment_Click(object sender, RoutedEventArgs e)
        {
            TbMode.Text = "Управление оборудованием";
        }

        private void BtnActives_Click(object sender, RoutedEventArgs e)
        {
            TbMode.Text = "Активы";
        }

        private void BtnBilling_Click(object sender, RoutedEventArgs e)
        {
            TbMode.Text = "Биллинг";
        }

        private void BtnSupport_Click(object sender, RoutedEventArgs e)
        {
            TbMode.Text = "Поддержка пользователей";
        }

        private void BtnSubscribers_Click(object sender, RoutedEventArgs e)
        {
            TbMode.Text = "Абоненты ТНС";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            switch (radioButton.Content)
            {
                case "Активные":
                    {
                        using (DemoDBEntities db = new DemoDBEntities())
                        {
                            LvSubscribers.ItemsSource = db.Subscribers.Where(p => p.ContractTerminationDate == null).ToList();
                        }
                        break;
                    }

                case "Неактивные":
                    {
                        using (DemoDBEntities db = new DemoDBEntities())
                        {
                            LvSubscribers.ItemsSource = db.Subscribers.Where(p => p.ContractTerminationDate != null).ToList();
                        }
                        break;
                    }

                case "Все договоры":
                    {
                        using (DemoDBEntities db = new DemoDBEntities())
                        {
                            LvSubscribers.ItemsSource = db.Subscribers.ToList();
                        }
                        break;
                    }
            }
        }

        private void ComboStreet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TbSurname.Text = "";
            TbAccount.Text = "";
            TbDistrict.Text = "";

            Adress = ComboStreet.SelectedItem as SubscriberAdress;
            if (Adress.Prefix=="Все улицы")
            {
                using (DemoDBEntities db = new DemoDBEntities())
                {
                    LvSubscribers.ItemsSource = db.Subscribers.ToList();
                }
            }
            else
            {
                using (DemoDBEntities db = new DemoDBEntities())
                {
                    LvSubscribers.ItemsSource = db.Subscribers.Where(p => p.SubscriberAdress.Any(c => c.Prefix == Adress.Prefix && c.House == Adress.House)).ToList();
                }
            }


        }

        private void TbDistrict_TextChanged(object sender, TextChangedEventArgs e)
        {
            TbSurname.Text = "";
            TbAccount.Text = "";

            if (TbDistrict.Text == "")
            {
                using (DemoDBEntities db = new DemoDBEntities())
                {
                    LvSubscribers.ItemsSource = db.Subscribers.ToList();
                }
            }
            else
            {
                using (DemoDBEntities db = new DemoDBEntities())
                {
                    LvSubscribers.ItemsSource = db.Subscribers.Where(p => p.SubscriberAdress.Any(c => c.Raion.ToLower().Contains(TbDistrict.Text.ToLower()))).ToList();
                }
            }

         
        }

        private void TbAccount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TbSurname.Text = "";
            TbDistrict.Text = "";

            if (TbAccount.Text == "")
            {
                using (DemoDBEntities db = new DemoDBEntities())
                {
                    LvSubscribers.ItemsSource = db.Subscribers.ToList();
                }
            }
            else
            {
                using (DemoDBEntities db = new DemoDBEntities())
                {
                    LvSubscribers.ItemsSource = db.Subscribers.Where(p => p.PersonalAccount.ToLower().Contains(TbAccount.Text.ToLower())).ToList();
                }
            }
        }

        private void TbSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            TbAccount.Text = "";
            TbDistrict.Text = "";

            if (TbSurname.Text == "")
            {
                using (DemoDBEntities db = new DemoDBEntities())
                {
                    LvSubscribers.ItemsSource = db.Subscribers.ToList();
                }
            }
            else
            {
                using (DemoDBEntities db = new DemoDBEntities())
                {
                    LvSubscribers.ItemsSource = db.Subscribers.Where(p => p.FIO.ToLower().Contains(TbSurname.Text.ToLower())).ToList();
                }
            }
        }
    }
}
