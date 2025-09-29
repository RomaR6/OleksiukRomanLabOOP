#include "Exam.h"
#include <iostream>
using namespace std;

Exam::Exam()
{
    setName("");
    setDate(1);
    setGrade(1);
    cout << "Default constructor called " << this << endl;
}

Exam::Exam(std::string n, int d, int g)
{
    setName(n);
    setDate(d);
    setGrade(g);
    cout << "Parameterized constructor called " << this << endl;
}

Exam::Exam(const Exam& other)
{
    setName(other.name);
    setDate(other.date);
    setGrade(other.grade);
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
    if (!n.empty())
        name = n;
    else
        name = "Unknown";
}

void Exam::setDate(int d)
{
    if (d >= 1 && d <= 30)
        date = d;
    else
        date = 1;
}

void Exam::setGrade(int g)
{
    if (g >= 1 && g <= 5)
        grade = g;
    else
        grade = 1;
}

void Exam::printExam()
{
    cout << "Name: " << name << "\n";
    cout << "Date: " << date << "\n";
    cout << "Grade: " << grade << "\n";
}

void Exam::setExam(std::string n, int d, int g)
{
    setName(n);
    setDate(d);
    setGrade(g);
}
