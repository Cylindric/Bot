#ifndef Wheels_h
#define Wheels_h

class Wheels
{
  public:
    static const int WHEEL_COUNT = 2; // How many powered wheels are there?
    static const int MIN_POWER = 40;  // This should be the power level where the motor stops moving
    static const int MAX_POWER = 100; // The maximum PWM to send to the motor, 0-255, usually 255.

    enum { LEFT_WHEEL = 0, RIGHT_WHEEL = 1 }; // Wheel identifiers
    enum { STEER_STRAIGHT = 0, STEER_LEFT = -1, STEER_RIGHT = 1 }; // Steering
    enum { DIR_FORWARD = 1, DIR_REVERSE = -1 }; // Direction
    enum { CTRL_A = 0, CTRL_B = 1};   // Wheel control identifiers
    
    // Initialise the object with the pins to which the wheel H-Bridges are connected
    Wheels(int PinLeftA, int PinLeftB, int PinLeftP, int PinRightA, int PinRightB, int PinRightP);
    void update();
    void setDirection(int direction);
    int getSpeed();
    void setSpeed(int speed);
    void setSpeed(int speed, unsigned long easeIn);
    void determineMin();
    
  private:
    int SteeringPins[WHEEL_COUNT][2];
    int PowerPins[WHEEL_COUNT];
    int _leftWheelPinA;
    int _leftWheelPinB;
    int _leftWheelPinP;
    int _rightWheelPinA;
    int _rightWheelPinB;
    int _rightWheelPinP;
    int _minPower;
    int _maxPower;

    int CurrentSteering;
    int CurrentSpeed;
    
    int StartSpeed;
    int TargetSpeed;
    unsigned long SpeedRequestedAt;
    unsigned long SpeedRequestedFor;
    
    void left();
    void right();
    void forward();
    void reverse();
    void stop();
    void setPower(int power);
};


#endif


