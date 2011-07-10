#include "GLCD.h"

uint8_t LCD_PIN = 3;

GLCD lcd;

void setup()
{
  lcd.attach(LCD_PIN);
  delay(1000);
  lcd.clear();
  delay(1000);
  lcd.demo();
  delay(2000);

  TestBacklightControl();
  TestSetBox();

  lcd.clear();
}

void loop()
{
}

void TestSetBox()
{
  lcd.clear();

  // Draw some boxes  
  for (int i = 0; i < 5; i++)
  {
    lcd.setBox(5*i, 5*i, 128-(5*i), 64-(5*i), 1);
    delay(500);
  }
  delay(5000);
  
  // Done
  lcd.clear();
  Serial.print("SetBox finished");
  delay(5000);
}

void TestBacklightControl()
{
  lcd.clear();
  Serial.print("BacklightControl starting");
  delay(5000);
  
  // Fill screen with some data
  lcd.clear();
  lcd.setBox(20, 20, 107, 44, 1);
  delay(5000);
  
  // Fiddle the levels
  lcd.setBacklight(100);

  // Done
  lcd.clear();
  Serial.print("BacklightControl finished");
  delay(5000);
}
