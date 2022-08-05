using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class PhoneManager:IComparable
    {
        public void HomePage(PhoneDal phoneDal)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            int selection = int.Parse(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    RegisteringANewPhoneNumber(phoneDal);
                    break;
                case 2:
                    DeleteNumber(phoneDal);
                    break;
                case 3:
                    UpdateNumber(phoneDal);
                    break;
                case 4:
                    ListPhoneBook(phoneDal);
                    break;
                case 5:
                    SearchThePhoneBook(phoneDal);
                    break;
            }
        }

        public void RegisteringANewPhoneNumber(PhoneDal phoneDal)
        {
            string firstName, lastName;
            int phoneNumber;
            Console.Clear();
            Console.Write("Lütfen isim Giriniz : ");
            firstName = Console.ReadLine();
            Console.Write("Lütfen soyisim Giriniz : ");
            lastName = Console.ReadLine();
            Console.Write("Lütfen telefon numarası Giriniz : ");
            phoneNumber = int.Parse(Console.ReadLine());
            Person person = new Person { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber };
            phoneDal.Add(person);
            HomePage(phoneDal);

        }
        public void DeleteNumber(PhoneDal phoneDal)
        {
            Console.Clear();
            Console.WriteLine("Silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string name = Console.ReadLine();

            foreach (var item in phoneDal.GetAll())
            {
                if (item.FirstName == name || item.LastName == name)
                {
                    Console.Write(item.FirstName + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                    char check = char.Parse(Console.ReadLine());
                    if (check == 'y')
                    {
                        phoneDal.Delete(item);
                        Console.WriteLine(item.FirstName + " Başarı ile silindi");
                        ReturnToMainMenu(phoneDal);


                    }
                    else if (check == 'n')
                    {
                        DeleteNumber(phoneDal);
                    }
                }                              
            }
            int selection;
            Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("Silmeyi sonlandırmak için : (1)");
            Console.WriteLine("Yeniden denemek için : (2)");
            selection = int.Parse(Console.ReadLine());
            if (selection == 1)
            {
                HomePage(phoneDal);
            }
            else if (selection == 2)
            {
                DeleteNumber(phoneDal);
            }
            Console.ReadKey();
        }
        public void UpdateNumber(PhoneDal phoneDal)
        {
            Console.Clear();
            Console.WriteLine("Güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string name = Console.ReadLine();

            foreach (var item in phoneDal.GetAll())
            {
                if (item.FirstName == name || item.LastName == name)
                {
                    
                    Console.WriteLine("İsim : " + item.FirstName);
                    Console.WriteLine("Soyisim : " + item.LastName);
                    Console.WriteLine("Telefon Numarası : " + item.PhoneNumber);
                    Console.WriteLine();
                    Console.Write("Yeni isim gir : ");
                    string firstName = Console.ReadLine();
                    Console.Write("Yeni soyisim gir : ");
                    string lastName = Console.ReadLine();             
                    Console.Write("Yeni numara gir : ");
                    int phoneNumber = int.Parse(Console.ReadLine());
                    Person person = new Person { FirstName = item.FirstName, LastName = item.LastName, PhoneNumber = item.PhoneNumber };
                    Person person1 = new Person { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber };
                    phoneDal.Update(person,person1);
                    Console.WriteLine("Başarı ile güncellendi");
                    ReturnToMainMenu(phoneDal);
                }
            }
            int selection;
            Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("Güncellemeyi sonlandırmak için : (1)");
            Console.WriteLine("Yeniden denemek için : (2)");
            selection = int.Parse(Console.ReadLine());
            if (selection == 1)
            {
                HomePage(phoneDal);
            }
            else if (selection == 2)
            {
                UpdateNumber(phoneDal);
            }
            Console.ReadKey();

        }
            
        public void ListPhoneBook(PhoneDal phoneDal)
        {
            Console.Clear();
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("***********************************");
            Console.WriteLine("A-Z için 0 'i tuşlayın.");
            Console.WriteLine("Z-A için 1'i tuşlayın");
            char selection = char.Parse(Console.ReadLine());
            Console.Clear();
            if (selection == '0')
            {
                var result = phoneDal.GetAll().OrderBy(x => x.FirstName);
                foreach (var item in result)
                {
                    Console.WriteLine("İsim : " + item.FirstName);
                    Console.WriteLine("Soyisim : " + item.LastName);
                    Console.WriteLine("Telefon Numarası : " + item.PhoneNumber);
                    Console.WriteLine();
                }
            }
            else if (selection == '1')
            {
                var result = phoneDal.GetAll().OrderByDescending(x => x.FirstName);
                foreach (var item in result)
                {
                    Console.WriteLine("İsim : " + item.FirstName);
                    Console.WriteLine("Soyisim : " + item.LastName);
                    Console.WriteLine("Telefon Numarası : " + item.PhoneNumber);
                    Console.WriteLine();
                }
            }
     
            
            ReturnToMainMenu(phoneDal);
        }

        public void SearchThePhoneBook(PhoneDal phoneDal)
        {
            Console.Clear();
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine(" **********************************************");
            Console.WriteLine();
            Console.WriteLine("İsim veya soyisim arama yapmak için (1) :");
            Console.WriteLine("Telefon numarasına göre arama yapmak (2) :");
            char selection = char.Parse(Console.ReadLine());
            if (selection == '1')
            {
                
                Console.Clear();
                Console.Write("İsim veya soyisim giriniz : ");
                string name = Console.ReadLine();
                foreach (var item in phoneDal.GetAll())
                {
                    if (item.FirstName == name||item.LastName==name)
                    {
                        Console.WriteLine("İsim : " + item.FirstName);
                        Console.WriteLine("Soyisim : " + item.LastName);
                        Console.WriteLine("Telefon Numarası : " + item.PhoneNumber);
                        Console.WriteLine();
                        ReturnToMainMenu(phoneDal);
                        
                    } 
                }
                Console.WriteLine("Böyle bir kayıt bulunamadı");
                ReturnToMainMenu(phoneDal);

            }
            else if (selection == '2')
            {
                Console.Clear();
                Console.WriteLine("Telefon numarası giriniz.");
                int number = int.Parse(Console.ReadLine());
                foreach (var item in phoneDal.GetAll())
                {
                    if (item.PhoneNumber == number)
                    {
                        Console.WriteLine("İsim : " + item.FirstName);
                        Console.WriteLine("Soyisim : " + item.LastName);
                        Console.WriteLine("Telefon Numarası : " + item.PhoneNumber);
                        Console.WriteLine();
                        ReturnToMainMenu(phoneDal);

                    }
                }
                Console.WriteLine("Böyle bir kayıt bulunamadı");
                ReturnToMainMenu(phoneDal);

            }

        }

        public void ReturnToMainMenu(PhoneDal phoneDal)
        {
            Console.WriteLine("Ana menüye dönmek için 0'ı tuşlayın.");
            int selection = int.Parse(Console.ReadLine());
            if (selection == 0)
            {
                HomePage(phoneDal);
            }
        }

    }
}
