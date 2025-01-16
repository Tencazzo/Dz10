using Failik.Classes;
using System;
using System.Collections.Generic;
using Failik.Interfaces;

namespace Failik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventManager eventManager = new EventManager();

            eventManager.AddStudent(new Student("Алексей", "Группа A"));
            eventManager.AddStudent(new Student("Мария", "Группа B"));
            eventManager.AddStudent(new Student("Сергей", "Группа A"));

            Task1(eventManager);
            Task2();
        }

        static void Task1(EventManager eventManager)
        {
            Console.Write("Введите название мероприятия: ");
            string eventName = Console.ReadLine();

            DateTime eventDate = GetEventDate();

            int participantsPerGroup = GetParticipantsPerGroup();

            List<string> preferences = GetStudentPreferences();

            eventManager.CreateEvent(eventName, eventDate, participantsPerGroup, preferences);
            Console.WriteLine("Мероприятие создано успешно!");
        }

        static DateTime GetEventDate()
        {
            DateTime eventDate;
            while (true)
            {
                Console.Write("Введите дату мероприятия (дд.мм.гггг): ");
                string input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out eventDate))
                {
                    return eventDate;
                }
                Console.WriteLine("Некорректный формат даты. Пожалуйста, попробуйте снова.");
            }
        }

        static int GetParticipantsPerGroup()
        {
            int participantsPerGroup;
            while (true)
            {
                Console.Write("Введите количество участников от каждой группы: ");
                if (int.TryParse(Console.ReadLine(), out participantsPerGroup) && participantsPerGroup > 0)
                {
                    return participantsPerGroup;
                }
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
            }
        }

        static List<string> GetStudentPreferences()
        {
            List<string> preferences = new List<string>();
            while (true)
            {
                Console.Write("Введите имя студента, который хочет участвовать (или 'стоп' для завершения): ");
                string preference = Console.ReadLine();
                if (preference.ToLower() == "стоп")
                {
                    break;
                }

                if (!preferences.Contains(preference))
                {
                    preferences.Add(preference);
                }
                else
                {
                    Console.WriteLine("Этот студент уже добавлен в список предпочтений.");
                }
            }
            return preferences;
        }

        static void Task2()
        {
            List<Person> people = new List<Person>
        {
            new Person("Алексей", "выход сериала"),
            new Person("Мария", "концерт"),
            new Person("Сергей", "выставка")
        };

            while (true)
            {
                Console.WriteLine("Введите событие (выход сериала, концерт, выставка) или 'стоп' для выхода:");
                string eventName = Console.ReadLine();

                if (eventName.ToLower() == "стоп")
                {
                    break;
                }

                bool eventFound = false;
                foreach (var person in people)
                {
                    if (person.Hobby == eventName)
                    {
                        Console.WriteLine(person.GetReaction(eventName));
                        eventFound = true;
                    }
                }

                if (!eventFound)
                {
                    Console.WriteLine("Никто не заинтересован в этом событии.");
                }
            }
        }
    }
 }