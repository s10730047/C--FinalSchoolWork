#include <OneWire.h>
#include <DallasTemperature.h>

#define DQ_pin 2  

OneWire oneWire(DQ_pin);
DallasTemperature sensors(&oneWire);

void setup(void)
{
  Serial.begin(9600);
  sensors.begin();
}

void loop(void)
{
  
  sensors.requestTemperatures();
  Serial.println(sensors.getTempCByIndex(0));
  delay(2000);
}
