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

class car: public ground_vehicle{
protected:
    string engine_type;
    string car_brand;
    int amount_of_doors;

public:
    car() : ground_vehicle(), engine_type("Gas_engine"),car_brand("Lada"),amount_of_doors(4){
        cout << "Конструктор по умолчанию класса Car: " << endl;
        cout << "engine`s type: " << engine_type << ", car brand: " << car_brand << ", amount of doors: " << amount_of_doors <<  endl;
        cout << "\n";
    }
    car(int number_of_wheels,string color, string engine_type,string car_brand,int amount_of_doors) : ground_vehicle(number_of_wheels,color), engine_type(engine_type),car_brand(car_brand),amount_of_doors(amount_of_doors){
        cout << "Конструктор c параметрами класса Car: " << endl;
        cout << "engine`s type: " << this -> engine_type << ", car brand: " << this -> car_brand << ", amount of doors: " << this -> amount_of_doors <<  endl;
        cout << "\n";
    }
    car(const car &another_car) : ground_vehicle(another_car.number_of_wheels,another_car.color), engine_type(another_car.engine_type),car_brand(another_car.car_brand),amount_of_doors(another_car.amount_of_doors){
        cout << "Конструктор копирования класса Car: " << endl;
        cout << "engine`s type: " << engine_type << ", car brand: " << car_brand << ", amount of doors: " << amount_of_doors <<  endl;
        cout << "\n";
    }
    void car_horm(){
        cout << "``` bib ```" <<endl;
    }

    ~car(){
        cout << "Диструктор класса Car" << endl;
        cout << "engine`s type: " << engine_type << ", car brand: " << car_brand << ", amount of doors: " << amount_of_doors <<  endl;
        cout << "\n";
    }
};

class baggage: public ground_vehicle{
private:
    string handle_material;

public:
    baggage(): ground_vehicle(), handle_material("Metal"){
        cout << "Конструктор по умолчанию класса telega: " << endl;
        cout << "handle material: " << handle_material << endl;
        cout << "\n";
    }
    baggage(int number_of_wheels,string color, string handle_material) : ground_vehicle(number_of_wheels,color), handle_material(handle_material){
        cout << "Конструктор c параметрами класса telega: " << endl;
        cout << "handle material: " << this -> handle_material << endl;
        cout << "\n";
    }
    baggage(const baggage &another_telega) : ground_vehicle(another_telega.number_of_wheels,another_telega.color), handle_material(another_telega.handle_material){
        cout << "Конструктор копирования класса telega: " << endl;
        cout << "handle material: " <<  handle_material << endl;
        cout << "\n";
    }

    ~baggage(){
        cout << "Диструктор класса telega" << endl;
        cout << "handle material: " <<  handle_material << endl;
        cout << "\n";
    }
};

class truck{
private:
    baggage *b;
    car c; // во втором вызове вызовится по умолчанию но хз почему

public:
    truck(){
        cout << "Конструктор по умолчанию класса truck: " << endl;
        this -> b = new baggage();
        cout << "\n";
    }
    truck(baggage *bag,car &own_car): c(own_car){
        cout << "Конструктор с параметрами класса truck: " << endl;
        this -> b = new baggage(*bag);
        cout << "\n";
    }
    truck(const truck &another_truck): c(another_truck.c){
        cout << "Конструктор копирования класса truck: " << endl;
        this -> b = new baggage(*(another_truck.b));
        cout << "\n";
    }

    void Cargo_loading(){
        cout << "``` Звуки погрузки груза в грузовую машину ```" << endl;
    }

    ~truck(){
        cout << " Диструктор класса truck " << endl;
        delete b;
    }
};

void Cargo_unloading(const truck &my_truck){
    cout << "``` Звуки выгрузки груза в грузовую машину ```" << endl;
}

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

    {
        cout << "Статистическое создание объектов класса car: " << endl;
        car car_4;
        car car_5(4,"White","Disel","Toyota",4);
        car car_6 = car(car_5);

        car_5.go_straight();
        car_5.car_horm();
        cout << "\n";
    }
    cout << "Динамическое создание объектов класса car: " << endl;
    car *car_4 = new car;
    car *car_5 = new car(4,"White","Disel","Toyota",4);
    car *car_6 = new car(*car_5);

    delete car_4;
    delete car_5;
    delete car_6;

    cout << "\n";
    cout << "\n";
    cout << "\n";
    cout << "\n";

    baggage b_1(8,"Brown","strong_metal");
    car car_1 = car(12,"Gray","Disel","KAMAZ",4);

    cout << "\n";
    cout << "\n";
    cout << "\n";
    cout << "\n";

    {
        cout << "Статическое создание объектов класса truck:" << endl;
        truck truck_1;
        truck truck_3 = truck(&b_1,car_1);
        truck truck_4 = truck(truck_3);

        truck_4.Cargo_loading();
        Cargo_unloading(truck_4);
        cout << "\n";
    }

    cout << "Динамическое создание объектов класса truck: " << endl;
    truck *truck_4 = new truck;
    truck *truck_5 = new truck(&b_1,car_1);
    truck *truck_6 = new truck(*truck_5);

    delete truck_4;
    delete truck_5;
    delete truck_6;

    cout << "\n";
    cout << "\n";
    cout << "\n";
    cout << "\n";

    cout << "Тестируем помещение объектов в переменные различных типов: " << endl;

    ground_vehicle *car_10 =  new car(4,"Black","Gas engine","Opel",4);




    
    return 0;
}
