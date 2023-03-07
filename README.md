This is a simple quiz application developed using object-oriented programming (OOP) principles in C#. The application consists of several classes that work together to produce a functioning quiz, with a user interface built using XAML. The Quiz application is developed using .NET MAUI framework which enables building cross-platform applications.
Getting started:
To get started with the Quiz application, follow the below steps:
1.	Clone the repository from GitHub or download the ZIP file.
2.	Open the solution file in Visual Studio 2022 or later.
3.	Build the solution to restore the required NuGet packages.
4.	Run the application in the desired platform-specific emulator or simulator.
Classes:
The Quiz application consists of several classes that work together to produce a functioning quiz.
1.	Question class: This is the base class that represents a question.
2.	MultipleChoiceQuestion class: This is a child class that inherits from the Question class. It represents a multiple-choice question.
3.	TrueFalseQuestion class: This is a child class that inherits from the Question class. It represents a true/false question.
4.	Quiz class: This class is responsible for managing the quiz and tracking the user's progress. It contains a list of questions, checks user answers, and tracks the user's score.
User interface:
The user interface of the Quiz application is built using XAML. It consists MainPage that allow the user to take the quiz and see their score at the end.
Conclusion:
The Quiz application is a good exercise in OOP principles and provides a useful introduction to building simple applications in MAUI. It demonstrates how to create classes, inherit from base classes, and build a user interface using XAML. The application can be further enhanced by adding new question types, implementing a timer, or storing quiz data in a database.
