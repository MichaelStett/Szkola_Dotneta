using System;

using static System.Console;

namespace Quiz
{
    public class Answer
    {
        public string Text { get; set; }
        public bool IsRight { get; set; }

        public override string ToString()
        {
            return $"{Text}";
        }
    }

    public class Question
    {
        public string Text { get; set; }

        public Answer[] Answers { get; set; }

        public override string ToString()
        {
            return $"{Text}? \n{ string.Join("\n", (object[])Answers)}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var questions = new Question[]
            {
                new Question
                {
                    Text = "Q1",
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            Text = "a) A1",
                            IsRight = false
                        },
                        new Answer
                        {
                            Text = "b) A2",
                            IsRight = true
                        },
                        new Answer
                        {
                            Text = "c) A3",
                            IsRight = false
                        },
                        new Answer
                        {
                            Text = "d) A4",
                            IsRight = false
                        },
                    },
                },
                new Question
                {
                    Text = "Q2",
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            Text = "a) A1",
                            IsRight = false
                        },
                        new Answer
                        {
                            Text = "b) A2",
                            IsRight = false
                        },
                        new Answer
                        {
                            Text = "c) A3",
                            IsRight = true
                        },
                        new Answer
                        {
                            Text = "d) A4",
                            IsRight = false
                        },
                    },
                },
                new Question
                {
                    Text = "Q3",
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            Text = "a) A1",
                            IsRight = false
                        },
                        new Answer
                        {
                            Text = "b) A2",
                            IsRight = false
                        },
                        new Answer
                        {
                            Text = "c) A3",
                            IsRight = false
                        },
                        new Answer
                        {
                            Text = "d) A4",
                            IsRight = true
                        },
                    },
                },
                new Question
                {
                    Text = "Q4",
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            Text = "a) A1",
                            IsRight = true
                        },
                        new Answer
                        {
                            Text = "b) A2",
                            IsRight = false
                        },
                        new Answer
                        {
                            Text = "c) A3",
                            IsRight = false
                        },
                        new Answer
                        {
                            Text = "d) A4",
                            IsRight = false
                        },
                    },
                },
                new Question
                {
                    Text = "Q5",
                    Answers = new Answer[]
                    {
                        new Answer
                        {
                            Text = "a) A1",
                            IsRight = false
                        },
                        new Answer
                        {
                            Text = "b) A2",
                            IsRight = false
                        },
                        new Answer
                        {
                            Text = "c) A3",
                            IsRight = true
                        },
                        new Answer
                        {
                            Text = "d) A4",
                            IsRight = false
                        },
                    },
                },
            };

            var points = 0;

            foreach (var question in questions)
            {
                WriteLine(question);
                var input = ReadKey().KeyChar;
                var expected = ' ';

                foreach (var answer in question.Answers)
                {
                    if (answer.IsRight)
                    {
                        expected = answer.Text[0];
                        break;
                    }
                }

                if (input == expected)
                {
                    WriteLine("\nGood answer!");
                    points++;
                } 
                else
                {
                    WriteLine("\nBad answer!");
                }
            }

            WriteLine($"Score: {Math.Round((decimal)points / questions.Length * 100, 2)}%");
        }
    }
}
