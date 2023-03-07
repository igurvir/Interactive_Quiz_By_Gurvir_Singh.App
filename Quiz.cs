using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Quiz_By_Gurvir_Singh
{
    public class Quiz
    {
        private List<Question> _questionList = new List<Question>();

        public int _currentQuestionIndex = -1;
        public Question _currentQuestion;
        public string Title { get; set; }
        private int _score;
        public int _UserquestionCount = 0;
        public int CorrectCount = 0;
        public int Score
        {
            get { return _score; }
            private set { _score = value; }
        }
        public Quiz()
        {
            LoadQuestion();
        }
        private void LoadQuestion()
        {
            List<Question> questions = new List<Question>
            {
                new MultipleChoiceQuestion
                {
                    QuestionText = "Which country features a shipwreck on its national flag?",
                    Points = 5,
                    CorrectAnswer = "Bermuda",
                    Option1 = "Bermuda",
                    Option2 = "Denmark",
                    Option3 = "Russia",
                    Option4 = "China"
                },
                new MultipleChoiceQuestion
                {
                    QuestionText = "Which is capital of Pero?",
                    Points = 5,
                    CorrectAnswer = "Lima",
                    Option1 = "Kingston",
                    Option2 = "Lima",
                    Option3 = "Tirana",
                    Option4 = "Yerevan"
                },
                new MultipleChoiceQuestion
                {
                    QuestionText = "What is the Capital of East Timor?",
                    Points = 5,
                    CorrectAnswer = "Dili",
                    Option1 = "Dili",
                    Option2 = "Ottawa",
                    Option3 = "Seoul",
                    Option4 = "Bangkok"
                },
                new MultipleChoiceQuestion
                {
                    QuestionText = "The Capital of Irealand is?",
                    Points = 5,
                    CorrectAnswer = "Dublin",
                    Option1 = "Asmara",
                    Option2 = "Banjul",
                    Option3 = "Paris",
                    Option4 = "Dublin"
                },
                new MultipleChoiceQuestion
                {
                    QuestionText = "Windhoek is the capital of?",
                    Points = 5,
                    CorrectAnswer = "Namibia",
                    Option1 = "Namibia",
                    Option2 = "Niger",
                    Option3 = "Chad",
                    Option4 = "Ghana"
                },
                new TrueFalseQuestion
                {
                    QuestionText = "Christianity is the third biggest religion in India",
                    Points = 3,
                    CorrectAnswer = "true"
                },
                new TrueFalseQuestion
                {
                    QuestionText = "Gandhi was the first Prime Minister of India",
                    Points = 3,
                    CorrectAnswer = "false"
                },
                new TrueFalseQuestion
                {
                    QuestionText = "Cricket is the National sport of India",
                    Points = 3,
                    CorrectAnswer = "false"
                },
                new TrueFalseQuestion
                {
                    QuestionText = "India is the world’s largest producer of bananas",
                    Points = 3,
                    CorrectAnswer = "true"
                },
                new TrueFalseQuestion
                {
                    QuestionText = "Around 82% of Indian households keep a pet elephant",
                    Points = 3,
                    CorrectAnswer = "false"
                }

            };
            Random rand = new Random();
            for (int i = questions.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                var temp = questions[i];
                questions[i] = questions[j];
                questions[j] = temp;
            }
            _questionList = questions;
            _currentQuestion = GetNextQuestion();

        }
        public Question GetNextQuestion()
        {
            _currentQuestionIndex++;
            return GetQuestionWithoutAnswer();


        }
        private Question GetQuestionWithoutAnswer()
        {

            if (_currentQuestionIndex >= _questionList.Count)
            {
                return null;
            }

            var question = _questionList[_currentQuestionIndex];


            if (question is MultipleChoiceQuestion mcq)
            {
                var newQuestion = new MultipleChoiceQuestion
                {
                    QuestionText = mcq.QuestionText,
                    Points = mcq.Points,
                    Option1 = mcq.Option1,
                    Option2 = mcq.Option2,
                    Option3 = mcq.Option3,
                    Option4 = mcq.Option4,
                };
                Title = "MCQs";
                return newQuestion;
            }
            else if (question is TrueFalseQuestion tfq)
            {
                var newQuestion = new MultipleChoiceQuestion
                {
                    QuestionText = tfq.QuestionText,
                    Points = tfq.Points,
                    Option1 = "true",
                    Option2 = "false",
                };
                Title = "True/False";
                return newQuestion;
            }
            else
            {
                throw new InvalidOperationException("Invalid question type.");
            }
        }
        public bool CheckAnswer(string answer)
        {
            _UserquestionCount++;
            var question = _questionList[_currentQuestionIndex];
            var isCorrect = question.CorrectAnswer.Equals(answer, StringComparison.OrdinalIgnoreCase);
            if (isCorrect)
            {
                CorrectCount++;
                Score += question.Points;
            }
            return isCorrect;

        }
    }
}
