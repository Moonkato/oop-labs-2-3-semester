#include <iostream>

using namespace std;


class animal{
public:
   animal(){
        cout << " animal() " << endl;
    }


    void method_1(){
       cout << "method_1 animal" << endl;
       method_2();
   }

   virtual void method_2(){
       cout << "method_2 animal" << endl;
   }

   void method_3(){
       cout << "method_3 animal" << endl;
   }


    virtual ~animal(){
         cout << " ~animal() " << endl;
    }
};

class cat: public animal{
private:
    string hair_color;

public:
    cat(): hair_color("gray"){
        cout << " cat() " << endl;
    }

    void method_2() override{
        cout << "method_2 cat " << endl;
    }

    void method_3(){
        cout << "method_3 cat " << endl;
    }

    ~cat(){
        cout << " ~cat() " << endl;
    }
};



class vehicle{
protected:
    int amount_of_wheels;

public:
    virtual void horn_sound() = 0;

    virtual string classname(){
        return "vehicle";
    }
    virtual bool isa(const string &who){
        return who == "vehicle";
    }
    virtual void open_trunk(){

    };
};

class car_another_ver: public vehicle{
private:
    int amount_of_doors;

public:
    void horn_sound() override{
        cout << "bib-bib" << endl;
    }

    void turn_signal(){
        cout << " -> -> -> -> ->" << endl;
    }

    void motor_sound(){
        cout << "rrrrRRRR" << endl;
    }
    string classname() override{
        return "car_another_ver";
    }

    void open_trunk() override{
        cout << "trunk has been opened" << endl;
    }

    bool isa(const string &who){
        return (who == "car_another_ver" || (vehicle::isa(who)));
    }

};

class sportcar: public car_another_ver{
public:

    void speed(){
        cout << "380 km/h" << endl;
    }

    string classname() override{
        return "sportcar";
    }

    bool isa(const string &who) override{
        return (who == "sportcar" || (car_another_ver::isa(who)));
    }
};

class bicycle: public vehicle{
private:
    string type;

public:
    void horn_sound() override{
        cout << "dz-dz" << endl;
    }
    void gear_shifter(){
        cout << "1 - 2 - 3 - 4 - 5 - 6 - 7" << endl;
    }

    string classname() override{
        return "bicycle";
    }

    bool isa(const string &who){
        return (who == "bicycle" || (vehicle::isa(who)));
    }
};



class ground_vehicle{
public:
    ground_vehicle(){
        cout << "Конструктор по умолчанию класса ground_vehicle: " << endl;
        cout << "\n";
    }
    ground_vehicle(ground_vehicle *veh){
        cout << "Конструктор копирования с указателем класса ground_vehicle: " << endl;
        cout << "\n";
    }
    ground_vehicle(ground_vehicle &veh){
        cout << "Конструктор копирования по ссылке класса ground_vehicle: " << endl;
        cout << "\n";
    }

    void go_straight(){
        cout << "``` is going straight ```" << endl;
    }

    ~ground_vehicle(){
        cout << "Диструктор класса ground_vehicle:" << endl;
        cout << "\n";
    }

};

class car: public ground_vehicle{
public:
    car(){
        cout << "Конструктор по умолчанию класса Car: " << endl;
        cout << "\n";
    }

    car(car *another_car){
        cout << "Конструктор копирования с указателем класса Car: " << endl;
        cout << "\n";
    }

    car(const car &another_car){
        cout << "Конструктор копирования по ссылке класса Car: " << endl;
        cout << "\n";
    }

    void car_horm(){
        cout << "``` bib ```" <<endl;
    }

    ~car(){
        cout << "Диструктор класса Car" << endl;
        cout << "\n";
    }
};

int main() {

    cout << "Examples: " << endl;

    cout << "#1" << endl;
    animal *beast = new cat;
    delete beast;

    cout << "#2" << endl;
    cat* cat_1 = new cat;
    cout << "-----" << endl;
    cat_1->method_1();
    cout << "-----" << endl;
    delete cat_1;

    cout << "#3" << endl;
    animal *another_beast = new cat;
    cat* another_cat = new cat;
    cout << "-----" << endl;
    another_beast->method_3();
    another_cat->method_3();
    cout << "-----" << endl;
    delete another_beast;
    delete another_cat;

    cout << "Examples part 2: " << endl;

    cout << "#1" << endl;
    vehicle* storage[10];

    for(int i=0; i< 10;i++){
        if(i % 2==0){
            storage[i] = new car_another_ver;
        }else{
            storage[i] = new bicycle;
        }
    }

    for(int i=0; i<10; i++){
        if(storage[i]->classname() == "car_another_ver"){
            static_cast <car_another_ver*> (storage[i]) -> motor_sound();
        }else if(storage[i]->classname() == "bicycle"){
            static_cast <bicycle*> (storage[i]) ->gear_shifter();
        }
    }

    cout << "#2" << endl;

    delete storage[5];
    storage[5] = new sportcar;

    for(int i=0; i<10; i++){
        if(storage[i]->isa("car_another_ver")){
            static_cast <car_another_ver*> (storage[i]) -> motor_sound();
        }else if(storage[i]->isa("bicycle")){
            static_cast <bicycle*> (storage[i]) ->gear_shifter();
        }else if(storage[i]->isa("sportcar")){
            static_cast <sportcar*> (storage[i]) ->speed();
        }
    }

    if (storage[5]->isa("sportcar")) //Если поставить car_another_ver, в цикле выше будет преведение типа к car_another_ver
        static_cast <sportcar*> (storage[5]) ->speed();


    cout << "#3" << endl;
    for(int i=0; i<10; i++){
        car_another_ver* car_1 = dynamic_cast<car_another_ver*>(storage[i]);

        if(car_1 != nullptr)
            car_1 ->horn_sound();
        else
            cout << "This is probably bicycle" << endl;
    }

    cout << "#4" << endl;

    for(int i=0; i<10; i++){
        storage[i] -> open_trunk();
    }


    return 0;
}
