#include <WProgram.h>
#include "Antenna.h"

Antenna::Antenna(int leftAntenna, int rightAntenna)
{
  _leftAntenna = leftAntenna;
  _rightAntenna = rightAntenna;
  _leftState = false;
  _rightState = false;
  _triggered = false;
  
  pinMode(_leftAntenna, INPUT);
  pinMode(_rightAntenna, INPUT);
}      

void Antenna::update()
{
  int oldLeftState = _leftState;
  int oldRightState = _rightState;
  _leftState = (digitalRead(_leftAntenna) != 0);
  _rightState = (digitalRead(_rightAntenna) != 0);

  if (oldLeftState != _leftState)
  {
    if (_leftState) {
      Serial.println("Antenna: Left hit something.");
    }
    else
    {
      Serial.println("Antenna: Left cleared.");
    }
  }

  if (oldRightState != _rightState)
  {
    if (_rightState) {
      Serial.println("Antenna: Right hit something.");
    }
    else
    {
      Serial.println("Antenna: Right cleared.");
    }
  }


  // If the last state was LOW, then trigger
  if ((oldLeftState == false) && (oldRightState == false ))
  {
    if ((_leftState == true) || (_rightState == true))
    {
      Serial.println("Antenna: Triggered!");
      _triggered = true;
    }
  }
}

bool Antenna::touching()
{
  return (_leftState || _rightState);
}

bool Antenna::triggered()
{
  return _triggered;
}

void Antenna::reset()
{
  _triggered = false;
}
