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



#include <iostream>
#include "IntMatrix.h"
using namespace std;

int main()
{
    int n;
    cout << "Enter the size of the matrix (n x n): ";
    cin >> n;

    IntMatrix matrix(n);
    matrix.input();
    matrix.output();

    int col;
    cout << "Enter the column index to sum (0 to " << n - 1 << "): ";
    cin >> col;
    int sum = matrix.sumOfColumn(col);
    cout << "Sum of column " << col << ": " << sum << endl;

    int zeroCount = matrix.getZeroCount();
    cout << "Number of zero elements in the matrix: " << zeroCount << endl;

    int diagValue;
    cout << "Enter the value to set on the main diagonal: ";
    cin >> diagValue;
    matrix.setMainDiagonal(diagValue);

    matrix.output();

    return 0;
}
