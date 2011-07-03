#include <WProgram.h>
#include "Wheels.h"

Wheels::Wheels(int leftWheel, int rightWheel)
{
  _leftWheel = leftWheel;
  _rightWheel = rightWheel;
  
  _minPower = 40;  // This should be the power level where the motor stops moving
  _maxPower = 200; // The maximum PWM to send to the motor, usually 255.

  _direction = 1;
  _speed = 0;

  _startSpeed = 0;
  _targetSpeed = 0;
  _speedRequestedAt = 0;
  _speedRequestedFor = 0;

  pinMode(_leftWheel, OUTPUT);
  pinMode(_rightWheel, OUTPUT);
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


  if (_speed <= 0) {
    analogWrite(_leftWheel, 0);
    analogWrite(_rightWheel, 0);
  }
  else
  {
    analogWrite(_leftWheel, map(_speed, 0, 255, _minPower, _maxPower));
    analogWrite(_rightWheel, map(_speed, 0, 255, _minPower, _maxPower));
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
  _targetSpeed = constrain(speed, 0, 255);
  _speedRequestedAt = millis();
  _speedRequestedFor = (_speedRequestedAt + easeIn);
  Serial.print("Wheels: Easing to speed "); Serial.print(speed); Serial.print(" in "); Serial.print(easeIn); Serial.println(" millis.");
}


void Wheels::determineMin()
{
  for (int power = _minPower; power < 255; power += 5)
  {
    Serial.print("Wheels: Trying power ");
    Serial.println(power);
    analogWrite(_leftWheel, power);
    analogWrite(_rightWheel, power);
    delay(1000);
  }
  analogWrite(_leftWheel, 0);
  analogWrite(_rightWheel, 0);
}
