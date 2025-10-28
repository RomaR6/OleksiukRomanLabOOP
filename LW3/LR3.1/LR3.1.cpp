#include <windows.h> 
#include "Database.h"
#include "Produkt.h"
#include "Partia.h"
#include "Komplekt.h"

void show_menu() {
    std::cout << "\n--- МЕНЮ --- \n"
        << "1. Додати продукт\n"
        << "2. Додати партію товару\n"
        << "3. Додати комплект\n"
        << "4. Показати всі товари\n"
        << "5. Знайти прострочені товари\n"
        << "0. Вихід\n"
        << "Ваш вибір: ";
}

int main() {
    
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    setlocale(LC_ALL, "Ukrainian");

    int choice;
    do {
        show_menu();
        std::cin >> choice;

        switch (choice) {
        case 1: {
            auto produkt = std::make_unique<Produkt>();
            produkt->init();
            Database::Add(std::move(produkt));
            break;
        }
        case 2: {
            auto partia = std::make_unique<Partia>();
            partia->init();
            Database::Add(std::move(partia));
            break;
        }
        case 3: {
            auto komplekt = std::make_unique<Komplekt>();
            komplekt->init();
            Database::Add(std::move(komplekt));
            break;
        }
        case 4:
            Database::ShowAll();
            break;
        case 5:
            Database::FindExpired();
            break;
        case 0:
            std::cout << "Завершення роботи.\n";
            break;
        default:
            std::cout << "Невірний вибір. Спробуйте ще раз.\n";
            break;
        }
    } while (choice != 0);

    return 0;
}