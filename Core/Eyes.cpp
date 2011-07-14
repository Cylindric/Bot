#include <Servo.h>
#include <WProgram.h>
#include "Eyes.h"

Eyes::Eyes(int pingPin, int neckPin)
{
  _pingPin = pingPin;
  _neckPin = neckPin;
  _distance = 0;
  _lastPing = millis();
  pinMode(_neckPin, OUTPUT);
}


void Eyes::wake()
{
  
}


void Eyes::update()
{
  long pingDuration, cm;
  
  if ((millis() - _lastPing) > _pingInterval)
  {
    pinMode(_pingPin, OUTPUT);
    digitalWrite(_pingPin, LOW);
    delayMicroseconds(2);
    digitalWrite(_pingPin, HIGH);
    delayMicroseconds(5);
    digitalWrite(_pingPin, LOW);
  
    pinMode(_pingPin, INPUT);
    _distance = pulseIn(_pingPin, HIGH);
    _lastPing = millis();
    //Serial.print("EYES: Distance = "); Serial.println((_distance / 58));
  }
}


int Eyes::getDistance()
{
  return (_distance / 58);
}
