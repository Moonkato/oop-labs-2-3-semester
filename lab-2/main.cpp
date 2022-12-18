#include <iostream>

using namespace std;

class ground_vehicle{
protected:
    int number_of_wheels;
    string color;
public:
    ground_vehicle(): number_of_wheels(4),color("white"){
        cout << "Конструктор по умолчанию класса ground_vehicle: " << endl;
        cout << "number_of_wheels: " <<  number_of_wheels << ", color: " << color << endl;
        cout << "\n";
    }
    ground_vehicle(int number_of_wheels,string color): number_of_wheels(number_of_wheels),color(color){
        cout << "Конструктор с параметрами класса ground_vehicle: " << endl;
        cout << "number_of_wheels: " <<  this -> number_of_wheels << ", color: " << this -> color << endl;
        cout << "\n";
    }
    ground_vehicle(const ground_vehicle &vehicle): number_of_wheels(vehicle.number_of_wheels),color(vehicle.color){
        cout << "Конструктор копирования класса ground_vehicle: " << endl;
        cout << "number_of_wheels: " <<  number_of_wheels << ", color: " << color << endl;
        cout << "\n";
    }

    void go_straight(){
        cout << "``` is going straight ```" << endl;
    }

    ~ground_vehicle(){
        cout << "Диструктор класса ground_vehicle:" << endl;
        cout << "number_of_wheels: " <<  number_of_wheels << ", color: " << color << endl;
        cout << "\n";
    }

};


int main() {
    {
        cout << "Статистическое создание объектов класса vehicle: " << endl;
        ground_vehicle vehicle_1;
        ground_vehicle vehicle_2 = ground_vehicle(6,"Red");
        ground_vehicle vehicle_3 = ground_vehicle(vehicle_2);


        vehicle_3.go_straight();
        cout << "\n";
    }

    cout << "Динамическое создание объектов класса vehicle: " << endl;
    ground_vehicle *vehicle_4 = new ground_vehicle;
    ground_vehicle *vehicle_5 = new ground_vehicle(6,"Red");
    ground_vehicle *vehicle_6 = new ground_vehicle(*vehicle_5);

    cout << "\n";
    cout << "\n";
    cout << "\n";
    cout << "\n";

    return 0;
}
