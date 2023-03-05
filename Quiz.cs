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
                    QuestionText = "What should a Javanese couple do in order to get married?",
                    Points = 5,
                    CorrectAnswer = "Plant 5 trees",
                    Option1 = "Plant 5 trees",
                    Option2 = "ree 5 birds",
                    Option3 = "Free 5 animals",
                    Option4 = "Visit 5 countries"
                },
                new MultipleChoiceQuestion
                {
                    QuestionText = "Baigue is a type of which sport popular among Turkish people?",
                    Points = 5,
                    CorrectAnswer = "Volleyball",
                    Option1 = "Volleyball",
                    Option2 = "Cycling",
                    Option3 = "Martial Art",
                    Option4 = "Horse racing"
                },
                new MultipleChoiceQuestion
                {
                    QuestionText = "Which mountain range gets its name from the Sanskrit language meaning ‘abode of snow’?",
                    Points = 5,
                    CorrectAnswer = "Himalayas",
                    Option1 = "Karakoram",
                    Option2 = "Hindukush",
                    Option3 = "Ural",
                    Option4 = "Himalayas"
                },
                new MultipleChoiceQuestion
                {
                    QuestionText = "Which singer made the “Moonwalk” dance famous?",
                    Points = 5,
                    CorrectAnswer = "Michael Jackson",
                    Option1 = "James Brown",
                    Option2 = "Elvis Presley",
                    Option3 = "Michael Jackson",
                    Option4 = "Justin Bieber"
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
                Title = "Multiple Choise Question";
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
                Title = "True/False Question";
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
