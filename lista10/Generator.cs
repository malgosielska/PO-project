using lista10.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using lista10.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lista10
{
    public class TimetableGenerator
    {
        private readonly Random random = new Random();

        public List<Lesson> GenerateTimetable(Class givenClass, MyDbContext context)
        {
            // Pobierz wszystkie lekcje dla danej klasy
            var classSchedule = GetClassSchedule(givenClass, context);

            // Przygotuj strukturę planu lekcji
            var timetable = new List<Lesson>();
            var counter = 0;

            for (int i = 0; i <40; i++){
               var dayOfWeek = random.Next(1, 6);
               var hour = random.Next(1, 9);
               var lessons = classSchedule
                    .Where(s => s.Hours > 0)
                    .ToList();

                if (lessons.Any())
                {
                    var availableLessons = lessons
                        .Where(l => !timetable.Any(t => t.DayOfWeek == dayOfWeek && t.Hour == hour))
                        .ToList();

                    while (!availableLessons.Any())
                    {
                        dayOfWeek = random.Next(1, 6);
                        hour = random.Next(1, 9);
                        availableLessons = lessons
                            .Where(l => !timetable.Any(t => t.DayOfWeek == dayOfWeek && t.Hour == hour))
                            .ToList();
                    }
                    if (availableLessons.Any())
                    {
                        var randomLesson = availableLessons[random.Next(availableLessons.Count())];
                        var teacher = GetTeacherForSubject(randomLesson.SubjectId, context);
                        var subject = GetSubjectWithGivenId(randomLesson.SubjectId, context);

                        if (randomLesson.SubjectId != 0)
                        {
                            timetable.Add(new Lesson
                            {
                                LessonId = counter++,
                                DayOfWeek = dayOfWeek,
                                Hour = hour,
                                ClassName = givenClass,
                                Subject = subject,
                                Teacher = teacher
                            });
                        }
                        randomLesson.Hours--;
                    }
                }
            }

            return timetable;
        }

        private Subject GetSubjectWithGivenId(int subjectId, MyDbContext context)
        {
            return context.Subject.FirstOrDefault(s => s.SubjectId == subjectId);
        }

        private Teacher GetTeacherForSubject(int subjectId, MyDbContext context)
        {
            
            var teachersForSubject = context.Teacher
             .Where(t => t.SubjectId == subjectId)
             .ToList();

            if (teachersForSubject.Any())
            {
                // Wybierz losowego nauczyciela z danego przedmiotu
                return teachersForSubject[random.Next(teachersForSubject.Count)];
            }
            else
            {
                // Jeśli nie ma nauczyciela dla danego przedmiotu, przypisz losowego nauczyciela z innych przedmiotów
                var allTeachers = context.Teacher.ToList();
                return allTeachers[random.Next(allTeachers.Count)];
            }
        }

        private List<Schedule> GetClassSchedule(Class givenClass, MyDbContext context)
        {
            // Pobierz lekcje dla danej klasy
            // Tutaj należy dostosować do swojej bazy danych
            // Poniżej jest przykładowa implementacja
            
            return context.Schedule
                .Where(s => s.Class == givenClass)
                .ToList();
            
        }
    }
}