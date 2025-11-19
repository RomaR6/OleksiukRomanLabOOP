#include <iostream>
#include <vector>
#include <list>      
#include <algorithm>
#include <iterator> 
#include <Windows.h>

using namespace std;

void ShowVector(const vector<int>& v);
void ShowList(const list<int>& l);

int main()
{
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

    
    cout << "\n ЧАСТИНА 1: КОНТЕЙНЕР VECTOR \n";

    
    vector<int> v;
    int n;
    cout << "Введіть кількість елементів для вектора: ";
    cin >> n;

    cout << "Введіть " << n << " цілих чисел: ";
    for (int i = 0; i < n; i++) {
        int num;
        cin >> num;
        v.push_back(num);
    }

    
    cout << "Вміст вектора: ";
    ShowVector(v);

    
    if (!v.empty()) {
        
        int delIndex;
        cout << "\n Введіть індекс для ВИДАЛЕННЯ (0 - " << v.size() - 1 << "): ";
        cin >> delIndex;
        if (delIndex >= 0 && delIndex < v.size()) {
            v.erase(v.begin() + delIndex);
            cout << "Елемент видалено.\n";
        }

        
        if (!v.empty()) {
            int repIndex, newVal;
            cout << " Введіть індекс для ЗАМІНИ (0 - " << v.size() - 1 << "): ";
            cin >> repIndex;
            if (repIndex >= 0 && repIndex < v.size()) {
                cout << "Введіть нове значення: ";
                cin >> newVal;
                v.at(repIndex) = newVal; 
                cout << "Елемент замінено.\n";
            }
        }
    }

    
    cout << "Фінальний вектор (через ітератори): ";
    for (auto it = v.begin(); it != v.end(); ++it) {
        cout << *it << " ";
    }
    cout << "\n Фінальний вектор\n";


   
    cout << " ЧАСТИНА 2: КОНТЕЙНЕР LIST \n";

    
    list<int> l;
    cout << "Введіть кількість елементів для списку: ";
    cin >> n;

    cout << "Введіть " << n << " цілих чисел: ";
    for (int i = 0; i < n; i++) {
        int num;
        cin >> num;
        l.push_back(num);
    }

    
    cout << "Вміст списку: ";
    ShowList(l);

    
    if (!l.empty()) {
        
        int delPos;
        cout << "\n Введіть позицію для ВИДАЛЕННЯ зі списку (0 - " << l.size() - 1 << "): ";
        cin >> delPos;

        if (delPos >= 0 && delPos < l.size()) {
            auto it = l.begin();
            std::advance(it, delPos); 
            l.erase(it);
            cout << "Елемент зі списку видалено.\n";
        }

        
        if (!l.empty()) {
            int repPos, newVal;
            cout << " Введіть позицію для ЗАМІНИ у списку (0 - " << l.size() - 1 << "): ";
            cin >> repPos;

            if (repPos >= 0 && repPos < l.size()) {
                cout << "Введіть нове значення: ";
                cin >> newVal;

                auto it = l.begin();
                std::advance(it, repPos); 
                *it = newVal; 
                cout << "Елемент у списку замінено.\n";
            }
        }
    }

   
    cout << "Фінальний список (через ітератори): ";
    for (auto it = l.begin(); it != l.end(); ++it) {
        cout << *it << " ";
    }
    cout << endl;

    return 0;
}


void ShowVector(const vector<int>& v) {
    if (v.empty()) {
        cout << "(Порожньо)" << endl;
        return;
    }
    for (int x : v) cout << x << " ";
    cout << endl;
}


void ShowList(const list<int>& l) {
    if (l.empty()) {
        cout << "(Порожньо)" << endl;
        return;
    }
    for (int x : l) cout << x << " ";
    cout << endl;
}