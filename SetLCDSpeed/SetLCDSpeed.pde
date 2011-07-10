const uint8_t LCD_SPEED[] = {0x31, 0x32,  0x33,  0x34,  0x35,   0x36};
const long BAUD_SPEED[] =   {4800, 9600, 19200, 38400, 57600, 115200};

const byte speedToUse = 2;

void setup()
{
  Serial.begin(115200);
  delay(5000);
  Serial.print(0x7C, BYTE);
  Serial.print(0x70, BYTE);
  Serial.print(LCD_SPEED[speedToUse]);
  delay(1000);
  Serial.end();
  Serial.begin(BAUD_SPEED[speedToUse]);
  delay(1000);
  Serial.print(0x7C, BYTE);
  Serial.print(0x00, BYTE);
  Serial.print(0x7C, BYTE);
  Serial.print(0x04, BYTE);
  delay(5000);
  Serial.print(0x7C, BYTE);
  Serial.print(0x00, BYTE);
}

void loop()
{
  Serial.write("a");
}
