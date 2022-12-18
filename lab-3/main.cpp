#include <iostream>
#include <vector>

using namespace std;

class object{
public:
    object(){
        cout << "Конструктор по умолчанию класса object" << endl;
    }

    ~object() {
        cout << "Диструктор класса object" << endl;
    }
    virtual void name_yourself(){
        cout << "yooou Object" << endl;
    }
};




int main() {
   


    return 0;
}
