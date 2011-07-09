#include "NewSoftSerial.h"

/*
31 “1” = 4800bps
32 “2” = 9600bps
33 “3” = 19,200bps
34 “4” = 38,400bps
35 “5” = 57,600bps
36 “6” = 115,200bps

*/

uint8_t LCD_RESET[] = {0x7C,0x00};
uint8_t LCD_DEMO[] = {0x7C,0x04};
uint8_t LCD_SPEED_2[] = {0x7C,0x07, 0x32}; //  4,800
uint8_t LCD_SPEED_3[] = {0x7C,0x07, 0x33}; // 19,200
uint8_t LCD_SPEED_4[] = {0x7C,0x07, 0x34}; // 38,400
const long SPEED_2 = 9600;
const long SPEED_3 = 19200;
const long SPEED_4 = 38400;
const long SPEED_5 = 57600;
const long SPEED_6 = 115200;

NewSoftSerial lcd(-1, 6);

void setup()
{
  // reset to slow mode
  // upload sketch with LCD power not connected
  // wait for USB tx/rx to complete
  // reset the board
  // when LED turns on, connect power to the LCD
  if (true)
  {
    delay(2000);
    digitalWrite(13, HIGH);
    Serial.begin(SPEED_6); // 115200
    unsigned long startTime = millis();
    while ((millis()-startTime)<10000)
    {
      Serial.write("a");
    }
    digitalWrite(13, LOW);
    delay(1000);
    Serial.write(LCD_DEMO, 2);
    delay(5000);
    Serial.write(LCD_RESET, 2);
        
    Serial.write(LCD_SPEED_4, 3);
    Serial.end();
    digitalWrite(13, HIGH);
    delay(1000);
    Serial.begin(SPEED_4);
    Serial.write(LCD_DEMO, 2);  
  }

  blinkFast(10);
  
  if (false) //reset
  {
    resetLCDspeed();
  }
    
  // softSerial text
  if (false)
  {
    lcd.begin(115200);
    lcd.print(0x7C, BYTE);
    lcd.print(0x00, BYTE);
    lcd.print("Hello, Mark, this is a softserial message");    
  }
  
  // text test
  if (false)
  {
    Serial.begin(9600);
    Serial.write(LCD_RESET, 2);
    Serial.print("Hello, Mark");
  }
  
  //slow demo
  if (false)
  {
    Serial.begin(9600); // 9600, 115200
    delay(1000);
    Serial.write(LCD_RESET, 2);
    delay(1000);
    Serial.write(LCD_DEMO, 2);
    delay(1000);
  }

  
  //fast demo
  if (true)
  {
    Serial.begin(115200); // 115200
    delay(1000);
    Serial.write(LCD_RESET, 2);
    delay(1000);
    Serial.write(LCD_DEMO, 2);
    delay(1000);
  }


  digitalWrite(13, HIGH);

//  Serial.begin(115200);
//  delay(1000);
//  Serial.print(0x7C); Serial.print(0x07); Serial.print("2"); // Set baud 9600
//  delay(1000);

//  Serial.print(0x7C); Serial.print(0x00); // Clear
//  delay(1000);
//  Serial.print(0x7C); Serial.print(0x04); // Demo
//  delay(1000);
  
//  resetLCDspeed();
//  Serial.begin(9600);
//  lcd.begin(9600);
//  lcd.print(0x7C);
//  lcd.print(0x02);

//  Serial.println(0x7C);
//  Serial.println(0x02);
//  delay(1000);

//  Serial.print(0x7C);
//  Serial.println(0x04);
//  delay(1000);
}

void loop()
{
//  lcd.print("Hello");
//  lcd.println("Hello");
//  delay(1000);
}

void resetLCDspeed()
{
  pinMode(13, OUTPUT);
  digitalWrite(13, HIGH);
  delay(5000);
  for (int i = 0; i < 5; i++)
  {
    digitalWrite(13, LOW);
    delay(200);
    digitalWrite(13, HIGH);
    delay(200);
  }
  
  Serial.begin(115200);
  for(;;)
  {
    Serial.print("a");
  }
}


void setLCDspeed()
{
  pinMode(13, OUTPUT);
  digitalWrite(13, HIGH);
  delay(5000);
  for (int i = 0; i < 10; i++)
  {
    digitalWrite(13, LOW);
    delay(200);
    digitalWrite(13, HIGH);
    delay(200);
  }
  
  Serial.begin(115200);
  Serial.print(0x7C);
  Serial.print(0x07);
  Serial.print("2");
  Serial.end();
  digitalWrite(13, LOW);
  Serial.begin(9600);
  for (;;)
  {
    Serial.print("Hello");
    delay(1000);
  }
}

void blinkFast(int n)
{
  while (n > 0)
  {
    digitalWrite(13, HIGH);
    delay(1000);
    digitalWrite(13, LOW);
    delay(1000);
    n--;
  }
  delay(1000);
}
