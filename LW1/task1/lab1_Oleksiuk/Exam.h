#pragma once
#include <string>

class Exam
{
private:
    std::string name;
    int date;
    int grade;

public:
    Exam();
    Exam(std::string name, int date, int grade);
    Exam(const Exam& other);
    ~Exam();

    std::string getName();
    int getDate();
    int getGrade();

    void setExam(std::string name, int d, int g);
    void setName(std::string name);
    void setDate(int date);
    void setGrade(int grade);

    void printExam();
};
