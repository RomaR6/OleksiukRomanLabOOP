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
#include "IntMatrix.h"
#include <iostream>
using namespace std;

IntMatrix::IntMatrix(int size) : n(size)
{
    IntArray = new int* [n];
    for (int i = 0; i < n; ++i)
        IntArray[i] = new int[n] {};
}

IntMatrix::~IntMatrix()
{
    for (int i = 0; i < n; ++i)
        delete[] IntArray[i];
    delete[] IntArray;
}

void IntMatrix::input()
{
    cout << "Enter elements of the matrix (" << n << "x" << n << "):\n";
    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j) {
            cout << "Element [" << i << "][" << j << "]: ";
            cin >> IntArray[i][j];
        }
}

void IntMatrix::output()
{
    cout << "Matrix elements:\n";
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < n; ++j)
            cout << IntArray[i][j] << " ";
        cout << endl;
    }
}

int IntMatrix::sumOfColumn(int col) const
{
    if (col < 0 || col >= n) {
        cout << "Column index out of bounds.\n";
        return 0;
    }
    int sum = 0;
    for (int i = 0; i < n; ++i)
        sum += IntArray[i][col];
    return sum;
}

int IntMatrix::getZeroCount() const
{
    int count = 0;
    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j)
            if (IntArray[i][j] == 0)
                ++count;
    return count;
}

void IntMatrix::setMainDiagonal(int value)
{
    for (int i = 0; i < n; ++i)
        IntArray[i][i] = value;
}
