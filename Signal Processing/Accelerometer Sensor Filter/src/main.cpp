#include <Arduino.h>
#include <AcceleroMMA7361.h>

AcceleroMMA7361 accelero;

int x;
int y;
int z;

void setup()
{
  Serial.begin(9600);
  accelero.begin(13, 12, 11, 10, A0, A1, A2);
  accelero.setSensitivity(HIGH);
  accelero.calibrate();
}

void loop()
{
  x = accelero.getXRaw();
  y = accelero.getYRaw();
  z = accelero.getZRaw();

  Serial.print(x);
  Serial.print(",");
  Serial.print(y);
  Serial.print(",");
  Serial.println(z);
  // Serial.println(",");
}
