using System;

namespace Failik.Classes
{
    using System;

    public class Person
    {
        public string Name { get; }
        public string Hobby { get; }

        private static readonly Random RandomGenerator = new Random();
        private static readonly string[] Reactions =
        {
        "Я ждал(а) это событие! {0} - это именно то, что я люблю!",
        "В восторге от {0}!",
        "Не могу дождаться {0}!"
    };

        public Person(string name, string hobby)
        {
            Name = string.IsNullOrWhiteSpace(name)
                ? throw new ArgumentException("Имя не может быть пустым или null.", nameof(name))
                : name;

            Hobby = string.IsNullOrWhiteSpace(hobby)
                ? throw new ArgumentException("Хобби не может быть пустым или null.", nameof(hobby))
                : hobby;
        }

        public string GetReaction(string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName))
            {
                throw new ArgumentException("Название события не может быть пустым или null.", nameof(eventName));
            }

            var reactionTemplate = Reactions[RandomGenerator.Next(Reactions.Length)];
            return $"{Name} говорит: '{string.Format(reactionTemplate, eventName)}'";
        }
    }
}
