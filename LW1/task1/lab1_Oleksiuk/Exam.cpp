/* ЛР.ОК19.ПІ231.01.06
* 6.ІСПИТ
ім'я студента-string
дата - int
оцінка- int

*/

#include "Exam.h"
#include <iostream>
using namespace std;

Exam::Exam() : name(""), date(0), grade(0)
{
    cout << "Default constructor called " << this << endl;
}

Exam::Exam(std::string n, int d, int g) : name(n), date(d), grade(g)
{
    cout << "Parameterized constructor called " << this << endl;
}

Exam::Exam(const Exam& other) : name(other.name), date(other.date), grade(other.grade)
{
    cout << "Copy constructor called " << this << endl;
}

Exam::~Exam()
{
    cout << "Destructor called " << this << endl;
}

std::string Exam::getName()
{
    return name;
}

int Exam::getDate()
{
    return date;
}

int Exam::getGrade()
{
    return grade;
}

void Exam::setName(std::string n)
{
    name = n;
}

void Exam::setDate(int d)
{
    date = d;
}

void Exam::setGrade(int g)
{
    grade = g;
}

void Exam::printExam()
{
    cout << "Name: " << name << "\n";
    cout << "Date: " << date << "\n";
    cout << "Grade: " << grade << "\n";
}

void Exam::setExam(std::string n, int d, int g)
{
    name = n;
    date = d;
    grade = g;
}
