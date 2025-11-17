#ifndef DATABASE_H
#define DATABASE_H

#include "Tovar.h"
#include <vector>
#include <memory>

class Database {
private:
    static std::vector<std::unique_ptr<Tovar>> items;

public:
    static void Add(std::unique_ptr<Tovar> item);
    static void ShowAll();
    static void FindExpired();
    static const std::vector<std::unique_ptr<Tovar>>& getItems();
};

#endif