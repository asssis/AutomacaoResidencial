#include <Dimmer.h>


Dimmer lamp2(5, RAMP_MODE);

int dimmer;
char tipo;
int pino;
char comando[25];
int potenciaLampada;

  String resposta;

void setup() {
  dimmer = 0;
  potenciaLampada = 0;
	Serial.begin(9600);
  lamp2.begin();  
  lamp2.set(0);
}
void loop()
{
	servicos();
}
void lerComando()
{
  int cont = 0;
  int contComando = 0;
  resposta = "";
  char indPino[2];
  limparComando();
  
  while (Serial.available() > 0)
  {
    char caractere = Serial.read();
    if (caractere != '\n')
    {      
      resposta = resposta + caractere;
      if (cont == 0)
        tipo = caractere;
      else if (cont == 1)
        indPino[0] = caractere;
      else if (cont == 2)
      {
        indPino[1] = caractere; pino = atoi(indPino);
      }
      else if (cont >= 3)
        comando[cont - 3] = caractere;
      cont++;
    }
    delay(10);
  }
}
void servicos()
{
  if(dimmer == 10)    
    lamp2.set(potenciaLampada);
	if (Serial.available() > 0)
	{

    lerComando();
		if (tipo == '1')
			simplesComando();
		if (tipo == '3')
			gradualComando();
      if (tipo == '4')
      especificoComando();
    if (tipo == '6')
      lerDispositivoAmperagem();

	}
}
void limparComando()
{
	for (int i = 0; i < 20; i++)
	{
		comando[i] = (char)NULL;
	}
}

void simplesComando()
{
  pinMode(pino, OUTPUT);
  if (comando[0] == '1')
    digitalWrite(pino, HIGH);
  else if (comando[0] == '0')
    digitalWrite(pino, LOW);    
  else if(comando[0] == '2')
  {
    if (digitalRead(pino) == LOW)
    {
      digitalWrite(pino, HIGH);
    }
    else
    {
      digitalWrite(pino, LOW);
    }
  }
  Serial.println(resposta);
}
void gradualComando()
{
  
}
void lerDispositivoAmperagem()
{
  int pinoSensor = pino;
  // Para ACS712 de  5 Amperes use 0.185
  // Para ACS712 de 10 Amperes use 0.100
  // Para ACS712 de 30 Amperes use 0.066
  float sensibilidade = atof(comando);

  int sensorValue_aux = 0;
  float valorSensor = 0;
  float valorCorrente = 0;

  float voltsporUnidade = 0.004887586;

  for (int i = 1000; i>0; i--)
  {
    sensorValue_aux = (analogRead(pinoSensor) - 510);
    valorSensor += pow(sensorValue_aux, 2);
  }
  valorSensor = (sqrt(valorSensor / 1000)) * voltsporUnidade;
  valorCorrente = (valorSensor / sensibilidade);
  if (valorCorrente <= 0.095)
  {
    valorCorrente = 0;
  }
  delay(10);
  Serial.println((String)valorCorrente);
}
void especificoComando()
{
  if ((String)pino == "5")
    Cp5();
}
//COMANDOS ESPECIFICO
void Cp5()
{    
    potenciaLampada = atoi(comando) * 0.50;
    lamp2.set(potenciaLampada);
    delay(100);    
  Serial.println(resposta);
}//VENTILAR

