#ifndef Wheels_h
#define Wheels_h

class Wheels
{
  public:
    Wheels(int leftWheel, int rightWheel);
    void update();
    void setDirection(int direction);
    int getSpeed();
    void setSpeed(int speed);
    void setSpeed(int speed, unsigned long easeIn);
    void determineMin();
    
  private:
    int _leftWheel;
    int _rightWheel;
    int _minPower;
    int _maxPower;

    int _direction;
    int _speed;
    
    int _startSpeed;
    int _targetSpeed;
    unsigned long _speedRequestedAt;
    unsigned long _speedRequestedFor;
};


#endif