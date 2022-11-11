int ledPin = 13; //integrated LED
int serialData = '1';

void setup() {
  Serial.begin(9600);  //initialize serial comms
  pinMode(ledPin, OUTPUT);
}

void loop() {
  if (Serial.available()) {
    serialData = Serial.read();
    if(serialData == '1'){
      digitalWrite(ledPin, HIGH);
    }
    else {
      digitalWrite(ledPin, LOW);
    }
  }
}
