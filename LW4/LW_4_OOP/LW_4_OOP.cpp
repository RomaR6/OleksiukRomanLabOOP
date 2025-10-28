#include <Windows.h> 
#include "D4.h"      
#include "D5.h"      

int main()
{
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

    cout << "--- Створення об'єкту D4 ---" << endl;
    D4 obj_d4(10, 11, 14);
    cout << "Виклик obj_d4.show(): ";
    obj_d4.show();
    cout << endl << endl;


    cout << "--- Створення об'єкту D5 ---" << endl;
    D5 obj_d5(20, 21, 22, 23, 25);
    cout << "Виклик obj_d5.show(): ";
    obj_d5.show();
    cout << endl << endl;

    cout << "--- Виклик деструкторів ---" << endl;
}