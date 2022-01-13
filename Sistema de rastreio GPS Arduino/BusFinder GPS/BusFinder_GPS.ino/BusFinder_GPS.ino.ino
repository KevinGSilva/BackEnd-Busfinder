#include <TinyGPS.h>
#include <ArduinoJson.h>
#include <SoftwareSerial.h>
#include <WiFi.h>
#include <HTTPClient.h>

const char* ssid     = "iPhone de Joao Paulo"; //Especifica em qual rede o ESP-32 deve se conectar
const char* password = "12345678";             //Especifica a senha da rede definida

int id = 3; //Atualização do Arduino com ID 3 no banco de dados

SoftwareSerial serial1(17, 16); // RX, TX
TinyGPS gps1;

void setup()
{
    Serial.begin(115200);
    serial1.begin(9600);
    //delay(10);
    
    // We start by connecting to a WiFi network

    Serial.println();
    Serial.println();
    Serial.print("Connecting to ");
    Serial.println(ssid);

    WiFi.begin(ssid, password);

    while (WiFi.status() != WL_CONNECTED) {
        delay(500);
        Serial.print(".");
    }

    Serial.println("");
    Serial.println("WiFi connected");
    Serial.println("IP address: ");
    Serial.println(WiFi.localIP());



    Serial.println("Aguardando satélites...");
}

int value = 0;

void loop()
{
  bool recebido = false;

  while (serial1.available()) {
     char cIn = serial1.read();
     recebido = gps1.encode(cIn);
  }

  if (recebido) {
     Serial.println("----------------------------------------");
     
     //Latitude e Longitude
     long latitude, longitude;
     unsigned long idadeInfo;
     gps1.get_position(&latitude, &longitude, &idadeInfo);     

     if (latitude != TinyGPS::GPS_INVALID_F_ANGLE) {
        Serial.print("Latitude: ");
        Serial.println(float(latitude) / 1000000, 6);
        //float latitude2 = (float(latitude) / 1000000, 6);
     }

     if (longitude != TinyGPS::GPS_INVALID_F_ANGLE) {
        Serial.print("Longitude: ");
        Serial.println(float(longitude) / 1000000, 6);
        //float longitude2 = (float(longitude) / 1000000, 6);
        
     }

     if (idadeInfo != TinyGPS::GPS_INVALID_AGE) {
        Serial.print("Idade da Informacao (ms): ");
        Serial.println(idadeInfo);
     }
     float latitude1 = (float(latitude) / 1000000);
     float longitude1 = (float(longitude) / 1000000);


  int ano;
  byte mes, dia, hora, minuto, segundo, centesimo;
  gps1.crack_datetime(&ano, &mes, &dia, &hora, &minuto, &segundo, &centesimo, &idadeInfo);
  int horario;
  if (hora > 3){
    horario = hora - 3; 
  }else horario = 24 - 3;

  
  const int capacity = JSON_OBJECT_SIZE(6);
  StaticJsonDocument<capacity> doc;

  doc["id"] = id;
  doc["longitude"] = longitude1;
  doc["latitude"] = latitude1;
  doc["hora"] = horario;
  doc["minuto"] = minuto;
  doc["segundo"] = segundo;
  //doc["veiculoId"] = veiculoId;

  // Serialize JSON document
  String json = "";
  serializeJson(doc, json);

  Serial.println("Json serializado: " + json);
  
    delay(5000);
    ++value;

   HTTPClient http;   
  
   http.begin("https://busfinder-v2.azure-api.net/api/arduinos/3");  //Especifica o destino para a solicitação HTTP
   http.addHeader("Content-Type", "application/json");             //Especifica o content-type do cabeçalho


   int httpResponseCode = http.PUT(json);   //Envia a requisição POST, atual
  
   if(httpResponseCode>0){
  
    String response = http.getString();                       //Faz o GET da resposta da requisição
  
    Serial.println(httpResponseCode);   //Mostra o código de retorno
    Serial.println(response);           //Mostra a resposta da requisição
  
   }else{
  
    Serial.print("Error on sending POST: ");
    Serial.println(httpResponseCode);
  
   }
  
   http.end();  

    Serial.println();
    Serial.println("closing connection");


  }
  
}
