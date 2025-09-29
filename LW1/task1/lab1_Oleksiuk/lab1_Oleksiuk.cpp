#include <iostream>
#include "Exam.h"
using namespace std;

void print(Exam* ex)
{
    cout << "print function called\n";
    ex->printExam();
}

int main()
{
    Exam* ex = new Exam("oleksiuk", 20, -5);  
    Exam* ex1 = new Exam("", 50, 4);          
    Exam* ex2 = new Exam("ivanov", 21, 4);

    ex->printExam();
    ex1->printExam();
    ex2->printExam();

    cout << "-------------------\n";
    print(ex2);

    delete ex;
    delete ex1;
    delete ex2;

    return 0;
}
