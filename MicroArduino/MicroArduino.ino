#include <IRremote.h>
#include<IRremoteInt.h>

char tipo;
int pino;
char comando[25];
String resposta;


//VARIAVEIS DO INFRA VERMELHO
int RECV_PIN = 8; 
IRrecv irrecv(RECV_PIN);
decode_results results;

void setup() {
 Serial.begin(9600); 
 digitalWrite(2, LOW);
 digitalWrite(3, LOW);
   irrecv.enableIRIn();
}
void loop()
{
	servicos();
}
void servicos()
{
	if (Serial.available() > 0)
	{
		lerComando();
		if (tipo == '1')
      simplesComando();
		if (tipo == '2')
			logicoComando();
		if (tipo == '3')
			gradualComando();
		if (tipo == '4')
			especificoComando();
		if (tipo == '6')
			lerDispositivoAmperagem();
		if (tipo == '9')
		{
			for (int i = 0; i < 10; i++)
			{
				delay(10);
				if (irrecv.decode(&results))
					lerInfraVermelho(&results);
				irrecv.resume();
			}
			Serial.println("");
		}
	}
}
void limparComando()
{
	for (int i = 0; i < 25; i++)
	{
		comando[i] = (char)NULL;
	}
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

void logicoComando()
{
	
	IRsend irsend;
	String ctrl;
	ctrl = (String)comando[0] + (String)comando[1] + (String)comando[2];

	int bits;
	if (comando[3] == '(' && comando[6] == ')') { char valor[2]; valor[0] = comando[4]; valor[1] = comando[5]; bits = atoi(valor); }


	char cmd[20];
	for (int i = 0; i < 20; i++)
		cmd[i] = (char)NULL;

	for (int i = 0; i < 20; i++)
		cmd[i] = comando[i + 7];
	
	long valor = strtoul(cmd, 0, 16);

	Serial.println((String)ctrl);
	Serial.println(bits);
	Serial.println(valor, HEX);
for (int i = 0; i < 4; i++)
  {
	if ((String)"NEC" == ctrl)
		irsend.sendNEC(valor, bits);
	else if ((String)"SON" == ctrl)
		irsend.sendSony(valor, bits);
	else if ((String)"RC5" == ctrl)
		irsend.sendRC5(valor, bits);
	else if ((String)"RC6" == ctrl)
		irsend.sendRC6(valor, bits);
	else if ((String)"LGX" == ctrl)
		irsend.sendLG(valor, bits);
	else if ((String)"JVC" == ctrl)
		irsend.sendJVC(valor, bits, false);
	else if ((String)"SAN" == ctrl)
		irsend.sendSAMSUNG(valor, bits);
	else if ((String)"DIS" == ctrl)
		irsend.sendDISH(valor, bits);
	else if ((String)"SHA" == ctrl)
		irsend.sendSharpRaw(valor, bits);
	else if ((String)"AIW" == ctrl)
		irsend.sendAiwaRCT501(valor);
	else if ((String)"WHY" == ctrl)
		irsend.sendWhynter(valor, bits);
	else if((String)"PAN" == ctrl)
	  irsend.sendPanasonic(valor, bits);
  delay(40);
  }
  
  Serial.println(resposta);
}
void especificoComando()
{
	if (pino == 4)
		Cp4();
	if (pino == 6)
		Cp6();
  if (pino == 9)
    Cp9();
  if (pino == 11)
    Cp11();
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
//LER INFRA VERMELHO
void lerInfraVermelho(decode_results *results)
{   
  int count = results->rawlen;

  if (results->decode_type == UNKNOWN) {
    Serial.print("UNK");
  }
  else if (results->decode_type == NEC) {
    Serial.print("NEC");
  }
  else if (results->decode_type == SONY) {
    Serial.print("SON");
  }
  else if (results->decode_type == RC5) {
    Serial.print("RC5");
  }
  else if (results->decode_type == RC6) {
    Serial.print("RC6");
  }
  else if (results->decode_type == PANASONIC) {
    Serial.print("PAN");
    Serial.print(results->address, HEX);
    Serial.print(" Value: ");
  }
  else if (results->decode_type == LG) {
    Serial.print("LGX");
  }
  else if (results->decode_type == JVC) {
    Serial.print("JVC");
  }
  else if (results->decode_type == AIWA_RC_T501) {
    Serial.print("AIW");
  }
  else if (results->decode_type == WHYNTER) {
    Serial.print("WHY");
  }  
  Serial.print("(");
  Serial.print(results->bits, DEC);
  Serial.print(")");
  Serial.print(results->value, HEX);
}

//COMANDOS ESPECIFICO
void Cp4()
{
	int L1 = 4;
	int M1 = 5;

	pinMode(M1, OUTPUT);
	pinMode(L1, OUTPUT);
	digitalWrite(L1, HIGH);

	int valor = atoi(comando) * 2.55;
	analogWrite(M1, valor);
 
  Serial.println(resposta);
}//VENTILAR
void Cp6()
{
	int L2 = 7;
	int M2 = 6;

	pinMode(L2, OUTPUT);
	pinMode(M2, OUTPUT);
	if (comando[0] == '1')
	{
		digitalWrite(M2, HIGH);
		analogWrite(L2, 0);
	}
	else if (comando[0] == '2')
	{
		digitalWrite(M2, HIGH);
		analogWrite(L2, 255);
	}

  Serial.println(resposta);
	for (int i = 0; i < 100; i++)
	{
		servicos();
		delay(30);
	}
	digitalWrite(M2, LOW);
  
}//PORTA

void Cp9()
{
  pinMode(10, OUTPUT);
  int valor = atoi(comando) * 1.3;
  valor = valor + 125;
  int cmd = atoi(comando);
   if(cmd != 0)
   {
    analogWrite(10,HIGH);   
    delay(200);
    analogWrite(10, valor);
   }
   else
   {
    analogWrite(10, 0);
   }
   
  Serial.println(resposta);
}//VENTILARDOR

void Cp11()
{
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
  if (comando[0] == '2')
  {
   digitalWrite(2, LOW);
   digitalWrite(3, HIGH);
  }
  else if (comando[0] == '1')
  {
    digitalWrite(2, HIGH);
    digitalWrite(3, LOW);
  }

  Serial.println(resposta);
  for (int i = 0; i < 500; i++)
  {
    servicos();
    delay(20);
  }  
 digitalWrite(2, LOW);
 digitalWrite(3, LOW);
 
}//PORTA


