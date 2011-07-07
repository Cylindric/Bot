#include <WProgram.h>
#include "Wheels.h"

Wheels::Wheels(int leftWheelA, int leftWheelB, int leftWheelP, int rightWheelA, int rightWheelB, int rightWheelP)
{
  _leftWheelA = leftWheelA;
  _leftWheelB = leftWheelB;
  _leftWheelP = leftWheelP;
  _rightWheelA = rightWheelA;
  _rightWheelB = rightWheelB;
  _rightWheelP = rightWheelP;
  
  _minPower = 40;  // This should be the power level where the motor stops moving
  _maxPower = 255; // The maximum PWM to send to the motor, usually 255.

  _direction = 0; // Steering Direction.  0 = straight.  -1 = left.  1 = right.
  _speed = 0;

  _startSpeed = 0;
  _targetSpeed = 0;
  _speedRequestedAt = 0;
  _speedRequestedFor = 0;

  pinMode(_leftWheelA, OUTPUT);
  pinMode(_leftWheelB, OUTPUT);
  pinMode(_leftWheelP, OUTPUT);
  pinMode(_rightWheelA, OUTPUT);
  pinMode(_rightWheelB, OUTPUT);
  pinMode(_rightWheelP, OUTPUT);
  digitalWrite(_leftWheelA, LOW);
  digitalWrite(_leftWheelB, LOW);
  digitalWrite(_leftWheelP, LOW);
  digitalWrite(_rightWheelA, LOW);
  digitalWrite(_rightWheelB, LOW);
  digitalWrite(_rightWheelP, LOW);
}      


void Wheels::update()
{

  if (_speedRequestedFor <= millis())
  {
    _speed = _targetSpeed;
  }
  else
  {
    float timeScale = ((float)((millis() - _speedRequestedAt)))/((float)(_speedRequestedFor - _speedRequestedAt));
    float speedDelta = (_targetSpeed - _startSpeed);
    _speed = _startSpeed + (speedDelta * timeScale);
  }

  // Set direction of wheels - forwards or backwards
  if (_speed < 0) {
    switch (_direction)
    {
      case -1:
        digitalWrite(_leftWheelA, HIGH);
        digitalWrite(_leftWheelB, LOW);
        digitalWrite(_rightWheelA, LOW);
        digitalWrite(_rightWheelB, LOW);
        break;
      case 0:
        digitalWrite(_leftWheelA, HIGH);
        digitalWrite(_leftWheelB, LOW);
        digitalWrite(_rightWheelA, HIGH);
        digitalWrite(_rightWheelB, LOW);
        break;
      case 1:
        digitalWrite(_leftWheelA, LOW);
        digitalWrite(_leftWheelB, LOW);
        digitalWrite(_rightWheelA, HIGH);
        digitalWrite(_rightWheelB, LOW);
        break;
    }

  } else {
    digitalWrite(_leftWheelA, LOW);
    digitalWrite(_leftWheelB, HIGH);
    digitalWrite(_rightWheelA, LOW);
    digitalWrite(_rightWheelB, HIGH);
  }
    
  // Set wheel power
  if (_speed == 0) {
    analogWrite(_leftWheelP, 0);
    analogWrite(_rightWheelP, 0);
  }
  else
  {
    analogWrite(_leftWheelP, map(abs(_speed), 0, 255, _minPower, _maxPower));
    analogWrite(_rightWheelP, map(abs(_speed), 0, 255, _minPower, _maxPower));
  }

}


/*
 * Sets the direction of motion.
 * Positive is forwards, negative is backwards.
 */
void Wheels::setDirection(int direction)
{
  _direction = direction;
}


/*
 * Gets the speed of the wheels.
 * Value is between 0 (stopped) and 255 (full speed).
 */
int Wheels::getSpeed()
{
  return _speed;
}

/*
 * Sets the speed of the wheels.
 * Value is between 0 (stopped) and 255 (full speed).
 */
void Wheels::setSpeed(int speed)
{
  setSpeed(speed, 0);
}


/*
 * Sets the speed of the wheels.
 * Value will actually be reached after `duration` milliseconds
 */
void Wheels::setSpeed(int speed, unsigned long easeIn)
{
  _startSpeed = _speed;
  _targetSpeed = constrain(speed, -255, 255);
  _speedRequestedAt = millis();
  _speedRequestedFor = (_speedRequestedAt + easeIn);
}


void Wheels::determineMin()
{
  for (int power = _minPower; power < 255; power += 5)
  {
    Serial.print("Wheels: Trying power ");
    Serial.println(power);
    analogWrite(_leftWheelP, power);
    analogWrite(_rightWheelP, power);
    delay(1000);
  }
  analogWrite(_leftWheelP, 0);
  analogWrite(_rightWheelP, 0);
}
