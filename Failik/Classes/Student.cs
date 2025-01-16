
using System;
using System.Collections.Generic;


namespace Failik.Classes
{
    public class Student
    {
        public string Name { get; }
        public string Group { get; }
        private List<string> lastEvents;

        public IReadOnlyList<string> LastEvents => lastEvents.AsReadOnly();

        public Student(string name, string group)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не может быть пустым или null.", nameof(name));

            if (string.IsNullOrWhiteSpace(group))
                throw new ArgumentException("Группа не может быть пустой или null.", nameof(group));

            Name = name;
            Group = group;
            lastEvents = new List<string>();
        }

        public void AddEvent(string newEvent)
        {
            if (string.IsNullOrWhiteSpace(newEvent))
                throw new ArgumentException("Событие не может быть пустым или null.", nameof(newEvent));

            lastEvents.Add(newEvent);

            if (lastEvents.Count > 3)
            {
                lastEvents.RemoveAt(0); 
            }
        }
    }

}
