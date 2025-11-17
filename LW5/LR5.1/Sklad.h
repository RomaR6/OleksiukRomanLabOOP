#ifndef SKLAD_H
#define SKLAD_H

#include <vector>
#include <string>
#include "Tovar.h"

class Sklad {
private:
    std::string name;
    std::vector<Tovar*> items;

public:
    Sklad(const std::string& n);
    void AddItem(Tovar* item);
    void ShowContents() const;
    std::string getName() const;
    bool containsItem(const Tovar* item) const;
};

#endif