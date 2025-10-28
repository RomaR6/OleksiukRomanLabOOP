#include <windows.h>
#include <iostream>
#include <string>
#include "Library.h"
#include "Book.h"
#include "Textbook.h"
#include "Magazine.h"

void show_menu() {
    std::cout << "\n--- МЕНЮ БІБЛІОТЕКИ --- \n"
        << "1. Додати книгу\n"
        << "2. Додати підручник\n"
        << "3. Додати журнал\n"
        << "4. Показати всі видання\n"
        << "5. Знайти видання за назвою\n"
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
            PrintedEdition* book = new Book();
            book->init();
            Library::Add(book);
            break;
        }
        case 2: {
            PrintedEdition* textbook = new Textbook();
            textbook->init();
            Library::Add(textbook);
            break;
        }
        case 3: {
            PrintedEdition* magazine = new Magazine();
            magazine->init();
            Library::Add(magazine);
            break;
        }
        case 4:
            Library::ShowAll();
            break;
        case 5: {
            std::string title;
            std::cout << "Введіть назву для пошуку: ";
            
            std::cin.ignore(1024, '\n');
            getline(std::cin, title);
            Library::FindByTitle(title);
            break;
        }
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