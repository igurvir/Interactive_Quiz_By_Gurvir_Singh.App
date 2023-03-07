using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interactive_Quiz_By_Gurvir_Singh
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        private Quiz _quiz;
        private ICommand _nextQuestionCommand;
        private ICommand _quitCommand;
        private ICommand _Option1Command;
        private ICommand _Option2Command;
        private ICommand _Option3Command;
        private ICommand _Option4Command;
        private Color _color1 = Colors.LightGray;
        private Color _color2 = Colors.LightGray;
        private Color _color3 = Colors.LightGray;
        private Color _color4 = Colors.LightGray;
        private bool _isEnabled = true;
        private bool _isSubmited = true;
        private bool _resultLabl = false;
        private string _result = string.Empty;
        public QuizViewModel()
        {
            _quiz = new Quiz();
            _nextQuestionCommand = new Command(NextQuestion);
            _quitCommand = new Command(QuitQuiz);
            _Option1Command = new Command(Option1_Clicked);
            _Option2Command = new Command(Option2_Clicked);
            _Option3Command = new Command(Option3_Clicked);
            _Option4Command = new Command(Option4_Clicked);
        }
        public string Title
        {
            get { return _quiz.Title; }
        }
        public bool buttonDisable
        {
            get { return !string.IsNullOrEmpty(CurrentQuestion.Option3) && !string.IsNullOrEmpty(CurrentQuestion.Option4) ? true : false; }
        }
        public bool isEnabled
        {
            get { return _isEnabled; }
        }
        public bool isSubmited
        {
            get { return _isSubmited; }
        }
        public bool resultLabl
        {
            get { return _resultLabl; }
        }
        public string Result
        {
            get { return _result; }
        }
        public Color color1
        {
            get { return _color1; }
        }
        public Color color2
        {
            get { return _color2; }
        }
        public Color color3
        {
            get { return _color3; }
        }
        public Color color4
        {
            get { return _color4; }
        }
        public MultipleChoiceQuestion CurrentQuestion
        {
            get { return (MultipleChoiceQuestion)_quiz._currentQuestion; }
        }
        public ICommand Option1Command
        {
            get { return _Option1Command; }
        }
        public ICommand Option2Command
        {
            get { return _Option2Command; }
        }
        public ICommand Option3Command
        {
            get { return _Option3Command; }
        }
        public ICommand Option4Command
        {
            get { return _Option4Command; }
        }
        public ICommand NextQuestionCommand
        {
            get { return _nextQuestionCommand; }
        }
        public ICommand QuitCommand
        {
            get { return _quitCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Option1_Clicked()
        {
            if (_quiz.CheckAnswer(CurrentQuestion.Option1))
            {
                _color1 = Colors.Green;
            }
            else
            {
                _color1 = Colors.Red;
            }
            _isEnabled = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isEnabled"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("color1"));
        }
        public void Option2_Clicked()
        {
            if (_quiz.CheckAnswer(CurrentQuestion.Option2))
            {
                _color2 = Colors.Green;
            }
            else
            {
                _color2 = Colors.Red;
            }
            _isEnabled = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isEnabled"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("color2"));
        }
        public void Option3_Clicked()
        {
            if (_quiz.CheckAnswer(CurrentQuestion.Option3))
            {
                _color3 = Colors.Green;
            }
            else
            {
                _color3 = Colors.Red;
            }
            _isEnabled = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isEnabled"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("color3"));
        }
        public void Option4_Clicked()
        {
            if (_quiz.CheckAnswer(CurrentQuestion.Option4))
            {
                _color4 = Colors.Green;
            }
            else
            {
                _color4 = Colors.Red;
            }
            _isEnabled = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isEnabled"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("color4"));
        }
        private void NextQuestion()
        {
            _quiz._currentQuestion = _quiz.GetNextQuestion();
            if (_quiz._currentQuestion == null)
            {
                _result=  "You got " + _quiz.CorrectCount + " correct answers out of " + _quiz._UserquestionCount;
                _isSubmited = false;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isSubmited"));
                _quiz._currentQuestion = new MultipleChoiceQuestion();
                _resultLabl = true;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("resultLabl"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
            ResetColor();
            _isEnabled = true;
            NotifyPropertyChanged(nameof(CurrentQuestion));
            if (string.IsNullOrEmpty(CurrentQuestion.Option3) && string.IsNullOrEmpty(CurrentQuestion.Option4))
            {
                _quiz.Title = "True/False";

            }
            else
            {
                _quiz.Title = "MCQs";
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("buttonDisable"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("color1"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("color2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("color3"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("color4"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isEnabled"));

        }
        private void QuitQuiz()
        {
            _result = "You got " + _quiz.CorrectCount + " correct answers out of " + _quiz._UserquestionCount;
            _isSubmited = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isSubmited"));
            _quiz._currentQuestion = new MultipleChoiceQuestion();
            _resultLabl = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("resultLabl"));
        }
        public void ResetColor()
        {
            _color1 = Colors.LightGray;
            _color2 = Colors.LightGray;
            _color3 = Colors.LightGray;
            _color4 = Colors.LightGray;
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
