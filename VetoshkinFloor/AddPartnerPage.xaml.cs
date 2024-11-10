using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace VetoshkinFloor
{
    /// <summary>
    /// Логика взаимодействия для AddPartnerPage.xaml
    /// </summary>
    public partial class AddPartnerPage : Page
    {
        private Partners currentPartner = new Partners();

        public bool check = false;

        public AddPartnerPage(Partners SelectedPartner)
        {
            InitializeComponent();
            var PartnersTypes = VetoshkinFloorMasterEntities.GetContext().OrganizationForm.Select(p => p.OrganizationTypeName).ToList();

            foreach (var PartnerType in PartnersTypes)
            {
                PartnerTypeComboBox.Items.Add(PartnerType);
            }

            if (SelectedPartner != null)
            {
                check = true;
                currentPartner = SelectedPartner;
                PartnerTypeComboBox.SelectedIndex = currentPartner.PartnerType - 1;
            }
            else
            {
                currentPartner.PartnerRating = 0.0;
                PartnerTypeComboBox.SelectedIndex = 0;
            }

            DataContext = currentPartner;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerCompanyName))
                errors.AppendLine("Укажите название партнера");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerCompanyAdressIndex.ToString()))
                errors.AppendLine("Укажите индекс");
            else
            {
                if (currentPartner.PartnerCompanyAdressIndex.ToString().Length != 6)
                    errors.AppendLine("Длина индекса адреса компании должна быть равна 6 символам!");
            }
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerCompanyAdressRegion))
                errors.AppendLine("Укажите регион");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerCompanyAdressCity))
                errors.AppendLine("Укажите город");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerCompanyAdressStreet))
                errors.AppendLine("Укажите улицу");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerCompanyAdressHouse))
                errors.AppendLine("Укажите дом");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerCompanyINN))
                errors.AppendLine("Укажите ИНН");
            else
            {
                if (currentPartner.PartnerCompanyINN.ToString().Length != 10 ||
         !currentPartner.PartnerCompanyINN.ToString().All(char.IsDigit))
                    errors.AppendLine("Длина ИНН компании должна быть равна 10 символам и содержать только цифры!");
            }
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerDirectorSurname))
                errors.AppendLine("Укажите фамилию директора");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerDirectorName))
                errors.AppendLine("Укажите имя директора");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerDirectorPatronymic))
                errors.AppendLine("Укажите отчество директора");
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerPhoneNumber))
            {
                errors.AppendLine("Укажите номер телефона!");
            }
            else
            {
                // Проверяем, что номер телефона состоит из 11 символов и начинается с '8'
                if (currentPartner.PartnerPhoneNumber.Length != 11 ||
                    !currentPartner.PartnerPhoneNumber.StartsWith("8") ||
                    !currentPartner.PartnerPhoneNumber.All(char.IsDigit))
                {
                    errors.AppendLine("Номер телефона должен начинаться с цифры 8 и состоять из 11 цифр!");
                }
            }
            if (string.IsNullOrWhiteSpace(currentPartner.PartnerEmail))
                errors.AppendLine("Укажите Email");
            else
            {
                string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9]+$";
                if (!Regex.IsMatch(currentPartner.PartnerEmail, emailPattern))
                    errors.AppendLine("Не корректный Email!");
            }
            if (currentPartner.PartnerRating == null || currentPartner.PartnerRating < 0.0f)
                errors.AppendLine("Неверный рейтинг партнера");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            currentPartner.PartnerType = PartnerTypeComboBox.SelectedIndex + 1;

            var allPartner = VetoshkinFloorMasterEntities.GetContext().Partners.ToList();
            allPartner = allPartner.Where(p => p.PartnerCompanyName == currentPartner.PartnerCompanyName).ToList();
            if (allPartner.Count == 0 || check == true)
            {
                if (currentPartner.PartnerID == 0)
                {
                    VetoshkinFloorMasterEntities.GetContext().Partners.Add(currentPartner);
                }

                try
                {
                    VetoshkinFloorMasterEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Такой партнер уже сущесвтует!");
        }
    }
}
