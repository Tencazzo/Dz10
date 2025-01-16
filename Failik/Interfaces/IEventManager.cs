using System;
using System.Collections.Generic;
using Failik.Classes;

namespace Failik.Interfaces
{
        public interface IEventManager
        {
            void AddStudent(Student student);
            void CreateEvent(string eventName, DateTime eventDate, int participantsPerGroup, List<string> preferences);
        }
}
