/* ЛР.ОК19.ПІ231.01.06
* 6.ІСПИТ
ім'я студента-string
дата - int
оцінка- int

*/

#include <iostream>
#include "Exam.h"
using namespace std;
void print(Exam ex)
{
	cout << "print function called\n";
	ex.printExam();
}
int main()
{
	Exam ex("oleksiuk", 20, 5);	
	Exam ex1("ivanov", 21, 4);
	ex.printExam();
	ex1.printExam();
	return 0;

}


