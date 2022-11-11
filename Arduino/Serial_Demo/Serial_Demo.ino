int ledPin = 13; //integrated LED
int serialData = '1';
String readString;

void setup() {
  Serial.begin(9600);  //initialize serial comms
  pinMode(ledPin, OUTPUT);
  Serial.println("Enter LED Number 0 to 7 or 'x' to clear");
}

void loop() {

  while (Serial.available()) {
    delay(2);  //delay to allow byte to arrive in input buffer
    char c = Serial.read();
    readString += c;
  }

  if (readString.length() >0) {
    Serial.println(readString);

    readString="";
  } 
  // if (Serial.available()) {
  //   serialData = Serial.read();
  //   // Serial.println('I received: ');
  //   Serial.println(serialData, DEC);
  //   if(serialData == '1'){
  //     digitalWrite(ledPin, HIGH);
  //     // Serial.println('A 1');
  //   }
  //   else {
  //     digitalWrite(ledPin, LOW);
  //     // Serial.println('Not a 1');
  //   }
  // }
}