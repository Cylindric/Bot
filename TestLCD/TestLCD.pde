#include "NewSoftwareSerial.h"

NewSoftwareSerial glcd(7, 8);

void setup()
{
  glcd.begin(115200);
  delay(5000);
  
  glcd.print(0x7C, BYTE); // Command
  glcd.print(0x00, BYTE); // Clear
  glcd.print(0x7C, BYTE); // Command
  glcd.print(0x04, BYTE); // Demo
  delay(5000);

  if(true)
  {
    glcd.print(0x7C, BYTE); // Command
    glcd.print(0x10, BYTE); // Backlight    
    glcd.print(0x64, BYTE); // Backlight Level (00-64)
    delay(2000);
    glcd.print(0x7C, BYTE); // Command
    glcd.print(0x10, BYTE); // Backlight    
    glcd.print(0x05, BYTE); // Backlight Level (00-64)
    delay(2000);    
  }

  if(true)
  {
    glcd.print(0x7C, BYTE); // Command
    glcd.print(0x00, BYTE); // Clear

    for (int xPos = 0; xPos < 128; xPos+=5)
    {
      for (int yPos = 0; yPos < 64; yPos+=5)
      {
        glcd.print(0x7C, BYTE); // Command
        glcd.print(0x10, BYTE); // Pixel    
        glcd.print(xPos, BYTE); // Pixel X (00-7F)
        glcd.print(yPos, BYTE); // Pixel Y (00-3F)
        glcd.print(0x01, BYTE); // Pixel State (00-01)
      }
    }
    delay(5000);
  }
  
  if(true)
  {
    glcd.print(0x7C, BYTE); // Command
    glcd.print(0x00, BYTE); // Clear

    glcd.print(0x7C, BYTE); // Command
    glcd.print(0x0F, BYTE); // Box
    glcd.print(0x04, BYTE); // Box X1 (00-7F)
    glcd.print(0x04, BYTE); // Box Y1 (00-3F)
    glcd.print(0x7D, BYTE); // Box X2 (00-7F)
    glcd.print(0x3D, BYTE); // Box Y2 (00-3F)
    glcd.print(0x01, BYTE); // Box State (00-01)
    delay(5000);
  }

}


void loop()
{
}
