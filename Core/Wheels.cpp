#include <WProgram.h>
#include "Wheels.h"

Wheels::Wheels(int PinLeftA, int PinLeftB, int PinLeftP, int PinRightA, int PinRightB, int PinRightP)
{
  SteeringPins[Wheels::LEFT_WHEEL][Wheels::CTRL_A] = PinLeftA;
  SteeringPins[Wheels::LEFT_WHEEL][Wheels::CTRL_B] = PinLeftB;
  SteeringPins[Wheels::RIGHT_WHEEL][Wheels::CTRL_A] = PinRightA;
  SteeringPins[Wheels::RIGHT_WHEEL][Wheels::CTRL_A] = PinRightB;
  PowerPins[Wheels::LEFT_WHEEL] = PinLeftP;
  PowerPins[Wheels::RIGHT_WHEEL] = PinRightP;

  CurrentSteering = 0; // Steering Direction.  See Wheels.h for directional enums.
  CurrentSpeed = 0;

  StartSpeed = 0;
  TargetSpeed = 0;
  SpeedRequestedAt = 0;
  SpeedRequestedFor = 0;

  for (int i = 0; i < Wheels::WHEEL_COUNT; i++)
  {
    pinMode(PowerPins[i], OUTPUT);
    pinMode(SteeringPins[i][Wheels::CTRL_A], OUTPUT);
    pinMode(SteeringPins[i][Wheels::CTRL_A], OUTPUT);
    digitalWrite(SteeringPins[i][Wheels::CTRL_A], LOW);
    digitalWrite(SteeringPins[i][Wheels::CTRL_B], LOW);
  }
}


/**
 * Sets up all wheels to forward motion
 */
void Wheels::forward()
{
  for (int i = 0; i < Wheels::WHEEL_COUNT; i++)
  {
    digitalWrite(SteeringPins[i][Wheels::CTRL_A], HIGH);
    digitalWrite(SteeringPins[i][Wheels::CTRL_B], LOW);
  }
}


/**
 * Sets up all wheels to reverse motion
 */
void Wheels::reverse()
{
  for (int i = 0; i < Wheels::WHEEL_COUNT; i++)
  {
    digitalWrite(SteeringPins[i][Wheels::CTRL_A], LOW);
    digitalWrite(SteeringPins[i][Wheels::CTRL_B], HIGH);
  }
}


/**
 * Sets up all wheels to steer left.
 * Even-numbered wheels will turn forwards, odd-numbered wheels will turn backwards
 */
void Wheels::left()
{
  for (int i = 0; i < Wheels::WHEEL_COUNT; i++)
  {
    if ((i % 2) == 0)
    {
      digitalWrite(SteeringPins[i][Wheels::CTRL_A], LOW);
      digitalWrite(SteeringPins[i][Wheels::CTRL_B], HIGH);
    }
    else
    {
      digitalWrite(SteeringPins[i][Wheels::CTRL_A], HIGH);
      digitalWrite(SteeringPins[i][Wheels::CTRL_B], LOW);
    }
  }
}


/**
 * Sets up all wheels to steer right.
 * Odd-numbered wheels will turn forwards, even-numbered wheels will turn backwards
 */
void Wheels::right()
{
  for (int i = 0; i < Wheels::WHEEL_COUNT; i++)
  {
    if ((i % 2) == 1)
    {
      digitalWrite(SteeringPins[i][Wheels::CTRL_A], LOW);
      digitalWrite(SteeringPins[i][Wheels::CTRL_B], HIGH);
    }
    else
    {
      digitalWrite(SteeringPins[i][Wheels::CTRL_A], HIGH);
      digitalWrite(SteeringPins[i][Wheels::CTRL_B], LOW);
    }
  }
}


void Wheels::setPower(int power)
{
  int realPower = 0;

  if (power == 0) {
    for (int i = 0; i < Wheels::WHEEL_COUNT; i++)
    {
      analogWrite(PowerPins[i], 0);
    }
  }
  else
  {
    realPower = map(abs(power), 0, 255, Wheels::MIN_POWER, Wheels::MAX_POWER);
    for (int i = 0; i < Wheels::WHEEL_COUNT; i++)
    {
      analogWrite(PowerPins[i], realPower);
    }
  }
}


void Wheels::stop()
{
  setPower(0);
}


void Wheels::update()
{

  if (SpeedRequestedFor <= millis())
  {
    CurrentSpeed = TargetSpeed;
  }
  else
  {
    float timeScale = ((float)((millis() - SpeedRequestedAt)))/((float)(SpeedRequestedFor - SpeedRequestedAt));
    float speedDelta = (TargetSpeed - StartSpeed);
    CurrentSpeed = StartSpeed + (speedDelta * timeScale);
  }

  // Set direction of wheels
  // If speed is positive then wheel motion is as expected,
  // if the speed is negative, then the turning is reversed.
  if (CurrentSpeed >= 0)
  {
    switch (CurrentSteering)
    {
      case (Wheels::STEER_LEFT):
        left();
        break;
      case (Wheels::STEER_STRAIGHT):
        forward();
        break;
      case (Wheels::STEER_RIGHT):
        right();
        break;
    }
  }
  else
  {
    switch (CurrentSteering)
    {
      case (Wheels::STEER_LEFT):
        right();
        break;
      case (Wheels::STEER_STRAIGHT):
        reverse();
        break;
      case (Wheels::STEER_RIGHT):
        left();
        break;
    }
  }

  // Set wheel power
  setPower(CurrentSpeed);

}


/*
 * Sets the direction of motion.
 * Positive is forwards, negative is backwards.
 */
void Wheels::setDirection(int direction)
{
  CurrentSteering = direction;
}


/*
 * Gets the speed of the wheels.
 * Value is between 0 (stopped) and 255 (full speed).
 * Note: This returns the actual current speed, and not the target
 * speed that may not have been reached yet.
 */
int Wheels::getSpeed()
{
  return CurrentSpeed;
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
  StartSpeed = CurrentSpeed;
  TargetSpeed = constrain(speed, -255, 255);
  SpeedRequestedAt = millis();
  SpeedRequestedFor = (SpeedRequestedAt + easeIn);
}


void Wheels::determineMin()
{
  for (int power = _minPower; power < 255; power += 5)
  {
    Serial.print("Wheels: Trying power ");
    Serial.println(power);
    analogWrite(_leftWheelPinP, power);
    analogWrite(_rightWheelPinP, power);
    delay(1000);
  }
  analogWrite(_leftWheelPinP, 0);
  analogWrite(_rightWheelPinP, 0);
}


