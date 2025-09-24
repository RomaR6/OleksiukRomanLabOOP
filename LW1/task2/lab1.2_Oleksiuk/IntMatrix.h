/*6.	Створити клас для роботи з двовимірним масивом цілих чисел.Розробити наступні елементи класу :
o	Поля :
	int[, ] IntIntArrayay;
	int n.
o	Конструктор, що дозволяє створити масив розмірності nЧn.
o	Методи, що дозволяють :
	ввести елементи масиву з клавіатури;
	вивести елементи масиву на екран;
	обчислити суму элеметов i - того стовпця.
o	Властивості :
	які надають можливість  обчислити кількість нульових елементів в масиві(доступне тільки для читання);
	які надають можливість  встановити значення всіх елементи головної діагоналі масиву рівне скаляру(доступне тільки для запису).
 */
#pragma once
#include <iostream>
using namespace std;

class IntMatrix
{
private:
    int** IntArray;
    int n;

public:
    IntMatrix(int size);
    ~IntMatrix();

    void input();
    void output();
    int sumOfColumn(int col) const;
    int getZeroCount() const;
    void setMainDiagonal(int value);
};
