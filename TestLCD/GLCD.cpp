#include <WProgram.h>
#include "GLCD.h"
#include "NewSoftSerial.h"

static const uint8_t LCD_SPEED[] = {0x31, 0x32,  0x33,  0x34,  0x35,   0x36};
static const long BAUD_SPEED[] =   {4800, 9600, 19200, 38400, 57600, 115200};

NewSoftSerial glcd(-1, 4);

GLCD::GLCD()
{
}

void GLCD::attach(uint8_t dataPin)
{
  _GLCDPin = dataPin;
  if (_GLCDPin == 1)
  {
    Serial.begin(115200);
  }
  else
  {
    Serial.begin(115200);
    Serial.print("Starting GLCD on pin "); Serial.println(_GLCDPin);
//    NewSoftSerial glcd(-1, _GLCDPin);
    for(int test = 0; test < 6; test++)
    {
      Serial.print("Testing at"); Serial.println(BAUD_SPEED[test]);
      glcd.begin(LCD_SPEED[test]);
      glcd.print("Test");
      glcd.print(BAUD_SPEED[test]);
      for(int i = 0; i < 100; i++)
      {
        glcd.print(i);
      }
      delay(1000);
    }
  }
}

void GLCD::clear()
{
  sendCommand(0x7C);
  sendCommand(0x00);
}


void GLCD::setXY(uint8_t x, uint8_t y)
{
  sendCommand(0x7C);
  sendCommand(0x18);
  sendCommand(x);
  sendCommand(0x7C);
  sendCommand(0x19);
  sendCommand(y);
}


void GLCD::setPixel(uint8_t x, uint8_t y, bool state)
{
  sendCommand(0x7C);
  sendCommand(0x10);
  sendCommand(x);
  sendCommand(y);
  if (state == true)
  {
    sendCommand(1);
  }
  else
  {
    sendCommand(0);
  }
}


void GLCD::setLine(uint8_t x1, uint8_t y1, uint8_t x2, uint8_t y2, bool state)
{
  sendCommand(0x7C);
  sendCommand(0x0C);
  sendCommand(x1);
  sendCommand(y1);
  sendCommand(x2);
  sendCommand(y2);
  if (state == true)
  {
    sendCommand(1);
  }
  else
  {
    sendCommand(0);
  }
}


void GLCD::setCircle(uint8_t x, uint8_t y, uint8_t r, bool state)
{
  sendCommand(0x7C);
  sendCommand(0x0F);
  sendCommand(x);
  sendCommand(y);
  sendCommand(r);
  if (state == true)
  {
    sendCommand(1);
  }
  else
  {
    sendCommand(0);
  }
}


void GLCD::setBox(uint8_t x1, uint8_t y1, uint8_t x2, uint8_t y2, bool state)
{
  sendCommand(0x7C);
  sendCommand(0x0F);
  sendCommand(x1);
  sendCommand(y1);
  sendCommand(x2);
  sendCommand(y2);
  if (state == true)
  {
    sendCommand(1);
  }
  else
  {
    sendCommand(0);
  }
}


void GLCD::eraseBlock(uint8_t x1, uint8_t y1, uint8_t x2, uint8_t y2, bool state)
{
  sendCommand(0x7C);
  sendCommand(0x05);
  sendCommand(x1);
  sendCommand(y1);
  sendCommand(x2);
  sendCommand(y2);
}


void GLCD::demo()
{
  sendCommand(0x7C);
  sendCommand(0x04);
}


void GLCD::toggleReverse()
{
  sendCommand(0x7C);
  sendCommand(0x12);
}


void GLCD::toggleSplash()
{
  sendCommand(0x7C);
  sendCommand(0x13);
}


void GLCD::setBacklight(uint8_t brightness)
{
  sendCommand(0x7C);
  sendCommand(0x02);
  sendCommand(brightness);
}


void GLCD::sendCommand(uint8_t data)
{
  if (_GLCDPin == 1)
  {
    Serial.write(data);
  }
  else
  {
    if (data == 0x7C)
    {
      Serial.println("");
      Serial.print("Command: ");
    }
   Serial.print(data, HEX);
   glcd.print(data);
  }
}
