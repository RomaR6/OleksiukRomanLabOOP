#include <windows.h>
#include <vector>
#include <iomanip>
#include <sstream>
#include "Database.h"
#include "Produkt.h"
#include "Partia.h"
#include "Komplekt.h"
#include "Sklad.h"

void showFullReport(const std::vector<Sklad*>& allSklady) {
    const auto& allItems = Database::getItems();
    if (allItems.empty()) {
        std::cout << "База даних порожня. Нічого показувати.\n";
        return;
    }
    
    std::cout << "\n" << std::string(115, '-') << "\n";
    std::cout << "| " << std::setw(25) << std::left << "Базові поля (Назва, Ціна)"
        << "| " << std::setw(15) << std::left << "Тип об'єкта"
        << "| " << std::setw(30) << std::left << "Агрегація (знаходиться у)"
        << "| " << std::setw(35) << std::left << "Композиція (склад)"
        << "|\n";
    std::cout << std::string(115, '-') << "\n";

    for (const auto& item : allItems) {
        std::stringstream priceStream;
        priceStream << std::fixed << std::setprecision(2) << item->getPrice();
        std::string baseInfo = item->getName() + " (" + priceStream.str() + " UAH)";
        std::cout << "| " << std::setw(25) << std::left << baseInfo;

        std::cout << "| " << std::setw(15) << std::left << item->getType();

        std::string aggregationInfo;
        for (const auto& sklad : allSklady) {
            if (sklad->containsItem(item.get())) {
                aggregationInfo += sklad->getName() + "; ";
            }
        }
        if (aggregationInfo.empty()) {
            aggregationInfo = "N/A";
        }
        std::cout << "| " << std::setw(30) << std::left << aggregationInfo;

        std::string compositionInfo = "N/A";
        if (Komplekt* komplekt = dynamic_cast<Komplekt*>(item.get())) {
            compositionInfo = komplekt->getComponentsInfo();
        }
        std::cout << "| " << std::setw(35) << std::left << compositionInfo << "|\n";
    }
    std::cout << std::string(115, '-') << "\n";
}

void show_menu() {
    std::cout << "\n--- ГОЛОВНЕ МЕНЮ --- \n"
        << "1. Додати продукт\n"
        << "2. Додати партію товару\n"
        << "3. Додати комплект\n"
        << "--------------------------\n"
        << "4. Показати всі товари в базі\n"
        << "5. Знайти прострочені товари\n"
        << "--------------------------\n"
        << "6. Показати склад продуктів\n"
        << "7. Показати склад партій\n"
        << "8. Показати склад комплектів\n"
        << "--------------------------\n"
        << "9. ПОКАЗАТИ ПОВНИЙ ЗВІТ\n"
        << "--------------------------\n"
        << "0. Вихід\n"
        << "Ваш вибір: ";
}

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    setlocale(LC_ALL, "Ukrainian");

    Sklad skladProduktiv("Склад продуктів");
    Sklad skladPartiy("Склад партій");
    Sklad skladKomplektiv("Склад комплектів");

    std::vector<Sklad*> allSklady = { &skladProduktiv, &skladPartiy, &skladKomplektiv };

    int choice;
    do {
        show_menu();
        std::cin >> choice;

        switch (choice) {
        case 1: {
            auto produkt = std::make_unique<Produkt>();
            produkt->init();
            skladProduktiv.AddItem(produkt.get());
            Database::Add(std::move(produkt));
            break;
        }
        case 2: {
            auto partia = std::make_unique<Partia>();
            partia->init();
            skladPartiy.AddItem(partia.get());
            Database::Add(std::move(partia));
            break;
        }
        case 3: {
            auto komplekt = std::make_unique<Komplekt>();
            komplekt->init();
            skladKomplektiv.AddItem(komplekt.get());
            Database::Add(std::move(komplekt));
            break;
        }
        case 4:
            std::cout << "\n--- ВСІ ТОВАРИ В БАЗІ ДАНИХ ---\n";
            Database::ShowAll();
            break;
        case 5:
            Database::FindExpired();
            break;
        case 6:
            skladProduktiv.ShowContents();
            break;
        case 7:
            skladPartiy.ShowContents();
            break;
        case 8:
            skladKomplektiv.ShowContents();
            break;
        case 9:
            showFullReport(allSklady);
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