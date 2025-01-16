using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Failik.Classes;



namespace Failik.Interfaces
{
    public class EventManager : IEventManager
    {
        private List<Student> students;

        public EventManager()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student), "Студент не может быть null.");

            students.Add(student);
        }

        public void CreateEvent(string eventName, DateTime eventDate, int participantsPerGroup, List<string> preferences)
        {
            if (string.IsNullOrWhiteSpace(eventName))
                throw new ArgumentException("Название мероприятия не может быть пустым или null.", nameof(eventName));

            if (participantsPerGroup <= 0)
                throw new ArgumentOutOfRangeException(nameof(participantsPerGroup), "Количество участников должно быть больше нуля.");

            if (preferences == null)
                throw new ArgumentNullException(nameof(preferences), "Предпочтения не могут быть null.");

            Event newEvent = new Event(eventName, eventDate);

            var selectedStudents = students
                .Where(s => preferences.Contains(s.Name))
                .OrderBy(s => Guid.NewGuid())
                .Take(participantsPerGroup)
                .ToList();

            foreach (var student in selectedStudents)
            {
                newEvent.Participants.Add(student);
                UpdateStudentEvents(student, eventName);
            }

            WriteEventResults("event_results.txt", newEvent);
        }

        private void WriteEventResults(string filePath, Event eventDetails)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"Мероприятие: {eventDetails.Name}, Дата: {eventDetails.Date}");
                    writer.WriteLine("Участники:");
                    foreach (var participant in eventDetails.Participants)
                    {
                        writer.WriteLine(participant.Name);
                    }
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
        }

        private void UpdateStudentEvents(Student student, string eventName)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student), "Студент не может быть null.");

            if (string.IsNullOrWhiteSpace(eventName))
                throw new ArgumentException("Название события не может быть пустым или null.", nameof(eventName));

            student.AddEvent(eventName);
        }
    }
}

