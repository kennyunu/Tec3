int pinPot = A0;  
int valor = 0;

void setup()
{
  Serial.begin(9600);
}

void loop()
{
  valor = analogRead(pinPot); 

  Serial.println(valor);       
  delay(20);
}
