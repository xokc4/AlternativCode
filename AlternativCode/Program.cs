using System;
using System.Collections.Generic;

namespace AlternativCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var vacationDictionary = InitializeVacationDictionary();
            FillVacationDates(vacationDictionary);
            PrintVacationDates(vacationDictionary);

            Console.ReadKey();
        }

        /// <summary>
        /// Метод для  словаря сотрудников и их отпусков
        /// </summary>
        /// <returns></returns>
        static Dictionary<string, List<DateTime>> InitializeVacationDictionary()
        {
            return new Dictionary<string, List<DateTime>>
            {
                ["Иванов Иван Иванович"] = new List<DateTime>(),
                ["Петров Петр Петрович"] = new List<DateTime>(),
                ["Юлина Юлия Юлиановна"] = new List<DateTime>(),
                ["Сидоров Сидор Сидорович"] = new List<DateTime>(),
                ["Павлов Павел Павлович"] = new List<DateTime>(),
                ["Георгиев Георг Георгиевич"] = new List<DateTime>()
            };
        }

        /// <summary>
        /// Метод для заполнения отпусков для каждого сотрудника
        /// </summary>
        /// <param name="vacationDictionary"></param>
        static void FillVacationDates(Dictionary<string, List<DateTime>> vacationDictionary)
        {
            var random = new Random();
            var workingDaysOfWeek = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
                                                           DayOfWeek.Thursday, DayOfWeek.Friday };

            foreach (var employee in vacationDictionary.Keys)
            {
                var vacationCount = 28;//количество дней отпуска для сотрудника,
                var currentDate = new DateTime(DateTime.Now.Year, 1, 1);// начальная дата отпуска (1 января текущего года).

                while (vacationCount > 0)
                {
                    var randomDate = currentDate.AddDays(random.Next((int)(DateTime.Today - currentDate).TotalDays));

                    if (workingDaysOfWeek.Contains(randomDate.DayOfWeek))// проверка на рабочий день
                    {
                        var vacationDuration = random.Next(1, Math.Min(8, vacationCount + 1));//создается отпуск не превышая 7 дней

                        for (int i = 0; i < vacationDuration; i++) // продолжается для все сотрудников
                        {
                            vacationDictionary[employee].Add(randomDate.AddDays(i));
                        }

                        vacationCount -= vacationDuration;
                    }
                }
            }
        }

        // Метод для вывода информации о днях отпуска для каждого сотрудника
        static void PrintVacationDates(Dictionary<string, List<DateTime>> vacationDictionary)
        {
            foreach (var employee in vacationDictionary)
            {
                Console.WriteLine($"Дни отпуска {employee.Key}: ");
                foreach (var vacationDate in employee.Value)
                {
                    Console.WriteLine(vacationDate.ToShortDateString());
                }
                Console.WriteLine();
            }
        }
    }
}
