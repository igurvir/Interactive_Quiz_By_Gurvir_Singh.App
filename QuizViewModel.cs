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
        public string Option1
        {
            get { return CurrentQuestion.Option1; }
        }

        public string Option2
        {
            get { return CurrentQuestion.Option2; }
        }

        public string Option3
        {
            get { return CurrentQuestion.Option3; }
        }

        public string Option4
        {
            get { return CurrentQuestion.Option4; }
        }
        public bool buttonDisable
        {
            get { return !string.IsNullOrEmpty(CurrentQuestion.Option3) && !string.IsNullOrEmpty(CurrentQuestion.Option4) ? true : false; }
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
        }
        public void Option2_Clicked()
        {
        }
        public void Option3_Clicked()
        {
        }
        public void Option4_Clicked()
        {
        }
        private void NextQuestion()
        {
            _quiz._currentQuestion = _quiz.GetNextQuestion();

            NotifyPropertyChanged(nameof(CurrentQuestion));
            if (string.IsNullOrEmpty(CurrentQuestion.Option3) && string.IsNullOrEmpty(CurrentQuestion.Option4))
            {
                _quiz.Title = "True/False Question";

            }
            else
            {
                _quiz.Title = "Multiple Choice Question Question";
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("QuestionText"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Option1"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Option2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Option3"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Option4"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("buttonDisable"));
        }
        private async void QuitQuiz()
        {
            await Application.Current.MainPage.DisplayAlert("Result", "You got " + _quiz.CorrectCount + " correct answers out of " + _quiz._UserquestionCount + "", "OK");
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
