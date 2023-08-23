using Module25_ElectronicLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module25_ElectronicLibrary
{
    public class UserContext
    {
        private UserRepository _UserRepository;
        public UserContext(UserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public void UsersActions()
        {
            string action = string.Empty;
            do
            {
                //Console.WriteLine("Доступные действия:\n'show': показать всех пользователей данные;\n'showone': выбрать пользователя по id;\n'add': добавить пользователя;\n'update': изменить имя;\n'delete': удалить по Id;\n'exit': выход\n");
                Console.WriteLine("Доступные действия:\n'show': показать всех пользователей данные;\n'showone': выбрать пользователя по id;\n'add': добавить пользователя;\n'delete': удалить по Id;\n'update': изменить имя;\n'exit': выход\n");
                Console.Write("\nВведите нужное действие: ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "show":
                        List<User> list =_UserRepository.SelectAllUsers();
                        list.ForEach(x => Console.WriteLine(x.Id + " " + x.Name + " " + x.Email ));
                        break;
                    case "showone":
                        int idTemp;
                        Console.Write("Введите id пользователя");
                        bool result = Int32.TryParse(Console.ReadLine(), out idTemp);
                        if (result)
                        {
                            list = _UserRepository.SelectUserById(idTemp);
                            list.ForEach(x => Console.WriteLine(x.Id + " " + x.Name + " " + x.Email));
                        }
                        else Console.WriteLine("Введено не числовое значение, операция выборки пользователя прервана");
                        break;
                    case "add":
                        Entities.User user = new Entities.User();
                        Console.WriteLine("Введите Имя пользователя: ");
                        user.Name = Console.ReadLine();

                        Console.WriteLine("Введите Email пользователя: ");
                        user.Email = Console.ReadLine();
                        _UserRepository.CreateUser(user);
                        Console.WriteLine("Пользователь создан");
                        break;
                    case "del":
                        bool successDel=false;
                        Console.Write("Введите id пользователя");
                        result = Int32.TryParse(Console.ReadLine(), out idTemp);
                        if (result)
                        {
                            successDel = _UserRepository.DeleteUser(idTemp);
                        }
                        else Console.WriteLine("Введено не числовое значение, операция удаления пользователя прервана");
                        if (successDel)
                        {
                            Console.WriteLine("Пользователь {0} удален", idTemp);
                        }
                        else Console.WriteLine("Пользователь {0} не найден", idTemp);
                        break;
                    case "upd":
                        bool successUpd = false;
                        Console.Write("Введите id пользователя");
                        result = Int32.TryParse(Console.ReadLine(), out idTemp);
                        if (result)
                        {
                            Console.WriteLine("Введите Имя пользователя: ");
                            string userName = Console.ReadLine();
                            successUpd = _UserRepository.UpdateUser(idTemp, userName);
                        }
                        else
                        {
                            Console.WriteLine("Введено не числовое значение, операция обновления имени пользователя прервана");
                            break;
                        }
                        if (successUpd)
                        {
                            Console.WriteLine("Пользователь {0} обновлен", idTemp);
                        }
                        else Console.WriteLine("Пользователь {0} не найден", idTemp);
                        break;
                }
                Console.ReadLine();
            }
            while (action != "exit");
        }
    }
}
