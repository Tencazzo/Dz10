using System;
using System.Collections.Generic;

namespace Failik.Classes
{

    public class Event
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public List<Student> Participants { get; private set; }

        public Event(string name, DateTime date)
        {
            Name = !string.IsNullOrWhiteSpace(name)
                ? name
                : throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            Date = date;
            Participants = new List<Student>();
        }

        public void AddParticipant(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Participant cannot be null.");
            }

            Participants.Add(student);
        }

        public bool RemoveParticipant(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Participant cannot be null.");
            }

            return Participants.Remove(student);
        }

        public override string ToString()
        {
            return $"{Name} scheduled for {Date:MMMM dd, yyyy}, with {Participants.Count} participant(s): {string.Join(", ", Participants)}.";
        }
    }
}
